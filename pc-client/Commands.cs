using System;


namespace pc_client
{
    static class Commands
    {
        ///////////////////////////////////////////////////////////////////////
        #region constant hex commands

        // 0x<Baustein><Operation> z.B. 0x10 --> ADW(1)READ(0)
        // e.g. call it like --> public byte EEPROM_READ = EEPROM | READ;


        // Components --> XXXX_0000
        public const byte MASTER =  0x00; // 0000_0000
        public const byte EEPROM =  0x10; // 0001_0000
        public const byte ADW =     0x20; // 0010_0000
        public const byte ADT =     0x30; // 0011_0000

        // Commands --> 0000_XXXX
        public const byte READ =            0x00; // 0000_0000
        public const byte WRITE =           0x01; // 0000_0001
        public const byte ERASE =           0x02; // 0000_0010
        public const byte CH1 =             0x03; // 0000_0011
        public const byte CH2 =             0x04; // 0000_0100
        public const byte RNG1 =            0x05; // 0000_0101  +-2.50V
        public const byte RNG2 =            0x06; // 0000_0110  +-0.16V      
        public const byte EEPROM_READ =     0x07; // 0000_0111  read 16bit command   
        public const byte EEPROM_WRITE =    0x08; // 0000_1000  write 16bit command     

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region constant responses

        public const byte OK = 0xaa;

        #endregion
        

        ///////////////////////////////////////////////////////////////////////
        #region constant identifiers

        public const string ID_HARDWARE = "Hardware";
        public const string ID_TEMPERATURE = "Temperature";
        public const string ID_ADCHANNEL1 = "ADChannel1";
        public const string ID_ADCHANNEL2 = "ADChannel2";
        public const string ID_EEPROM = "Eeprom";
        public const string ID_TERMINAL = "Terminal";

        #endregion
    }
}
