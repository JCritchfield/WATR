using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATR_GUI
{
    public static class WATRXbeeReceivePacketTypes
    {
        public const byte LocalATCmdResponse = 0x88;
        public const byte TransmitStatus = 0x8B;
        public const byte ReceivePacket = 0x90;
        public const byte RemoteCommandResponse = 0x97;
    }
}
