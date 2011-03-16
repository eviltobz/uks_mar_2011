using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class BasicHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            BasicHandler>
        {
        
        }

        [Subject(typeof(BasicHandler))]
        public class when_processing_an_http_context : concern
        {

            Establish c = () =>
            {
                front_controller = the_dependency<FrontController>();
                request_factory = the_dependency<RequestFactory>();
                request = an<Request>();
                the_current_context = ObjectFactory.create_http_context();

                request_factory.setup(x => x.create_from(the_current_context)).Return(request);

            };

            Because b = () =>
                sut.ProcessRequest(the_current_context);

            It should_delegate_the_processing_of_the_request_to_the_front_controller = () =>
                front_controller.received(x => x.process(request));

            static FrontController front_controller;
            static Request request;
            static HttpContext the_current_context;
            static RequestFactory request_factory;
        }
    }
}
