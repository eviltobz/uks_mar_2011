namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface RequestCommand : ApplicationBehaviour
    {
        bool can_handle(Request request);
    }
}