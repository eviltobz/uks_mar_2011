using System;
using System.Text;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubUrlBuilderFactory
    {
        public static UrlBuilder create(Type type)
        {
            var token_store = new DefaultTokenStore<string, object>();
            return new DefaultUrlBuilder(type,
                                         new StubPayloadBuilderFactory(token_store),
                                         token_store,
                                         new DefaultUrlFormattingVistor(new StringBuilder()));
        }

        public class StubPayloadBuilderFactory : PayloadBuilderFactory
        {
            TokenStore<string, object> token_store;

            public StubPayloadBuilderFactory(TokenStore<string, object> token_store)
            {
                this.token_store = token_store;
            }

            public PayloadBuilder<ReportModel> create_for<ReportModel>(ReportModel some_report_model,
                                                                       TokenStore<string, object> token_store)
            {
                return new DefaultPayloadBuilder<ReportModel>(token_store, some_report_model,
                                                              new DefaultPropertyExpressionTokenFactory());
            }
        }
    }
}