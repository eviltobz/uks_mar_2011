using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewAReportModel<ReportModel> : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        Query<ReportModel> query;

        public ViewAReportModel(RenderingGateway rendering_gateway, Query<ReportModel> query)
        {
            this.rendering_gateway = rendering_gateway;
            this.query = query;
        }

        public void process(Request request)
        {
            rendering_gateway.render(query(request));
        }
    }
}