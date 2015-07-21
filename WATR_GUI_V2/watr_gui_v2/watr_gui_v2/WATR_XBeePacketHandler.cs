using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace watr_gui_v2
{
    public class WATR_XBeePacketHandler
    {
        //Class Declarations
        private SerialPort xbeePort;

        //Event declaration
        public event EventHandler<WATR_ValidDataGetArgs> ValidDataGet;
        public event EventHandler<WATR_InvalidDataGetArgs> InvalidDataGet;

        //Public properties
        public bool isOperatingAsync = false;

        //Constructor
        public WATR_XBeePacketHandler(string PortName)
        {
            //Instantiate classes
            xbeePort = new SerialPort(PortName);
        }

        //Start the serial port
        public void beginOperation()
        {
            xbeePort.Open();
        }

        //Stop the serial port
        public void haltOperation()
        {
            if(xbeePort.IsOpen)
                xbeePort.Close();
        }

        //Allows asynchronus operation of the serial port; freely call the event
        public void beginAsynchronousOperation()
        {
            //Add the serial port's data received event to the class
            xbeePort.DataReceived += xbeePort_DataReceived;
            this.isOperatingAsync = true;
        }

        //Halts asynchronous operation of the serial port; packets must be read manually
        public void stopAsynchronousOperation()
        {
            //Remove the serial port's data received event to the class
            xbeePort.DataReceived -= xbeePort_DataReceived;
            this.isOperatingAsync = false;
        }

        //Event handler for the serial port data
        private void xbeePort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Check to see if the first byte received is 0x7e for a valid packet
            if (xbeePort.ReadByte() == 0x7E)
            {
                //Wait a tenth of a second for the rest of the data to be available
                System.Threading.Thread.Sleep(200);

                //Get the packet length as individual bytes
                int msbLength = xbeePort.ReadByte();
                int lsbLength = xbeePort.ReadByte();
                //Get the total length as combined bytes
                int totalLength = (msbLength << 8) | lsbLength;

                //Buffer for the incoming data
                byte[] incomingData = new byte[totalLength];

                //Get the entire packet 
                xbeePort.Read(incomingData, 0, totalLength);

                //The last byte we get should be the checksum
                int checksum = xbeePort.ReadByte();

                //Check the entire packet for validity
                if (challengeChecksum(incomingData, checksum))
                {
                    //If it's valid, assemble the data into an rx (receive) frameData class
                    WATR_XBeeRxFrameData data = new WATR_XBeeRxFrameData(incomingData);

                    //Raise an event saying we've got valid data and pass the framedata to it
                    WATR_ValidDataGetArgs validDataGet = new WATR_ValidDataGetArgs(data);
                    if (validDataGet != null)
                        ValidDataGet(this, validDataGet);
                }
                else
                {
                    //If it's not valid, send an event saying it's not valid
                    //Keep them as bytes; they may not assemble properly into frame data and may cause an error
                    WATR_InvalidDataGetArgs invalidDataGet = new WATR_InvalidDataGetArgs(incomingData);
                    if (invalidDataGet != null)
                        InvalidDataGet(this, invalidDataGet);
                }
            }
        }

        //Used to manually grab a packet on the serial port
        public WATR_XBeeRxFrameData getPacket()
        {
            //Add a timeout in case we have a hardware serial port that will not nack
            xbeePort.ReadTimeout = 1000;    //1s timeout

            try
            {
                //Check to see if the first byte received is 0x7e for a valid packet
                if (xbeePort.ReadByte() == 0x7E)
                {
                    //Wait a tenth of a second for the rest of the data to be available
                    System.Threading.Thread.Sleep(100);

                    //Get the packet length as individual bytes
                    int msbLength = xbeePort.ReadByte();
                    int lsbLength = xbeePort.ReadByte();
                    //Get the total length as combined bytes
                    int totalLength = (msbLength << 8) | lsbLength;

                    //Buffer for the incoming data
                    byte[] incomingData = new byte[totalLength];

                    //Get the entire packet 
                    xbeePort.Read(incomingData, 0, totalLength);

                    //The last byte we get should be the checksum
                    int checksum = xbeePort.ReadByte();

                    //Check the entire packet for validity
                    if (challengeChecksum(incomingData, checksum))
                    {
                        xbeePort.ReadTimeout = -1;
                        return new WATR_XBeeRxFrameData(incomingData);
                    }
                    else
                    {
                        xbeePort.ReadTimeout = -1;
                        ClearPort();
                        return null;
                    }
                }
                else
                {
                    xbeePort.ReadTimeout = -1;
                    return null;
                }
            }
            catch (TimeoutException e)
            {
                xbeePort.ReadTimeout = -1;
                return null;
            }
        }

        //Check the checksum of a received packet
        private bool challengeChecksum(byte[] array, int checksum)
        {
            //Temp checksum value holder
            int tempChecksum = 0;

            //Iterate through the entire array and add the bytes together
            for (int i = 0; i < array.Length; i++)
            {
                tempChecksum += array[i];
            }

            //Add the checksum itself
            tempChecksum += checksum;

            //Remove the excess by ANDing it with 0xFF
            tempChecksum &= 0xFF; 

            //Check if the checksum is equal to 0xFF now
            if (tempChecksum == 0xFF)
                return true;
            else
                return false;
        }

        //Generates a checksum for a transmission packet
        private byte generateChecksum(byte[] frameData)
        {
            //Holding value for the checksum
            int tempChkSmHolder = 0;

            //Iterate through the array and add it
            for (int i = 0; i < frameData.Length; i++)
            {
                tempChkSmHolder += frameData[i];
            }

            //And off any excess info
            tempChkSmHolder &= 0xFF;

            //Return it
            return Convert.ToByte(0xFF - tempChkSmHolder);
        }

        //Transmit information
        public void TransmitData(WATR_IXBeeTxFrameData frame)
        {
            if(!xbeePort.IsOpen) 
            {
                 //At this point, we need to panic a little: The Xbee that was originally found was gone. We need to remedy this!
                do
                {
                    //Tell them the connectivity is gone
                    DialogResult answer = MessageBox.Show("Error! The attached Xbee can no longer be contacted;" +
                                                          " Please check the Xbee connection and press okay",
                                                          "Connectivity Error",
                                                          MessageBoxButtons.OKCancel
                                                          );
                    //Give the user a choice to retry finding the device or close it
                    if (answer == DialogResult.OK)
                    {
                        if(SerialPort.GetPortNames().Contains(xbeePort.PortName))
                            xbeePort.Open();
                    }
                    else
                    {
                        if (MessageBox.Show("Cancelling will exit the program; proceed?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //To Do:
                            //Write an exit code. This is not going to be a simple matter...
                        }
                    }
                } while (!xbeePort.IsOpen);
            }

            //If we've gotten this far we can continue now, as the error has been handled

            //Take the frame and package it
            byte[] tempArray = frame.PackageForTransmission();

            //Cheating again :X
            List<byte> holder = new List<byte>();

            //Add deliminator
            holder.Add(0x7E);

            //Get the length and add it
            holder.AddRange(Convert.ToUInt16(tempArray.Length).ToByteArray());

            //Add the frame data now
            holder.AddRange(tempArray);

            //Get the checksum and add it to the holder
            holder.Add(generateChecksum(tempArray));

            //We need a new array again to hold the final array
            byte[] finalTempArray = holder.ToArray();

            //Send this crap. We're done!
            xbeePort.Write(finalTempArray, 0, finalTempArray.Length);
        }

        //If an error occurs; clear the port of all excess info
        public void ClearPort()
        {
            //Clear IO buffers after making sure the port is open
            if (xbeePort.IsOpen)
            {
                this.xbeePort.DiscardInBuffer();
                this.xbeePort.DiscardOutBuffer();
            }
        }
    }
}
