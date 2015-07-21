using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Timers;

namespace watr_gui_v2
{
    public class WATR_XBeeDevice
    {
        //Public properties
        public ulong Address { get; private set; }
        public string Identifier { get; private set; }

        //Forms
        WATR_DeviceInfoForm form;
        WATR_Logbook log;

        //Other objects
        Timer refreshTimer;

        //Events
        public event EventHandler<WATR_RefreshRequestArgs> RefreshRequest;
        public event EventHandler<WATR_LogbookRequestArgs> LogbookRequest;

        public WATR_XBeeDevice(ulong address, string nodeIdentifier)
        {
            //Assign values
            this.Address = address;
            this.Identifier = nodeIdentifier;

            //Instantiate form
            form = new WATR_DeviceInfoForm();
            form.setRefreshButton.Click += setRefreshButton_Click;
            form.forceRefreshButton.Click += forceRefreshButton_Click;
            form.viewLogButton.Click += viewLogButton_Click;
            form.FormClosing += form_FormClosing;
            SetFormName();

            //Instantiate the timer
            refreshTimer = new Timer();
            refreshTimer.Interval = 900000;
            refreshTimer.Elapsed += refreshTimer_Elapsed;
            refreshTimer.Start();
        }

        public void CloseForm()
        {
            this.form.Close();
        }

        void form_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //Clear up the log book.
            if (log != null)
                log.Close();
        }

        void forceRefreshButton_Click(object sender, EventArgs e)
        {
            this.form.forceRefreshButton.Enabled = false;
            this.ForceRefresh();
        }

        public void SetFormLocation(Point p)
        {
            this.form.Location = p;
        }

        public Size GetFormSize()
        {
            return this.form.Size;
        }

        void viewLogButton_Click(object sender, EventArgs e)
        {
            WATR_LogbookRequestArgs req = new WATR_LogbookRequestArgs(this);
            if (req != null)
                LogbookRequest(this, req);
        }

        //Called by the backend in response to a log request
        public void UpdateLogRecord(DataTable record)
        {
            //Make sure a log book doesn't exist first...
            if (log == null)
            {
                log = new WATR_Logbook();
                //Add an event handler for the log
                log.FormClosing += log_FormClosing;
                log.Text += " - " + this.Identifier;
                log.SetDataSource(record);
                log.Show();
            }
        }

        //Called when the log form is closed
        void log_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //Remove the log handler; it'll cause problems otherwise..
            log.FormClosing -= log_FormClosing;
            //Null the reference
            log = null;
        }

        public void ForceRefresh()
        {
            WATR_RefreshRequestArgs request = new WATR_RefreshRequestArgs(this.Address);
            if (request != null)
                RefreshRequest(this, request);
        }

        private void setRefreshButton_Click(object sender, EventArgs e)
        {
            //refreshTimer.Interval = form.GetRefreshTime() * 60 * 1000; 
        }

        private void refreshTimer_Elapsed(object sender, EventArgs e)
        {
            WATR_RefreshRequestArgs request = new WATR_RefreshRequestArgs(this.Address);
            if (request != null)
                RefreshRequest(this, request);
        }

        private void SetFormName()
        {
            form.Text = Identifier;
        }

        public void ShowForm()
        {
            if (!form.Visible)
                form.Show();
        }

        public void SetRecord(WATR_SensorRecord record)
        {
            //Insert the record
            if (form.InvokeRequired)
            {
                form.Invoke(new Action<WATR_SensorRecord>(SetRecord), record);
            }
            else
            {
                form.insertRecord(record);
            }
        }
    }
}
