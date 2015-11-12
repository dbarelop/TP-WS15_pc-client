using System.Windows.Forms;
using System.Collections.Generic;
using System;
namespace HmiProgram
{
    public class Dispatcher
    {
        ///////////////////////////////////////////////////////////////////////
        #region delegates
        public delegate void NewManufactureDataReceivedEventHandler(object sender, string data);
        public event NewManufactureDataReceivedEventHandler NewManufactureDataReceivedEvent;

        public delegate void NewCustomerDataReceivedEventHandler(object sender, string data);
        public event NewCustomerDataReceivedEventHandler NewCustomerDataReceivedEvent;

        public delegate void NewVersionDataReceivedEventHandler(object sender, string data);
        public event NewVersionDataReceivedEventHandler NewVersionDataReceivedEvent;

        public delegate void NewHardwareDataReceivedEventHandler(object sender, string data);
        public event NewHardwareDataReceivedEventHandler NewHardwareDataReceivedEvent;

        public delegate void NewSerialDataReceivedEventHandler(object sender, string data);
        public event NewSerialDataReceivedEventHandler NewSerialDataReceivedEvent;

        public delegate void NewDateDataReceivedEventHandler(object sender, string data);
        public event NewDateDataReceivedEventHandler NewDateDataReceivedEvent;

        public delegate void NewTimeDataReceivedEventHandler(object sender, string data);
        public event NewTimeDataReceivedEventHandler NewTimeDataReceivedEvent;

        public delegate void NewKeyEnterDataReceivedEventHandler(object sender, string data);
        public event NewKeyEnterDataReceivedEventHandler NewKeyEnterDataReceivedEvent;

        public delegate void NewKeyUpDataReceivedEventHandler(object sender, string data);
        public event NewKeyUpDataReceivedEventHandler NewKeyUpDataReceivedEvent;

        public delegate void NewKeyDownDataReceivedEventHandler(object sender, string data);
        public event NewKeyDownDataReceivedEventHandler NewKeyDownDataReceivedEvent;

        public delegate void NewKeyPowerDataReceivedEventHandler(object sender, string data);
        public event NewKeyPowerDataReceivedEventHandler NewKeyPowerDataReceivedEvent;

        public delegate void NewKeyPageDataReceivedEventHandler(object sender, string data);
        public event NewKeyPageDataReceivedEventHandler NewKeyPageDataReceivedEvent;

        public delegate void NewBrakePressedDataReceivedEventHandler(object sender, string data);
        public event NewBrakePressedDataReceivedEventHandler NewBrakePressedDataReceivedEvent;

        public delegate void NewProductNoDataReceivedEventHandler(object sender, string data);
        public event NewProductNoDataReceivedEventHandler NewProductNoDataReceivedEvent;

        public delegate void NewProductNoRevDataReceivedEventHandler(object sender, string data);
        public event NewProductNoRevDataReceivedEventHandler NewProductNoRevDataReceivedEvent;

        public delegate void NewConfigNoDataReceivedEventHandler(object sender, string data);
        public event NewConfigNoDataReceivedEventHandler NewConfigNoDataReceivedEvent;

        public delegate void NewFirmwareNoDataReceivedEventHandler(object sender, string data);
        public event NewFirmwareNoDataReceivedEventHandler NewFirmwareNoDataReceivedEvent;

        public delegate void NewDataReceivedEventHandler(object sender, string data);
        public event NewDataReceivedEventHandler NewDataReceivedEvent;

        public delegate void NewRequestReceivedEventHandler(object sender, string data, bool logCommand);
        public event NewRequestReceivedEventHandler NewRequestReceivedEvent;

        public delegate void NewErrorReceivedEventHandler(object sender, string data);
        public event NewErrorReceivedEventHandler NewErrorReceivedEvent;

        public delegate void NewDaylightDataReceivedEventHandler(object sender, string data);
        public event NewDaylightDataReceivedEventHandler NewDaylightDataReceivedEvent;

        public delegate void NewLightCalibrationDataReceivedEventHandler(object sender, string data);
        public event NewLightCalibrationDataReceivedEventHandler NewLightCalibrationDataReceivedEvent;

        public delegate void NewLightAmplifierDataReceivedEventHandler(object sender, string data);
        public event NewLightAmplifierDataReceivedEventHandler NewLightAmplifierDataReceivedEvent;

