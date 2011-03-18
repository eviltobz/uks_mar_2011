using System.Collections.Generic;
using System.Linq.Expressions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class PropertyExpressionTokenFactorySpecs
    {
        public abstract class concern : Observes<PropertyExpressionTokenFactory,
                                            DefaultPropertyExpressionTokenFactory>
        {
        }

        [Subject(typeof(PropertyExpressionTokenFactory))]
        public class when_creating_a_token : concern
        {
            Establish c = () =>
            {
                report_model = an<AReportModel>();
                accessor = (aReportModel) => aReportModel.name;
                the_key = "name";
                the_value = new APropertyType();
                report_model.name = the_value;
            };

            Because b = () =>
                token = sut.create_from(accessor, report_model);

            It should_create_a_token_with_a_key_equal_to_the_accessor_property_name
                = () => token.Key.ShouldEqual(the_key);

            It should_create_a_token_with_a_value_equal_to_the_value_of_the_accessor_property_on_the_report_model
                = () => token.Value.ShouldEqual(the_value);

            static KeyValuePair<string, object> token;
            static string the_key;
            static APropertyType the_value;
            static Expression<PropertyAccessor<AReportModel, APropertyType>> accessor;
            static AReportModel report_model;
        }

        public class AReportModel
        {
            public APropertyType name { get; set; }
        }

        public class APropertyType
        {
        }
    }
}