using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATR_GUI
{
    public class WATRXbeeSerialNumber
    {
        public static readonly long BroadcastAddress = 0x000000000000FFFF;

        //The two serial numbers are UInt32s
        public UInt32 SerialNumberHigh { get; private set; }
        public UInt32 SerialNumberLow { get; private set; }

        //Return the merged serial number
        public ulong FullSerialNumber
        {
            get
            {
                ulong temp = 0;
                temp += SerialNumberHigh;
                temp <<= 32;
                temp |= SerialNumberLow;

                return temp;
            }
        }

        //We can either provide the full serial number...
        public WATRXbeeSerialNumber(ulong fullSerialNum)
        {
            SerialNumberLow = Convert.ToUInt32(fullSerialNum & 0x00000000FFFFFFFF);
            SerialNumberHigh = Convert.ToUInt32((fullSerialNum >> 32) & 0x00000000FFFFFFFF);
        }


        //Or only the low; all Xbee Series 2 devices have the same high qword serial number
        public WATRXbeeSerialNumber(UInt32 serialLow)
        {
            SerialNumberHigh = 1286656;
            SerialNumberLow = serialLow;
        }
    }

}
