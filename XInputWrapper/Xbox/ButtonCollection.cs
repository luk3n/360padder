using System;
using System.Collections;
using System.Collections.Generic;

namespace XInputWrapper.Xbox
{
    public class ButtonCollection : IEnumerable<Button>
    {
        private Button[] _buttons;

        public ButtonCollection(Button[] buttons)
        {
            _buttons = buttons;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(_buttons);
        }

        public IEnumerator<Button> GetEnumerator()
        {
            return new Enumerator(_buttons);
        }
    }

    public class Enumerator : IEnumerator<Button>
    {
        private Button[] _buttons;
        private int Cursor;

        public Enumerator(Button[] buttons)
        {
            this._buttons = buttons;
            Cursor = -1;
        }

        void IEnumerator.Reset()
        {
            Cursor = -1;
        }

        bool IEnumerator.MoveNext()
        {
            if (Cursor < _buttons.Length)
                Cursor++;

            return (!(Cursor == _buttons.Length));
        }

        public Button Current
        {
            get
            {
                if ((Cursor < 0) || (Cursor == _buttons.Length))
                    throw new InvalidOperationException();

                return _buttons[Cursor];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if ((Cursor < 0) || (Cursor == _buttons.Length))
                    throw new InvalidOperationException();

                return _buttons[Cursor];
            }
        }

        public void Dispose() { }
    }
}
