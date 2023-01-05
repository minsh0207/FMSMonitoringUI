using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : WinLeadTime Request
    /// </summary>
    public class _jsonWinLeadTimeRequest : __baseRequest
    {
        public _jsonWinLeadTimeRequest() { }
        ~_jsonWinLeadTimeRequest() { }
    }


    /// <summary>
    /// JSON Format Body : WinLeadTime Response
    /// </summary>
    public class _jsonWinLeadTimeResponse : _baseResponse
    {
        public _jsonWinLeadTimeResponse() { }
        ~_jsonWinLeadTimeResponse() { }

        public List<_win_lead_time> DATA;
    }

}
