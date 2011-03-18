using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.utility.containers;
using developwithpassion.specifications.extensions;

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

        public class when_attempting_to_provide_to_the_underlying_container_facade_and_no_facade_has_been_configured : concern
        {

            Because b = () =>
                catch_exception(() =>
                {
                    var item = Container.resolve;   
                });

            It should_throw_a_container_unconfigured_exception = () =>
                exception_thrown_by_the_sut.ShouldBeAn<ContainerUnconfiguredException>();

            static DependencyContainer result;
            static DependencyContainer configured_facade;
        }
    }
}