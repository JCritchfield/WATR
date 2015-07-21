using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATR_GUI
{
    public class WATRSensorRecord
    {
        public WATRXbeeSerialNumber XBeeSerialNumber { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public int HumidityLevel { get; private set; }
        public double TemperatureLevel { get; private set; }
        public int MoistureLevel { get; private set; }
        public int BatteryLevel { get; private set; }

        public WATRSensorRecord(WATRXbeeSerialNumber XBeeSN, DateTime timestamp, int humidityLevel, double temperatureLevel, int moistureLevel, int batteryLevel)
        {
            this.XBeeSerialNumber = XBeeSN;
            this.TimeStamp = timestamp;
            this.HumidityLevel = humidityLevel;
            this.TemperatureLevel = temperatureLevel;
            this.MoistureLevel = moistureLevel;
            this.BatteryLevel = batteryLevel;
        }
    }
}
