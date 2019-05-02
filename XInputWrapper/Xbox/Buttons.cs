using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XInputWrapper.Xbox
{
    public interface IButtons
    {
        IEnumerable<Button> Update(XInputState state);
    }

    public class Buttons : IButtons
    {
        ButtonCollection _buttons = new ButtonCollection(new Button[]
        {
            new Button(ButtonFlags.XINPUT_GAMEPAD_A),
            new Button(ButtonFlags.XINPUT_GAMEPAD_B),
            new Button(ButtonFlags.XINPUT_GAMEPAD_Y),
            new Button(ButtonFlags.XINPUT_GAMEPAD_X),
            new Button(ButtonFlags.XINPUT_GAMEPAD_LEFT_SHOULDER),
            new Button(ButtonFlags.XINPUT_GAMEPAD_RIGHT_SHOULDER),
            new Button(ButtonFlags.XINPUT_GAMEPAD_BACK),
            new Button(ButtonFlags.XINPUT_GAMEPAD_START),
            new Button(ButtonFlags.XINPUT_GAMEPAD_LEFT_THUMB),
            new Button(ButtonFlags.XINPUT_GAMEPAD_RIGHT_THUMB),
            new Button(ButtonFlags.XINPUT_GAMEPAD_GUIDE)
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
