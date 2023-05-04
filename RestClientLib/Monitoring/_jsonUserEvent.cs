using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : _jsonUserEvent Request
    /// </summary>
    public class _jsonUserEventRequest : __baseRequest
    {
        public _jsonUserEventRequest() { }
        ~_jsonUserEventRequest() { }

        public string USER_ID { get; set; }
        public string WINDOW_ID { get; set; }
        public string TRAY_ID { get; set; }
        public string CELL_ID { get; set; }
        public string USER_EVENT { get; set; }
        public string USER_EVENT_LOG { get; set; }
    }


    /// <summary>
    /// JSON Format Body : _jsonUserEvent Response
    /// </summary>
    public class _jsonUserEventResponse : _baseResponse
    {
        public _jsonUserEventResponse() { }
        ~_jsonUserEventResponse() { }

        
    }

}
