using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watr_gui_v2
{
    public interface WATR_IXBeeTxFrameData
    {
        //This interface simply states that classes will implement solely one method:
        //The packageForTransmission will compose the entire frame data for transmission to hardware
        byte[] PackageForTransmission();
    }
}
