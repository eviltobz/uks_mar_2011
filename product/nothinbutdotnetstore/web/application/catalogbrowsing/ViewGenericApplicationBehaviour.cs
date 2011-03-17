using System;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewGenericApplicationBehaviour : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        StoreCatalog general_catalog;

        public ViewGenericApplicationBehaviour() : this(new WebFormRenderer(),
                                                        Stub.with<StubStoreCatalog>())
        {
        }

        public ViewGenericApplicationBehaviour(RenderingGateway rendering_gateway,
                                               StoreCatalog catalog)
        {
            this.rendering_gateway = rendering_gateway;
            this.general_catalog = catalog;
        }

        public void process(Request request)
        {
            rendering_gateway.render(general_catalog.get_the_departments_in(request.map<Department>()));
        }
    }
}