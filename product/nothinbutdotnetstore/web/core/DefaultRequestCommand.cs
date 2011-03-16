namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestCriteria request_criteria;
        ApplicationBehaviour application_behaviour;

        public DefaultRequestCommand(RequestCriteria request_criteria, ApplicationBehaviour application_behaviour)
        {
            this.request_criteria = request_criteria;
            this.application_behaviour = application_behaviour;
        }

        public bool can_handle(Request request)
        {
            return request_criteria(request);
        }

        public void process(Request request)
        {
            application_behaviour.process(request);
        }
    }
}