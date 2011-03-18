using System;
using System.Linq.Expressions;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultPayloadBuilder<ItemWithProperty> : PayloadBuilder<ItemWithProperty>
    {
        readonly TokenStore<string,object> token_store;
        readonly ItemWithProperty item_with_property;
        readonly PropertyExpressionTokenFactory token_factory;

        public DefaultPayloadBuilder(TokenStore<string,object> token_store, ItemWithProperty item_with_property,
                                     PropertyExpressionTokenFactory token_factory)
        {
            this.token_store = token_store;
            this.item_with_property = item_with_property;
            this.token_factory = token_factory;
        }

        public PayloadBuilder<ItemWithProperty> with_detail<PropertyType>(Expression<PropertyAccessor<ItemWithProperty, PropertyType>> accessor)
        {
            token_store.register(token_factory.create_from(accessor, item_with_property));
            return new DefaultPayloadBuilder<ItemWithProperty>(token_store,item_with_property, token_factory);
        }
    }
}