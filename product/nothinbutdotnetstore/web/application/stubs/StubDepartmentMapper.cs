using System;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application.stubs
{
    class StubDepartmentMapper : Mapper<TokenStore<string, string>,Department>
    {
        public Department map(TokenStore<string, string> item)
        {
            return new Department {name = "basdfsf", introduced_into_store_on = DateTime.Now};
        }
    }
}