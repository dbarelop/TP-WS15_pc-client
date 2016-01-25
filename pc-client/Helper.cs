using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

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


        public int HexStringToDecimal(String hex)
        {
            if(hex.Length > 0)
            {
                int decValue = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                return decValue;
            }
            else
            {
                return 0;
            }
        }


        public String HexArrayToString(byte[] hexValues)
        {
            string retval = "";
            for (int i = 0; i < hexValues.Length; i++)
            {
                // Convert integer byte as a hex in a string variable
                string digit = hexValues[i].ToString("X");
                if(digit.Length == 1)
                {
                    digit = "0" + hexValues[i].ToString("X");
                }
                retval += digit;
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


        public byte[] RemoveEMPTY(byte[] rawData)
        {
            byte[] withoutEMPTY = new byte[rawData.Length];
            Array.Copy(rawData, withoutEMPTY, rawData.Length);
            byte toRemove = Commands.EMPTY;
            withoutEMPTY = rawData.Where(val => val != toRemove).ToArray();

            return withoutEMPTY;
        }


        public List<object> CreateObjectList(object o1, object o2)
        {
            List<object> arguments = new List<object>();
            arguments.Add(o1);
            arguments.Add(o2);
            return arguments;
        }


        public List<object> CreateObjectList(object o1, object o2, object o3)
        {
            List<object> arguments = new List<object>();
            arguments.Add(o1);
            arguments.Add(o2);
            arguments.Add(o3);
            return arguments;
        }

    }
}
