using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;

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
            It first_observation = () => { };
        }
    }
}