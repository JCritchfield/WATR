using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_CustomPacketHandler
    {
        //private ints for locations of our custom packet
        int customPacketIndicatorStart = 0;
        int customPacketTypeStart = 2;
        int customPacketDataStart = 3;

        //Events
        public event EventHandler<WATR_SensorRecordGetArgs> SensorRecordGet;
        public event EventHandler<WATR_GeolocationInformationGetArgs> GeolocationInfoGet;

        public WATR_CustomPacketHandler()
        {
            //Do nothing for now.......
        }

        //Things to note:
        //I am making a "custom" packet type for this shit.
        //Basically, it will look like this:
        // [0x13] [0x37] are the start bits
        // Next we have a number for the packet type
        // 1 = temperature response
        // 2 = geolocation response
        // For a 1 (which is all we're implementing at the moment)
        // We will have a T, followed by a number then "t", an H, followed by a number then "h"
        // an M, followed by a number then "m", and then a B followed by a number and "b",
        // then an E.
        // The T is temperature
        // The H is humidity
        // The M is moisture
        // The B is battery level
        // The E means it's the end of the packet
        public void ParseReceiveFrameData(WATR_XBeeReceivePacketFrameData data)
        {
            //Check the first two bytes; make sure they are 0x13 0x37, and that the last byte is E
            if (data.ReceiveData[customPacketIndicatorStart] == 0x13 && data.ReceiveData[customPacketIndicatorStart + 1] == 0x37 && data.ReceiveData[data.ReceiveData.Length - 1] == 'E')
            {
                //See what kind of packet type it is
                switch (data.ReceiveData[customPacketTypeStart])
                {
                    case 0x01:
                        {
                            parseRFDataTemperatureRecord(data.SourceAddress, data.ReceiveData);
                            break;
                        }
                    default:
                        {
                            //Shit.. this shouldn't happen :c
                            break;
                        }
                }
            }
        }

        //Parse an incoming temperature record
        private void parseRFDataTemperatureRecord(ulong source, byte[] rf)
        {
            string rfData = rf.ConvertToString(customPacketDataStart);

            //Simple error check - the temp record should -NEVER- be less than 5 bytes. EVER.
            if (rfData.Length < 5)
                return;

            //Get the temperature
            //Math: The index of the first "T", add one so we don't include the T
            //Then, the length is the lower 't' position subtracting the upper-case T's location
            //So if we have "T".loc = 3 and "t".loc = 8
            //We start at position 3 + 1 = 4 for the first part of the temperature
            //Then copy until 8 - 3 = 5 - 1 = 4 (because of the fact that "T" is actually one more letter than we need)
            int temperature = Convert.ToInt32(rfData.Substring(rfData.IndexOf('T') + 1, rfData.IndexOf('t') - rfData.IndexOf('T') - 1));
            
            //The rest of the records follow the same logic
            int humidity = Convert.ToInt32(rfData.Substring(rfData.IndexOf('H') + 1, rfData.IndexOf('h') - rfData.IndexOf('H') - 1));
            int moisture = Convert.ToInt32(rfData.Substring(rfData.IndexOf('M') + 1, rfData.IndexOf('m') - rfData.IndexOf('M') - 1));
            int battery = Convert.ToInt32(rfData.Substring(rfData.IndexOf('B') + 1, rfData.IndexOf('b') - rfData.IndexOf('B') - 1));

            //Create a record
            WATR_SensorRecord record = new WATR_SensorRecord(source, temperature, humidity, moisture, battery);

            //Raise an event
            WATR_SensorRecordGetArgs getRecord = new WATR_SensorRecordGetArgs(record);
            if (getRecord != null)
                SensorRecordGet(this, getRecord);
        }

        //Generates a RFData packet byte for use to request it
        public byte[] generateSensorRecordRequest()
        {
            List<byte> temp = new List<byte>();
            
            //Add the two bytes that are the start bytes
            temp.Add(0x13);
            temp.Add(0x37);

            //Add the frame type
            temp.Add(0x01);

            //Add the 'E"
            temp.Add(Convert.ToByte('E'));

            //Return an array
            return temp.ToArray();
        }
    }
}
