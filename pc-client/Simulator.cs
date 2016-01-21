using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pc_client
{
    class Simulator
    {
        ///////////////////////////////////////////////////////////////////////
        #region variables

        Dispatcher _dispatcher = null;
        Helper _helper = null;
        public byte[] eeprom = { 0xFF };

        #endregion


        ///////////////////////////////////////////////////////////////////////
        #region constant responses

        public const byte OK = 0xaa;
        public const byte DONE = 0xbb;
        public const int FIRMWARE = 4;
        public const int RANDOM = 0xff;

        #endregion


        public Simulator(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            _helper = new Helper();
        }


        public void SimulateResponses(byte command)
        {
            char data;
            switch (command)
            {
                    //Read Firmware
                case (Commands.MASTER|Commands.READ):
                    data = (char)OK;
                    _dispatcher.SendData(Commands.ID_VOID, data);
                    data = (char)FIRMWARE;
                    _dispatcher.SendData(Commands.ID_VOID, data);
                    break;
                    //Read ADT
                case (Commands.ADT | Commands.READ):
                    data = (char)OK;
                    _dispatcher.SendData(Commands.ID_VOID, data);
                    data = (char)RANDOM;
                    _dispatcher.SendData(Commands.ID_VOID, data);
                    break;
                    //Read ADW
                case (Commands.ADW | Commands.READ):
                    data = (char)OK;
                    _dispatcher.SendData(Commands.ID_VOID, data);
                    data = (char)RANDOM;
                    _dispatcher.SendData(Commands.ID_VOID, data);
                    break;
                //Set ADW Range 1
                case (Commands.ADW | Commands.RNG1):
                    data = (char)OK;
                    _dispatcher.SendData(Commands.ID_VOID, data);
                    break;
                //Set ADW Range 2
                case (Commands.ADW | Commands.RNG2):
                    data = (char)OK;
                    _dispatcher.SendData(Commands.ID_VOID, data);
                    break;
                //Set ADW Channel 1
                case (Commands.ADW | Commands.CH1):
                    data = (char)OK;
                    _dispatcher.SendData(Commands.ID_VOID, data);
                    break;
                //Set ADW Channel 2
                case (Commands.ADW | Commands.CH2):
                    data = (char)OK;
                    _dispatcher.SendData(Commands.ID_VOID, data);
                    break;

                 default:
                    break;
            }
        }
    }

}
