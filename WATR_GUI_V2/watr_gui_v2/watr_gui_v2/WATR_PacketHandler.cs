using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_PacketHandler
    {
        //Hardware packet handler
        WATR_XBeePacketHandler xbeePacketHandler;

        //DB Connection for interaction
        WATR_Database db;

        //Events that this class can pass:
        public event EventHandler<WATR_TransmitStatusGetArgs> ReceivedTransmitStatus;
        public event EventHandler<WATR_ATCmdResponseGetArgs> ReceivedATCmdResponse;
        public event EventHandler<WATR_RemoteATCmdResponseGetArgs> ReceivedRemoteATCommandResponse;
        public event EventHandler<WATR_RxPacketGetArgs> ReceivedRxPacket;

        public WATR_PacketHandler(string serialPortName, WATR_Database db)
        {
            //Instantiate hardware packet handler
            xbeePacketHandler = new WATR_XBeePacketHandler(serialPortName);

            //Assign the DB
            this.db = db;
        }

        //Tests to make sure that the com port currently hooked into is valid
        public bool TestCommunications()
        {
            //Open the com port
            xbeePacketHandler.beginOperation();

            //Transmit the VR command to get the unique identifier that it's a coordinator
            this.TransmitLocalATCommand("VR");

            //Get a packet
            WATR_XBeeRxFrameData testPacket = xbeePacketHandler.getPacket();

            if (testPacket == null)
                return false;

            //Log it
            db.LogReceivePacket(testPacket.RawData);

            //This is as elegant as my downcasting problem is going to get
            if (testPacket != null)
            {
                if (testPacket.GetFrameType() is WATR_XBeeATCommandResponseFrameData)
                {
                    WATR_XBeeATCommandResponseFrameData response = testPacket.GetFrameType();

                    if (response.IsNumber)
                    {
                        if (Convert.ToUInt64(response.CommandData) == 8615)
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        //Locate ALL devices in the given network
        public void FindDevices()
        {
            //Transmit a broadcast event
            TransmitRemoteATCommand("NI", 65535);
        }

        //Start Asynchronus transmissions and link events!
        public void StartAsyncOperations()
        {
            //Start async ops
            xbeePacketHandler.beginAsynchronousOperation();

            //Add the event handlers
            xbeePacketHandler.ValidDataGet += xbeePacketHandler_ValidDataGet;
            xbeePacketHandler.InvalidDataGet += xbeePacketHandler_InvalidDataGet;
        }

        //Handle any invalid data retrieved here
        void xbeePacketHandler_InvalidDataGet(object sender, WATR_InvalidDataGetArgs e)
        {
            //Log information
            db.LogReceivePacket(e.Data);
        }

        //Handle any valid data retrieved here
        void xbeePacketHandler_ValidDataGet(object sender, WATR_ValidDataGetArgs e)
        {
            //Log information
            db.LogReceivePacket(e.Data.RawData);

            //Figure out what type of packet it is and raise the proper event
            if (e.Data.GetFrameType() is WATR_XBeeRemoteATCommandResponseFrameData)
            {
                WATR_RemoteATCmdResponseGetArgs remoteATcmdResp = new WATR_RemoteATCmdResponseGetArgs(e.Data.GetFrameType());
                if (remoteATcmdResp != null)
                    ReceivedRemoteATCommandResponse(this, remoteATcmdResp);
            }
            else if (e.Data.GetFrameType() is WATR_XBeeATCommandFrameData)
            {
                WATR_ATCmdResponseGetArgs atCmdResp = new WATR_ATCmdResponseGetArgs(e.Data.GetFrameType());
                if (atCmdResp != null)
                    ReceivedATCmdResponse(this, atCmdResp);
            }
            else if (e.Data.GetFrameType() is WATR_XBeeReceivePacketFrameData)
            {
                WATR_RxPacketGetArgs rxFrameData = new WATR_RxPacketGetArgs(e.Data.GetFrameType());
                if (rxFrameData != null)
                    ReceivedRxPacket(this, rxFrameData);
            }
            else
            {
                WATR_TransmitStatusGetArgs transmitStatusGet = new WATR_TransmitStatusGetArgs(e.Data.GetFrameType());
                if (transmitStatusGet != null)
                    ReceivedTransmitStatus(this, transmitStatusGet);
            }
        }

        //Transmit a local AT command to the coordinator XBee
        public void TransmitLocalATCommand(string ATCmd, string parameters = "")
        {
            //Create a packet
            WATR_XBeeATCommandFrameData command = new WATR_XBeeATCommandFrameData(ATCmd, parameters);

            //Log it
            db.LogTransmitPacket(command.PackageForTransmission());

            //Transmit it
            xbeePacketHandler.TransmitData(command);

        }

        //Send a remote AT Command to a device or ALL devices
        public void TransmitRemoteATCommand(string ATCmd, ulong destinationAddy, string parameters = "")
        {
            //Form the frame data
            WATR_XBeeRemoteATCommandFrameData command = new WATR_XBeeRemoteATCommandFrameData(ATCmd, destinationAddy, parameters);

            //Log it
            db.LogTransmitPacket(command.PackageForTransmission());

            //Transmit it
            xbeePacketHandler.TransmitData(command);
        }

        public void TransmitRequest(ulong destinationAddy, byte[] data)
        {
            //Form the data
            WATR_XBeeTransmitRequestFrameData req = new WATR_XBeeTransmitRequestFrameData(destinationAddy, data);

            //Log it
            db.LogTransmitPacket(req.PackageForTransmission());

            //Transmit it
            xbeePacketHandler.TransmitData(req);
        }

        //Allows the back end class to use the clear port function without making it messy
        public void RequestToClearPort()
        {
            xbeePacketHandler.ClearPort();
        }
    }
}
