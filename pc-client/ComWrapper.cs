﻿using System;
using System.IO.Ports;
using System.IO;

namespace pc_client
{
    public class ComWrapper
    {
        ///////////////////////////////////////////////////////////////////////
        #region delegates
        public delegate void NewDataReceivedEventHandler(object sender, byte[] data);
        public event NewDataReceivedEventHandler NewDataReceivedEvent;

        public delegate void NewRequestReceivedEventHandler(object sender, string data);
        public event NewRequestReceivedEventHandler NewRequestReceivedEvent;

        #endregion


        /////////////////////////////////////////////////////////////////////
        #region variables

        public SerialPort Comport
        { get; set; }

        ErrorMessageBoxes _error = null;

        #endregion

        
        public ComWrapper()
        {
            Comport = null;
            _error = new ErrorMessageBoxes();
        }

        
        ~ComWrapper()
        {
            if (Comport != null)
            {
                ComportDispose();
            }
        }

        
        public bool ComportIsOpen()
        {
            if (Comport != null && Comport.IsOpen)
            {
                return true;
            }
            return false;
        }
        

        public bool ComportDispose()
        {
            bool retval = true;

            try
            {
                Comport.DataReceived -= new SerialDataReceivedEventHandler(Port_DataReceived);

                if (ComportIsOpen() == true)
                {
                    Comport.Dispose();
                    Comport.Close();
                }
                if (Comport != null)
                {
                    Comport = null;
                }
            }
            catch (Exception)
            {
                retval = false;
                Comport = null;
            }

            return retval;
        }
        

        public bool ComportOpen()
        {
            if (Comport != null && Comport.IsOpen)
            {
                return false;
            }

            if (Comport == null)
            {
                Comport = new SerialPort();
                Comport.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
            }

            bool retval = true;

            Settings settings = Settings.GetInstance;
            try
            {
                Comport.BaudRate = int.Parse(settings.BaudRate);
                Comport.DataBits = int.Parse(settings.DataBits);
                Comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), settings.StopBits);
                Comport.Parity = (Parity)Enum.Parse(typeof(Parity), settings.Parity);
                Comport.PortName = settings.PortName;
                Comport.RtsEnable = settings.RTS;
                Comport.DtrEnable = settings.DTR;
            }
            catch
            {
                _error.PortSettingsError();
                retval = false;
            }

            if (retval)
            {
                // Open the port
                try
                {
                    Comport.Open();
                }
                catch (UnauthorizedAccessException) { retval = false; }
                catch (IOException) { retval = false; }
                catch (ArgumentException) { retval = false; }
            }
            return retval;
        }
        

        public bool ComportWrite(string sendtext)
        {
            if ((Comport == null) || (!Comport.IsOpen))
            {
                return false;
            }

            bool retval = true;

            try
            {
                if (NewRequestReceivedEvent != null)
                {
                    NewRequestReceivedEvent(this, sendtext);
                }
                Comport.Write(sendtext);
            }
            catch (Exception)
            {
                retval = false;
            }

            return retval;
        }


        public bool ComportWrite(Char data)
        {
            char[] character = new char[1];
            character[0] = data;

            if ((Comport == null) || (!Comport.IsOpen))
            {
                return false;
            }

            bool retval = true;

            try
            {
                Comport.Write(character, 0, 1);
            }
            catch (Exception)
            {
                retval = false;
            }

            return retval;
        }
        

        public string ComportRead()
        {
            string data = Comport.ReadExisting();
            return data;
        }

        
        public byte[] ComportReadBytes()
        {
            byte[] data = new byte[Comport.BytesToRead];
            Comport.Read(data, 0, data.Length);
            return data;
        }

        
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = ComportReadBytes();

            if (data.Length > 0)
            {
                if (NewDataReceivedEvent != null)
                {
                    NewDataReceivedEvent(this, data);
                }
            }
        }
        

        public string[] GetAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }


        public object[] GetBaudRateRange()
        {
            object[] range = { 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200 };
            return range;
        }


        public object[] GetDataBitsRange()
        {
            object[] range = { 7, 8, 9};
            return range;
        }

    }
}

