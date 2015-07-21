using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public static class WATR_XBeeFrameIDTransmitTracker
    {
        //Static byte value for holding our frame ID count;
        static byte frameIDCount = 1;

        public static int GetFrameIDNumber()
        {
            //Hold the value of our current count
            byte temp = frameIDCount;
            
            //Increase the count
            frameIDCount++;

            //Return the old count
            return temp;
        }
    }
}
