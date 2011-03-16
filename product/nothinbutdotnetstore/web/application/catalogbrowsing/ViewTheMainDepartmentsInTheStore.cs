using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheMainDepartmentsInTheStore : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        DepartmentRepository department_repository;

        public ViewTheMainDepartmentsInTheStore() : this(Stub.with<StubRenderingGateway>(),
                                                         Stub.with<StubDepartmentsRepository>())
        {
        }

        public ViewTheMainDepartmentsInTheStore(RenderingGateway rendering_gateway,
                                                DepartmentRepository department_repository)
        {
            this.rendering_gateway = rendering_gateway;
            this.department_repository = department_repository;
        }

        public void process(Request request)
        {
            rendering_gateway.render(department_repository.get_the_main_departments());
        }
    }
}