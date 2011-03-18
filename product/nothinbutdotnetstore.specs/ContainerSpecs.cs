using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.specs
{
    public class ContainerSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Container))]
        public class when_providing_access_to_the_underlying_container_facade : concern
        {
            Establish c = () =>
            {
                configured_facade = an<DependencyContainer>();
                ContainerResolver resolver = () => configured_facade;
                change(() => Container.active_resolver).to(resolver);
            };

            Because b = () =>
                result = Container.resolve;

            It should_return_the_configured_facade = () =>
                result.ShouldEqual(configured_facade);

            static DependencyContainer result;
            static DependencyContainer configured_facade;
        }
    }
}