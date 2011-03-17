using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;

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
            yield return new DefaultRequestCommand(x => true,
                                                   new ViewAReportModel<IEnumerable<Product>>((x,y) => x.get_the_products_in(y.map<Department>())));
        }
    }
}