using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace watr_gui_v2
{
    public class WATR_RefreshRequestArgs
    {
        public ulong Requestor { get; private set; }

        public WATR_RefreshRequestArgs(ulong requestor)
        {
            Requestor = requestor;
        }
    }
}
