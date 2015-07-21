using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_XBeeTransmitStatusFrameData : WATR_XBeeRxFrameData
    {
        public WATR_XBeeTransmitStatusFrameData(byte[] rawData)
            : base(rawData)
        {

        }
    }
}
