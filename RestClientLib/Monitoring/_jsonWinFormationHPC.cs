using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : WinFormationHPC Request
    /// </summary>
    public class _jsonWinFormationHPCRequest : __baseRequest
    {
        public _jsonWinFormationHPCRequest() { }
        ~_jsonWinFormationHPCRequest() { }
    }


    /// <summary>
    /// JSON Format Body : WinFormationHPC Response
    /// </summary>
    public class _jsonWinFormationHPCResponse : _baseResponse
    {
        public _jsonWinFormationHPCResponse() { }
        ~_jsonWinFormationHPCResponse() { }

        public List<_win_formation_hpc> DATA;
    }

}
