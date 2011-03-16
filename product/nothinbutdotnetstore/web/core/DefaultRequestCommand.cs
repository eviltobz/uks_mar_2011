using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestCriteria _criteria;

        public DefaultRequestCommand(RequestCriteria criteria)
        {
            _criteria = criteria;
        }

        public bool can_handle(Request request)
        {
            return _criteria(request);
        }

        public void process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}