using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : CtrlFormationHPC Request
    /// </summary>
    public class _jsonCtrlFormationHPCRequest : __baseRequest
    {
        public _jsonCtrlFormationHPCRequest() { }
        ~_jsonCtrlFormationHPCRequest() { }
    }


    /// <summary>
    /// JSON Format Body : CtrlFormationCHG Response
    /// </summary>
    public class _jsonCtrlFormationHPCResponse : _baseResponse
    {
        public _jsonCtrlFormationHPCResponse() { }
        ~_jsonCtrlFormationHPCResponse() { }

        public List<_ctrl_formation_hpc> DATA;
    }

}
