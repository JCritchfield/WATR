using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace watr_gui_v2
{
    public class WATR_RemoteATCmdResponseGetArgs
    {
        public WATR_XBeeRemoteATCommandResponseFrameData FrameData { get; private set; }

        public WATR_RemoteATCmdResponseGetArgs(WATR_XBeeRemoteATCommandResponseFrameData data)
        {
            FrameData = data;
        }
    }
}
