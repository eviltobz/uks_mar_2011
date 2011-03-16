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
            return new StubRequest();
        }

        class StubRequest : Request
        {

            public InputModel map<InputModel>()
            {
                object item = new Department();
                return (InputModel) item;
            }
        }
    }
}