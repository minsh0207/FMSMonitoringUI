using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : CtrlFormationCHG Request
    /// </summary>
    public class _jsonCtrlFormationCHGRequest : __baseRequest
    {
        public _jsonCtrlFormationCHGRequest() { }
        ~_jsonCtrlFormationCHGRequest() { }
    }


    /// <summary>
    /// JSON Format Body : CtrlFormationCHG Response
    /// </summary>
    public class _jsonCtrlFormationCHGResponse : _baseResponse
    {
        public _jsonCtrlFormationCHGResponse() { }
        ~_jsonCtrlFormationCHGResponse() { }

        public List<_ctrl_formation_chg> DATA;
    }

}
