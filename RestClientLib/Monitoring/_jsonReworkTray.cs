using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : ReworkTray Request
    /// </summary>
    public class _jsonReworkTrayRequest : __baseRequest
    {
        public _jsonReworkTrayRequest() { }
        ~_jsonReworkTrayRequest() { }
    }


    /// <summary>
    /// JSON Format Body : ReworkTray Response
    /// </summary>
    public class _jsonReworkTrayResponse : _baseResponse
    {
        public _jsonReworkTrayResponse() { }
        ~_jsonReworkTrayResponse() { }

        public List<_rework_tray> DATA;
    }

}
