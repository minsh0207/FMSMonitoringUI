using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : tb_dat_packing Request
    /// </summary>
    public class _jsonDatPackingRequest : __baseRequest
    {
        public _jsonDatPackingRequest() { }
        ~_jsonDatPackingRequest() { }        
    }


    /// <summary>
    /// JSON Format Body : tb_dat_packing Response
    /// </summary>
    public class _jsonDatPackingResponse : _baseResponse
    {
        public _jsonDatPackingResponse() { }
        ~_jsonDatPackingResponse() { }

        public List<_dat_packing> DATA;
    }

}
