using System;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultPayloadBuilder<ItemWithProperty> : PayloadBuilder<ItemWithProperty>
    {
        readonly TokenStore token_store;
        readonly ItemWithProperty item_with_property;
        readonly PropertyExpressionTokenFactory token_factory;

        public DefaultPayloadBuilder(TokenStore token_store, ItemWithProperty item_with_property,
            PropertyExpressionTokenFactory token_factory)
        {
            this.token_store = token_store;
            this.item_with_property = item_with_property;
            this.token_factory = token_factory;
        }

        public string with_detail<PropertyType>(Expression<PropertyAccessor<ItemWithProperty, PropertyType>> accessor)
        {
            token_store.register(token_factory.create_from(accessor, item_with_property));
            return string.Empty;
        }
    }
}