using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        public bool can_handle(Request request)
        {
            throw new NotImplementedException();
        }

        public void process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}