using System;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class RequestContainsCommand
    {
        Type command_type;

        public RequestContainsCommand(Type command_type)
        {
            this.command_type = command_type;
        }

        public bool matches(Request request)
        {
            return request.url.Contains(command_type.Name);
        }
    }
}