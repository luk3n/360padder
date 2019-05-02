using System;
using System.Threading;
using System.Windows.Forms;

namespace XInputWrapper.Xbox
{
    public class XboxController
    {
        int _playerIndex;
        static bool keepRunning;
        static int updateFrequency;
        static int waitTime;
        static bool isRunning;
        static object SyncLock;
        static Thread pollingThread;
        static bool lastStatus = false;
        static bool enabled = true;
        Buttons botones;
        DPad dpad;
        public RumblePack RumblePack { get; }
        Battery battery;
       
        //XInputCapabilities _capabilities;

        XInputState gamepadStatePrev = new XInputState();
        XInputState gamepadStateCurrent = new XInputState();

        public static int UpdateFrequency
        {
            get { return updateFrequency; }
            set
            {
                updateFrequency = value;
                waitTime = 1000 / updateFrequency;
            }
        }

        public const int MAX_CONTROLLER_COUNT = 4;
        public const int FIRST_CONTROLLER_INDEX = 0;
        public const int LAST_CONTROLLER_INDEX = MAX_CONTROLLER_COUNT - 1;

        static XboxController[] Controllers;

        static XboxController()
        {
            Controllers = new XboxController[MAX_CONTROLLER_COUNT];
            SyncLock = new object();
            for (int i = FIRST_CONTROLLER_INDEX; i <= LAST_CONTROLLER_INDEX; ++i)
            {
                Controllers[i] = new XboxController(i);
            }
            UpdateFrequency = 25;
        }

        // Crear evento similar pero para conexion y desconexion!
        public event EventHandler<XboxControllerStateChangedEventArgs> StateChanged = null;
        public event EventHandler<XboxControllerBatteryLevelChangedEventArgs> BatteryLevelChanged = null;
        public event EventHandler<XboxControllerConnectedEventArgs> Connected = null;
        public event EventHandler<XboxControllerDisconnectedEventArgs> Disconnected = null;
        public event EventHandler<XboxControllerKeyUpChangedEventArgs> KeyUp = null;
        public event EventHandler<XboxControllerKeyDownChangedEventArgs> KeyDown = null;

        public static XboxController RetrieveController(int index)
        {
            return Controllers[index];
        }

        private XboxController(int playerIndex)
        {
            _playerIndex = playerIndex;
            botones = new Buttons();
            dpad = new DPad();
            RumblePack = new RumblePack(_playerIndex);
            battery = new Battery(_playerIndex);
            battery.BatteryLevelChanged += Battery_BatteryLevelChanged;

            gamepadStatePrev.Copy(gamepadStateCurrent);
            
        }

        private void Battery_BatteryLevelChanged(object sender, XboxControllerBatteryLevelChangedEventArgs e)
        {
            OnBatteryLevelChanged(e);
        }

        protected void OnBatteryLevelChanged(XboxControllerBatteryLevelChangedEventArgs e)
        {
            if (BatteryLevelChanged != null)
            {
                BatteryLevelChanged(this, new XboxControllerBatteryLevelChangedEventArgs() { BatteryInformation = e.BatteryInformation });
            }
        }

        protected void OnKeyUp(Button button)
        {
            KeyUp?.Invoke(this, new XboxControllerKeyUpChangedEventArgs() { Button = button });
        }

        protected void OnKeyDown(Button button)
        {
            KeyDown?.Invoke(this, new XboxControllerKeyDownChangedEventArgs() { Button = button });
        }

        protected void OnStateChanged()
        {
            if (StateChanged != null)
                StateChanged(this, new XboxControllerStateChangedEventArgs() { CurrentInputState = gamepadStateCurrent, PreviousInputState = gamepadStatePrev });
        }

        

        public XInputCapabilities GetCapabilities()
        {
            XInputCapabilities capabilities = new XInputCapabilities();
            XInput.XInputGetCapabilities(_playerIndex, XInputConstants.XINPUT_FLAG_GAMEPAD, ref capabilities);
            return capabilities;
        }

        public void DisableController()
        {
            if (enabled)
            {
                XInput.XInputEnable(false);
                enabled = false;
            }
            else
            {
                XInput.XInputEnable(true);
                enabled = true;
            }
        }

