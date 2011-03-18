using System.Collections.Generic;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core
{
    public interface  PropertyExpressionTokenFactory
    {
        KeyValuePair<string, object> create_from<Item, PropertyType>(Expression<PropertyAccessor<Item, PropertyType>> accessor, Item report_model);
    }

}