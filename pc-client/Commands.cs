using System;


namespace pc_client
{
    class Commands
    {
        ///////////////////////////////////////////////////////////////////////
        #region constant commands

        //0x Baustein Operation z.B. 0x10 --> ADW(1) READ(0)

        public const byte EEPROM =  0x00; // 0000_0000
        public const byte ADW =     0x10; // 0001_0000
        public const byte ADT =     0x20; // 0010_0000

        public const byte READ =    0x00; // 0000_0000
        public const byte WRITE =   0x01; // 0000_0001
        public const byte ERASE =   0x02; // 0000_0010

        public const byte CH1 =     0x03; // 0000_0011
        public const byte CH2 =     0x04; // 0000_0100
        public const byte RNG1 =    0x05; // 0000_0101
        public const byte RNG2 =    0x06; // 0000_0110        

        public byte EEPROM_READ = EEPROM | READ;

        #endregion

        //TBD specified by protocol
        public string PrepareCommand(string cmd)
        {
            return cmd + "\r\n";
        }
    }
}
