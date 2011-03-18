using System;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultPayloadBuilder<ItemWithProperty> : PayloadBuilder<ItemWithProperty>
    {
        public string with_detail<PropertyType>(Expression<PropertyAccessor<ItemWithProperty, PropertyType>> accessor)
        {
            throw new NotImplementedException();
        }
    }
}