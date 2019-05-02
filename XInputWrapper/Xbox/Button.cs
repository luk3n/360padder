using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XInputWrapper.Xbox
{
    public sealed class Button
    {
        public ButtonFlags BitMask { get; private set; }
        public KeyState KeyState { get; internal set; }

        public Button(ButtonFlags bitMask)
        {
            BitMask = bitMask;
        }
    }

    public enum KeyState
    {
        None,
        Up,
        Down
    }
}
