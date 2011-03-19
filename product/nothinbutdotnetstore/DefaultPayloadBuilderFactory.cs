using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.payloads;

namespace nothinbutdotnetstore
{
    public class DefaultPayloadBuilderFactory : PayloadBuilderFactory
    {
        PropertyExpressionTokenFactory the_property_expression_token_factory;

        public DefaultPayloadBuilderFactory(PropertyExpressionTokenFactory the_property_expression_token_factory)
        {
            this.the_property_expression_token_factory = the_property_expression_token_factory;
        }

        public PayloadBuilder<ReportModel> create_for<ReportModel>(ReportModel report_model,
                                                                   TokenStore<string, object> token_store)
        {
            return new DefaultPayloadBuilder<ReportModel>(token_store, report_model,
                                                          the_property_expression_token_factory);
        }
    }
}