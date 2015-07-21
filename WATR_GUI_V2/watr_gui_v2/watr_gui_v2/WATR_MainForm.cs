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
    public partial class WATR_MainForm : Form
    {
        //List object of the devices
        Dictionary<ulong, WATR_XBeeDevice> devices;

        public WATR_MainForm()
        {
            InitializeComponent();
            this.FormClosing += WATR_MainForm_FormClosing;
        }

        void WATR_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ulong key in devices.Keys)
            {
                devices[key].CloseForm();
            }
        }

        //Set the device list then update the UI
        public void SetDeviceList(Dictionary<ulong, WATR_XBeeDevice> list)
        {
            devices = list;
            updateUI();
        }

        //Updates the UI values
        private void updateUI()
        {
            //Clear anything there
            deviceListBox.Items.Clear();

            //Re-add them
            foreach (ulong key in devices.Keys)
            {
                deviceListBox.Items.Add(devices[key].Address);
            }
        }

        private void deviceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deviceListBox.SelectedIndex >= 0)
            {
                devices[Convert.ToUInt64(deviceListBox.Items[deviceListBox.SelectedIndex].ToString())].ShowForm();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshButton.Enabled = false;
        }

        public void RequestToUpdateUI()
        {
            updateUI();
            refreshButton.Enabled = true;
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            int xLoc = this.Location.X + this.Size.Width;
            int yLoc = this.Location.Y;
            int count = 0;

            foreach (ulong key in devices.Keys)
            {
                //Show the form
                devices[key].ShowForm();

                count++;
                if (count % 4 == 0)
                {
                    yLoc += 30 + devices[key].GetFormSize().Height;
                    xLoc = this.Location.X + this.Size.Width;
                }
                devices[key].SetFormLocation(new Point(xLoc + 30, yLoc));
                xLoc += 30 + devices[key].GetFormSize().Width;


            }
        }
    }
}
