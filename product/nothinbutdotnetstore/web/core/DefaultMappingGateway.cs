using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultMappingGateway : MappingGateway
    {
        DependencyContainer container;

        public DefaultMappingGateway(DependencyContainer container)
        {
            this.container = container;
        }

        public Output map<Input, Output>(Input item)
        {
            return container.an<Mapper<Input, Output>>().map(item);
        }
    }
}