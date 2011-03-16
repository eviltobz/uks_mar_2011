using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application.stubs
{
    public class StubDepartmentsRepository : DepartmentRepository
    {
        public IEnumerable<Department> get_the_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Main Department 0")});
        }

        public IEnumerable<Department> get_the_departments_in(Department parent)
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Sub Department 0")});
        }
    }
}