using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_XBeeReceivePacketFrameData : WATR_XBeeRxFrameData
    {
        //Private variables for information location
        int sourceAddressStart = 1;
        int networkAddyStart = 9;
        int receiveOptionsStart = 11;
        int rxDataStart = 12;

        //Properties
        public ulong SourceAddress { get; private set; }
        public int NetworkAddress { get; private set; }
        public int ReceiveOptions { get; private set; }
        public byte[] ReceiveData;

        //Constructor
        public WATR_XBeeReceivePacketFrameData(byte[] rawData)
            : base(rawData)
        {
            parseInfo(rawData);
        }

        //Parse the byte array
        private void parseInfo(byte[] rawInfo)
        {
            //Get the source address
            SourceAddress = rawInfo.ExtractNumber(sourceAddressStart, sourceAddressStart + 8);

            //Get the network address
            NetworkAddress = (int)rawInfo.ExtractNumber(networkAddyStart, networkAddyStart + 2);

            //Get the receive options byte
            ReceiveOptions = rawInfo[receiveOptionsStart];

            //Get the rest of the data as bytes
            ReceiveData = rawInfo.SubArray(rxDataStart);
        }
    }
}
