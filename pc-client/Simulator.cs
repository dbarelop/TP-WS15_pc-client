namespace pc_client
{
    class Simulator
    {
        ///////////////////////////////////////////////////////////////////////
        #region variables

        Dispatcher _dispatcher = null;
        Helper _helper = null;
        public byte[] eeprom = new byte[512];
        
        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region constant responses

        public const byte OK = 0xaa;
        public const byte DONE = 0xbb;
        public const byte FIRMWARE = 6;

        #endregion


        public Simulator(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            _helper = new Helper();
            for(int i = 0; i < eeprom.Length; i++)
            {
                eeprom[i] = 0xff;
            }
            eeprom[0] = 0x61;
            eeprom[1] = 0x62;
        }


        public void SimulateResponses(byte command)
        {
            switch (command)
            {
                    //Read Firmware
                case (Commands.MASTER|Commands.READ):
                    byte[] sendMaster = { OK, FIRMWARE };
                    _dispatcher.SendData(sendMaster);
                    break;
                //Read Eeprom
                case (Commands.EEPROM | Commands.READ):
                    byte[] sendEeprom = { OK, eeprom[0], eeprom[1], 0xff };
                    _dispatcher.SendData(sendEeprom);
                    break;
                //Write Eeprom
                case (Commands.EEPROM | Commands.WRITE):
                    byte[] sendEepromWrite = { OK, DONE };
                    _dispatcher.SendData(sendEepromWrite);
                    break;
                //erease Eeprom
                case (Commands.EEPROM | Commands.ERASE):
                    byte[] sendEepromErease = { OK, DONE};
                    _dispatcher.SendData(sendEepromErease);
                    break;
                //Read ADT
                case (Commands.ADT | Commands.READ):
                    byte[] sendADT = { OK, 0x03, 0x13 };
                    _dispatcher.SendData(sendADT);
                    break;
                    //Read ADW
                case (Commands.ADW | Commands.READ):
                    byte[] sendADW = { OK, 0xd5, 0x85, 0x51 };
                    _dispatcher.SendData(sendADW);
                    break;
                //Set ADW Range 1
                case (Commands.ADW | Commands.RNG1):
                    byte[] sendRNG1 = { OK };
                    _dispatcher.SendData(sendRNG1);
                    break;
                //Set ADW Range 2
                case (Commands.ADW | Commands.RNG2):
                    byte[] sendRNG2 = { OK };
                    _dispatcher.SendData(sendRNG2);
                    break;
                //Set ADW Channel 1
                case (Commands.ADW | Commands.CH1):
                    byte[] sendCH1 = { OK};
                    _dispatcher.SendData(sendCH1);
                    break;
                //Set ADW Channel 2
                case (Commands.ADW | Commands.CH2):
                    byte[] sendCH2 = { OK };
                    _dispatcher.SendData(sendCH2);
                    break;

                 default:
                    break;
            }
        }
    }

}
