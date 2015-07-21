using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WATR_GUI
{
    public class WATRBackend
    {

        //-------
        public WATRXBConnection Xbee;
        public WATRDatabase Db;
        public Dictionary<WATRXbeeSerialNumber, WATRXBeeDevice> Devices;
        public WATRConfiguration Configuration;
        public WATRSplashScreen splashScreen;

        //Default Constructor
        public WATRBackend()
        {
            //Basic intialization
            Configuration = new WATRConfiguration();
            Db = new WATRDatabase();
            Devices = new Dictionary<WATRXbeeSerialNumber, WATRXBeeDevice>();
            splashScreen = new WATRSplashScreen();

            splashScreen.Show();
            
            //Check for first-time run
            if (Configuration.checkForFirstRun())
            {
                Configuration.firstTimeRunSetup(Db);
            }

            splashScreen.progress.Value += 10;

            //Once the first-time run check is done, now we need to go ahead and take care of some XBee stuff
            //Set the port name to what we found earlier, and the baud rate to 9600 - a default I plan on using for a long while
            Xbee = new WATRXBConnection(Configuration.GetPortName(), 9600);

            splashScreen.progress.Value += 20;

            //ToDo: Make sure the COM port works by sending a local AT Command, for now we're skipping it

            splashScreen.progress.Value += 30;

            //ToDo: Generate a device list

            splashScreen.progress.Value += 30;

            //ToDo: Finish startup

            splashScreen.progress.Value += 10;

            //Setup complete; get rid of the splash screen!
            splashScreen.Hide();
        }

    }
}
