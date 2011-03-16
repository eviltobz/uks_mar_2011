using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application
{
    public interface DepartmentRepository
    {
        IEnumerable<Department> get_the_main_departments();
    }
}