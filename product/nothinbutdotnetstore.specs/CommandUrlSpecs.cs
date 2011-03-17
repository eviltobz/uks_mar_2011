using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class CommandUrlSpecs
    {
        public abstract class concern : Observes<CommandUrl>
        {
        }

        [Subject(typeof(CommandUrl))]
        public class when_requesting_a_url_for_a_given_command : concern
        {
            It should_return_the_correct_url =
                () => { CommandUrl.to_run<SomeBehaviour>().ToString().ShouldEqual("SomeBehaviour.uk"); };
        }

        public class when_including_a_parameter_to_the_command_url : concern
        {
            Establish c = () =>
            {
                some_parameter = new SomeParameter {the_answer = 42};
            };

            It should_return_the_correct_url = () => 
                 CommandUrl.to_run<SomeBehaviour>().include(some_parameter).with_detail(x => x.the_answer)
                 .ToString().ShouldEqual("SomeBehaviour.uk?the_answer=42");

            static SomeParameter some_parameter;
        }

        class SomeBehaviour : ApplicationBehaviour
        {
            public void process(Request request)
            {
            }
        }

        public class SomeParameter
        {
            public int the_answer { get; set; }
        }
    }
}