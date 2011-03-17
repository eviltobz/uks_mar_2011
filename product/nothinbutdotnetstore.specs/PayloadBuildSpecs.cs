using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;
using System.Collections.Generic;

namespace nothinbutdotnetstore.specs
{   
    public class PayloadBuildSpecs
    {
        public abstract class concern : Observes<PayloadBuilder<ReportModel>,
                                            DefaultPayloadBuilder<ReportModel>>
        {
        
        }

        [Subject(typeof(DefaultPayloadBuilder<ReportModel>))]
        public class when_providing_a_property_accessor_pointing_to_potential_payload_information : concern
        {
            Establish c = () =>
            {
                token_store = the_dependency<TokenStore>();
                report_model = the_dependency<ReportModel>();
                token_factory = the_dependency<TokenFactory<ReportModel, PropertyType>>();
                a_token = token_factory(report_model, accessor);
            };

            Because b = () =>
            {
                result = sut.with_detail(accessor);
            };

            It should_store_a_token_into_the_token_store = () =>
            {
                token_store.received(x => x.register(a_token));
            };

            static PropertyAccessor<ReportModel, PropertyType> accessor;
            static string result;
            static TokenStore token_store;
            static KeyValuePair<string, object> a_token;
            static ReportModel report_model;
            static TokenFactory<ReportModel, PropertyType> token_factory;
        }

        class PropertyType {}
        public class ReportModel {}    
    }
}
