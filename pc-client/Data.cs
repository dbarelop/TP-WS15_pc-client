using System;

namespace pc_client
{
    class Data
    {

        private Data()
        { 
            TerminalData = new byte[0];
            Firmware = "";
            ADW1 = 0;
            ADW2 = 0;
            ADW1_Raw = "";
            ADW2_Raw = "";
            Eprom = "";
            Temperature = 0;
        }

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

        public double ADW1
        { get; set; }

        public String ADW1_Raw
        { get; set; }

        public double ADW2
        { get; set; }

        public String ADW2_Raw
        { get; set; }

        public String Eprom
        { get; set; }

        public double Temperature
        { get; set; }

        private const double RNG1 = 2.56;
        public double getRNG1()
        {
            return RNG1;
        }

        private const double RNG2 = 0.16;
        public double getRNG2()
        {
            return RNG2;
        }

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
