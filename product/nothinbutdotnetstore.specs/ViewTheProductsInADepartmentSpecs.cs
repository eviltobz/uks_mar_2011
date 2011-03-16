using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewTheProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheProductsInADepartment>
        {
        }

        [Subject(typeof(ViewTheProductsInADepartment))]
        public class when_run : concern
        {
            It first_observation = () => { };

        }
    }
}