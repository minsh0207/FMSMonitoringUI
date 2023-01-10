using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : WinFormationBox Request
    /// </summary>
    public class _jsonWinFormationBoxRequest : __baseRequest
    {
        public _jsonWinFormationBoxRequest() { }
        ~_jsonWinFormationBoxRequest() { }
    }


    /// <summary>
    /// JSON Format Body : WinFormationBox Response
    /// </summary>
    public class _jsonWinFormationBoxResponse : _baseResponse
    {
        public _jsonWinFormationBoxResponse() { }
        ~_jsonWinFormationBoxResponse() { }

        public List<_win_formation_box> DATA;
    }

}
