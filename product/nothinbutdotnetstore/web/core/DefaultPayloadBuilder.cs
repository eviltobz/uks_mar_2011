using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultPayloadBuilder<ItemWithProperty> : PayloadBuilder<ItemWithProperty>
    {
        public string with_detail<PropertyType>(PropertyAccessor<ItemWithProperty, PropertyType> accessor)
        {
            throw new NotImplementedException();
        }
    }
}