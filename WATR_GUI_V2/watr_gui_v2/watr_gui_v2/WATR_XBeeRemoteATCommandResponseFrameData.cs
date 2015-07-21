using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_XBeeRemoteATCommandResponseFrameData : WATR_XBeeRxFrameData
    {
        //Location of information
        int sourceStart = 2;
        int networkAddressStart = 10;
        int atCmdStart = 12;
        int cmdStatusStart = 14;
        int cmdDataStart = 15;

        //Properties
        public string ATCommand { get; private set; }
        public int CommandStatus { get; private set; }
        public int NetworkAddress { get; private set; }
        public ulong SourceAddress { get; private set; }
        public string CommandData { get; private set; }


        public WATR_XBeeRemoteATCommandResponseFrameData(byte[] rawData)
            : base(rawData)
        {
            //Process the byte array
            parseInfo(rawData);
        }

        //Extract information
        private void parseInfo(byte[] array)
        {
            //Let's start with the AT Command
            ATCommand += Convert.ToChar(array[atCmdStart]);
            ATCommand += Convert.ToChar(array[atCmdStart + 1]);

            //Then the command status
            CommandStatus = array[cmdStatusStart];

            //If NI, the data is pure ASCII
            if (ATCommand == "NI")
            {
                //Iterate from the cmd start to the length of the array since it's the final
                //Piece of information
                for (int i = cmdDataStart; i < array.Length; i++)
                {
                    CommandData += Convert.ToChar(array[i]);
                }
            }
            else
            {
                //Handle the params as one giant ulong
                CommandData = array.ExtractNumber(cmdDataStart, array.Length).ToString();
            }

            //Get the source address
            SourceAddress = array.ExtractNumber(sourceStart, sourceStart + 8);

            //Get the source network address
            NetworkAddress = Convert.ToInt32(array.ExtractNumber(networkAddressStart, networkAddressStart + 2));

            //Done!
            return;
        }
    }
}
