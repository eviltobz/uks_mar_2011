using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;

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
                a_url_builder = an<UrlBuilder>();
                UrlBuilderFactory factory = (x) =>
                {
                    x.ShouldEqual(typeof(SomeBehaviour));
                    return a_url_builder;
                };
                change(() => CommandUrl.url_builder_factory).to(factory);
            };

            Because b = () =>
                result = CommandUrl.to_run<SomeBehaviour>();

            It should_return_a_url_builder_created_using_the_type_of_the_command_requested = () =>
                result.ShouldEqual(a_url_builder);

            static UrlBuilder a_url_builder;
            static UrlBuilder result;
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