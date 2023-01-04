using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : WinTrayInfo Request
    /// </summary>
    public class _jsonTrayProcessFlowRequest : __baseRequest
    {
        public _jsonTrayProcessFlowRequest() { }
        ~_jsonTrayProcessFlowRequest() { }
    }


    /// <summary>
    /// JSON Format Body : WinTrayInfo Response
    /// </summary>
    public class _jsonTrayProcessFlowResponse : _baseResponse
    {
        public _jsonTrayProcessFlowResponse() { }
        ~_jsonTrayProcessFlowResponse() { }

        public List<_tray_process_flow> DATA;
    }

}
