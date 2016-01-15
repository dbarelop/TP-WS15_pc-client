﻿using System.Windows.Forms;
using System;
namespace pc_client
{
    public class Dispatcher
    {
        ///////////////////////////////////////////////////////////////////////
        #region delegates
        public delegate void NewDataReceivedEventHandler(object sender, byte[] data);
        public event NewDataReceivedEventHandler NewDataReceivedEvent;

        public delegate void NewRequestReceivedEventHandler(object sender, string data);
        public event NewRequestReceivedEventHandler NewRequestReceivedEvent;

        public delegate void NewErrorReceivedEventHandler(object sender, string data);
        public event NewErrorReceivedEventHandler NewErrorReceivedEvent;

        public delegate void NewHardwareDataReceivedEventHandler(object sender, byte[] data);
        public event NewHardwareDataReceivedEventHandler NewHardwareDataReceivedEvent;

        public delegate void NewTemperatureDataReceivedEventHandler(object sender, byte[] data);
        public event NewTemperatureDataReceivedEventHandler NewTemperatureDataReceivedEvent;

        public delegate void NewADChannel1DataReceivedEventHandler(object sender, byte[] data);
        public event NewADChannel1DataReceivedEventHandler NewADChannel1DataReceivedEvent;

        public delegate void NewADChannel2DataReceivedEventHandler(object sender, byte[] data);
        public event NewADChannel2DataReceivedEventHandler NewADChannel2DataReceivedEvent;

        public delegate void NewEpromDataReceivedEventHandler(object sender, byte[] data);
        public event NewEpromDataReceivedEventHandler NewEpromDataReceivedEvent;

        public delegate void NewTerminalDataReceivedEventHandler(object sender, byte[] data);
        public event NewTerminalDataReceivedEventHandler NewTerminalDataReceivedEvent;

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region member variables
        ComWrapper _comWrapper = null;
        string _sendCmd = null;
        System.Windows.Threading.Dispatcher _windowDispatcher;
        Form _receiverForm = null;
        volatile bool _requestPending = false;
        Object _lockObject = new Object();

        String _lastSendCommand;

        ErrorMessageBoxes _error = new ErrorMessageBoxes();
        #endregion


        delegate void NewDataReceivedDelegate(object sender, byte[] data);
        delegate void NewRequestReceivedDelegate(object sender, string data);


        public Dispatcher(Form form, ComWrapper comWrapper)
        {
            _comWrapper = comWrapper;
            _comWrapper.NewDataReceivedEvent += new ComWrapper.NewDataReceivedEventHandler(ComWrapper_NewDataReceivedEvent);
            _comWrapper.NewRequestReceivedEvent += new ComWrapper.NewRequestReceivedEventHandler(ComWrapper_NewRequestReceivedEvent);
            _windowDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            _receiverForm = form;
        }
        

        ~Dispatcher()
        {
            if (_comWrapper != null)
            {
                _comWrapper.NewDataReceivedEvent -= new ComWrapper.NewDataReceivedEventHandler(ComWrapper_NewDataReceivedEvent);
                _comWrapper.NewRequestReceivedEvent -= new ComWrapper.NewRequestReceivedEventHandler(ComWrapper_NewRequestReceivedEvent);
            }
        }


        public void SendData(string cmd, string data)
        {
            _sendCmd = cmd;

            SendData(data);
        }


        public void SendData(string cmd, char data)
        {
            _sendCmd = cmd;

            SendData(data);
        }



        public void SendData(string data)
        {
            CheckIfPortIsOpen();

            if (!_comWrapper.ComportWrite(data))
            {
                if (NewErrorReceivedEvent != null)
                {
                    NewErrorReceivedEvent(this, "Comport is closed");
                }
                throw new System.IO.InvalidDataException();
            }
            else
            {
                _requestPending = true;
                _lastSendCommand = data;
            }
        }


        public void SendData(char data)
        {
            CheckIfPortIsOpen();

            if (!_comWrapper.ComportWrite(data))
            {
                if (NewErrorReceivedEvent != null)
                {
                    NewErrorReceivedEvent(this, "Comport is closed");
                }
                throw new System.IO.InvalidDataException();
            }
            else
            {
                _requestPending = true;
                Helper helper = new Helper();
                _lastSendCommand = helper.HexToString((byte)data);
            }
        }


        public void CheckIfPortIsOpen()
        {
            if (!_comWrapper.ComportIsOpen())
            {
                string tmpPort = "";
                if (_comWrapper.Comport != null)
                {
                    tmpPort = _comWrapper.Comport.PortName;
                }
                _comWrapper.ComportDispose();
                bool tmp = _comWrapper.ComportOpen();
                if (tmp == false)
                {
                    _error.CanNotOpenComportError(tmpPort);
                    throw new System.IO.InvalidDataException();
                }
            }
        }


        public bool IsRequestPendig()
        {
            return _requestPending;
        }
        

        public void ComWrapper_NewDataReceivedEvent(object sender, byte[] data)
        {
            lock (_lockObject)
            {
                if (_receiverForm.InvokeRequired)
                {
                    _windowDispatcher.BeginInvoke(new NewDataReceivedDelegate(ComWrapper_NewDataReceivedEvent), new object[] { sender, data });
                    return;
                }

                if (NewDataReceivedEvent != null)
                {
                    NewDataReceivedEvent(this, data);
                }

                if (Array.Exists(data, element => element == 0xaa))
                {
                    _requestPending = false;
                    return;
                }

                else if (!Array.Exists(data, element => element == 0xaa))
                {
                      switch (_sendCmd)
                    {
                        case ("Hardware"):
                            if (NewHardwareDataReceivedEvent != null)
                            {
                                NewHardwareDataReceivedEvent(this, data);
                            }
                            break;
                        case ("Temperature"):
                            if (NewTemperatureDataReceivedEvent != null)
                            {
                                NewTemperatureDataReceivedEvent(this, data);
                            }
                            break;
                        case ("ADChannel1"):
                            if (NewADChannel1DataReceivedEvent != null)
                            {
                                NewADChannel1DataReceivedEvent(this, data);
                            }
                            break;
                        case ("ADChannel2"):
                            if (NewADChannel2DataReceivedEvent != null)
                            {
                                NewADChannel2DataReceivedEvent(this, data);
                            }
                            break;
                        case ("Eprom"):
                            if (NewEpromDataReceivedEvent != null)
                            {
                                NewEpromDataReceivedEvent(this, data);
                            }
                            break;
                        case ("Terminal"):
                            if (NewTerminalDataReceivedEvent != null)
                            {
                                NewTerminalDataReceivedEvent(this, data);
                            }
                            break;
                        default:
                            {
                            }
                            break;
                    }
                }
            }
        }
        

        public void ComWrapper_NewRequestReceivedEvent(object sender, string data)
        {
            if (_receiverForm.InvokeRequired)
            {
                _windowDispatcher.BeginInvoke(new NewRequestReceivedDelegate(ComWrapper_NewRequestReceivedEvent), new object[] { sender, data });
                return;
            }

            if (NewRequestReceivedEvent != null)
            {
                NewRequestReceivedEvent(this, data);
            }
        }

    }
}