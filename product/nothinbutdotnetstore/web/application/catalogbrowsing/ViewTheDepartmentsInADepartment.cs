using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheDepartmentsInADepartment : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        StoreCatalog department_repository;

        public ViewTheDepartmentsInADepartment(RenderingGateway rendering_gateway,
                                               StoreCatalog department_repository)
        {
            this.rendering_gateway = rendering_gateway;
            this.department_repository = department_repository;
        }

        public void process(Request request)
        {
            rendering_gateway.render(department_repository.get_the_departments_in(request.map<Department>()));
        }
    }
}