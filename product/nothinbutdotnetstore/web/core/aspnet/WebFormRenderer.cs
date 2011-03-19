using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class WebFormRenderer : RenderingGateway
    {
        WebFormViewFactory web_form_view_factory;
        CurrentContextResolver current_context;

        public WebFormRenderer(WebFormViewFactory web_form_view_factory, CurrentContextResolver current_context)
        {
            this.web_form_view_factory = web_form_view_factory;
            this.current_context = current_context;
        }

        public void render<ReportModel>(ReportModel report_model)
        {
            web_form_view_factory.create_view_that_can_display(report_model).ProcessRequest(current_context());
        }
    }
}