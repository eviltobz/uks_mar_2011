namespace nothinbutdotnetstore.web.core
{
    public interface RequestCommand : ApplicationBehaviour
    {
        bool can_handle(Request request);
    }
}