using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public class AutomaticDependencyFactory : DependencyFactory
    {
        readonly ConstructorSelection constructor_selection;

        public AutomaticDependencyFactory(ConstructorSelection constructor_selection, Type type_to_create)
        {
            this.constructor_selection = constructor_selection;
            this.type_to_create = type_to_create;
        }

        Type type_to_create;
        public object create()
        {
            var constructor_argument_values = new List<object>();
            
            var constructor_info = constructor_selection.Invoke(type_to_create);
            var constructor_arguments = constructor_info.GetParameters();
            foreach (var constructor_argument in constructor_arguments)
            {
                constructor_argument_values.Add(Container.resolve.an(constructor_argument.ParameterType));


            }
            return constructor_info.Invoke(constructor_argument_values.ToArray());

        }
    }
}