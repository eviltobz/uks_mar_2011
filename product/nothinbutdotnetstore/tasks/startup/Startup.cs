using System;
using System.Collections.Generic;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        static Dictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();

        public static void run()
        {
            initialize_core_components();
            initialize_everything_else();
        }

        static void initialize_everything_else()
        {
            throw new NotImplementedException();
        }

        static void initialize_core_components()
        {
            var current_container =
                new BasicDependencyContainer(new DefaultDependencyFactories(all_factories, missing_factory));
            Container.active_resolver = () => current_container;
        }

        static DependencyFactory missing_factory(Type type_that_has_no_factory)
        {
            throw new NotImplementedException(string.Format("The type {0} has no factory", type_that_has_no_factory.Name));
        }
    }
}