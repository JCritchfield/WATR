using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_XBeeATCommandFrameData : WATR_IXBeeTxFrameData
    {
        //Public properties
        public int FrameID { get; private set; }
        public string ATCommand { get; private set; }
        public string Parameters { get; private set; }
        
        public WATR_XBeeATCommandFrameData(string atCommand, string parameters = "")
        {
            //Set the frame ID to our static int
            FrameID = WATR_XBeeFrameIDTransmitTracker.GetFrameIDNumber();

            //Set the AT Command
            //Check if AT Command is > 2 chars
            if (atCommand.Length > 2)
            {
                //Toss an error; invalid; Implement a feature to actually query for the proper command if applicable
            }
            else
            {
                //Otherwise set the AT Command to the supplied string
                ATCommand = atCommand;
            }

            //Set the parameters to the supplied parameters; don't care if it's empty for now...
            Parameters = parameters;
        }

        public byte[] PackageForTransmission()
        {
            //Check to make sure the exception isn't being transmitted (aka "NI")
            if (ATCommand == "NI")
            {
                //We need to handle this differently...
                //I'm using a list for this. Cheating my ass :>
                List<byte> byteArray = new List<byte>();

                //Add the Frame Type
                byteArray.Add(0x08);

                //Add the two AT Command characters
                byteArray.Add(Convert.ToByte(ATCommand[0]));
                byteArray.Add(Convert.ToByte(ATCommand[1]));

                //Check for empty string and then add the ASCII Parameter for NI
                if(!string.IsNullOrEmpty(Parameters))
                    byteArray.AddRange(Parameters.ToByteArray());

                //Return the byte array
                return byteArray.ToArray();
            }
            else
            {
                //Package the parameters as a number
                //List declaration
                List<byte> byteArray = new List<byte>();

                //Add the Frame Type
                byteArray.Add(0x08);

                //Add the frame ID
                byteArray.Add(Convert.ToByte(FrameID));

                //Add the two AT Command characters
                byteArray.Add(Convert.ToByte(ATCommand[0]));
                byteArray.Add(Convert.ToByte(ATCommand[1]));

                //Check for empty string and then add the numerical parameter
                if (!string.IsNullOrEmpty(Parameters))
                    byteArray.AddRange(Convert.ToUInt64(Parameters).ToByteArray());

                //Return the byte array
                return byteArray.ToArray();
            }
        }
    }
}
