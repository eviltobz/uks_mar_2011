using System;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.frontcontroller;

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

            It should_have_configured_the_container = () =>
                Container.resolve.ShouldNotBeNull();

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