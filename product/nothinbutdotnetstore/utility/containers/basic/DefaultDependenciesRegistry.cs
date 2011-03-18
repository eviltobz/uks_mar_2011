using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public class DefaultDependenciesRegistry : Dependencies
    {
        IDictionary<Type, DependencyFactory> all_factories;
        MissingDependencyFactory missing_dependency_factory;

        public DefaultDependenciesRegistry(IDictionary<Type, DependencyFactory> all_factories, MissingDependencyFactory missing_dependency_factory)
        {
            this.all_factories = all_factories;
            this.missing_dependency_factory = missing_dependency_factory;
        }

        public DependencyFactory get_factory_that_can_create(Type dependency_type)
        {
            if (all_factories.ContainsKey(dependency_type))
                return all_factories[dependency_type];
            else
                return this.missing_dependency_factory(dependency_type);
        }
    }
}