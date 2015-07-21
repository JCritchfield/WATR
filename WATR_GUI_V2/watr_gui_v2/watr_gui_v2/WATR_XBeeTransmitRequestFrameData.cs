using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public class WATR_XBeeTransmitRequestFrameData : WATR_IXBeeTxFrameData
    {
        //Properties
        public ulong DestinationAddress { get; private set; }
        public byte[] RFData { get; private set; }
        public byte FrameID { get; private set; }

        //Constructor
        public WATR_XBeeTransmitRequestFrameData(ulong destination, byte[] rfData)
        {
            //Set the destination address to the one supplied
            DestinationAddress = destination;

            //Set the RF data to the one supplied
            RFData = rfData;

            //Get a frameID
            FrameID = Convert.ToByte(WATR_XBeeFrameIDTransmitTracker.GetFrameIDNumber());
        }

        public byte[] PackageForTransmission()
        {
            //Cheating by using a list
            List<byte> holder = new List<byte>();

            //Add the frame type
            holder.Add(0x10);

            //Add the frame ID
            holder.Add(FrameID);

            //Add the destination address
            holder.AddRange(DestinationAddress.ToByteArray());

            //Add the Network Addy (CONSTANT 0xFFFE)
            holder.Add(0xFF);
            holder.Add(0xFE);

            //add the broadcast radius (CONST MAX HOPS = 0)
            holder.Add(0x00);

            //Options byte MUST BE SET TO 0
            holder.Add(0x00);

            //Add the rf data to the packet
            holder.AddRange(RFData);

            //Return the list as an array =)
            return holder.ToArray();
        }
    }
}
