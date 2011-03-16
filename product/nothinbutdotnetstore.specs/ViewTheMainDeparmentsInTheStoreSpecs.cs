using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class ViewTheMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheMainDepartmentsInTheStore>
        {
        
        }

        [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
        public class when_run : concern
        {

            Because b = () =>
                sut.process(request);

            It first_observation = () =>

            static Request request;        
                
        }
    }
}
