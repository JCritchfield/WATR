using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATR_GUI
{
    public class WATRXBeeDevice
    {
        public string Name { get; private set; }
        public WATRXbeeSerialNumber SerialNumber { get; private set; }
        
        //Each xbee device should own it's own form - so here we go - it needs to be public because I need to be able to access the form's methods.
        public WATRSensorForm sensorForm;

        //Timer for the refresh timer
        Timer refreshTimer;

        public WATRXBeeDevice(string name, UInt32 serialNumberLow)
        {
            this.Name = name;
            this.SerialNumber = new WATRXbeeSerialNumber(serialNumberLow);
            sensorForm = new WATRSensorForm();
            sensorForm.Text = "WATR Sensor; Device: " + this.SerialNumber.FullSerialNumber.ToString();
        }
    }
}
