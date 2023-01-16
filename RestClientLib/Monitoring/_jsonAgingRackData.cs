using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : AgingRackData Request
    /// </summary>
    public class _jsonAgingRackDataRequest : __baseRequest
    {
        public _jsonAgingRackDataRequest() { }
        ~_jsonAgingRackDataRequest() { }
    }


    /// <summary>
    /// JSON Format Body : AgingRackData Response
    /// </summary>
    public class _jsonAgingRackDataResponse : _baseResponse
    {
        public _jsonAgingRackDataResponse() { }
        ~_jsonAgingRackDataResponse() { }

        public List<_aging_rack_data> DATA;
    }

}
