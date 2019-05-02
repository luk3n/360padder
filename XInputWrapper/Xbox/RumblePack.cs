using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XInputWrapper.Xbox
{
    public class RumblePack
    {
        int _playerIndex;
        bool _stopMotorTimerActive;
        DateTime _stopMotorTime;

        public RumblePack(int playerIndex)
        {
            _playerIndex = playerIndex;
        }

        public void Update()
        {
            if (_stopMotorTimerActive && (DateTime.Now >= _stopMotorTime))
            {
                XInputVibration stopStrength = new XInputVibration() { LeftMotorSpeed = 0, RightMotorSpeed = 0 };
                XInput.XInputSetState(_playerIndex, ref stopStrength);
            }
        }

        public void Vibrate(double leftMotor, double rightMotor)
        {
            Vibrate(leftMotor, rightMotor, TimeSpan.MinValue);
        }

        public void Vibrate(double leftMotor, double rightMotor, TimeSpan length)
        {
            leftMotor = Math.Max(0d, Math.Min(1d, leftMotor));
            rightMotor = Math.Max(0d, Math.Min(1d, rightMotor));

            XInputVibration vibration = new XInputVibration() { LeftMotorSpeed = (ushort)(65535d * leftMotor), RightMotorSpeed = (ushort)(65535d * rightMotor) };
            Vibrate(vibration, length);
        }


        public void Vibrate(XInputVibration strength)
        {
            _stopMotorTimerActive = false;
            XInput.XInputSetState(_playerIndex, ref strength);
        }

        public void Vibrate(XInputVibration strength, TimeSpan length)
        {
            XInput.XInputSetState(_playerIndex, ref strength);
            if (length != TimeSpan.MinValue)
            {
                _stopMotorTime = DateTime.Now.Add(length);
                _stopMotorTimerActive = true;
            }
        }
    }
}
