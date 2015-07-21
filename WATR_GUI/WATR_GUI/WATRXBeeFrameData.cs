using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATR_GUI
{
    //Base class for any frame data - it contains the basis of everything
    public abstract class WATRXBeeFrameData
    {
        //Some basic properties that we can define here
        public byte frameType { get; protected set; }
        public byte frameID { get; protected set; }
        public byte checkSum { get; protected set; }
        public bool IsValid { get; protected set; }

        //List passed from our interpreter
        public List<byte> frameData;

        public WATRXBeeFrameData()
        {
            //Instantiate the frame data; that's all we'll do in this class
            frameData = new List<byte>();
        }
    }
}
