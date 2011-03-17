using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewGenericApplicationBehaviourSpecs
    {
        public class concern : Observes<ApplicationBehaviour,
                                   ViewAReportModel<IEnumerable<SomeType>>>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                all_numbers = Enumerable.Range(1, 100).Select(x => new SomeType()).ToList();
                renderer = the_dependency<RenderingGateway>();
                the_catalog = the_dependency<StoreCatalog>();
                the_request = an<Request>();

                provide_a_basic_sut_constructor_argument<ViewRepositoryQuery<IEnumerable<SomeType>>>((x, y) =>
                {
                    x.ShouldEqual(the_catalog);
                    y.ShouldEqual(the_request);
                    return all_numbers;
                });
            };

            Because b = () =>
                sut.process(the_request);

            It should_tell_the_renderer_to_display_the_information_retrieved_by_the_query = () =>
                renderer.received(x => x.render(all_numbers));

            static ViewRepositoryQuery<IEnumerable<SomeType>> query;
            static RenderingGateway renderer;
            static Request request;
            static IEnumerable<SomeType> all_numbers;
            static StoreCatalog the_catalog;
            static Request the_request;
        }

        public class SomeType
        {
        }
    }
}