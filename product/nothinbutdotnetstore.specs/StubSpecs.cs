using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.specs
{
    public class StubSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Stub))]
        public class when_asked_to_create_a_stub_of_a_certain_type : concern
        {
            It should_return_an_instance_of_that_type = () =>
                Stub.with<StubType>().ShouldBeOfType(typeof(StubType));

            class StubType
            {
            }
        }
    }
}