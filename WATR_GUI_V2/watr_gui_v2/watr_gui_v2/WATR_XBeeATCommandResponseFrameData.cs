using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_XBeeATCommandResponseFrameData : WATR_XBeeRxFrameData
    {
        //Private variables for information location 
        int atCmdStart = 2;
        int cmdStatusStart = 4;
        int cmdDataStart = 5;

        //Properties
        public string ATCommand { get; private set; }
        public int CommandStatus { get; private set; }
        public string CommandData { get; private set; }
        public bool IsNumber { get; private set; }

        //Basic constructor
        public WATR_XBeeATCommandResponseFrameData(byte[] rawData)
            : base(rawData)
        {
            //Process the byte array
            parseInfo(rawData);
        }

        private void parseInfo(byte[] rawData)
        {
            //Get the AT Commands two characters
            ATCommand += Convert.ToChar(rawData[atCmdStart]);
            ATCommand += Convert.ToChar(rawData[atCmdStart + 1]);

            //Get the command status
            CommandStatus = Convert.ToInt16(rawData[cmdStatusStart]);

            //Now we need to do a little special parsing here:
            //If the ATCmd is "NI", we need to take the info as a literal string
            //If it's anything else, then it's a decimal number.
            if (ATCommand == "NI")
            {
                //Iterate through the rest of the frame and add it as text
                for (int i = cmdStatusStart; i < rawData.Length; i++)
                {
                    CommandData += Convert.ToChar(rawData[i]);
                }

                //Set the number flag to false
                IsNumber = false;
            }
            else
            {
                //Extract the information as ulong (should be no longer than 64bits if a number..)
                CommandData = rawData.ExtractNumber(cmdDataStart, rawData.Length).ToString();

                //Set the number flag to true
                IsNumber = true;
            }
        }
    }
}
