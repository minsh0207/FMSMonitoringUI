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
    public class _jsonWinAgingRackSettingRequest : __baseRequest
    {
        public _jsonWinAgingRackSettingRequest() { }
        ~_jsonWinAgingRackSettingRequest() { }
    }


    /// <summary>
    /// JSON Format Body : WinAgingRackSetting Response
    /// </summary>
    public class _jsonWinAgingRackSettingResponse : _baseResponse
    {
        public _jsonWinAgingRackSettingResponse() { }
        ~_jsonWinAgingRackSettingResponse() { }

        public List<_win_aging_rack> DATA;
    }

}
