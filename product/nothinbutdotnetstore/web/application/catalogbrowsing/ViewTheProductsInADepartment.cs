using System;
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheProductsInADepartment : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        StoreCatalog product_repository;

        public ViewTheProductsInADepartment():this(Stub.with<StubStoreCatalog>(),
            Stub.with<StubRenderingGateway>())
        {
        }

        public ViewTheProductsInADepartment(StoreCatalog product_repository, RenderingGateway rendering_gateway)
        {
            this.product_repository = product_repository;
            this.rendering_gateway = rendering_gateway;
        }

        public void process(Request request)
        {
            rendering_gateway.render(product_repository.get_the_products_in(request.map<Department>()));
        }
    }
}