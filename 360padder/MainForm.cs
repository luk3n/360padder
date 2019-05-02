using System;
using System.Windows.Forms;
using XInputWrapper.Xbox;

namespace _360padder
{
    public partial class MainForm : Form
    {
        XboxController _selectedController;
        XboxController _selectedcontroller2;
        public MainForm()
        {
            InitializeComponent();
            _selectedController = XboxController.RetrieveController(0); //PlayerIndex.One /HACER ENUMS!!!!
            _selectedcontroller2 = XboxController.RetrieveController(1);
            _selectedController.StateChanged += _selectedController_StateChanged;
            _selectedController.BatteryLevelChanged += _selectedController_BatteryLevelChanged;
            _selectedController.Connected += _selectedController_Connected;
            _selectedController.Disconnected += _selectedController_Disconnected;
            _selectedController.KeyUp += _selectedController_KeyUp;
            _selectedController.KeyDown += _selectedController_KeyDown;
            _selectedcontroller2.KeyDown += _selectedController2_KeyDown;
            _selectedcontroller2.KeyUp += _selectedController2_KeyUp;
            XboxController.StartPolling();
        }

        private void _selectedController2_KeyUp(object sender, XboxControllerKeyUpChangedEventArgs e)
        {
            textBox1.Invoke(t => t.Text += string.Format("{0}CONTROLLER 2: {1} up!", Environment.NewLine, e.Button.BitMask));
            textBox1.Invoke(t => t.SelectionStart = t.TextLength);
            textBox1.Invoke(t => t.ScrollToCaret());
        }

        private void _selectedController2_KeyDown(object sender, XboxControllerKeyDownChangedEventArgs e)
        {
            textBox1.Invoke(t => t.Text += string.Format("{0}CONTROLLER 2: {1} down! {2}", Environment.NewLine, e.Button.BitMask, e.Button.KeyState));
            textBox1.Invoke(t => t.SelectionStart = t.TextLength);
            textBox1.Invoke(t => t.ScrollToCaret());

            //if (e.Button.BitMask == ButtonFlags.XINPUT_GAMEPAD_A)
            //{
            //    _selectedcontroller2.RumblePack.Vibrate(0, 10, new TimeSpan(633896886277130000));
            //}
        }

        private void _selectedController_KeyDown(object sender, XboxControllerKeyDownChangedEventArgs e)
        {
            textBox1.Invoke(t => t.Text += string.Format("{0}CONTROLLER 1: {1} down! {2}", Environment.NewLine, e.Button.BitMask, e.Button.KeyState));
            textBox1.Invoke(t => t.SelectionStart = t.TextLength);
            textBox1.Invoke(t => t.ScrollToCaret());
        }

        private void _selectedController_KeyUp(object sender, XboxControllerKeyUpChangedEventArgs e)
        {
            textBox1.Invoke(t => t.Text += string.Format("{0}CONTROLLER 1: {1} up!", Environment.NewLine, e.Button.BitMask));
            textBox1.Invoke(t => t.SelectionStart = t.TextLength);
            textBox1.Invoke(t => t.ScrollToCaret());
        }

        private void _selectedController_BatteryLevelChanged(object sender, XboxControllerBatteryLevelChangedEventArgs e)
        {
            switch ((BatteryLevel)e.BatteryInformation.BatteryLevel)
            {
                case BatteryLevel.BATTERY_LEVEL_EMPTY:
                    batteryMeter.Invoke(b => b.Width = 1);
                    break;
                case BatteryLevel.BATTERY_LEVEL_LOW:
                    batteryMeter.Invoke(b => b.Width = 100);
                    PrintToEventLog("Battery level: LOW");
                    break;
                case BatteryLevel.BATTERY_LEVEL_MEDIUM:
                    batteryMeter.Invoke(b => b.Width = 200);
                    PrintToEventLog("Battery level: MEDIUM");
                    break;
                case BatteryLevel.BATTERY_LEVEL_FULL:
                    batteryMeter.Invoke(b => b.Width = 300);
                    PrintToEventLog("Battery level: FULL");
                    break;
            }
        }

        private void _selectedController_Disconnected(object sender, XboxControllerDisconnectedEventArgs e)
        {
            PrintToEventLog("Controller disconnected.");
        }

        private void _selectedController_Connected(object sender, XboxControllerConnectedEventArgs e)
        {
            PrintToEventLog("Controller connected.");
        }

        private void _selectedController_StateChanged(object sender, XboxControllerStateChangedEventArgs e)
        {
            if (_selectedController.IsLeftShoulderPressed & _selectedController.IsRightShoulderPressed)
            {
                PrintToEventLog("Launching Steam (Big Picture Mode).");
                System.Diagnostics.Process.Start("steam://open/bigpicture");
            }

            //textBox1.Invoke(t => t.Text += string.Format("{0}{1}", Environment.NewLine, e.CurrentInputState.Gamepad.sThumbLX));
            //textBox1.Invoke(t => t.SelectionStart = t.TextLength);
            //textBox1.Invoke(t => t.ScrollToCaret());

            //if (_selectedController.IsAPressed)
            //    checkBox1.Invoke(c => c.Checked = true);
            //else
            //    checkBox1.Invoke(c => c.Checked = false);

            //if (_selectedController.IsYPressed)
            //    checkBox2.Invoke(c => c.Checked = true);
            //else
            //    checkBox2.Invoke(c => c.Checked = false);

            //if (_selectedController.IsXPressed)
            //    checkBox3.Invoke(c => c.Checked = true);
            //else
            //    checkBox3.Invoke(c => c.Checked = false);

            //if (_selectedController.IsBPressed)
            //    checkBox4.Invoke(c => c.Checked = true);
            //else
            //    checkBox4.Invoke(c => c.Checked = false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Disable_Click(object sender, EventArgs e)
        {
            _selectedController.DisableController();
        }

        private void PrintToEventLog(string message)
        {
            textBox1.Invoke(t => t.Text += string.Format("{0}{1}", Environment.NewLine, message));
            textBox1.Invoke(t => t.SelectionStart = t.TextLength);
            textBox1.Invoke(t => t.ScrollToCaret());
        }

        private void btn_Vibrate_Click(object sender, EventArgs e)
        {
            _selectedController.RumblePack.Vibrate(20, 0, new TimeSpan(0, 0, 0, 0, 300));
            System.Threading.Thread.Sleep(300);
            _selectedController.RumblePack.Vibrate(0, 20, new TimeSpan(0, 0, 0, 0, 300));
        }
    }
}
