using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application.stubs
{
    public class StubStoreCatalog : StoreCatalog
    {
        public IEnumerable<Department> get_the_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Main Department 0")});
        }

        public IEnumerable<Product> get_the_products_in(Department department)
        {
            return
                Enumerable.Range(1, 100).Select(
                    x => new Product {name = x.ToString("Product 0"), description = "Blah", price = .01m*x});
        }

        public IEnumerable<Department> get_the_departments_in(Department parent)
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Sub Department 0")});
        }
    }
}