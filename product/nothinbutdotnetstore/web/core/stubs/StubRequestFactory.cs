using System;
using System.Collections.Generic;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext the_current_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
            public Dictionary<string, string> get_parameters()
            {
                throw new NotImplementedException();
            }
        }
    }
}