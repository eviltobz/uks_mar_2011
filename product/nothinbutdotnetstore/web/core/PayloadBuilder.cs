using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core
{
    public interface PayloadBuilder<ItemWithProperty>
    {
        PayloadBuilder<ItemWithProperty> with_detail<PropertyType>(Expression<PropertyAccessor<ItemWithProperty, PropertyType>> accessor);
    }
}