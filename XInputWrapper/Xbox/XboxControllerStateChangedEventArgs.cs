using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XInputWrapper.Xbox
{
    public class XboxControllerStateChangedEventArgs : EventArgs
    {
        public XInputState CurrentInputState { get; set; }
        public XInputState PreviousInputState { get; set; }
        public Button boton { get; set; }
    }
}
