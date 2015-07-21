using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace WATR_GUI
{
    public class WATRConfiguration
    {
        //Change these three to properties later
        const string configFilePath = ".\\config.ini";
        const string firstRunString = "firstRun";
        const string comPortString = "comPort";
        const string dbCreationString = "dbCreate";
        const string lastRecordString = "lastRecordID";

        Dictionary<string, string> configStrings;

        WATRConfigurationForm configForm;

        public WATRConfiguration()
        {
            configStrings = new Dictionary<string, string>();
        }

        public bool checkForFirstRun()
        {
            //Load the config.ini file if it exists...
            if (File.Exists(configFilePath))
            {
                //Prase the config file
                readConfigFile();

                //Now as a final thought, check for the firstRun file =D
                if (configStrings.ContainsKey(firstRunString))
                {
                    return Convert.ToBoolean(configStrings[firstRunString]);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                //Otherwise return true for that it -is- a first run because the file does not exist
                return true;
            }
        }

        public string GetPortName()
        {
            return configStrings[comPortString];
        }

        public void firstTimeRunSetup(WATRDatabase db)
        {
            //Sets the program for first time use - we need the DB passed to this to add new tables, etc... to the DB

            //Create a first run dialog form and show it
            configForm = new WATRConfigurationForm();
            configForm.ShowDialog();

            //Get the com port that the user chose and write it to our dictionary
            configStrings.Add(comPortString, configForm.SelectedComPort);

            //Get rid of our form - we're done!
            configForm.Dispose();

            //Create DB using the function I made and make note that it's there
            db.FirstRunCreateTables();
            configStrings.Add(dbCreationString, true.ToString());

            //At this point, the setup is successful - go ahead and set that in our dictionary
            configStrings.Add(firstRunString, false.ToString());

            //And generate the configuration file to finish it.
            writeConfigFile();
        }

        private void readConfigFile()
        {
            //Create a File Stream, opening the file; Buffer it through a stream; then push it to a reader
            using (FileStream fs = new FileStream(configFilePath, FileMode.Open))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader reader = new StreamReader(bs))
            {
                //Do until we get to the end of the stream
                while (!reader.EndOfStream)
                {
                    //Read each line, parse each line and add it to the dictionary so we don't have to open this file again
                    //Unless changes occur to specific items
                    string line = reader.ReadLine();
                    string configKey = line.Substring(0, line.IndexOf('='));
                    string configValue = line.Substring(line.IndexOf('=') + 1, line.Length - 1 - line.IndexOf('='));
                    configStrings.Add(configKey, configValue);
                }
            }
        }

        private void writeConfigFile()
        {
            using (FileStream fs = new FileStream(configFilePath, FileMode.Create))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter writer = new StreamWriter(bs))
            {
                foreach (string key in configStrings.Keys)
                {
                    writer.WriteLine(key + "=" + configStrings[key]);
                }
            }
        }
    }
}
