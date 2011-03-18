using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public class DefaultDependenciesRegistry : Dependencies
    {
        IDictionary<Type, DependencyFactory> all_factories;

        public DefaultDependenciesRegistry(IDictionary<Type, DependencyFactory> all_factories)
        {
            this.all_factories = all_factories;
        }

        public DependencyFactory get_factory_that_can_create(Type dependency_type)
        {
            return all_factories[dependency_type];
        }
    }
}