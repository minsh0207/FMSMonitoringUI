using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : WinManageEqp Request
    /// </summary>
    public class _jsonWinManageEqpRequest : __baseRequest
    {
        public _jsonWinManageEqpRequest() { }
        ~_jsonWinManageEqpRequest() { }
    }


    /// <summary>
    /// JSON Format Body : WinManageEqp Response
    /// </summary>
    public class _jsonWinManageEqpResponse : _baseResponse
    {
        public _jsonWinManageEqpResponse() { }
        ~_jsonWinManageEqpResponse() { }

        public List<_win_manage_eqp> DATA;
    }

}
