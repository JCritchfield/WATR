using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace watr_gui_v2
{
    public class WATR_ATCmdResponseGetArgs
    {
        public WATR_XBeeATCommandResponseFrameData FrameData { get; private set; }

        public WATR_ATCmdResponseGetArgs(WATR_XBeeATCommandResponseFrameData data)
        {
            FrameData = data;
        }

    }
}
