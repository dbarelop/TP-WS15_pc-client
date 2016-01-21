using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace pc_client
{
    public partial class MainForm : Form
    {
        ///////////////////////////////////////////////////////////////////////
        #region Variables

        ComWrapper _comWrapper = null;
        Dispatcher _dispatcher = null;
        Helper _helper = null;
        ErrorMessageBoxes _error = null;
        Settings _settings = null;
        Data _data = null;
        int _waitCounter = 1;
        char _lastSendCommand;

        List<string> _commandHistory = new List<string>();

        System.Windows.Threading.Dispatcher _windowDispatcher;
        Form _receiverForm = null;
        Object _lockObject = new Object();
        

        delegate void NewDataReceivedDelegate(object sender, byte[] data);

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region Initialization

        public MainForm()
        {
            _comWrapper = new ComWrapper();
            _dispatcher = new Dispatcher(this, _comWrapper);
            _data = Data.GetInstance;
            _helper = new Helper();
            _settings = Settings.GetInstance;
            _error = new ErrorMessageBoxes();
            _windowDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            _receiverForm = this;

            InitializeComponent();
            InitializeControlValues();
            EnableControls();
            InitializePortTimer();
            RegisterEventHandlers(true);
        }


        public void InitializeControlValues()
        {
            cmbParity.Items.Clear();
            cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbStopBits.Items.Clear();
            cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));
            cmbParity.Text = Properties.Settings.Default.Parity;
            cmbStopBits.Text = Properties.Settings.Default.StopBits;
            cmbDataBits.Text = Properties.Settings.Default.DataBits;
            cmbBaudRate.Text = Properties.Settings.Default.BaudRate;
            chkDTR.Checked = Properties.Settings.Default.DTR;
            chkRTS.Checked = Properties.Settings.Default.RTS;
            cmbPortName.Text = Properties.Settings.Default.Port;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region EventHandlers

        private void RegisterEventHandlers(bool register)
        {
            if (register)
            {
                _dispatcher.NewHardwareDataReceivedEvent += new Dispatcher.NewHardwareDataReceivedEventHandler(Dispatcher_NewHardwareDataReceivedEvent);
                _dispatcher.NewTemperatureDataReceivedEvent += new Dispatcher.NewTemperatureDataReceivedEventHandler(Dispatcher_NewTemperatureDataReceivedEvent);
                _dispatcher.NewADChannel1DataReceivedEvent += new Dispatcher.NewADChannel1DataReceivedEventHandler(Dispatcher_NewADChannel1DataReceivedEvent);
                _dispatcher.NewHardwareDataReceivedEvent += new Dispatcher.NewHardwareDataReceivedEventHandler(Dispatcher_NewHardwareDataReceivedEvent);
                _dispatcher.NewADChannel2DataReceivedEvent += new Dispatcher.NewADChannel2DataReceivedEventHandler(Dispatcher_NewADChannel2DataReceivedEvent);
                _dispatcher.NewErrorReceivedEvent += new Dispatcher.NewErrorReceivedEventHandler(Dispatcher_NewErrorReceivedEvent);
                _dispatcher.NewEpromDataReceivedEvent += new Dispatcher.NewEpromDataReceivedEventHandler(Dispatcher_NewEpromDataReceivedEvent);
                _dispatcher.NewTerminalDataReceivedEvent += new Dispatcher.NewTerminalDataReceivedEventHandler(Dispatcher_NewTerminalDataReceivedEvent);
                _dispatcher.NewVoidDataReceivedEvent += new Dispatcher.NewVoidDataReceivedEventHandler(Dispatcher_NewVoidDataReceivedEvent);
                _dispatcher.NewLogOutputDataReceivedEvent += new Dispatcher.NewLogOutputDataReceivedEventHandler(Dispatcher_NewLogOutputDataReceivedEvent);
                _dispatcher.NewLogInputDataReceivedEvent += new Dispatcher.NewLogInputDataReceivedEventHandler(Dispatcher_NewLogInputDataReceivedEvent);
            }
            else
            {
                _dispatcher.NewHardwareDataReceivedEvent -= new Dispatcher.NewHardwareDataReceivedEventHandler(Dispatcher_NewHardwareDataReceivedEvent);
                _dispatcher.NewTemperatureDataReceivedEvent -= new Dispatcher.NewTemperatureDataReceivedEventHandler(Dispatcher_NewTemperatureDataReceivedEvent);
                _dispatcher.NewADChannel1DataReceivedEvent -= new Dispatcher.NewADChannel1DataReceivedEventHandler(Dispatcher_NewADChannel1DataReceivedEvent);
                _dispatcher.NewHardwareDataReceivedEvent -= new Dispatcher.NewHardwareDataReceivedEventHandler(Dispatcher_NewHardwareDataReceivedEvent);
                _dispatcher.NewADChannel2DataReceivedEvent -= new Dispatcher.NewADChannel2DataReceivedEventHandler(Dispatcher_NewADChannel2DataReceivedEvent);
                _dispatcher.NewErrorReceivedEvent -= new Dispatcher.NewErrorReceivedEventHandler(Dispatcher_NewErrorReceivedEvent);
                _dispatcher.NewEpromDataReceivedEvent -= new Dispatcher.NewEpromDataReceivedEventHandler(Dispatcher_NewEpromDataReceivedEvent);
                _dispatcher.NewTerminalDataReceivedEvent -= new Dispatcher.NewTerminalDataReceivedEventHandler(Dispatcher_NewTerminalDataReceivedEvent);
                _dispatcher.NewVoidDataReceivedEvent -= new Dispatcher.NewVoidDataReceivedEventHandler(Dispatcher_NewVoidDataReceivedEvent);
                _dispatcher.NewLogOutputDataReceivedEvent -= new Dispatcher.NewLogOutputDataReceivedEventHandler(Dispatcher_NewLogOutputDataReceivedEvent);
                _dispatcher.NewLogInputDataReceivedEvent -= new Dispatcher.NewLogInputDataReceivedEventHandler(Dispatcher_NewLogInputDataReceivedEvent);
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region Receivers

        void Dispatcher_NewHardwareDataReceivedEvent(object sender, byte[] value)
        {
            if(value != null)
            {
                tbHardware.Text = _helper.HexArrayToString(value);
                StopBGWTimer();
            }
        }


        void Dispatcher_NewTemperatureDataReceivedEvent(object sender, byte[] value)
        {
             if (value != null)
            {
                tbTemperatur.Text = _helper.HexArrayToString(value);
                StopBGWTimer();
            }
        }


        void Dispatcher_NewADChannel1DataReceivedEvent(object sender, byte[] value)
        {
            if (value != null)
            {
                tbADChannel1.Text = _helper.HexArrayToString(value);
                StopBGWTimer();
            }
        }


        void Dispatcher_NewADChannel2DataReceivedEvent(object sender, byte[] value)
        {
            if (value != null)
            {
                tbADChannel2.Text = _helper.HexArrayToString(value);
                StopBGWTimer();
            }
        }


        void Dispatcher_NewEpromDataReceivedEvent(object sender, byte[] value)
        {
            if (value != null)
            {
                rtfEprom.Text = _helper.HexArrayToString(value);
                StopBGWTimer();
            }
        }


        void Dispatcher_NewTerminalDataReceivedEvent(object sender, byte[] data)
        {
            StopBGWTimer();
            _data.AppendTerminalData(data);

            if (chkInputType.Checked == true)
            {
                rtfTerminalIn.Clear();

                rtfTerminalIn.AppendText(_helper.HexToString(_data.TerminalData[0]));
                for (int i = 1; i < _data.TerminalData.Length; i++)
                {
                    rtfTerminalIn.AppendText(":");
                    rtfTerminalIn.AppendText(_helper.HexToString(_data.TerminalData[i]));
                }
            }
            else
            {
                rtfTerminalIn.Text = System.Text.Encoding.Default.GetString(_data.TerminalData);
            }
        }


        void Dispatcher_NewErrorReceivedEvent(object sender, string text)
        {
            _error.SendingCommandError(text);
            StopBGWTimer();
        }


        void Dispatcher_NewLogInputDataReceivedEvent(object sender, byte[] value)
        {
            if (value != null)
            {
                logInput(value);
            }
        }


        void Dispatcher_NewLogOutputDataReceivedEvent(object sender, String value)
        {
            if (value != null)
            {
                logOutput(value);
            }
        }


        void Dispatcher_NewVoidDataReceivedEvent(object sender, byte[] value)
        {
            StopBGWTimer();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region SaveSettings

        public void SaveSettings()
        {
            _settings.PortName = cmbPortName.Text;
            _settings.Parity = cmbParity.Text;
            _settings.StopBits = cmbStopBits.Text;
            _settings.DataBits = cmbDataBits.Text;
            _settings.BaudRate = cmbBaudRate.Text;
            _settings.DTR = chkDTR.Checked;
            _settings.RTS = chkRTS.Checked;

            Properties.Settings.Default.Port = cmbPortName.Text;
            Properties.Settings.Default.BaudRate = cmbBaudRate.Text;
            Properties.Settings.Default.DataBits = cmbDataBits.Text;
            Properties.Settings.Default.Parity = cmbParity.Text;
            Properties.Settings.Default.StopBits = cmbStopBits.Text;
            Properties.Settings.Default.RTS = chkRTS.Checked;
            Properties.Settings.Default.DTR = chkDTR.Checked;

            Properties.Settings.Default.Save();
        }

        #endregion
                

        ///////////////////////////////////////////////////////////////////////
        #region ClosePort

        public void close_port()
        {
            _comWrapper.ComportDispose();
            _backgroundWorker.CancelAsync();
            _backgroundWorker.Dispose();
        }

        #endregion
        

        ///////////////////////////////////////////////////////////////////////
        #region OpenPort
        
        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            if (btnOpenPort.Text == "Open Port")
            {
                btnOpenPort.Text = "Close Port";
                btnConnect.Text = "Close";
                DisableSettingsControls();
                open_port();
            }
            else if (btnOpenPort.Text == "Close Port")
            {
                btnOpenPort.Text = "Open Port";
                btnConnect.Text = "Connect";
                EnableSettingsControls();
                close_port();
            }

            rtfTerminalOut.Focus();
        }
        

        public void open_port()
        {
            bool error = false;

            try
            {
                SaveSettings();

                // Open the port
                _comWrapper.ComportOpen();                    
            }

            catch (UnauthorizedAccessException) { error = true; }
            catch (IOException) { error = true; }
            catch (ArgumentException) { error = true; }

            if (error) 
            {
               MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

                DisableSettingsControls();

            // Change the state of the form's controls
            EnableControls();
        }

        #endregion
        

        ///////////////////////////////////////////////////////////////////////
        #region RefreshComportList

        private void RefreshComPortList()
        {
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, _comWrapper.ComportIsOpen());

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                cmbPortName.Items.Clear();
                cmbPortName.Items.AddRange(OrderedPortNames());
                cmbPortName.SelectedItem = selected;
            }
        }
        

        private string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;

            // Order the serial port names in numberic order (if possible)
            return _comWrapper.GetAvailablePorts().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }
        

        private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            string[] ports = _comWrapper.GetAvailablePorts();

            // First determain if there was a change (any additions or removals)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            // If there was a change, then select an appropriate default port
            if (updated)
            {
                // Use the correctly ordered set of port names
                ports = OrderedPortNames();

                // Find newest port if one or more were added
                string newest = _comWrapper.GetAvailablePorts().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                // If the port was already open... (see logic notes and reasoning in Notes.txt)
                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region BackgroundWorkers

        void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                List<object> genericlist = e.Argument as List<object>;
                _dispatcher.SendData((String)genericlist[0], (char)genericlist[1]);
                WaitForPendingRequest();
            }
            catch
            {
                _error.FatalError();
            }
        }


        private void _backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            DisableSettingsControls();
        }


        private void _backgroundWorkerADW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                List<object> genericlist = e.Argument as List<object>;

                _dispatcher.SendData(Commands.ID_VOID, (char)genericlist[0]);
                WaitForPendingRequest();
                _dispatcher.SendData((String)genericlist[1], (char)genericlist[2]);
                WaitForPendingRequest();
            }
            catch
            {
                _error.FatalError();
            }
        }


        private void _backgroundWorkerADW_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            DisableSettingsControls();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region Sending-Timer

        private void InitializeBGWTimer()
        {
            portTimer.Interval = 5000;
            portTimer.Enabled = true;
            this.portTimer.Tick += new System.EventHandler(this.bgwTimer_Tick);
        }


        private void StopBGWTimer()
        {
            bgwTimer.Stop();
            portTimer.Enabled = false;
            this.portTimer.Tick -= new System.EventHandler(this.bgwTimer_Tick);
        }


        private void bgwTimer_Tick(object sender, System.EventArgs e)
        {
            StopBGWTimer();
            _error.TimeOutError(_lastSendCommand);
            _backgroundWorker.CancelAsync();
            DisableSettingsControls();
            _dispatcher.SetRequestPendig(false);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region EnableSettingsControls

        public void EnableControls()
        {
            if (_comWrapper.ComportIsOpen())
            {
                DisableSettingsControls();
                btnOpenPort.Text = "Close Port";
            }
            else
            {
                EnableSettingsControls();
                btnOpenPort.Text = "Open Port";
            }
        }


        public void EnableSettingsControls()
        {
            chkDTR.Enabled = true;
            chkRTS.Enabled = true;
            cmbPortName.Enabled = true;
            cmbParity.Enabled = true;
            cmbBaudRate.Enabled = true;
            cmbStopBits.Enabled = true;
            cmbDataBits.Enabled = true;
            chkSimulation.Enabled = true;

            btnReadADC1.Enabled = false;
            btnReadADC2.Enabled = false;
            btnReadEprom.Enabled = false;
            btnReadTemperatur.Enabled = false;
            btnResetHardware.Enabled = false;
            btnWriteEprom.Enabled = false;
            chkPollTemp.Enabled = false;
            chkAD1.Enabled = false;
            chkAD2.Enabled = false;
            rbV1.Enabled = false;
            rbV2.Enabled = false;
            btnSend.Enabled = false;
        }


        public void DisableSettingsControls()
        {
            chkDTR.Enabled = false;
            chkRTS.Enabled = false;
            cmbPortName.Enabled = false;
            cmbParity.Enabled = false;
            cmbBaudRate.Enabled = false;
            cmbStopBits.Enabled = false;
            cmbDataBits.Enabled = false;

            btnReadADC1.Enabled = true;
            btnReadADC2.Enabled = true;
            btnReadEprom.Enabled = true;
            btnReadTemperatur.Enabled = true;
            btnResetHardware.Enabled = true;
            btnWriteEprom.Enabled = true;
            chkPollTemp.Enabled = true;
            chkAD1.Enabled = true;
            chkAD2.Enabled = true;
            rbV1.Enabled = true;
            rbV2.Enabled = true;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region Comport-Tab-InputEvents

        private void cmbPortName_DropDown(object sender, EventArgs e)
        {
            RefreshComPortList();
        }


        private void cmbBaudRate_DropDown(object sender, EventArgs e)
        {
            cmbBaudRate.Items.Clear();
            cmbBaudRate.Items.AddRange(_comWrapper.GetBaudRateRange());          
        }


        private void cmbDataBits_DropDown(object sender, EventArgs e)
        {
            cmbDataBits.Items.Clear();
            cmbDataBits.Items.AddRange(_comWrapper.GetDataBitsRange());   
        }
        

        private void OnMouseEntering(object sender, EventArgs e)
        {
            rtfTerminalOut.Focus();
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            TerminalSendData();
        }


        private void rtfTerminalOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                TerminalSendData();
            }
        }


        private void btnClearOut_Click(object sender, EventArgs e)
        {
            rtfTerminalOut.Clear();
            btnClearOut.Enabled = false;
        }


        private void btnClearIn_Click(object sender, EventArgs e)
        {
            rtfTerminalIn.Clear();
            btnClearIn.Enabled = false;
            _data.TerminalData = new byte[0];
        }


        private void chkInputType_CheckedChanged(object sender, EventArgs e)
        {
            if (_data.TerminalData.Length == 0)
            {
                return; // nothing to convert
            }

            rtfTerminalIn.Clear();

            if (chkInputType.Checked == true)
            {
                rtfTerminalIn.AppendText(_helper.HexToString(_data.TerminalData[0]));
                for (int i = 1; i < _data.TerminalData.Length; i++)
                {
                    rtfTerminalIn.AppendText(":");
                    rtfTerminalIn.AppendText(_helper.HexToString(_data.TerminalData[i]));
                }
            }
            else
            {
                rtfTerminalIn.AppendText(System.Text.Encoding.Default.GetString(_data.TerminalData));
            }
        }

        private void rtfTerminalOut_TextChanged(object sender, EventArgs e)
        {
            if (rtfTerminalOut.Text.Length > 0)
            {
                btnClearOut.Enabled = true;
            }

            if (rtfTerminalOut.Lines.Length == 0)
            {
                btnSend.Enabled = false;
                btnClearOut.Enabled = false;
                return; //nothing left to do
            }

            if (rtfTerminalOut.Lines[rtfTerminalOut.Lines.Length - 1].Length > 0)
            {
                btnSend.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
            }
        }


        private void rtfTerminalIn_TextChanged(object sender, EventArgs e)
        {
            if (rtfTerminalIn.Text.Length > 0)
            {
                btnClearIn.Enabled = true;
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegisterEventHandlers(false);
            SaveSettings();

            try
            {
                _comWrapper.ComportDispose();
            }
            catch (Exception)
            {
                ;//Program should be able to close
            }
        }


        private void btnLogClear_Click(object sender, EventArgs e)
        {
            if(rtfLog.Text.Length > 0)
            {
                rtfLog.Clear();
            }
        }


        private void rtfLog_TextChanged(object sender, EventArgs e)
        {
            if (rtfLog.Text.Length > 0)
            {
                btnLogClear.Enabled = true;
            }
            else
            {
                btnLogClear.Enabled = false;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region Main-Tab-InputEvents

        private void mainTabControl_Enter(object sender, EventArgs e)
        {
            btnConnect.Focus();
        }
               
        
        private void btnReadHardware_Click(object sender, EventArgs e)
        {
            if (!_backgroundWorker.IsBusy)
            {
                object identifier = Commands.ID_HARDWARE;
                object command = (char)(Commands.MASTER | Commands.READ);

                EnableSettingsControls();
                _lastSendCommand = (char)command;
                InitializeBGWTimer();
                _backgroundWorker.RunWorkerAsync(_helper.CreateObjectList(identifier, command));
            }
        }


        private void btnReadTemperatur_Click(object sender, EventArgs e)
        {
            if (!_backgroundWorker.IsBusy)
            {
                object identifier = Commands.ID_TEMPERATURE;
                object command = (char)(Commands.ADT | Commands.READ);

                EnableSettingsControls();
                _lastSendCommand = (char)command;
                InitializeBGWTimer();
                _backgroundWorker.RunWorkerAsync(_helper.CreateObjectList(identifier, command));
            }
        }


        private void btnReadADC1_Click(object sender, EventArgs e)
        {
            if (!_backgroundWorkerADW.IsBusy)
            {
                object identifier = Commands.ID_ADCHANNEL1;
                object channel = (char)(Commands.ADW | Commands.CH1);
                object command = (char)(Commands.ADW | Commands.READ);

                EnableSettingsControls();
                _backgroundWorkerADW.RunWorkerAsync(_helper.CreateObjectList(channel, identifier, command));
            }
        }


        private void btnReadADC2_Click(object sender, EventArgs e)
        {
            if (!_backgroundWorkerADW.IsBusy)
            {
                object identifier = Commands.ID_ADCHANNEL2;
                object channel = (char)(Commands.ADW | Commands.CH2);
                object command = (char)(Commands.ADW | Commands.READ);

                EnableSettingsControls();
                _backgroundWorkerADW.RunWorkerAsync(_helper.CreateObjectList(channel, identifier, command));
            }
        }


        private void rbV1_Click(object sender, EventArgs e)
        {
            if (!_backgroundWorker.IsBusy)
            {
                object identifier = Commands.ID_VOID;
                object command = (char)(Commands.ADW | Commands.RNG1);

                EnableSettingsControls();
                _backgroundWorker.RunWorkerAsync(_helper.CreateObjectList(identifier, command));
            }
        }


        private void rbV2_Click(object sender, EventArgs e)
        {
            if (!_backgroundWorker.IsBusy)
            {
                object identifier = Commands.ID_VOID;
                object command = (char)(Commands.ADW | Commands.RNG2);

                EnableSettingsControls();
                _backgroundWorker.RunWorkerAsync(_helper.CreateObjectList(identifier, command));
            }
        }


        private void btnReadEeprom_Click(object sender, EventArgs e)
        {
            if (!_backgroundWorker.IsBusy)
            {
                object identifier = Commands.ID_EEPROM;
                object command = (char)(Commands.EEPROM | Commands.READ);

                EnableSettingsControls();
                _backgroundWorker.RunWorkerAsync(_helper.CreateObjectList(identifier, command));
            }
        }


        private void btnWriteEprom_Click(object sender, EventArgs e)
        {
            if (!_backgroundWorker.IsBusy)
            {
                object identifier = Commands.ID_EEPROM;
                object command = (char)(Commands.EEPROM | Commands.READ);

                EnableSettingsControls();
                _backgroundWorker.RunWorkerAsync(_helper.CreateObjectList(identifier, command));
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region Synchronisation

        private bool WaitForPendingRequest()
        {
            while (_dispatcher.IsRequestPendig())
            {
                System.Threading.Thread.Sleep(10);
            }
            return true;
        }


        private bool EepromCompleted()
        {
            while (_dispatcher.EepromISBusy())
            {
                System.Threading.Thread.Sleep(10);
            }
            return true;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region TerminalSendData

        private void TerminalSendData()
        {
            String sendData = "";

            if (rtfTerminalOut.Lines.Length > 0)
            {
                sendData = rtfTerminalOut.Lines[rtfTerminalOut.Lines.Length - 1];
            }

            if (chkHex.Checked == true)
            {
                String subString = "";
                char data;
                for (int i = 0; i < sendData.Length; i += 2)
                {
                    try
                    {
                        subString = sendData.Substring(i, 2);
                       // logOutput(subString);
                        int intValue = int.Parse(subString, System.Globalization.NumberStyles.HexNumber);
                        data = (char)intValue;
                        _dispatcher.SendData(Commands.ID_TERMINAL, data);
                    }
                    catch
                    {
                        _error.HexConversionError();
                    }                    
                }
            }
            else
            {
                _dispatcher.SendData(Commands.ID_TERMINAL, sendData);
            } 
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region Logging

        private void logOutput(char output)
        {
            logOutput(output.ToString());
        }


        private void logOutput(byte[] output)
        {
            String logValue = System.Text.Encoding.Default.GetString(output);
            logOutput(logValue);
        }

        
        private void logOutput(String output)
        {
            Invoke(new MethodInvoker(delegate
            {
                rtfLog.AppendText("OUT:\t" + DateTime.Now.ToString("HH:mm:ss:ffff") + "\t" + output + "\n");
            }));
        }


        private void logInput(char input)
        {
            logInput(input.ToString());
        }


        private void logInput(byte[] input)
        {
            logInput(_helper.HexArrayToString(input));
        }


        private void logInput(String input)
        {
            Invoke(new MethodInvoker(delegate
            {
                rtfLog.AppendText("IN:\t" + DateTime.Now.ToString("HH:mm:ss:ffff") + "\t" + input + "\n");
            }));
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region PortStatus

        private void InitializePortTimer()
        {
            portTimer.Interval = 600;
            portTimer.Enabled = true;
            this.portTimer.Tick += new System.EventHandler(this.portTimer_Tick);
        }

        private void portTimer_Tick(object sender, System.EventArgs e)
        {
            bool portAvailable = false;
            string[] availablePortNames = SerialPort.GetPortNames();
            String portName = cmbPortName.Text;

            string waiting = "";

            for (int i = 0; i < availablePortNames.Length; i++)
            {
                if (portName == availablePortNames[i])
                {
                    portAvailable = true;
                }
            }

            for (int i = 0; i < _waitCounter; i++)
            {
                waiting += ".";
            }
            _waitCounter++;
            if (_waitCounter > 4)
            {
                _waitCounter = 1;
            }

            if (_comWrapper.ComportIsOpen())
            {
                PortInUse(portName, waiting);
                return;
            }
            if (portAvailable == true)
            {
                PortAvailable(portName, waiting);
            }
            else
            {
                PortNotAvailable(portName, waiting);
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region PortStatusControl

        private void PortInUse(string portname, string waiting)
        {
            string text = " is connected";

            _portLabel.Text = portname + text + waiting;
            _portLabel.ForeColor = System.Drawing.Color.Black;

        }


        private void PortAvailable(string portname, string waiting)
        {
            string text = " available";

            _portLabel.Text = portname + text + waiting;
            _portLabel.ForeColor = System.Drawing.Color.Black;
        }


        private void PortNotAvailable(string portname, string waiting)
        {
            string text = " not available! ";
            
            _portLabel.Text = portname + text + waiting;
            _portLabel.ForeColor = System.Drawing.Color.DimGray;
        }



        #endregion


    }
}
