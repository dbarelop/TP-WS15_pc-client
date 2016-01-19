using System;
using System.Text;
using System.Linq;

namespace pc_client
{
    class Helper
    {
        public Helper()
        { }


        public String StringToHex(String value)
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


        public String HexToString(byte hexValue)
        {
            int value = Convert.ToInt32(hexValue);
            return String.Format("{0:x}", value);
        }


        public String HexArrayToString(byte[] hexValues)
        {
            string retval = "";
            for (int i = 0; i < hexValues.Length; i++)
            {
                // Convert integer byte as a hex in a string variable
                retval += hexValues[i].ToString("X");
            }

            return retval;
        }


        public byte[] RemoveOK(byte[] rawData)
        {
            byte[] withoutOK = new byte[rawData.Length];
            Array.Copy(rawData, withoutOK, rawData.Length);
            byte toRemove = Commands.OK;
            withoutOK = rawData.Where(val => val != toRemove).ToArray();

            return withoutOK;
        }

    }
}
