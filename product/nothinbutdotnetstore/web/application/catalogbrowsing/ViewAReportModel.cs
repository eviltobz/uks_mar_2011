using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewAReportModel<ReportModel> : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        StoreCatalog general_catalog;
        ViewRepositoryQuery<ReportModel> query;

        public ViewAReportModel(ViewRepositoryQuery<ReportModel> query) : this(new WebFormRenderer(),
                                                        Stub.with<StubStoreCatalog>(), query)
        {
            this.query = query;
        }

        public ViewAReportModel(RenderingGateway rendering_gateway,
                                               StoreCatalog catalog, ViewRepositoryQuery<ReportModel> query)
        {
            this.rendering_gateway = rendering_gateway;
            this.query = query;
            this.general_catalog = catalog;
        }

        public void process(Request request)
        {
            rendering_gateway.render(query(general_catalog, request));
        }
    }
}