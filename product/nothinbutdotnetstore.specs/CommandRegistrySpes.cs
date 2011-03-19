using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.specs
{   
    public class CommandRegistrySpes
    {
        public abstract class concern : Observes<CommandRegistry,
                                            DefaultCommandRegistry>
        {
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_getting_a_command_to_handle_a_request_and_it_does_not_have_the_command: concern
        {

            Establish c = () =>
            {
                request =an<Request>();
                missing_command = an<RequestCommand>();
                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(new List<RequestCommand>());
                provide_a_basic_sut_constructor_argument<MissingCommandFactory>(() => missing_command);

            };

            Because b = () =>
                result = sut.get_the_command_that_can_handle(request);

            It should_return_the_missing_command_strategy = () =>
                result.ShouldEqual(missing_command);

            static RequestCommand result;
            static Request request;
            static RequestCommand missing_command;
        }
        [Subject(typeof(DefaultCommandRegistry))]
        public class when_getting_a_command_to_handle_a_request_and_it_has_the_command : concern
        {

            Establish c = () =>
            {
                request =an<Request>();
                the_command_that_can_handle = an<RequestCommand>();
                all_commands = Enumerable.Range(1,100).Select(x => an<RequestCommand>()).ToList();
                all_commands.Add(the_command_that_can_handle);

                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);

                the_command_that_can_handle.setup(x => x.can_handle(request)).Return(true);

            };
            Because b = () =>
                result = sut.get_the_command_that_can_handle(request);

            It should_return_the_command_that_can_process_the_request = () =>
                result.ShouldEqual(the_command_that_can_handle);

            static RequestCommand result;
            static RequestCommand the_command_that_can_handle;
            static Request request;
            static List<RequestCommand> all_commands;
        }
    }
}
