using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : TroubleEquipment Request
    /// </summary>
    public class _jsonTroubleEquipmentRequest : __baseRequest
    {
        public _jsonTroubleEquipmentRequest() { }
        ~_jsonTroubleEquipmentRequest() { }
    }


    /// <summary>
    /// JSON Format Body : TroubleEquipment Response
    /// </summary>
    public class _jsonTroubleEquipmentResponse : _baseResponse
    {
        public _jsonTroubleEquipmentResponse() { }
        ~_jsonTroubleEquipmentResponse() { }

        public List<_trouble_equipment_list> DATA;
    }

}
