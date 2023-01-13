using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : EntireEqpList Request
    /// </summary>
    public class _jsonEntireEqpListRequest : _recipe_data
    {
        public _jsonEntireEqpListRequest() { }
        ~_jsonEntireEqpListRequest() { }
    }


    /// <summary>
    /// JSON Format Body : EntireEqpList Response
    /// </summary>
    public class _jsonEntireEqpListResponse : _recipe_data
    {
        public _jsonEntireEqpListResponse() { }
        ~_jsonEntireEqpListResponse() { }

        public List<_entire_eqp_list> DATA;
    }

}
