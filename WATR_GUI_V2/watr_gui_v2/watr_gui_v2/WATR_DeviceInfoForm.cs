using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watr_gui_v2
{
    public partial class WATR_DeviceInfoForm : Form
    {
        public WATR_DeviceInfoForm()
        {
            InitializeComponent();
        }

        public void insertRecord(WATR_SensorRecord record)
        {
            batteryPercentStatusLabel.Text = record.BatteryLevel.ToString() + "%";
            temperatureTextBox.Text = record.Temperature.ToString();
            humidityTextBox.Text = record.Humidity.ToString();
            moistureLevelTextBox.Text = record.MoistureLevel.ToString();
            lastUpdateDateLabel.Text = record.TimeStamp.ToString();

            //Re-enable the refresh button if it's disabled
            this.forceRefreshButton.Enabled = true;
        }

        private void WATR_DeviceInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public int GetRefreshTime()
        {
            return (int)this.numericUpDown1.Value;
        }
    }
}
