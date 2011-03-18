using System.Collections.Generic;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultPropertyExpressionTokenFactory : PropertyExpressionTokenFactory
    {
        public KeyValuePair<string, object> create_from<Item, PropertyType>(
            Expression<PropertyAccessor<Item, PropertyType>> accessor, Item report_model)
        {
            return new KeyValuePair<string, object>(((MemberExpression) accessor.Body).Member.Name,
                                                    accessor.Compile()(report_model));
        }
    }
}