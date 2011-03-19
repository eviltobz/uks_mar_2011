using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.frontcontroller;

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
                                                   Container.resolve.an<ViewTheMainDepartmentsInTheStore>());

            yield return new DefaultRequestCommand(IncomingRequest.is_for<ViewTheDepartmentsInADepartment>(),
                                                   Container.resolve.an<ViewTheDepartmentsInADepartment>());

            yield return new DefaultRequestCommand(IncomingRequest.is_for<ViewTheProductsInADepartment>(),
                                                   Container.resolve.an<ViewTheProductsInADepartment>());
        }
    }
}