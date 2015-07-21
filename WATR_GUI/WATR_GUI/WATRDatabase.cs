using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace WATR_GUI
{
    public class WATRDatabase
    {
        //Constants
        const string dbFilePath = "Data Source='.\\localData.db'";
        const string tableRawSQLFile = ".\\sql\\createTables.sql";
        
        SQLiteConnection dbConnection;

        //Basic constructor; not going to make anything different for now
        public WATRDatabase()
        {
            dbConnection = new SQLiteConnection(dbFilePath);
        }

        //Executes raw SQL data, such as SELECT * FROM BLAH BLAH, etc.
        private void executeRawSQL(string sqlStatement)
        {
            //Open the DB Connection
            dbConnection.Open();
            
            //Create the command, execute it
            SQLiteCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = sqlStatement;
            cmd.ExecuteNonQuery();

            //Close the connection
            dbConnection.Close();
        }

        //Used to retrieve records from a data table
        private DataTable executeRawRetrieveSQL(string sqlStatement)
        {
            SQLiteDataAdapter adapter;
            DataTable tableHolder = new DataTable();

            dbConnection.Open();
            SQLiteCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = sqlStatement;
            adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(tableHolder);

            return tableHolder;
        }

        //Only to be ran on a first-run!
        public void FirstRunCreateTables()
        {
            string rawCmdCreateTables = File.ReadAllText(tableRawSQLFile);
            executeRawSQL(rawCmdCreateTables);
        }

        //--- QUERIES INTO DATABASE ---
        // These are not finished - there are a -lot- of queries that need to be made. For the sake of not losing my mind,
        // I decided to end here with just these few - I need to be able to test it, first.

        //Query to add a sensor reading record
        public void InsertSensorRecord(WATRSensorRecord record)
        {
            string query = "INSERT INTO SensorReadings_T VALUES (" +  record.XBeeSerialNumber.ToString() + ", '" + record.TimeStamp.ToString() +
                "'," + record.HumidityLevel.ToString() + "," + record.TemperatureLevel.ToString() + "," + record.MoistureLevel + "," + record.BatteryLevel.ToString() + ");";

            executeRawSQL(query);
        }


        //Query the table to get a DataTable of a single devices entire record history ordered by date
        public DataTable RetrieveRecordsFromSingleDevice(WATRXbeeSerialNumber XBeeSN)
        {
            string sqlQuery = "SELECT * FROM SensorReadings_T WHERE deviceSN = " + XBeeSN.FullSerialNumber.ToString() + " ORDER BY readingDate;";

            return executeRawRetrieveSQL(sqlQuery);
        }


        //Return ALL records, period - oredered by ROWID
        public DataTable RetrieveAllRecords()
        {
            string sqlQuery = "SELECT * FROM SensorReadings_T ORDER BY ROWID;";

            return executeRawRetrieveSQL(sqlQuery);
        }

        //Get the most recent record from a device
        /* There is no need EVER for this function - after doing some mathematical analysis and diagramming, this should never be needed.
         * If a form, for some reason, ever gets out of sync, it will refresh and be provided a fresh WATRSensorRecord piece of data.
         * public WATRSensorRecord RetrieveMostCurrentRecord(double XBeeSN)
        {
            string sqlQuery = "SELECT * FROM + SensorReadings_T ORDER BY sensorReadingID DESC LIMIT 1";

            DataTable table = executeRawRetrieveSQL(sqlQuery);

            return new WATRSensorRecord(Convert.ToDouble(table.Columns["deviceSN"]), Convert.ToDateTime(table.Columns["readingDate"]), Convert.ToInt32(table.Columns["humidityLevel"]), Convert.ToDouble(table.Columns["temperatureLevel"]),
                Convert.ToInt32(table.Columns["moistureLevel"]), Convert.ToInt32(table.Columns["batteryLevel"]));
        }*/

        //--- END QUERIES INTO DATA BASE ---
    }
}
