using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.application.stubs;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<RequestCommand> GetEnumerator()
        {
            yield return new DefaultRequestCommand(x => false,
                                                   new ViewAReportModel<IEnumerable<Department>>((y) => Stub.with<StubStoreCatalog>().get_the_main_departments()));
            yield return new DefaultRequestCommand(x => true,
                                                   new ViewAReportModel<IEnumerable<Product>>((y) => Stub.with<StubStoreCatalog>().get_the_products_in(y.map<Department>())));
            yield return new DefaultRequestCommand(x => true,
                                                   new ViewAReportModel<IEnumerable<Department>>((y) => Stub.with<StubStoreCatalog>().get_the_departments_in(y.map<Department>())));
        }
    }
}