using System.Windows.Forms;

namespace pc_client
{
    class ErrorMessageBoxes
    {
        public ErrorMessageBoxes() { }


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


        public void SendingCommandError(string text)
        {
            MessageBox.Show("Error occurred while sending command: " + text,
            "Error While Sending Command",
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

