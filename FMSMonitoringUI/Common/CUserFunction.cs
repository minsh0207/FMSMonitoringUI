using OPCUAClientClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringUI.Common
{
    /// <summary>
    /// 화성라인에서만 사용되는 사용자 함수용 클래스
    /// </summary>
    public static class CUserFunction
    {
        /// <summary>
        /// procID를 가지고 EqpTypeID, OperGroupID, OperID 반환, ProcID 규칙에 위반될 경우 000반환
        /// </summary>
        public static CMapProcID SplitProcID(string strProcID)
        {
            CMapProcID proc = new CMapProcID();

            if(strProcID.Length == 3)
            {
                proc.EqpTypeID = strProcID.Substring(0, 1);
                proc.OperGroupID = strProcID.Substring(1, 1);
                proc.OperID = strProcID.Substring(2, 1);
            }

            return proc;
        }
    }


    public class CMapProcID
    {
        public string EqpTypeID { get; set; } = "0";
        public string OperGroupID { get; set; } = "0";
        public string OperID { get; set; } = "0";
    }

    public class CMonitoredItem
    {
        public CMonitoredItem() 
        {
            GroupNo = 0;
            SiteNo = 0;
            CraneNo = 0;
            TrayExist = false;
            EqpStatus = 1;
            TrayRework = false;
            FireSensor = false;
            CraneName = string.Empty;
        }

        public int GroupNo { get; set; }
        public int SiteNo { get; set; }
        public int CraneNo { get; set; }
        public bool TrayExist { get; set; }
        public int EqpStatus { get; set; }
        public bool TrayRework { get; set; }
        public bool FireSensor { get; set; }
        public string CraneName { get; set; }
    }
    public class CSubscribeInfo
    {
        public Dictionary<int, CMonitoredItem> Item;

        /// <summary>
        /// first= Site no, Second = Monitored Item
        /// </summary>
        public CSubscribeInfo()
        {
            Item = new Dictionary<int, CMonitoredItem>();
        }

    }
}
