using System;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using Machine.Specifications;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class PayloadBuilderFactorySpecs
    {
        public abstract class concern : Observes<PayloadBuilderFactory,
                                            DefaultPayloadBuilderFactory>
        {
        }

        [Subject(typeof(DefaultPayloadBuilderFactory))]
        public class when_observation_name : concern
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
                result.ShouldBeAn<DefaultPayloadBuilder<SomeReportModelType>>();
                result.downcast_to<DefaultPayloadBuilder<SomeReportModelType>>().token_store.ShouldEqual(the_tokenstore);
                result.downcast_to<DefaultPayloadBuilder<SomeReportModelType>>().item_with_property.ShouldEqual(
                    the_report_model);
                result.downcast_to<DefaultPayloadBuilder<SomeReportModelType>>().token_factory.ShouldEqual(
                    the_property_expression_token_factory);
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