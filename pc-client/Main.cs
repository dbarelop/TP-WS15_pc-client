using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;

namespace pc_client
{
    public partial class MainForm : Form
    {
        ///////////////////////////////////////////////////////////////////////
        #region Variables

        ComWrapper _comWrapper = null;
        ErrorMessageBoxes _error = null;
        Settings _settings = null;
        int _waitCounter = 1;

        private bool _keyHandled = false;
        List<string> _commandHistory = new List<string>();

        System.Windows.Threading.Dispatcher _windowDispatcher;
        Form _receiverForm = null;
        Object _lockObject = new Object();

        private static byte[] _receivedInput = null;

        delegate void NewDataReceivedDelegate(object sender, byte[] data);

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region Initialization

        public MainForm()
        {
            InitializeComponent();

            _comWrapper = new ComWrapper();
            _comWrapper.NewDataReceivedEvent += new ComWrapper.NewDataReceivedEventHandler(ComWrapper_NewDataReceivedEvent);
            _settings = Settings.GetInstance;
            _error = new ErrorMessageBoxes();
            _windowDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            _receiverForm = this;
            _receivedInput = new byte[0];

            InitializeControlValues();
            EnableControls();
            InitializeTimer();
        }


        ~MainForm()
        {
            if (_comWrapper != null)
            {
                _comWrapper.NewDataReceivedEvent -= new ComWrapper.NewDataReceivedEventHandler(ComWrapper_NewDataReceivedEvent);
            }
        }

        #endregion

                           
        
        ///////////////////////////////////////////////////////////////////////
        #region InitializeControlValues

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
        #region MiscellaneousEvents

        private void txtSendData_KeyPress(object sender, KeyPressEventArgs e)
        { 
            e.Handled = _keyHandled; 
        }



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

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            rtfTerminalOut.Focus();
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

            if (rtfTerminalIn.Text.Length == 0)
            {
                btnClearIn.Enabled = false;
            }
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
            btnSend.Enabled = true;

            if(rtfTerminalIn.Text.Length > 0)
            {
                btnClearIn.Enabled = true;
            }
        }

        # endregion



        private void btnSend_Click(object sender, EventArgs e)
        {
            SendData();  
        }



        private void rtfTerminalOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                SendData();               
            }
        }



        public void ComWrapper_NewDataReceivedEvent(object sender, byte[] data)
        {
            byte[] newData = new byte[_receivedInput.Length + data.Length];

            lock (_lockObject)
            {
                if (_receiverForm.InvokeRequired)
                {
                    _windowDispatcher.BeginInvoke(new NewDataReceivedDelegate(ComWrapper_NewDataReceivedEvent), new object[] { sender, data });
                    return;
                }

                System.Buffer.BlockCopy(_receivedInput, 0, newData, 0, _receivedInput.Length);
                System.Buffer.BlockCopy(data, 0, newData, _receivedInput.Length, data.Length);
                _receivedInput = newData;

                if (chkInputType.Checked == true)
                {
                    rtfTerminalIn.Clear();

                    rtfTerminalIn.AppendText(HexToString(_receivedInput[0]));
                    for (int i = 1; i < _receivedInput.Length; i++)
                    {
                        rtfTerminalIn.AppendText(":");
                        rtfTerminalIn.AppendText(HexToString(_receivedInput[i]));
                    }
                }
                else
                {
                    rtfTerminalIn.Text  = System.Text.Encoding.Default.GetString(_receivedInput);
                }                
            }
            
        }



        private void SendData()
        {
            String sendData = ""; ;

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
                        int intValue = int.Parse(subString, System.Globalization.NumberStyles.HexNumber);
                        data = (char)intValue;
                        _comWrapper.ComportWrite(data);
                    }
                    catch
                    {
                        _error.HexConversionError();
                    }                    
                }
            }
            else
            {
                _comWrapper.ComportWrite(sendData, true);
            } 
        }



        private void chkInputType_CheckedChanged(object sender, EventArgs e)
        {
            if(_receivedInput.Length == 0)
            {
                return; // nothing to convert
            }

            rtfTerminalIn.Clear();

            if (chkInputType.Checked == true)
            {              
                rtfTerminalIn.AppendText(HexToString(_receivedInput[0]));
                for (int i = 1; i < _receivedInput.Length; i++)
                {
                    rtfTerminalIn.AppendText(":");
                    rtfTerminalIn.AppendText(HexToString(_receivedInput[i]));
                }
            }
            else
            {
                rtfTerminalIn.AppendText(System.Text.Encoding.Default.GetString(_receivedInput));
            }
        }



        private String StringToHex(String value)
        {
            String returnValue = "";
            // Convert the string into a byte[].
            byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
            
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                // Convert integer byte as a hex in a string variable
                string hexValue = asciiBytes[i].ToString("X");
                returnValue += hexValue;
            }
            return returnValue;
        }



        private String HexToString(byte hexValue)
        {
            int value = Convert.ToInt32(hexValue);
            string hexOutput = String.Format("{0:x}", value);
            return hexOutput;
        }        



        private void btnClearOut_Click(object sender, EventArgs e)
        {
            rtfTerminalOut.Clear();
        }



        private void btnClearIn_Click(object sender, EventArgs e)
        {
            rtfTerminalIn.Clear();
            _receivedInput = new byte[0]; 
        }


        ///////////////////////////////////////////////////////////////////////
        #region PortStatus

        private void InitializeTimer()
        {
            timer1.Interval = 600;
            timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
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
