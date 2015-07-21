using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.IO.Ports;

namespace watr_gui_v2
{
    public partial class WATR_BackEndSS : Form
    {
        //We're going to need several classes here
        WATR_Configurator configurator; //First is the configurator class that handles saved configurations
        WATR_Database database; //Next, we need the database implementation
        Dictionary<ulong, WATR_XBeeDevice> deviceList; //Device list
        WATR_PacketHandler packetHandler; //Handles direct communication with hardware; translates it into software-level information and vice versa
        WATR_CustomPacketHandler customPacker;
        WATR_MainForm mainForm;

        //Timeout object for when we're searching for packets
        Timer deviceLocateTimeout;
        Timer hideThisDamnForm;

        public WATR_BackEndSS()
        {
            //Intitialize components on the form itself by the visual studio designer
            InitializeComponent();

            //Initialize the timeout timer
            deviceLocateTimeout = new Timer();
            deviceLocateTimeout.Interval = 3000;    //3s
            deviceLocateTimeout.Tick += deviceLocateTimeout_Tick;   //Event handler

            //Instantiate components
            configurator = new WATR_Configurator();
            database = new WATR_Database();
            deviceList = new Dictionary<ulong, WATR_XBeeDevice>();
            customPacker = new WATR_CustomPacketHandler();

            //Show the form
            this.Show();

            //Begin basic startup procedures
            startupOperation();

            //Main Form
            mainForm = new WATR_MainForm();
            mainForm.refreshButton.Click += refreshButton_Click;
            mainForm.FormClosed += emergencyExit;
            mainForm.SetDeviceList(deviceList);
            mainForm.Show();

            //I hate this crap
            hideThisDamnForm = new Timer();
            hideThisDamnForm.Interval = 100;
            hideThisDamnForm.Tick += hideThisDamnForm_Tick;
            hideThisDamnForm.Enabled = true;
        }

        void emergencyExit(object sender, EventArgs e)
        {
          
            //Close the SQL Connection!
            database.CloseSQLConnection();

            //Clear the input and output buffers on the serial port
            packetHandler.RequestToClearPort();

            //Close his form to end the current thread
            this.Close();
        }

        //This is called when the user presses the main "refresh list" button
        void refreshButton_Click(object sender, EventArgs e)
        {
            //Purge the current device list
            deviceList.Clear();
            
            //Send the call out
            packetHandler.FindDevices();

            //Re-Enable the device time-out
            deviceLocateTimeout.Enabled = true;
            while (deviceLocateTimeout.Enabled)
                Application.DoEvents();

            //Done; request the form to update it's UI now as well
            mainForm.RequestToUpdateUI();
        }

        void hideThisDamnForm_Tick(object sender, EventArgs e)
        {
            hideThisDamnForm.Enabled = false;
            this.Hide();
        }

        //Basic startup procedures
        private void startupOperation()
        {
            //Check for a first-time run
            progressLabel.Text = "Checking for first-time setup...";
            if (configurator.isFirstRun())
            {
                //If it is, let's first-run this program!
                configurator.firstRunSetup(database);
            }

            //Update the progress bar
            this.loadProgressBar.Value = 10;

            //Now we need to find the COM port our Xbee is on
            foreach (string portName in SerialPort.GetPortNames())
            {
                //Update label
                progressLabel.Text = "Trying " + portName;

                //Instantiate the packet handler under the port name
                packetHandler = new WATR_PacketHandler(portName, database);
                if (packetHandler.TestCommunications())
                {
                    //We've found our match! Success! Break out of this loop
                    progressLabel.Text += " ... success!";
                    break;
                }

                //If we reach this, then there is no xbee device attached currently
                packetHandler = null;
            }

            //Check to make sure the packet handler was not null
            if (packetHandler == null)
            {
                MessageBox.Show("Error: No Xbee devices found; exiting...", "Error");

                //Exit
                Environment.Exit(0);
            }

            //Update the progress bar
            this.loadProgressBar.Value = 40;


            //Start Asynch operations on the packet handler, and update the pbar value
            this.progressLabel.Text = "Starting Async Operations";
            packetHandler.StartAsyncOperations();
            loadProgressBar.Value = 50;

            //Add event handlers
            this.progressLabel.Text = "Adding proper handlers... ";
            packetHandler.ReceivedRemoteATCommandResponse += packetHandler_ReceivedRemoteATCommandResponse;
            packetHandler.ReceivedRxPacket += packetHandler_ReceivedRxPacket;
            packetHandler.ReceivedTransmitStatus += packetHandler_ReceivedTransmitStatus;
            packetHandler.ReceivedATCmdResponse += packetHandler_ReceivedATCmdResponse;
            customPacker.SensorRecordGet += customPacker_SensorRecordGet;   //This goes up here because of how I'm going to handle the record update

            //Enable our timeout and search for devices
            //Do note that devices can -ALWAYS- be detected, just we want an initial population
            this.progressLabel.Text = "Searching for devices...";
            packetHandler.FindDevices();
            deviceLocateTimeout.Enabled = true;
            while (deviceLocateTimeout.Enabled)
                Application.DoEvents(); //Quick and dirty way to process events... suffices without multi-threading

            //Done finding devices
            this.progressLabel.Text = "Done. Found " + deviceList.Count.ToString() + " devices";
            this.loadProgressBar.Value = 85;

            //Finish up some final processess
            this.progressLabel.Text = "Finishing up final routines...";

            //Ask for a force update on all devices
            foreach (ulong key in deviceList.Keys)
            {
                deviceList[key].ForceRefresh();
            }

            this.progressLabel.Text += " done!";
            this.loadProgressBar.Value = 100;

            //It's been a long road, but we are D O N E WITH THE STARTUP!
            return;
        }

