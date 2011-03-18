using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubUrlBuilderFactory
    {
        public UrlBuilder create(Type command_behaviour)
        {
            return new DefaultUrlBuilder(command_behaviour,
                                         new StubPayloadBuilderFactory(),
                                         new DefaultTokenStore(),
                                         new StubUrlFormattingVisitor());
        }

        class StubPayloadBuilderFactory : PayloadBuilderFactory
        {
            public PayloadBuilder<ReportModel> create_for<ReportModel>(ReportModel some_report_model, TokenStore token_store)
            {
                return new DefaultPayloadBuilder<ReportModel>(token_store, some_report_model,
                                                              new StubExpressionFactory());
                //return new DefaultPayloadBuilder<ReportModel>(token_store, some_report_model,
                //                                              detail_builder);
            }
        }

        class StubUrlFormattingVisitor : UrlFormattingVisitor
        {
            StringBuilder builder;

            public StubUrlFormattingVisitor()
            {
                builder = new StringBuilder();
            }

            public void process(KeyValuePair<string, object> item)
            {
                if (builder.Length == 0)
                    builder.AppendFormat("{0}.uk", item.Value);
                else
                    builder.AppendFormat("?{0}={1}", item.Key, item.Value);
            }

            public string get_result()
            {
                return builder.ToString();
            }
        }

        class StubExpressionFactory : PropertyExpressionTokenFactory
        {
            public KeyValuePair<string, object> create_from<Item, PropertyType>(
                Expression<PropertyAccessor<Item, PropertyType>> accessor, Item report_model)
            {
                return new KeyValuePair<string, object>(((MemberExpression) accessor.Body).Member.Name,
                                                        accessor.Compile()(report_model));
            }
        }
    }
}