using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace watr_gui_v2
{
    public class WATR_InvalidDataGetArgs
    {
        public byte[] Data { get; private set; }

        public WATR_InvalidDataGetArgs(byte[] data)
        {
            this.Data = Data;
        }
    }
}
