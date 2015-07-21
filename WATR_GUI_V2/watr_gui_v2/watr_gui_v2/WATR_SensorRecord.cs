using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_SensorRecord
    {
        //Public properties
        public ulong SourceAddress { get; private set; }
        public int Temperature { get; private set; }
        public int Humidity { get; private set; }
        public int MoistureLevel { get; private set; }
        public int BatteryLevel { get; private set; }
        public DateTime TimeStamp { get; private set; }

        public WATR_SensorRecord(ulong sourceAddress, int temperature, int humidity, int moistureLevel, int batteryLevel)
        {
            //Set all the constructor values to the 
            SourceAddress = sourceAddress;
            Temperature = temperature;
            Humidity = humidity;
            MoistureLevel = moistureLevel;
            BatteryLevel = batteryLevel;
            TimeStamp = DateTime.Now;
        }
    }
}
