using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATR_GUI
{
    public static class WATRXBeeTransmitPacketTypes
    {
        public const byte TransmitRequest = 0x10;
        public const byte LocalATCommand = 0x08;
        public const byte RemoteCommandRequest = 0x17;
    }
}
