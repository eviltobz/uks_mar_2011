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

                var dic = new Dictionary<string, string>();
                dic.Add("department_name", department_name);
                request.setup(x=>x.get_parameters()).Return(dic);
                department_repository.setup(x => x.get_the_sub_departments(department_name)).
                    Return(the_list_of_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_get_list_of_departments_of_the_from_the_departments_repository = () =>
            {
            };

            It should_pass_the_list_to_the_result_rendering_gateway = () =>
                rendering_gateway.received(x => x.render(the_list_of_departments));

            static string department_name = "your mum";
            static Request request;
            static DepartmentRepository department_repository;
            static IEnumerable<Department> the_list_of_departments;
            static RenderingGateway rendering_gateway;
        }
    }
}