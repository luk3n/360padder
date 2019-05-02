using System.Drawing;
using System.Windows.Forms;

namespace Controls
{
    public class BlueButton : Button
    {
        private static Font _normalFont = new Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        private static Color _foreColor = System.Drawing.Color.White;
        private static Color _backColor = System.Drawing.Color.FromArgb(255, 0, 66, 86);
        private static Color _backColorHover = System.Drawing.Color.FromArgb(255, 0, 78, 100);
        private static Color _backColorClicked = System.Drawing.Color.FromArgb(255, 42, 52, 47);

        private static Padding _margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
        private static Padding _padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
        private static Size _minSize = new System.Drawing.Size(100, 30);

        private bool _active;

        public BlueButton()
            : base()
        {
            base.Font = _normalFont;
            base.BackColor = _backColor;
            base.ForeColor = _foreColor;
            base.FlatAppearance.BorderColor = _backColor;
            base.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            base.FlatAppearance.MouseOverBackColor = _backColorHover;
            base.FlatAppearance.MouseDownBackColor = _backColorClicked;
            base.Margin = _margin;
            base.Padding = _padding;
            base.MinimumSize = _minSize;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            UseVisualStyleBackColor = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!_active)
            {
                base.FlatAppearance.BorderColor = _backColorClicked;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!_active)
            {
                base.FlatAppearance.BorderColor = _backColorHover;
            }
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!_active)
            {
                base.FlatAppearance.BorderColor = _backColorHover;
            }
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!_active)
            {
                base.FlatAppearance.BorderColor = _backColor;
            }
        }

        public void SetStateActive()
        {
            _active = true;
        }

        public void SetStateNormal()
        {
            _active = false;
        }
    }
}
