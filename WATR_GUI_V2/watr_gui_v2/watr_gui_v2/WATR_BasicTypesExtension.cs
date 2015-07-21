using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public static class WATR_BasicTypesExtension
    {
        //Get a number from a byte array
        public static ulong ExtractNumber(this byte[] array, int startPos, int endPos)
        {
            //Temp value holder
            ulong tempValue = 0;

            //Iterate through the bytes
            for (int i = startPos; i < endPos; i++)
            {
                tempValue |= (Convert.ToUInt64(array[i]) << ((endPos - i - 1) * 8));
            }

            return tempValue;
        }

        //Get a byte array from a ulong
        public static byte[] ToByteArray(this ulong number)
        {
            byte[] tempValue = new byte[sizeof(ulong)];

            for (int i = 0; i < tempValue.Length; i++)
            {
                //Math check:
                //At i = 0, 7 - 0 = 7
                //8 * 7 = 56
                //So this takes the MSB 8 bits and shifts them 56 to the right
                //Check!
                tempValue[i] = Convert.ToByte((number >> 8 * (sizeof(ulong) - 1 - i)) & 0xFF);
            }

            return tempValue;
        }

        //Get a byte array of a string
        public static byte[] ToByteArray(this string data)
        {
            byte[] tempValue = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                tempValue[i] = Convert.ToByte(data[i]);
            }

            return tempValue;
        }

        //Get a byte array of a 2-byte short / int whatever
        public static byte[] ToByteArray(this ushort number)
        {
            byte[] tempValue = new byte[sizeof(ushort)];

            for (int i = 0; i < tempValue.Length; i++)
            {
                //Math check:
                //At i = 0, 1 - 0 = 1
                //8 * 1 = 8
                //So this takes the MSB 8 bits and shifts them 8 to the right
                //Check!
                tempValue[i] = Convert.ToByte((number >> 8 * (sizeof(ushort) - 1 - i)) & 0xFF);
            }

            return tempValue;
        }

        //Get a fraction of the byte array
        public static byte[] SubArray(this byte[] array, int startPoint)
        {
            byte[] holder = new byte[array.Length - startPoint];

            for (int i = startPoint; i < array.Length; i++)
            {
                holder[i - startPoint] = array[i];
            }

            return holder;
        }

        //Return a hex-byte value of all bytes in a string-format
        public static string ToHexInASCII(this byte[] array)
        {
            string temp = "";

            for (int i = 0; i < array.Length; i++)
            {
                temp += "[" + array[i].ToString("X2").PadLeft(2, '0') + "]";
                if (i != array.Length)
                    temp += " ";
            }

            return temp;
        }

        //Extract a string from an array at a specific point up to but not including the ending index
        public static string ExtractString(this byte[] array, int startIndex, int endIndex)
        {
            string temp = "";

            for (int i = startIndex; i < endIndex; i++)
            {
                temp += array[i].ToString();
            }

            return temp;
        }

        //Returns the byte array as an entire string, starting from a specific position
        public static string ConvertToString(this byte[] array, int startPos)
        {
            string temp = "";

            for (int i = startPos; i < array.Length; i++)
            {
                temp += Convert.ToChar(array[i]);
            }

            return temp;
        }
    }
}
