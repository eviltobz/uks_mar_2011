using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application.stubs
{
    public class StubStoreCatalog : StoreCatalog
    {
        public IEnumerable<Department> get_the_main_departments()
        {
            return create_a_set_of(100, create_department("Main"));
        }

        public IEnumerable<Product> get_the_products_in(Department department)
        {
            return create_a_set_of(100,
                                   x =>
                                       new Product
                                       {name = x.ToString("Product 0"), description = "Blah", price = .01m*x});
        }

        public IEnumerable<Department> get_the_departments_in(Department parent)
        {
            return create_a_set_of(100, create_department("Sub"));
        }

        Func<int, Department> create_department(string department_prefix)
        {
            return x => new Department
            {
                name = string.Format("The {0} department {1}", department_prefix, x.ToString()),
            };
        }

        IEnumerable<ItemToCreate> create_a_set_of<ItemToCreate>(int number, Func<int, ItemToCreate> factory)
        {
            return Enumerable.Range(1, number).Select(factory);
        }
    }
}