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
}
