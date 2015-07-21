using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace watr_gui_v2
{
    public class WATR_Database
    {
        //Constant strings
        const string dbFilePath = "Data Source='.\\sensordb.db'";       //Where the db file is going to be located

        //SQLite3 connection class
        SQLiteConnection dbConnection;

        //Properties
        private bool inOperation { get; set; }

        //Default constructor
        public WATR_Database()
        {
            dbConnection = new SQLiteConnection(dbFilePath);
            
            //Open the DB IMMEDIATELY OR BAD THINGS HAPPEN Q_Q
            OpenSQLConnection();
        }

        //Open the SQL db connection
        public bool OpenSQLConnection()
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //Close the SQL Db connection
        public bool CloseSQLConnection()
        {
            if (dbConnection.State == ConnectionState.Open)
            {
                dbConnection.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Execute a write sql query through raw sql
        public void executeRawSQL(string sqlStatement)
        {
            //Make sure we have a valid connection before attempting to write to the DB
            if (dbConnection.State == ConnectionState.Open)
            {
                //Create the command + execute it
                SQLiteCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = sqlStatement;
                cmd.ExecuteNonQuery();
            }
        }

        //Use to read general records from the sql
        public DataTable executeRawRetrieveSQL(string sqlStatement)
        {
            //We need an adapter to adapt data into the c# dataTable class
            SQLiteDataAdapter adapter;

            //And we need an actual data table
            DataTable tableHolder = new DataTable();

            //Make sure the DB is open before we try any shit here
            if (dbConnection.State == ConnectionState.Open)
            {

                //Create a command
                SQLiteCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = sqlStatement;

                //Create the adapter and execute the query
                adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(tableHolder);
            }

            //Return the table
            return tableHolder;
        }

        //Used to log outgoing / incoming packets from the computer
        public void LogTransmitPacket(byte[] array)
        {
            string cmd = "INSERT INTO TransmitRecord_T VALUES ( datetime('now'),'" + array.ToHexInASCII() + "');";
            executeRawSQL(cmd);
        }

        public void LogReceivePacket(byte[] array)
        {
            string cmd = "INSERT INTO ReceiveRecord_T VALUES ( datetime('now'),'" + array.ToHexInASCII() + "');";
            executeRawSQL(cmd);
        }

        public void LogSensorRecord(WATR_SensorRecord record)
        {
            string cmd = "INSERT INTO SensorInfo_T VALUES (" + record.SourceAddress.ToString() + "," + record.Temperature.ToString() + ","
                + record.Humidity.ToString() + "," + record.MoistureLevel.ToString() + "," + record.BatteryLevel.ToString() + ","
                + "'" +record.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            executeRawSQL(cmd);
        }

        public DataTable GetSensorLog(ulong sensorID)
        {
            string cmd = "SELECT RowID as 'Record Number', XbeeSerialNumber as 'Device', RecordDate as 'Timestamp',"
                + "Temperature as 'Temperature', Humidity as 'Humidity', Moisture as 'Moisture Level', Battery as 'Battery Level' FROM SensorInfo_T"
                + " WHERE XbeeSerialNumber = " + sensorID.ToString() + ";";

            return executeRawRetrieveSQL(cmd);
        }
    }
}
