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
                                                   new ViewTheMainDepartmentsInTheStore());

            yield return new DefaultRequestCommand(x => true,
                                                   new ViewTheDepartmentsInADepartment());

            yield return new DefaultRequestCommand(x => true,
                                                   new ViewTheProductsInADepartment());
        }
    }
}