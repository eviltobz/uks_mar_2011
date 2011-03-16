using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application
{
    public interface StoreCatalog
    {
        IEnumerable<Department> get_the_main_departments();
        IEnumerable<Department> get_the_departments_in(Department department);
        IEnumerable<Product> get_the_products_in(Department department);
    }
}