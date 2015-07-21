using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace WATR_GUI
{
    public class WATRXBConnection : SerialPort
    {
        Timer deviceSearchTimeout = new Timer();

        //Public constructor - I want to go ahead and pass the port name and baud rate to the serial port from the very start
        public WATRXBConnection(string portName, int baudRate) : base(portName, baudRate)
        {
            //Set up some basic things
            deviceSearchTimeout.Tick += deviceSearchTimedOut;


            //Try to open the serial port - if it fails, let the user know some cryptic message... for now
            try
            {
                this.Open();
            }
            catch (Exception E)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + E.ToString(), "Exception");
                this.Close();
            }
        }

        private void deviceSearchTimedOut(object sender, EventArgs e)
        {
            this.DataReceived -= deviceQueryReceieved;
            this.DataReceived += dataInfoReceived;
        }

        private void dataInfoReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }

        private void deviceQueryReceieved(object sender, SerialDataReceivedEventArgs e)
        {
            //Check for 0x7E, or, the start deliminator
            if (this.ReadByte() == 0x7E)
            {
                //Read the next two bytes for the length of the packet
                byte msbLength = Convert.ToByte(this.ReadByte());
                byte lsbLength = Convert.ToByte(this.ReadByte());

                //Create a list to hold the packet
                List<byte> incomingPacket = new List<byte>();
                byte[] buffer = new byte[(msbLength << 8) | lsbLength];

                this.Read(buffer, 0, ((msbLength << 8) | lsbLength));
                incomingPacket.AddRange(buffer);
            }
        }


        //Sends a broadcast packet to all devices, in attempt to find all devices currently connected
        private void sendDeviceQuery()
        {
            //Disable the data processing and enable device query processing
            this.DataReceived -= dataInfoReceived;
            this.DataReceived += deviceQueryReceieved;

            List<byte> frameData = new List<byte>();
            frameData.Add(WATRXBeeTransmitPacketTypes.RemoteCommandRequest);
            frameData.Add(0);
            frameData.AddRange(WATRXbeeSerialNumber.BroadcastAddress.ToByteArray());
            frameData.Add(0xFF);
            frameData.Add(0xFE);
            frameData.Add(Convert.ToByte('S'));
            frameData.Add(Convert.ToByte('L'));

            int checksum = 0;
            foreach (byte info in frameData)
            {
                checksum += Convert.ToInt16(info);
            }

            checksum &= 0xFF;

            List<byte> completePacket = new List<byte>();
            completePacket.Add(0x7E);
            completePacket.AddRange(Convert.ToInt16(frameData.Count).ToByteArray());
            completePacket.AddRange(frameData);
            completePacket.Add(Convert.ToByte(checksum));

            //Write the packet to the XBee device, start the time-out timer
            this.Write(completePacket.ToArray(), 0, completePacket.Count);

            //Enable the time-out timer for the device search and let the class handle the rest =)
            deviceSearchTimeout.Interval = 10000;
            deviceSearchTimeout.Enabled = true;
        }
    }
}
