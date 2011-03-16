using System;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheProductsInADepartment : ApplicationBehaviour
    {
        public ViewTheProductsInADepartment(ProductRepository product_repository, RenderingGateway rendering_gateway)
        {
            this.product_repository = product_repository;
            this.rendering_gateway = rendering_gateway;
        }

        ProductRepository product_repository;
        RenderingGateway rendering_gateway;

        public void process(Request request)
        {
            rendering_gateway.render(product_repository.get_the_products_in(request.map<Department>()));
        }
    }
}