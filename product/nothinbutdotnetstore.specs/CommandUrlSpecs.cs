using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core.frontcontroller;
using nothinbutdotnetstore.web.core.urls;

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
            Establish c = () =>
            {
                the_container = an<DependencyContainer>();
                ContainerResolver resolver = () => the_container;
                a_url_builder = an<UrlBuilder>();
                UrlBuilderFactory factory = (x) =>
                {
                    x.ShouldEqual(typeof(SomeBehaviour));
                    return a_url_builder;
                };
                the_container.setup(x => x.an<UrlBuilderFactory>()).Return(factory);
                change(() => Container.active_resolver).to(resolver);
            };

            Because b = () =>
                result = CommandUrl.to_run<SomeBehaviour>();

            It should_return_the_url_builder_created_by_the_factory = () =>
                result.ShouldEqual(a_url_builder);

            static UrlBuilder a_url_builder;
            static UrlBuilder result;
            static DependencyContainer the_container;
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