using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XInputWrapper.Xbox
{
    public class DPad : IButtons
    {
        ButtonCollection _buttons = new ButtonCollection(new Button[]
        {
            new Button(ButtonFlags.XINPUT_GAMEPAD_DPAD_UP),
            new Button(ButtonFlags.XINPUT_GAMEPAD_DPAD_RIGHT),
            new Button(ButtonFlags.XINPUT_GAMEPAD_DPAD_DOWN),
            new Button(ButtonFlags.XINPUT_GAMEPAD_DPAD_LEFT)
        });

        public IEnumerable<Button> Update(XInputState state)
        {
            foreach (Button button in _buttons)
            {
                if (((ButtonFlags)state.Gamepad.wButtons).HasFlag(button.BitMask))
                {
                    button.KeyState = KeyState.Down;
                }
                else if (button.KeyState == KeyState.Down)
                {
                    button.KeyState = KeyState.Up;
                }
                else
                {
                    button.KeyState = KeyState.None;
                }

                yield return button;
            }
        }
    }
}
