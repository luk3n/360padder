using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XInputWrapper.Xbox
{
    public class Battery
    {
        int _playerIndex;
        XInputBatteryInformation _batteryInformationGamepadPrev = new XInputBatteryInformation();
        XInputBatteryInformation _batteryInformationGamepadCurrent = new XInputBatteryInformation();
        XInputBatteryInformation _batterInformationHeadset;
        public event EventHandler<XboxControllerBatteryLevelChangedEventArgs> BatteryLevelChanged = null;

        public Battery(int playerIndex)
        {
            _playerIndex = playerIndex;
            _batteryInformationGamepadPrev.Copy(_batteryInformationGamepadCurrent);
        }

        public XInputBatteryInformation BatteryInformationGamepad
        {
            get { return _batteryInformationGamepadCurrent; }
            internal set { _batteryInformationGamepadCurrent = value; }
        }

        public XInputBatteryInformation BatteryInformationHeadset
        {
            get { return _batterInformationHeadset; }
            internal set { _batterInformationHeadset = value; }
        }

        public void UpdateBatteryState()
        {
            XInputBatteryInformation headset = new XInputBatteryInformation(),
            gamepad = new XInputBatteryInformation();

            XInput.XInputGetBatteryInformation(_playerIndex, (byte)BatteryDeviceType.BATTERY_DEVTYPE_GAMEPAD, ref gamepad);
            XInput.XInputGetBatteryInformation(_playerIndex, (byte)BatteryDeviceType.BATTERY_DEVTYPE_HEADSET, ref headset);

            BatteryInformationHeadset = headset;
            BatteryInformationGamepad = gamepad;

            if (_batteryInformationGamepadCurrent.BatteryLevel != _batteryInformationGamepadPrev.BatteryLevel)
            {
                OnBatteryLevelChanged();
            }
            _batteryInformationGamepadPrev.Copy(_batteryInformationGamepadCurrent);
        }

        protected void OnBatteryLevelChanged()
        {
            if (BatteryLevelChanged != null)
            {
                BatteryLevelChanged(this, new XboxControllerBatteryLevelChangedEventArgs() { BatteryInformation = _batteryInformationGamepadCurrent });
            }
        }
    }
}