        private void customPacker_SensorRecordGet(object sender, WATR_SensorRecordGetArgs e)
        {
            //Log the update
            database.LogSensorRecord(e.SensorRecord);

            //Update the device to point to the most current record;
            deviceList[e.SensorRecord.SourceAddress].SetRecord(e.SensorRecord);
        }

        void deviceLocateTimeout_Tick(object sender, EventArgs e)
        {
            deviceLocateTimeout.Enabled = false;
        }

        void packetHandler_ReceivedATCmdResponse(object sender, WATR_ATCmdResponseGetArgs e)
        {
            //Do nothing for now.
            return;
        }

        void packetHandler_ReceivedTransmitStatus(object sender, WATR_TransmitStatusGetArgs e)
        {
            //Do nothing for now =D
            return;
        }

        void packetHandler_ReceivedRxPacket(object sender, WATR_RxPacketGetArgs e)
        {
            //To Do:
            //Implement a Custom Packet Handler for our custom data from the xbees.
            //This method will call it and send it to there. From there, the custom packet
            //Will determine what kind of information you are getting, pass it back here
            //And the backend will update the proper device =D

            //My solution!
            //Also; do not process -ANY- of this while we are looking for devices... this is causing a bit of problems as well
            //I'm assuming it has something to do with a feedback buffer. No matter.
            if (!deviceLocateTimeout.Enabled)
            {
                customPacker.ParseReceiveFrameData(e.FrameData);
            }
        }

        void packetHandler_ReceivedRemoteATCommandResponse(object sender, WATR_RemoteATCmdResponseGetArgs e)
        {
            //Let's face it - I am seriously only using this as a way to find all of the devices in our network.
            //if I needed to populate information on a device itself, I'd need to disable this event
            //And add a custom one in that only interprets packets from a specific serial number.
            bool matchFound = false;

            foreach (ulong serial in deviceList.Keys)
            {
                if (e.FrameData.SourceAddress == serial)
                    matchFound = true;
            }

            if (!matchFound)
            {
                //Make sure that the device ID is NOT 0; I've been having MAJOR issues with this for some reason
                //This usually occurs when a packet is "valid" but still misread - meaning, there is something wrong
                //With either the way the packet received the information, or the way I transmitted it.
                if (e.FrameData.SourceAddress > 0)
                {
                    //Create the device
                    WATR_XBeeDevice temp = new WATR_XBeeDevice(e.FrameData.SourceAddress, e.FrameData.CommandData);

                    //Add the proper event handler to it
                    temp.RefreshRequest += xbee_RefreshRequest;
                    temp.LogbookRequest += temp_LogbookRequest;

                    //Force refresh - OUTDATED; moved so that this doesn't screw up
                    //temp.ForceRefresh();

                    //Add it to the list
                    deviceList.Add(e.FrameData.SourceAddress, temp);
                }
            }
        }

        void temp_LogbookRequest(object sender, WATR_LogbookRequestArgs e)
        {
            e.Requestor.UpdateLogRecord(database.GetSensorLog(e.Requestor.Address));
        }

        //Handle all of the refresh requests here
        void xbee_RefreshRequest(object sender, WATR_RefreshRequestArgs e)
        {
            //Send out a packet to the specified device and generate a sensor record request item
            packetHandler.TransmitRequest(e.Requestor, customPacker.generateSensorRecordRequest());
        }
    }
}
