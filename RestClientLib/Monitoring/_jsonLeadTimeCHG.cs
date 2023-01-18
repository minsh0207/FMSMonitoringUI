using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : LeadTimeCHG Request
    /// </summary>
    public class _jsonLeadTimeCHGRequest : __baseRequest
    {
        public _jsonLeadTimeCHGRequest() { }
        ~_jsonLeadTimeCHGRequest() { }
    }


    /// <summary>
    /// JSON Format Body : LeadTimeCHG Response
    /// </summary>
    public class _jsonLeadTimeCHGResponse : _baseResponse
    {
        public _jsonLeadTimeCHGResponse() { }
        ~_jsonLeadTimeCHGResponse() { }

        public List<_lead_time_chg> DATA;
    }

}
