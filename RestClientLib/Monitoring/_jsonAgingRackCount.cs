using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : WinAgingRackSetting Request
    /// </summary>
    public class _jsonAgingRackCountRequest : __baseRequest
    {
        public _jsonAgingRackCountRequest() { }
        ~_jsonAgingRackCountRequest() { }
    }


    /// <summary>
    /// JSON Format Body : WinAgingRackSetting Response
    /// </summary>
    public class _jsonAgingRackCountResponse : _baseResponse
    {
        public _jsonAgingRackCountResponse() { }
        ~_jsonAgingRackCountResponse() { }

        public List<_aging_rack_count> DATA;
    }

}
