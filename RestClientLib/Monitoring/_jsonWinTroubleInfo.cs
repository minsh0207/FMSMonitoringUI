using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : _jsonWinTroubleInfo Request
    /// </summary>
    public class _jsonWinTroubleInfoRequest : __baseRequest
    {
        public _jsonWinTroubleInfoRequest() { }
        ~_jsonWinTroubleInfoRequest() { }
    }


    /// <summary>
    /// JSON Format Body : _jsonWinTroubleInfo Response
    /// </summary>
    public class _jsonWinTroubleInfoResponse : _baseResponse
    {
        public _jsonWinTroubleInfoResponse() { }
        ~_jsonWinTroubleInfoResponse() { }

        public List<_trouble_info> DATA;
    }

}
