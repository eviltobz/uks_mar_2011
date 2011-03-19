using System.Web;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.specs
{
    public class RenderingGatewaySpecs
    {
        public abstract class concern : Observes<RenderingGateway,
                                            WebFormRenderer>
        {
        }

        [Subject(typeof(WebFormRenderer))]
        public class when_rendering_a_report_model : concern
        {
            Establish c = () =>
            {
                view_factory = the_dependency<WebFormViewFactory>();
                model = new OurModel();
                view = an<IHttpHandler>();
                the_current_context = ObjectFactory.create_http_context();

                provide_a_basic_sut_constructor_argument<CurrentContextResolver>(() => the_current_context);

                view_factory.setup(x => x.create_view_that_can_display(model)).Return(view);
            };

            Because b = () =>
                sut.render(model);

            It should_tell_the_factory_to_create_a_view_to_render_the_model = () =>
                view_factory.received(x => x.create_view_that_can_display(model));

            It should_tell_the_view_to_render = () =>
                view.received(x => x.ProcessRequest(the_current_context));

  

            static WebFormViewFactory view_factory;
            static OurModel model;
            static IHttpHandler view;
            static HttpContext the_current_context;
        }

        public class OurModel
        {
        }
    }
}