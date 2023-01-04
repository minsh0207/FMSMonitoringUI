using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : ProcessData Request
    /// </summary>
    public class _jsonProcessDataRequest : _processing_data
    {
        public _jsonProcessDataRequest() { }
        ~_jsonProcessDataRequest() { }
    }


    /// <summary>
    /// JSON Format Body : ProcessData Response
    /// </summary>
    public class _jsonProcessDataResponse : _processing_data
    {
        public _jsonProcessDataResponse() { }
        ~_jsonProcessDataResponse() { }

        public List<_processing_data> DATA;
    }

}
