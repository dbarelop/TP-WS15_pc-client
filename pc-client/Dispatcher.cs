using System.Windows.Forms;
using System.Collections.Generic;
using System;


namespace pc_client
{
    public class Dispatcher
    {
        ///////////////////////////////////////////////////////////////////////
        #region delegates

        public delegate void NewDataReceivedEventHandler(object sender, string data);
        public event NewDataReceivedEventHandler NewDataReceivedEvent;

        public delegate void NewRequestReceivedEventHandler(object sender, string data, bool logCommand);
        public event NewRequestReceivedEventHandler NewRequestReceivedEvent;

        public delegate void NewErrorReceivedEventHandler(object sender, string data);
        public event NewErrorReceivedEventHandler NewErrorReceivedEvent;

        public delegate void NewTemperatureDataReceivedEventHandler(object sender, string data);
        public event NewTemperatureDataReceivedEventHandler NewTemperatureDataReceivedEvent;

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region member variables
        ComWrapper _comWrapper = null;
        ErrorMessageBoxes _error = null;
        string _sendCmd = null;
        System.Windows.Threading.Dispatcher _windowDispatcher;
        Form _receiverForm = null;
        volatile bool _requestPending = false;
        Object _lockObject = new Object();

        string _lastSendCommand;

        #endregion


        delegate void NewDataReceivedDelegate(object sender, string data);
        delegate void NewRequestReceivedDelegate(object sender, string data, bool logCommand);

        public Dispatcher(Form form, ComWrapper comWrapper)
        {
            _comWrapper = comWrapper;
            _error = new ErrorMessageBoxes();
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

            SendData(data, true);
        }



        public void SendData(string data, bool logCommand)
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

            if (!_comWrapper.ComportWrite(data, logCommand))
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



        public bool IsRequestPendig()
        {
            return _requestPending;
        }



        public void ComWrapper_NewDataReceivedEvent(object sender, string data)
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

                if (data.Contains("OK"))
                {
                    _requestPending = false;
                    return;
                }

                else if (data != "OK")
                {
                    if (data == "ERROR")
                    {
                        _requestPending = false;

                        if (NewErrorReceivedEvent != null)
                        {
                            NewErrorReceivedEvent(this, _lastSendCommand);
                        }
                        return;
                    }



                    switch (_sendCmd)
                    {
                        case ("T"):
                            if (NewTemperatureDataReceivedEvent != null)
                            {
                                NewTemperatureDataReceivedEvent(this, data);
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



        public void ComWrapper_NewRequestReceivedEvent(object sender, string data, bool logCommand)
        {
            if (_receiverForm.InvokeRequired)
            {
                _windowDispatcher.BeginInvoke(new NewRequestReceivedDelegate(ComWrapper_NewRequestReceivedEvent), new object[] { sender, data, logCommand });
                return;
            }

            if (NewRequestReceivedEvent != null)
            {
                NewRequestReceivedEvent(this, data, logCommand);
            }
        }

    }
}