namespace nothinbutdotnetstore.utility.mapping
{
    public interface MappingGateway
    {
        Output map<Input, Output>(Input item);
    }
}