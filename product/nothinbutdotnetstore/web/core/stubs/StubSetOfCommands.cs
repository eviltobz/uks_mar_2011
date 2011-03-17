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
            yield return new DefaultRequestCommand(x=>UrlFilter.Matches<ViewTheMainDepartmentsInTheStore>(x),
                                                   new ViewTheMainDepartmentsInTheStore());

            yield return new DefaultRequestCommand(x => UrlFilter.Matches<ViewTheDepartmentsInADepartment>(x),
                                                   new ViewTheDepartmentsInADepartment());

            yield return new DefaultRequestCommand(x => UrlFilter.Matches<ViewTheProductsInADepartment>(x),
                                                   new ViewTheProductsInADepartment());
        }
    }
}