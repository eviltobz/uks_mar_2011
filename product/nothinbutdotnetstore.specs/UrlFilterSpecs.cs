using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class UrlFilterSpecs
    {
        public abstract class concern : Observes<UrlFilter>
        {
        }

        [Subject(typeof(UrlFilter))]
        public class when_checking_if_a_requests_matches_a_behaviour : concern
        {
            Establish ctx = () =>
            {
                request = an<Request>();
            };

            It should_return_true_if_the_request_url_contains_the_behaviour_typename_dot_uk =
                () =>
                {
                    request.url = "SomeBehaviour.uk";
                    UrlFilter.Matches<SomeBehaviour>(request).ShouldBeTrue();
                };


            It should_return_false_if_the_request_url_does_not_contain_the_behaviour_typename_dot_uk =
                () =>
                {
                    request.url = "SomeOtherBehaviour.uk";
                    UrlFilter.Matches<SomeBehaviour>(request).ShouldBeFalse();
                };

            static Request request;
        }

        public class SomeBehaviour : ApplicationBehaviour
        {
            public void process(Request request)
            {
            }
        }
    }
}