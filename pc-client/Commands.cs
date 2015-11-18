using System;

namespace pc_client
{
    class Commands
    {
        ///////////////////////////////////////////////////////////////////////
        #region constant commands

        public const string _CMD_TEMPERATURE = "T";

        #endregion

        //TBD specified by protocol
        public string PrepareCommand(string cmd)
        {
            return cmd + "\r\n";
        }
    }
}
