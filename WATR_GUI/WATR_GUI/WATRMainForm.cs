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
    public partial class WATRMainForm : Form
    {
        //Backend class declaration
        WATRBackend Backend = new WATRBackend();
        

        //Public Constructor
        public WATRMainForm()
        {
            InitializeComponent();
            updateUI();
        }

        //Update the UI
        private void updateUI()
        {
            this.deviceListBox.Items.Clear();

            foreach (WATRXbeeSerialNumber key in Backend.Devices.Keys)
            {
                this.deviceListBox.Items.Add(Backend.Devices[key].SerialNumber.FullSerialNumber.ToString());
            }
        }

        //Show the current selected devices sensor box
        private void viewBox_Click(object sender, EventArgs e)
        {
            if (deviceListBox.SelectedIndex >= 0)
            {
                foreach (WATRXbeeSerialNumber sn in Backend.Devices.Keys)
                {
                    if (Convert.ToUInt64(deviceListBox.Items[deviceListBox.SelectedIndex].ToString()) == Backend.Devices[sn].SerialNumber.FullSerialNumber)
                    {
                        Backend.Devices[sn].sensorForm.Show();
                    }
                }
            }
        }
    }
}
