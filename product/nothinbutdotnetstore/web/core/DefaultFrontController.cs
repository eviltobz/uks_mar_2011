using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
    	readonly CommandRegistry command_registry;

    	public DefaultFrontController(CommandRegistry commandRegistry)
    	{
    		command_registry = commandRegistry;
    	}

    	public void process(Request request)
    	{
    		RequestCommand command = command_registry.get_the_command_that_can_handle(request);
			command.process(request);
    	}
    }
}