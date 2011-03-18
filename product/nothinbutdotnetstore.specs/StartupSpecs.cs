using System;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class StartupSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Startup))]
        public class when_run : concern
        {
            Because b = () =>
                Startup.run();

            It should_have_initialized_a_url_builder_factory = () =>
                CommandUrl.url_builder_factory(typeof(SomeCommand));
        }

        public class SomeCommand : ApplicationBehaviour
    {
        public void process(Request request)
        {
            throw new NotImplementedException();
        }
    }
    }

}