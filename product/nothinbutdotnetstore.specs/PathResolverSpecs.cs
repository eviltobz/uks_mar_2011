using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.specs
{
    public class PathResolverSpecs
    {
        public abstract class concern : Observes<PathResolver,
                                            DefaultPathResolver>
        {
        }

        [Subject(typeof(DefaultPathResolver))]
        public class when_getting_path : concern
        {
            Establish c = () =>
            {
                the_registry = the_dependency<UrlRegistry>();
                the_path = "blah";
                the_registry.setup(x=>x.get_path(typeof(SomeReportModelType))).Return(the_path);
            };

            Because b = () =>
                the_result = sut.get_path_for_view_that_can_display<SomeReportModelType>();


            It should_return_the_path_that_the_registry_returns = () =>
                the_result.ShouldEqual(the_path);

            static UrlRegistry the_registry;
            static string the_result;
            static string the_path;
        }

        public class SomeReportModelType
        {
        }
    }
}