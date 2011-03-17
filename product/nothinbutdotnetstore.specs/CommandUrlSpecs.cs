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
                () => { CommandUrl.to_run<SomeBehaviour>().ShouldEqual("SomeBehaviour.uk"); };
        }

        class SomeBehaviour : ApplicationBehaviour
        {
            public void process(Request request)
            {
            }
        }
    }
}