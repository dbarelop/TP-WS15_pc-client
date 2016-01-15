﻿using System;
using System.Text;

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
            string hexOutput = String.Format("{0:x}", value);
            return hexOutput;
        }
    }
}
