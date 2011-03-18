using System;
using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext the_current_context)
        {
            return new DefaultRequest(transform(the_current_context));
        }

        private IEnumerable<KeyValuePair<string, string>> transform(HttpContext context)
        {
            return new List<KeyValuePair<string, string>>();
        }
    }

}