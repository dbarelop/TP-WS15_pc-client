using System;

namespace PC_Client
{
    public class Settings
    {
        private Settings() 
        { }

        // singleton
        private static Settings instance;

        public static Settings GetInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Settings();
                }
                return instance;
            }
        }
        

        ///////////////////////////////////////////////////////////////////////
        #region GetterSetter

        public string BaudRate
        { get; set; }

        public string DataBits
        { get; set; }

        public string StopBits
        { get; set; }

        public string Parity
        { get; set; }

        public string PortName
        { get; set; }

        public bool DTR
        { get; set; }

        public bool RTS
        { get; set; }

        #endregion
    }
}