using System;

namespace pc_client
{
    class ADW
    {

        private ADW()
        { }

        // singleton
        private static ADW instance;

        public static ADW GetInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ADW();
                }
                return instance;
            }
        }

            ///////////////////////////////////////////////////////////////////////
            #region GetterSetter

            public string Channel
            { get; set; }

            public string Range
            { get; set; }

        
            #endregion
    }
}
