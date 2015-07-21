using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATR_GUI
{
    public abstract class WATRXBeeReceiveFrameData : WATRXBeeFrameData
    {
        WATRXbeeSerialNumber senderDeviceSN;

        public WATRXBeeReceiveFrameData(List<byte> frameDataList)
        {
            //Take the list and set it equal to the list sent from the interpreter
            this.frameData = frameDataList;

            //Get some basic information
            this.frameType = frameData[0];
            this.frameID = frameData[1];
            this.checkSum = frameData[frameData.Count - 1];
            
            //Get the reciever's serial number
            senderDeviceSN = new WATRXbeeSerialNumber(frameData.GetRange(2, 9).ToULongValue());

            //Make sure frame data is valid
            if (challengeChecksum())
                this.IsValid = true;
            else
                this.IsValid = false;
        }

        public WATRXBeeReceiveFrameData(byte[] frameDataList)
        {
            //Take the byte array, turn it into a list, and set it as the frame data
            this.frameData = frameDataList.ToList<byte>();

            //Get some basic information
            this.frameType = frameData[0];
            this.frameID = frameData[1];
            this.checkSum = frameData[frameData.Count - 1];

            //Get the reciever's serial number
            senderDeviceSN = new WATRXbeeSerialNumber(frameData.GetRange(2, 9).ToULongValue());

            //Make sure frame data is valid
            if (challengeChecksum())
                this.IsValid = true;
            else
                this.IsValid = false;
        }

        public virtual bool challengeChecksum()
        {
            //Declare a variable to hold our temporary value
            byte checksum = 0;
            
            //Iterate through each byte in our frame data and add it to checksum
            foreach (byte data in this.frameData)
            {
                checksum += data;          
            }

            //After it's all done, it should equal 0xFF - if not, it's not a valid packet
            if (checksum == 0xFF)
                return true;
            else
                return false;
        }
    }
}