        public delegate void NewHmiTemperatureDataReceivedEventHandler(object sender, string data);
        public event NewHmiTemperatureDataReceivedEventHandler NewHmiTemperatureDataReceivedEvent;

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region member variables
        ComWrapper _comWrapper = null;
        string _sendCmd = null;
        System.Windows.Threading.Dispatcher _windowDispatcher;
        Form _receiverForm = null;
        volatile bool _requestPending = false;
        Object _lockObject = new Object();

        string _lastSendCommand;

        ErrorMessageBoxes _error = new ErrorMessageBoxes();
        #endregion


        delegate void NewDataReceivedDelegate(object sender, string data);
        delegate void NewRequestReceivedDelegate(object sender, string data, bool logCommand);

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
                        case ("GMI"):
                            if (NewManufactureDataReceivedEvent != null)
                            {
                                NewManufactureDataReceivedEvent(this, data);
                            }
                            break;
                        case ("GMM"):
                            if (NewCustomerDataReceivedEvent != null)
                            {
                                NewCustomerDataReceivedEvent(this, data);
                            }
                            break;
                        case ("GMR"):
                            if (NewVersionDataReceivedEvent != null)
                            {
                                NewVersionDataReceivedEvent(this, data);
                            }
                            break;
                        case ("GHW"):
                            if (NewHardwareDataReceivedEvent != null)
                            {
                                NewHardwareDataReceivedEvent(this, data);
                            }
                            break;
                        case ("GSN"):
                            if (NewSerialDataReceivedEvent != null)
                            {
                                NewSerialDataReceivedEvent(this, data);
                            }
                            break;
                        case ("Date"):
                            if (NewDateDataReceivedEvent != null)
                            {
                                NewDateDataReceivedEvent(this, data);
                            }
                            break;
                        case ("Time"):
                            if (NewTimeDataReceivedEvent != null)
                            {
                                NewTimeDataReceivedEvent(this, data);
                            }
                            break;
                        case ("KeyEnter"):
                            if (NewKeyEnterDataReceivedEvent != null)
                            {
                                NewKeyEnterDataReceivedEvent(this, data);
                            }
                            break;
                        case ("KeyUp"):
                            if (NewKeyUpDataReceivedEvent != null)
                            {
                                NewKeyUpDataReceivedEvent(this, data);
                            }
                            break;
                        case ("KeyDown"):
                            if (NewKeyDownDataReceivedEvent != null)
                            {
                                NewKeyDownDataReceivedEvent(this, data);
                            }
                            break;
                        case ("KeyPower"):
                            if (NewKeyPowerDataReceivedEvent != null)
                            {
                                NewKeyPowerDataReceivedEvent(this, data);
                            }
                            break;
                        case ("KeyPage"):
                            if (NewKeyPageDataReceivedEvent != null)
                            {
                                NewKeyPageDataReceivedEvent(this, data);
                            }
                            break;
                        case ("BrakePressed"):
                            if (NewBrakePressedDataReceivedEvent != null)
                            {
                                NewBrakePressedDataReceivedEvent(this, data);
                            }
                            break;
                        case ("ProductNo"):
                            if (NewProductNoDataReceivedEvent != null)
                            {
                                NewProductNoDataReceivedEvent(this, data);
                            }
                            break;
                        case ("ProductNoRev"):
                            if (NewProductNoRevDataReceivedEvent != null)
                            {
                                NewProductNoRevDataReceivedEvent(this, data);
                            }
                            break;
                        case ("ConfigNo"):
                            if (NewConfigNoDataReceivedEvent != null)
                            {
                                NewConfigNoDataReceivedEvent(this, data);
                            }
                            break;
                        case ("FirmwareNo"):
                            if (NewFirmwareNoDataReceivedEvent != null)
                            {
                                NewFirmwareNoDataReceivedEvent(this, data);
                            }
                            break;
                        case ("Illuminance"):
                            if (NewDaylightDataReceivedEvent != null)
                            {
                                NewDaylightDataReceivedEvent(this, data);
                            }
                            break;
                        case ("HmiTemperature"):
                            if (NewHmiTemperatureDataReceivedEvent != null)
                            {
                                NewHmiTemperatureDataReceivedEvent(this, data);
                            }
                            break;
                        case ("LightSensorGain"):
                            if (NewLightCalibrationDataReceivedEvent != null)
                            {
                                NewLightCalibrationDataReceivedEvent(this, data);
                            }
                            break;
                        case ("LightSensorAmplifier"):
                            if (NewLightAmplifierDataReceivedEvent != null)
                            {
                                NewLightAmplifierDataReceivedEvent(this, data);
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