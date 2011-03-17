using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class UrlFilterSpecs
    {
        public abstract class concern : Observes<RequestContainsCommand>
        {
        }

        [Subject(typeof(RequestContainsCommand))]
        public class when_checking_if_a_requests_matches_a_behaviour : concern
        {
            Establish ctx = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument(typeof(SomeBehaviour));
            };

            Because b = () =>
                result = sut.matches(request);

            public class and_the_request_contains_the_behaviour : when_checking_if_a_requests_matches_a_behaviour
            {
                Establish c = () => 
                    request.setup(x => x.url).Return("SomeBehaviour.uk"); 

                It should_match = () =>
                    result.ShouldBeTrue();
            }

            public class and_the_request_is_not_for_the_behaviour : when_checking_if_a_requests_matches_a_behaviour
            {
                Establish c = () =>
                    request.setup(x => x.url).Return(string.Empty);
                It should_not_match = () =>
                    result.ShouldBeFalse();
            }

            static Request request;
            static bool result;
        }

        public class SomeBehaviour : ApplicationBehaviour
        {
            public void process(Request request)
            {
            }
        }
    }
}