using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<FrontController,
                                            DefaultFrontController>
        {
        
        }

        [Subject(typeof(DefaultFrontController))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                command_registry = the_dependency<CommandRegistry>();
                request = an<Request>();
                command_that_can_process_request = an<RequestCommand>();

                command_registry.setup(x => x.get_the_command_that_can_handle(request))
                    .Return(command_that_can_process_request);

            };

            Because b = () =>
                sut.process(request);


            It should_delegate_the_processing_to_the_command_that_can_provide_the_behaviour = () =>
                command_that_can_process_request.received(x => x.process(request));

            static RequestCommand command_that_can_process_request;
            static Request request;
            static CommandRegistry command_registry;
        }
    }
}
