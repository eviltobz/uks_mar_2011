namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry command_registry;

        public DefaultFrontController():this(new DefaultCommandRegistry())
        {
        }

        public DefaultFrontController(CommandRegistry commandRegistry)
        {
            command_registry = commandRegistry;
        }

        public void process(Request request)
        {
            command_registry.get_the_command_that_can_handle(request).process(request);
        }
    }
}