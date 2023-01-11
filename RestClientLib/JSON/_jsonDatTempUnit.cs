using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : tb_dat_temp_unit Request
    /// </summary>
    public class _jsonDatTempUnitRequest : __baseRequest
    {
        public _jsonDatTempUnitRequest() { }
        ~_jsonDatTempUnitRequest() { }
    }


    /// <summary>
    /// JSON Format Body : tb_dat_temp_unit Response
    /// </summary>
    public class _jsonDatTempUnitResponse : _baseResponse
    {
        public _jsonDatTempUnitResponse() { }
        ~_jsonDatTempUnitResponse() { }
        
        public List<_dat_temp_unit> DATA;
    }

}
