using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.model;
using System.Collections.Generic;

namespace nothinbutdotnetstore.specs
{
    public class ViewTheProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheProductsInADepartment>
        {
        }

        [Subject(typeof(ViewTheProductsInADepartment))]
        public class when_run : concern
        {
            Establish e = () =>
            {
                request = an<Request>();
                rendering_gateway = the_dependency<RenderingGateway>();
                product_repository = the_dependency<ProductRepository>();

                the_list_of_products = new List<Product> { new Product() };
                department = new Department();

                request.setup(x => x.map<Department>()).Return(department);
                product_repository.setup(x => x.get_the_products_in(department)).
                    Return(the_list_of_products);
            };

            Because b = () =>
                sut.process(request);

            It should_get_list_of_products_of_the_from_the_producs_repository = () =>
            {
            };

            It should_pass_the_list_to_the_result_rendering_gateway = () =>
                rendering_gateway.received(x => x.render(the_list_of_products));


            static Request request;
            static ProductRepository product_repository;
            static IEnumerable<Product> the_list_of_products;
            static RenderingGateway rendering_gateway;
            static Department department;
        }
    }
}