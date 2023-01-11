using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : CtrlFormationHPCTemp Request
    /// </summary>
    public class _jsonCtrlFormationHPCTempRequest : __baseRequest
    {
        public _jsonCtrlFormationHPCTempRequest() { }
        ~_jsonCtrlFormationHPCTempRequest() { }
    }


    /// <summary>
    /// JSON Format Body : CtrlFormationHPCTemp Response
    /// </summary>
    public class _jsonCtrlFormationHPCTempResponse : _baseResponse
    {
        public _jsonCtrlFormationHPCTempResponse() { }
        ~_jsonCtrlFormationHPCTempResponse() { }

        public List<_ctrl_formation_hpc_temp> DATA;
    }

}
