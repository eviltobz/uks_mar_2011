using System;
using System.Collections.Generic;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlBuilder : UrlBuilder
    {
        PayloadBuilderFactory payload_builder_factory;
        TokenStore<string,object> token_store;
        UrlFormattingVisitor url_formatting_visitor;
        Type command_to_run;

        public DefaultUrlBuilder(Type command_to_run, PayloadBuilderFactory payload_builder_factory, TokenStore<string,object> token_store, UrlFormattingVisitor url_formatting_visitor)
        {
            this.command_to_run = command_to_run;
            this.url_formatting_visitor = url_formatting_visitor;
            this.token_store = token_store;
            this.payload_builder_factory = payload_builder_factory;

            token_store.register(new KeyValuePair<string, object>("Foo",command_to_run));
        }

        public UrlBuilder include<ItemWithProperty>(ItemWithProperty some_report_model, PayloadBuilderVisitor<ItemWithProperty> visitor)
        {
            visitor(payload_builder_factory.create_for(some_report_model, token_store));
            return this;
        }

        public override string ToString()
        {
            return token_store.get_the_result_of_visiting_all_items_with(url_formatting_visitor);
        }
    }
}
