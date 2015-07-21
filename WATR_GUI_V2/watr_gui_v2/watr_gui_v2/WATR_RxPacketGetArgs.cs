using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace watr_gui_v2
{
    public class WATR_RxPacketGetArgs
    {
        public WATR_XBeeReceivePacketFrameData FrameData { get; private set; }

        public WATR_RxPacketGetArgs(WATR_XBeeReceivePacketFrameData data)
        {
            FrameData = data;
        }
    }
}
