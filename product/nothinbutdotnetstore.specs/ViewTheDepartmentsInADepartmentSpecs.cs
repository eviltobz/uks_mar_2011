using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewTheDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheDepartmentsInADepartment>
        {
        }

        [Subject(typeof(ViewTheDepartmentsInADepartment))]
        public class when_run : concern
        {
            Establish e = () =>
            {
                request = an<Request>();
                rendering_gateway = the_dependency<RenderingGateway>();
                department_repository = the_dependency<DepartmentRepository>();

                the_list_of_departments = new List<Department> { new Department() };
                parent_department = new Department();

                request.setup(x=>x.map<Department>()).Return(parent_department);

                department_repository.setup(x => x.get_the_departments_in(parent_department)).
                    Return(the_list_of_departments);
            };

            Because b = () =>
                sut.process(request);


            It should_tell_the_rendering_gateway_to_display_the_sub_departments = () =>
                rendering_gateway.received(x => x.render(the_list_of_departments));

            static Request request;
            static DepartmentRepository department_repository;
            static IEnumerable<Department> the_list_of_departments;
            static RenderingGateway rendering_gateway;
            static Department parent_department;
        }
    }
}