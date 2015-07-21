using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace watr_gui_v2
{
    public class WATR_SensorRecordGetArgs
    {
        public WATR_SensorRecord SensorRecord { get; private set; }

        public WATR_SensorRecordGetArgs(WATR_SensorRecord record)
        {
            SensorRecord = record;
        }
    }
}
