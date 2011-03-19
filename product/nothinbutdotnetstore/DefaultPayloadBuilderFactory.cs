using System;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore
{
    public class DefaultPayloadBuilderFactory : PayloadBuilderFactory
    {
        PropertyExpressionTokenFactory the_property_expression_token_factory;

        public DefaultPayloadBuilderFactory(PropertyExpressionTokenFactory the_property_expression_token_factory)
        {
            this.the_property_expression_token_factory = the_property_expression_token_factory;
        }

        public PayloadBuilder<ReportModel> create_for<ReportModel>(ReportModel some_report_model,
                                                                   TokenStore<string, object> token_store)
        {
            return new DefaultPayloadBuilder<ReportModel>(token_store, some_report_model,
                                                          the_property_expression_token_factory);
        }
    }
}