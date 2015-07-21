using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATR_GUI
{
    public partial class WATRSensorForm : Form
    {
        //Properties to allow the backend to access the records on this device's form
        //Temperature
        public double currentTemperature { get; private set; }

        //Humidity
        public int currentHumidityLvl { get; private set; }

        //Moisture Level
        public int currentMoistureLvl { get; private set; }

        //Battery level
        public int currentBatteryLvl { get; private set; }

        public WATRSensorForm()
        {
            InitializeComponent();
        }

        public void PlaceCurrentRecord(WATRSensorRecord record)
        {
            this.currentHumidityLvl = record.HumidityLevel;
            this.currentBatteryLvl = record.BatteryLevel;
            this.currentTemperature = record.TemperatureLevel;
            this.currentMoistureLvl = record.MoistureLevel;
            this.dateTimeInfoSSLabel.Text = record.TimeStamp.ToString("MM/dd/yy hh:mm");
            updateUI();
        }

        private void updateUI()
        {
            this.humidityLabel.Text = "Humidity Level: " + currentHumidityLvl.ToString() + "%";
            this.tempLabel.Text = "Temperature: " + currentTemperature.ToString() + "°F";
            this.moistureLabel.Text = "Moisure Level: " + currentMoistureLvl.ToString() + "%";
            this.batteryPercentageSSLabel.Text = currentBatteryLvl.ToString() + "%";
        }
    }
}
