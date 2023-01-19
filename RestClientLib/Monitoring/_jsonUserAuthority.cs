using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : UserAuthority Request
    /// </summary>
    public class _jsonUserAuthorityRequest : __baseRequest
    {
        public _jsonUserAuthorityRequest() { }
        ~_jsonUserAuthorityRequest() { }
    }


    /// <summary>
    /// JSON Format Body : UserAuthority Response
    /// </summary>
    public class _jsonUserAuthorityResponse : _baseResponse
    {
        public _jsonUserAuthorityResponse() { }
        ~_jsonUserAuthorityResponse() { }

        public List<_user_authority> DATA;
    }

}
