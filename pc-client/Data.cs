using System;

namespace pc_client
{
    class Data
    {

        private Data()
        { }

        // singleton
        private static Data instance;

        public static Data GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();
                }
                return instance;
            }
        }

        ///////////////////////////////////////////////////////////////////////
        #region Properties

        public byte[] TerminalData
        { get; set; }

        public String Firmware
        { get; set; }

        public String ADW1
        { get; set; }

        public String ADW2
        { get; set; }

        public String Eprom
        { get; set; }

        public double Temperature
        { get; set; }

        #endregion


        public void AppendTerminalData(byte[] receivedData)
        {
            byte[] newData = new byte[TerminalData.Length + receivedData.Length];

            System.Buffer.BlockCopy(TerminalData, 0, newData, 0, TerminalData.Length);
            System.Buffer.BlockCopy(receivedData, 0, newData, TerminalData.Length, receivedData.Length);
            TerminalData = newData;
        }
    }
}
