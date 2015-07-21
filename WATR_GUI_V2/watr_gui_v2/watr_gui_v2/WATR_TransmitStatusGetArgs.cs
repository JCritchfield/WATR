using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace watr_gui_v2
{
    public class WATR_TransmitStatusGetArgs
    {
        public WATR_XBeeTransmitStatusFrameData FrameData { get; private set; }

        public WATR_TransmitStatusGetArgs(WATR_XBeeTransmitStatusFrameData data)
        {
            FrameData = data;
        }
    }
}
