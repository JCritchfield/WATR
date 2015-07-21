using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace watr_gui_v2
{
    public class WATR_ValidDataGetArgs
    {
        public WATR_XBeeRxFrameData Data { get; private set; }

        public WATR_ValidDataGetArgs(WATR_XBeeRxFrameData data)
        {
            this.Data = data;
        }
    }
}
