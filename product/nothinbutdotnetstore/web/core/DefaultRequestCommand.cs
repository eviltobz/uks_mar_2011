using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        readonly RequestCriteria request_criteria;

        public DefaultRequestCommand(RequestCriteria request_criteria)
        {
            this.request_criteria = request_criteria;
        }

        public bool can_handle(Request request)
        {
            return request_criteria(request);  
        }

        public void process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}