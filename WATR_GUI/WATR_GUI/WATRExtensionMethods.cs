using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATR_GUI
{
    public static class WATRExtensionMethods
    {
        public static byte[] ToByteArray(this long number)
        {
            byte[] tempArray = new byte[sizeof(double)];

            for (int i = 0; i < 8; i++)
            {
                tempArray[i] = Convert.ToByte((number >> (8 * (7 - i))) & 0xFF);
            }

            return tempArray;
        }

        public static byte[] ToByteArray(this Int16 number)
        {
            byte[] tempArray = new byte[sizeof(double)];

            for (int i = 0; i < 2; i++)
            {
                tempArray[i] = Convert.ToByte((number >> (8 * (1 - i))) & 0xFF);
            }

            return tempArray;
        }

        public static ulong ToULongValue(this List<byte> brokenULong)
        {
            ulong temp = 0;
            for (int i = 0; i < brokenULong.Count; i++)
            {
                temp += brokenULong[i];
                temp <<= 8 * i;
            }

            return temp;
        }
    }
}
