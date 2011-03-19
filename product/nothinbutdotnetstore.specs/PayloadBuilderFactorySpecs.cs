using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.payloads;

namespace nothinbutdotnetstore.specs
{
    public class PayloadBuilderFactorySpecs
    {
        public abstract class concern : Observes<PayloadBuilderFactory,
                                            DefaultPayloadBuilderFactory>
        {
        }

        [Subject(typeof(DefaultPayloadBuilderFactory))]
        public class when_creating_a_builder_for_a_report_model : concern
        {
            Establish c = () =>
            {
                the_tokenstore = an<TokenStore<string, object>>();
                the_report_model = new SomeReportModelType();
                the_property_expression_token_factory = the_dependency<PropertyExpressionTokenFactory>();
            };

            Because b = () =>
                result = sut.create_for(the_report_model, the_tokenstore);

            It should_return_a_new_default_payloadbuilder_with_the_correct_fields = () =>
            {
                var real_result = result.ShouldBeAn<DefaultPayloadBuilder<SomeReportModelType>>();

                real_result.token_store.Equals(the_tokenstore).ShouldBeTrue();
                real_result.item_with_property.ShouldEqual(the_report_model);
                real_result.token_factory.ShouldEqual(the_property_expression_token_factory);
            };

            static TokenStore<string, object> the_tokenstore;
            static SomeReportModelType the_report_model;
            static PayloadBuilder<SomeReportModelType> result;
            static PropertyExpressionTokenFactory the_property_expression_token_factory;

            public class SomeReportModelType
            {
            }
        }
    }
}