using developwithpassion.specifications.extensions;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class ViewTheMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheMainDepartmentsInTheStore>
        {
        
        }

        [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
        public class when_run : concern
        {
            Establish e = () =>
            {
                department_repository = the_dependency<DepartmentRepository>();

                the_list_of_departments = new string[]{};

                department_repository.setup(x => x.get_all_departments()).
                    Return(the_list_of_departments);

                rendering_gateway = the_dependency<RenderingGateway>();

            };

            Because b = () =>
                sut.process(request);

            It should_get_list_of_departments_of_the_departments_repository = () =>
            {
                department_repository.received(x => x.get_all_departments());
            };

            It should_pass_the_list_to_the_result_rendering_gateway = () =>
            {
                rendering_gateway.received(x => x.render_response_for(request).using(the_list_of_departments))
                ;
            }


            static Request request;
            static DepartmentRepository department_repository;
            static string[] the_list_of_departments;
            static RenderingGateway rendering_gateway;
        }
    }

    interface RenderingGateway
    {
        object render_response_for(Request request);
    }

    interface DepartmentRepository
    {
        string[] get_all_departments();
    }
}
