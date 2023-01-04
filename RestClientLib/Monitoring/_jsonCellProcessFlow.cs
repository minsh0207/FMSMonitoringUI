using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : WinCellDetailInfo Request
    /// </summary>
    public class _jsonCellProcessFlowRequest : __baseRequest
    {
        public _jsonCellProcessFlowRequest() { }
        ~_jsonCellProcessFlowRequest() { }
    }


    /// <summary>
    /// JSON Format Body : WinCellDetailInfo Response
    /// </summary>
    public class _jsonCellProcessFlowResponse : _baseResponse
    {
        public _jsonCellProcessFlowResponse() { }
        ~_jsonCellProcessFlowResponse() { }

        public List<_cell_process_flow> DATA;
    }

}
