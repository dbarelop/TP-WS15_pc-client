using System;

namespace pc_client
{
    class DataModel
    {       
        private DataModel()
        { }

        // singleton
        private static DataModel instance;

        public static DataModel GetInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DataModel();
                }
                return instance;
            }
        }

        ///////////////////////////////////////////////////////////////////////
        #region GetterSetter

        public string Temperature
        { get; set; }

        public string Value
        { get; set; }

        #endregion
    }
}
