using System.Collections.Generic;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class GetDepartmentsInDepartment
    {
        StoreCatalog catalog;

        public GetDepartmentsInDepartment(StoreCatalog catalog)
        {
            this.catalog = catalog;
        }

        public IEnumerable<Department> run(Request request)
        {
            return catalog.get_the_departments_in(request.map<Department>());
        }
    }
}