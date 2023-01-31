using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : TroubleAging Request
    /// </summary>
    public class _jsonTroubleAgingRequest : __baseRequest
    {
        public _jsonTroubleAgingRequest() { }
        ~_jsonTroubleAgingRequest() { }
    }


    /// <summary>
    /// JSON Format Body : TroubleAging Response
    /// </summary>
    public class _jsonTroubleAgingResponse : _baseResponse
    {
        public _jsonTroubleAgingResponse() { }
        ~_jsonTroubleAgingResponse() { }

        public List<_trouble_aging_list> DATA;
    }

}
