using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace watr_gui_v2
{
    public class WATR_LogbookRequestArgs
    {
        public WATR_XBeeDevice Requestor { get; private set; }

        public WATR_LogbookRequestArgs(WATR_XBeeDevice requestor)
        {
            Requestor = requestor;
        }
    }
}
