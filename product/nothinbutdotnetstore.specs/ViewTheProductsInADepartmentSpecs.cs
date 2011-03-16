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
                store_catalog = the_dependency<StoreCatalog>();

                the_list_of_products = new List<Product> { new Product() };
                department_with_products = new Department();

                request.setup(x => x.map<Department>()).Return(department_with_products);

                store_catalog.setup(x => x.get_the_products_in(department_with_products)).
                    Return(the_list_of_products);
            };

            Because b = () =>
                sut.process(request);

            It should_pass_the_list_to_the_result_rendering_gateway = () =>
                rendering_gateway.received(x => x.render(the_list_of_products));


            static Request request;
            static StoreCatalog store_catalog;
            static IEnumerable<Product> the_list_of_products;
            static RenderingGateway rendering_gateway;
            static Department department_with_products;
        }
    }
}