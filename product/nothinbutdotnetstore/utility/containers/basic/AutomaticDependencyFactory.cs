using System;
using System.Linq;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public class AutomaticDependencyFactory : DependencyFactory
    {
        DependencyContainer dependency_container;
        ConstructorSelection constructor_selection;
        Type type_to_create;

        public AutomaticDependencyFactory(ConstructorSelection constructor_selection, Type type_to_create,
                                          DependencyContainer dependency_container)
        {
            this.constructor_selection = constructor_selection;
            this.dependency_container = dependency_container;
            this.type_to_create = type_to_create;
        }

        public object create()
        {
            var constructor_info = constructor_selection.Invoke(type_to_create);
            var constructor_arguments = constructor_info.GetParameters().Select(x => dependency_container.an(x.ParameterType));
            return constructor_info.Invoke(constructor_arguments.ToArray());
        }
    }
}