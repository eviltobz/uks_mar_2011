using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;

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
            yield return new DefaultRequestCommand(IncomingRequest.is_for<ViewTheMainDepartmentsInTheStore>(),
                                                   new ViewTheMainDepartmentsInTheStore());

            yield return new DefaultRequestCommand(IncomingRequest.is_for<ViewTheDepartmentsInADepartment>(),
                                                   new ViewTheDepartmentsInADepartment());

            yield return new DefaultRequestCommand(IncomingRequest.is_for<ViewTheProductsInADepartment>(),
                                                   new ViewTheProductsInADepartment());
        }
    }
}