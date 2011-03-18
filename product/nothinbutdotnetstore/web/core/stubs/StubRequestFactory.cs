using System;
using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext the_current_context)
        {
            return new DefaultRequest(new DefaultTokenStore<string, string>(),
                                      new StubMappingGateway(), the_current_context.Request.RawUrl);
        }

        IEnumerable<KeyValuePair<string, string>> transform(HttpContext context)
        {
            return new List<KeyValuePair<string, string>>();
        }
    class StubMappingGateway : MappingGateway
    {
        public Output map<Input, Output>(Input item)
        {
            object department = new Department {name = "this is a name", introduced_into_store_on = DateTime.Now};
            return (Output) department;
        }
    }
    }

}