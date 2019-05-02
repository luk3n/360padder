using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XInputWrapper.Xbox
{
    public class XboxControllerBatteryLevelChangedEventArgs : EventArgs
    {
        public XInputBatteryInformation BatteryInformation { get; set; }
    }
}
