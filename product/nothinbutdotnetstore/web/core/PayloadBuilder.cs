using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core
{
    public interface PayloadBuilder<ItemWithProperty>
    {
        string with_detail<PropertyType>(Expression<PropertyAccessor<ItemWithProperty, PropertyType>> accessor);
    }
}