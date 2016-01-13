using System.Windows.Forms;

namespace pc_client
{
    class ErrorMessageBoxes
    {
        public ErrorMessageBoxes() { }


        public void ComportErrorOccurred(string port)
        {
            MessageBox.Show("An Error Occurred on ComPort: " + port,
            "ComPort Error Occurred",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1);
        }


        public void ReadValueErrorOccurred(string textbox)
        {
            MessageBox.Show("An error occurred while reading: " + textbox,
            "Error Occurred While Reading",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1);
        }


        public void HexConversionError()
        {
            MessageBox.Show("Please type HEX-values double-digit or leading 0",
            "Can't convert to HEX",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1);
        }

        
        public void CanNotOpenComportError(string port)
        {
            MessageBox.Show("Can not open ComPort " + port,
            "ComPort Error Occurred",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1);
        }


        public void ComportErrorOccurred()
        {
            MessageBox.Show("An Error Occurred on the ComPort",
            "ComPort Error Occurred",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1);
        }


        public void SendingCommandError(string text)
        {
            MessageBox.Show("Error occurred while sending command: " + text,
            "Error While Sending Command",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1);
        }


        public void StillReceivingDataError()
        {
            MessageBox.Show("The program is still receiving data from the Board",
            "Still Receiving Data",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1);
        }

        public void PortSettingsError()
        {
            MessageBox.Show("Port settings are incorrect. Please adjust the settings",
            "Port settings error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
        }

        public void FatalError()
        {
            MessageBox.Show("Library has crashed. Please restart Application",
            "Fatal error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
        }
    }
}

