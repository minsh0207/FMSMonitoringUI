using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    public class ServerInfo
    {
        public ServerInfo()
        {
            IPAddress = "";
            PORT = "";
        }
        /// <summary>
        /// IPAddress
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// PORT No
        /// </summary>
        public string PORT { get; set; }
    }

    public class CRestServerConfig
    {
        public CRestServerConfig()
        {
            //
        }

        #region [Properties]

        string _EqpType;
        public string EqpType
        {
            get => _EqpType;
            set => _EqpType = value;
        }

        string _IPAddress;
        public string IPAddress
        {
            get => _IPAddress;
            set => _IPAddress = value;
        }

        string _PORT;
        public string PORT
        {
            get => _PORT;
            set => _PORT = value;
        }

        List<CRestServerConfig> _Items;
        public List<CRestServerConfig> Items
        {
            get => _Items;
            set => _Items = value;
        }

        #endregion
    }
}
