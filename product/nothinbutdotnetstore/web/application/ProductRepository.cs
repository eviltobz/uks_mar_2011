using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application
{
    public interface ProductRepository
    {
        IEnumerable<Product> get_the_products_in(Department department);
    }
}
