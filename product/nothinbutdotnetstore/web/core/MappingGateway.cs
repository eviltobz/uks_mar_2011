namespace nothinbutdotnetstore.web.core
{
    public interface MappingGateway
    {
        Output map<Input, Output>(Input item);
    }
}