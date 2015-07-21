using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_XBeeRxFrameData
    {
        //Variables on locations where standard info should be located
        private int frameTypeLoc = 0;
        private int frameIdLoc = 1;

        //Holds the raw information used for instantiation
        public byte[] RawData { get; private set; }

        //Public properties
        public int FrameID { get; private set; }
        public int FrameType { get; private set; }

        //Constructor
        public WATR_XBeeRxFrameData(byte[] data)
        {
            RawData = data;
            parseRawData();
        }

        //Grab all basic data possible from the frame data
        private void parseRawData()
        {
            FrameType = RawData[frameTypeLoc];

            if (FrameType == 0x90)
            {
                FrameID = 0;
            }
            else
            {
                FrameID = RawData[frameIdLoc];
            }
        }

        //Automatically downcast to the appropriate packet type
        //This, honestly, is like sending massive fucking red flags off everywhere
        //I have no idea -how- bad this has the possibility to break.
        //We'll see....
        public dynamic GetFrameType()
        {
            switch (FrameType)
            {
                case 0x88:
                    {
                        return new WATR_XBeeATCommandResponseFrameData(this.RawData);
                    }
                case 0x97:
                    {
                        return new WATR_XBeeRemoteATCommandResponseFrameData(this.RawData);
                    }
                case 0x90:
                    {
                        return new WATR_XBeeReceivePacketFrameData(this.RawData);
                    }
                case 0x8B:
                    {
                        return new WATR_XBeeTransmitStatusFrameData(this.RawData);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
