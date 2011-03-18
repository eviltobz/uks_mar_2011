using System.Collections.Generic;
using System.Linq.Expressions;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class PayloadBuildSpecs
    {
        public abstract class concern : Observes<PayloadBuilder<SomeReportModel>,
                                            DefaultPayloadBuilder<SomeReportModel>>
        {
        }

        [Subject(typeof(DefaultPayloadBuilder<SomeReportModel>))]
        public class when_providing_an_expression_to_store_the_details_of : concern
        {
            Establish c = () =>
            {
                token_store = the_dependency<TokenStore<string,object>>();
                property_expression_token_factory = the_dependency<PropertyExpressionTokenFactory>();
                some_report_model = the_dependency<SomeReportModel>();

                a_token = new KeyValuePair<string, object>();
                accessor = x => x.name;

                property_expression_token_factory.setup(x => x.create_from(accessor, some_report_model)).Return(a_token);
            };

            Because b = () => { result = sut.with_detail(accessor); };

            It should_store_the_token_created_by_the_token_factory = () =>
                token_store.received(x => x.register(a_token));

            It should_return_a_new_payload_builder_with_the_right_information = () =>
                result.ShouldBeAn<DefaultPayloadBuilder<SomeReportModel>>().ShouldNotEqual(sut);

            static Expression<PropertyAccessor<SomeReportModel, string>> accessor;
            static PayloadBuilder<SomeReportModel> result;
            static TokenStore<string,object> token_store;
            static KeyValuePair<string, object> a_token;
            static SomeReportModel some_report_model;
            static PropertyExpressionTokenFactory property_expression_token_factory;
        }

        public class SomeReportModel
        {
            public string name { get; set; }
        }
    }
}