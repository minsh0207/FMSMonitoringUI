using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMSMonitoringUI.Common
{
    public class COPCUAConfig
    {
        public COPCUAConfig()
        {
            //
        }

        #region [Properties]

        string _DeviceID;
        public string DeviceID
        {
            get => _DeviceID;
            set => _DeviceID = value;
        }

        string _OPCServerNmae;
        public string OPCServerNmae
        {
            get => _OPCServerNmae;
            set => _OPCServerNmae = value;
        }

        string _PLCName;
        public string PLCName
        {
            get => _PLCName;
            set => _PLCName = value;
        }

        string _OPCServerURL;
        public string OPCServerURL
        {
            get => _OPCServerURL;
            set => _OPCServerURL = value;
        }

        string _UserID;
        public string UserID
        {
            get => _UserID;
            set => _UserID = value;
        }

        string _UserPW;
        public string UserPW
        {
            get => _UserPW;
            set => _UserPW = value;
        }

        string _FirstNodeID;
        public string FirstNodeID
        {
            get => _FirstNodeID;
            set => _FirstNodeID = value;
        }

        List<COPCUAConfig> _Items;
        public List<COPCUAConfig> Items
        {
            get => _Items;
            set => _Items = value;
        }

        #endregion
    }
}
