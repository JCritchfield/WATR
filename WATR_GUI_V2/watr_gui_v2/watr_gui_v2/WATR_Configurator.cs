using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace watr_gui_v2
{
    public class WATR_Configurator
    {
        //Either holds the values read from the conf file
        //or will contain the files to be written
        Dictionary<string, string> configurationFileStrings;

        //Const strings
        const string configFilePath = @".\config.ini";
        const string startupRawSql = @".\sql\firstrun.sql";
        const string firstRunString = "firstRun";
        //-------
        //Reasoning for commenting out comPortString:
        //Automatically search for it when the computer starts the program, that way any com port can be queried
        //const string comPortString = "comPort";
        //-------
        const string dbCreationString = "dbCreate";

        //Default constructor
        public WATR_Configurator()
        {
            //Instantiate objects
            configurationFileStrings = new Dictionary<string, string>();
        }

        //Checks to see if this is the program's first time runniong
        public bool isFirstRun()
        {
            if (File.Exists(configFilePath))
            {
                //Read the file
                readConfigFile();

                //Check the strings that the file read for a first run key
                if (configurationFileStrings.ContainsKey(firstRunString))
                {
                    //Return the key's value
                    return Convert.ToBoolean(configurationFileStrings[firstRunString]);
                }
                else
                {
                    //Otherwise, if it's not in the ini file, it's a first run or incomplete setup
                    return true;
                }
            }
            else
            {
                //We have to return true at this point - the file does not exist
                return true;
            }
        }

        //This is used for a first-time setup
        //We need to pass the DB so that we have access to it's functions
        public void firstRunSetup(WATR_Database db)
        {
            //Draw a configuration form for the user to fill out
            //configForm = new WATR_ConfigurationForm();
            //configForm.Show();

            //Retrieve com port from the form that was made
            //configurattionFIleStrings.add(comPortString, configForm.SelectedComPort);

            //Dispose of the form
            //configForm.dispose();

            //Create the DB file
            db.executeRawSQL(File.ReadAllText(startupRawSql));
            configurationFileStrings.Add(dbCreationString, true.ToString());

            //Our setup is now complete; the user can now begin using the program
            configurationFileStrings.Add(firstRunString, false.ToString());

            //Generate the configuration file
            writeConfigFile();
        }


        //Reads the configuration file
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
                    configurationFileStrings.Add(configKey, configValue);
                }
            }
        }

        //Used when making a configuration file for a first time setup
        private void writeConfigFile()
        {
            //Necessary file streams
            using (FileStream fs = new FileStream(configFilePath, FileMode.Create))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter writer = new StreamWriter(bs))
            {
                foreach (string key in configurationFileStrings.Keys)
                {
                    //Write each string
                    writer.WriteLine(key + "=" + configurationFileStrings[key]);
                }
            }
        }
    }
}
