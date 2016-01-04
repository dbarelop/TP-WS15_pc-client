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
        int _listIndex = 0;

        private bool _keyHandled = false;
        List<string> _commandHistory = new List<string>();

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region Initialization

        public MainForm()
        {
            InitializeComponent();

            _comWrapper = new ComWrapper();
            _settings = Settings.GetInstance;
            _error = new ErrorMessageBoxes();

            InitializeControlValues();
            EnableControls();

            #endregion
        }

                ///////////////////////////////////////////////////////////////////////
        #region Delegates

        public delegate void NewSnifferDataEventHandler(object sender, string data, bool logCommand);
        public event NewSnifferDataEventHandler NewSnifferDataEvent;

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
                DisableSettingsControls();
                open_port();
            }
            else if (btnOpenPort.Text == "Close Port")
            {
                btnOpenPort.Text = "Open Port";
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
        #region Control Keys

        private void txtSendData_KeyDown(object sender, KeyEventArgs e)
        {
            // If the user presses [ENTER], send the data now
            if (_keyHandled = e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendData();
                rtfTerminalOut.AppendText("\n");
                _listIndex = 0;
            }


            else if (_keyHandled = e.KeyCode == Keys.Up)
            {
                if (_commandHistory.Count == 0)
                {
                    return;
                }

                string[] tmpLines = rtfTerminalOut.Lines;
                tmpLines[tmpLines.Count() - 1] = "";
                rtfTerminalOut.Lines = tmpLines;

                int index = (_listIndex + (_commandHistory.Count - 1)) % _commandHistory.Count;

                if (index == 0)
                {
                    rtfTerminalOut.AppendText(_commandHistory.ElementAt(index));
                    return;
                }

                rtfTerminalOut.AppendText(_commandHistory.ElementAt(index));

                --_listIndex;
            }


            else if (_keyHandled = e.KeyCode == Keys.Down)
            {
                if (_commandHistory.Count == 0)
                {
                    return;
                }

                string[] tmpLines = rtfTerminalOut.Lines;
                tmpLines[tmpLines.Count() - 1] = "";
                rtfTerminalOut.Lines = tmpLines;

                int index = (_listIndex + (_commandHistory.Count - 1)) % _commandHistory.Count;

                if (index == _commandHistory.Count - 1)
                {
                    rtfTerminalOut.AppendText(_commandHistory.ElementAt(index));
                    return;
                }

                rtfTerminalOut.AppendText(_commandHistory.ElementAt(index));

                ++_listIndex;
            }
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
        #region SnifferData

        public void SnifferReceivedData(string input, bool isData, bool logCommand)
        {
            try
            {
                if (logCommand == false)
                {
                    return; //don't log because it's a manually typed command (already in the log)
                    //to avoid duplicate logentries
                }
                if (input.Contains("\n"))
                {
                    rtfTerminalOut.AppendText(input);
                }
                else
                {
                    rtfTerminalOut.AppendText(input + "\n");
                }
            }
            catch (Exception)
            {

                _error.StillReceivingDataError();
            }
        }

        #endregion



        ///////////////////////////////////////////////////////////////////////
        #region SendDataTextfield

        private void SendData()
        {
            string sendData = rtfTerminalOut.Lines[(rtfTerminalOut.Lines.Count() - 1)];

            if (NewSnifferDataEvent != null)
            {
                _commandHistory.Add(sendData);
                NewSnifferDataEvent(this, sendData, false);
            }
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
            chkSimulation.Enabled = false;
        }

        # endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            int hexValue = 41;
            //int decValue = Convert.ToInt32(hexValue, 16);
            Char sendChar = System.Convert.ToChar(System.Convert.ToUInt32("0x41"));
            String sendData = sendChar.ToString();
           _comWrapper.ComportWrite(sendData, true);
        }

        private void rtfTerminalOut_KeyDown(object sender, KeyEventArgs e)
        {
            //if()
        }




    }
}