        #region Digital Button States
        public bool IsDPadUpPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_DPAD_UP); }
        }

        public bool IsDPadDownPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_DPAD_DOWN); }
        }

        public bool IsDPadLeftPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_DPAD_LEFT); }
        }

        public bool IsDPadRightPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_DPAD_RIGHT); }
        }

        public bool IsAPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_A); }
        }

        public bool IsBPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_B); }
        }

        public bool IsXPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_X); }
        }

        public bool IsYPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_Y); }
        }


        public bool IsBackPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_BACK); }
        }


        public bool IsStartPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_START); }
        }


        public bool IsLeftShoulderPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_LEFT_SHOULDER); }
        }


        public bool IsRightShoulderPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_RIGHT_SHOULDER); }
        }

        public bool IsLeftStickPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_LEFT_THUMB); }
        }

        public bool IsRightStickPressed
        {
            get { return gamepadStateCurrent.Gamepad.IsButtonPressed((int)ButtonFlags.XINPUT_GAMEPAD_RIGHT_THUMB); }
        }
        #endregion

        #region Analogue Input States
        public int LeftTrigger
        {
            get { return (int)gamepadStateCurrent.Gamepad.bLeftTrigger; }
        }

        public int RightTrigger
        {
            get { return (int)gamepadStateCurrent.Gamepad.bRightTrigger; }
        }

        public Point LeftThumbStick
        {
            get
            {
                Point p = new Point()
                {
                    X = gamepadStateCurrent.Gamepad.sThumbLX,
                    Y = gamepadStateCurrent.Gamepad.sThumbLY
                };
                return p;
            }
        }

        public Point RightThumbStick
        {
            get
            {
                Point p = new Point()
                {
                    X = gamepadStateCurrent.Gamepad.sThumbRX,
                    Y = gamepadStateCurrent.Gamepad.sThumbRY
                };
                return p;
            }
        }

        #endregion

        bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            internal set { _isConnected = value; }
        }

        #region Polling
        public static void StartPolling()
        {
            if (!isRunning)
            {
                lock (SyncLock)
                {
                    if (!isRunning)
                    {
                        pollingThread = new Thread(PollerLoop);
                        pollingThread.Start();
                    }
                }
            }
        }

        public static void StopPolling()
        {
            if (isRunning)
                keepRunning = false;
        }

        static void PollerLoop()
        {
            lock (SyncLock)
            {
                if (isRunning == true)
                    return;
                isRunning = true;
            }
            keepRunning = true;
            while (keepRunning)
            {
                for (int i = FIRST_CONTROLLER_INDEX; i <= LAST_CONTROLLER_INDEX; ++i)
                {
                    Controllers[i].UpdateState();
                }
                Thread.Sleep(updateFrequency);
            }
            lock (SyncLock)
            {
                isRunning = false;
            }
        }

        public void UpdateState()
        {
            XInputCapabilities X = new XInputCapabilities();
            int result = XInput.XInputGetState(_playerIndex, ref gamepadStateCurrent);
            IsConnected = (result == 0);

            if (IsConnected)
            {
                if (Connected != null)
                {
                    if (!lastStatus)
                    {
                        Connected(this, new XboxControllerConnectedEventArgs());
                        lastStatus = true;
                    }
                }
            }
            else
            {
                if (Disconnected != null)
                {
                    if (lastStatus)
                    {
                        Disconnected(this, new XboxControllerDisconnectedEventArgs());
                        lastStatus = false;
                    }
                }
            }

            //UpdateBatteryState();
            if (gamepadStateCurrent.PacketNumber != gamepadStatePrev.PacketNumber)
            {
                OnStateChanged();


                // Poll buttons
                Poll(botones);

                // Poll DPad
                Poll(dpad);

                
            }
            gamepadStatePrev.Copy(gamepadStateCurrent);

            RumblePack.Update();
            battery.UpdateBatteryState();
        }
        #endregion

        private void Poll(IButtons control)
        {
            foreach (Button button in control.Update(gamepadStateCurrent))
            {
                switch (button.KeyState)
                {
                    case KeyState.Down:
                        OnKeyDown(button);
                        break;
                    case KeyState.Up:
                        OnKeyUp(button);
                        break;
                }
            }
        }

        public override string ToString()
        {
            return _playerIndex.ToString();
        }
    }
}
