using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : ManualCommand Request
    /// </summary>
    public class _jsonManualCommandRequest
    {
        public _jsonManualCommandRequest() { }
        ~_jsonManualCommandRequest() { }

        public string ACTION_ID { get; set; }
        public string ACTION_USER { get; set; }
        public string REQUEST_TIME { get; set; }
        public string EQP_TYPE { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public string COMMAND { get; set; }

    }


    /// <summary>
    /// JSON Format Body : ManualCommand Response
    /// </summary>
    public class _jsonManualCommandResponse
    {
        public _jsonManualCommandResponse() { }
        ~_jsonManualCommandResponse() { }

        public string ACTION_ID { get; set; }

        public string RESPONSE_TIME { get; set; }

        public string RESPONSE_CODE { get; set; }

        public string RESPONSE_MESSAGE { get; set; }

    }

}
