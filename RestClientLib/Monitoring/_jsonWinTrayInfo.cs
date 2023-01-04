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
    public class _jsonWinTrayInfoRequest : __baseRequest
    {
        public _jsonWinTrayInfoRequest() { }
        ~_jsonWinTrayInfoRequest() { }
    }


    /// <summary>
    /// JSON Format Body : WinTrayInfo Response
    /// </summary>
    public class _jsonWinTrayInfoResponse : _baseResponse
    {
        public _jsonWinTrayInfoResponse() { }
        ~_jsonWinTrayInfoResponse() { }

        public List<_win_tray_info> DATA;
    }

}
