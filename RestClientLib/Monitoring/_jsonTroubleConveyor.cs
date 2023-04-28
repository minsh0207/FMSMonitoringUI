using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : TroubleConveyor Request
    /// </summary>
    public class _jsonTroubleConveyorRequest : __baseRequest
    {
        public _jsonTroubleConveyorRequest() { }
        ~_jsonTroubleConveyorRequest() { }
    }


    /// <summary>
    /// JSON Format Body : TroubleConveyor Response
    /// </summary>
    public class _jsonTroubleConveyorResponse : _baseResponse
    {
        public _jsonTroubleConveyorResponse() { }
        ~_jsonTroubleConveyorResponse() { }

        public List<_trouble_conveyor_list> DATA;
    }

}
