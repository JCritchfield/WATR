using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_XBeeRemoteATCommandFrameData : WATR_IXBeeTxFrameData
    {
        //Public properties
        public int FrameID { get; private set; }
        public string ATCommand { get; private set; }
        public string Parameters { get; private set; }
        public ulong Destination { get; private set; }

        public WATR_XBeeRemoteATCommandFrameData(string atCommand, ulong destination, string parameters = "")
        {
            //Set the frame ID from the counter
            FrameID = WATR_XBeeFrameIDTransmitTracker.GetFrameIDNumber();

            //Set the AT Command
            //Check if the command is > 2 chars
            if (atCommand.Length > 2)
            {
                //Error here
            }
            else
            {
                //Otherwise set it to our property
                ATCommand = atCommand;
            }

            //Set the params
            Parameters = parameters;

            //Set the destination xbee device
            Destination = destination;
        }

        public byte[] PackageForTransmission()
        {
            //Make sure the command isn't NI
            if (ATCommand == "NI")
            {
                //If it is, we need to handle it specifically
                //List for easier byte array creation
                List<byte> rawByteArray = new List<byte>();

                //Add the frame type
                rawByteArray.Add(0x17);

                //Add the frameID
                rawByteArray.Add(Convert.ToByte(FrameID));

                //Add the 64bit destination
                rawByteArray.AddRange(Destination.ToByteArray());

                //Add the network address (CONST 0xFFFE FOR NOW)
                rawByteArray.Add(0xFF);
                rawByteArray.Add(0xFE);

                //Add the Remote Command Options (always 0x02)
                rawByteArray.Add(0x02);

                //Add the AT Command
                rawByteArray.AddRange(ATCommand.ToByteArray());

                //Add the parameters, if it's not empty
                if (!string.IsNullOrEmpty(Parameters))
                    rawByteArray.AddRange(Parameters.ToByteArray());

                //Done!
                return rawByteArray.ToArray();
            }
            else
            {
                //Otherwise, it'll be handled differently since the params are not ascii characters
                //List
                List<byte> rawByteArray = new List<byte>();

                //Add the frame type
                rawByteArray.Add(0x17);

                //Add the frameID
                rawByteArray.Add(Convert.ToByte(FrameID));

                //Add the 64bit destination
                rawByteArray.AddRange(Destination.ToByteArray());

                //Add the network address (CONST 0xFFFE FOR NOW)
                rawByteArray.Add(0xFF);
                rawByteArray.Add(0xFE);

                //Add the Remote Command Options (always 0x02)
                rawByteArray.Add(0x02);

                //Add the AT Command
                rawByteArray.AddRange(ATCommand.ToByteArray());

                //Add the parameters, if it's not empty
                if (!string.IsNullOrEmpty(Parameters))
                    rawByteArray.AddRange(Convert.ToUInt64(Parameters).ToByteArray());

                //Done!
                return rawByteArray.ToArray();
            }
        }
    }
}
