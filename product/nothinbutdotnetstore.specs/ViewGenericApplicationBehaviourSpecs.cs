using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewGenericApplicationBehaviourSpecs
    {
        public class concern : Observes<ApplicationBehaviour,
                                            ViewGenericApplicationBehaviour>
        {}

        public class when_run : concern
        {
            IEnumerable<SomeType>  vrq = ViewRepositoryQuery<SomeType>(x => x.get_the_products_in(Request.map<SomeType>));
            //.get_the_main_departments()
            //.get_the_departments_in(request.map<Department>())
            private It should_use_a_delegate_on_a_repository = () =>
                                                                      {
                                                                          
                                                                      };
             
            private It should_get_a_set_of_data_from_a_repository = () => { };

            private It should_pass_the_data_to_the_renderer = () => { };

            //get_the_products_in(request.map<Department>()
            private StoreCatalog catalog;
            
        }

        private class SomeType{}
        

        public delegate IEnumerable<SomeType> ViewRepositoryQuery<SomeType>(StoreCatalog catalog);
    }

}