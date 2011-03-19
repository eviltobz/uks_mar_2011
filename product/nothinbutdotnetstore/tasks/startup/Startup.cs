using System;
using System.Collections.Generic;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.basic;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        static Dictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();
        static DependencyContainer current_container;

        public static void run()
        {
            initialize_core_components();
            initialize_everything_else();
        }

        static void register<TypeOfContract>(TypeOfContract instance)
        {
            all_factories.Add(typeof(TypeOfContract), new BasicDependencyFactory(() => instance));
        }

        static void register<TypeOfContract, TypeOfImplementation>() where TypeOfImplementation : TypeOfContract
        {
            all_factories.Add(typeof(TypeOfContract),
                              new AutomaticDependencyFactory(current_strategy(typeof(TypeOfImplementation)),
                                                             typeof(TypeOfImplementation), current_container));
        }

        static void initialize_everything_else()
        {
            register<FrontController, DefaultFrontController>();
            register<CommandRegistry, DefaultCommandRegistry>();
            register<IEnumerable<RequestCommand>, StubSetOfCommands>();
            register<MappingGateway,DefaultMappingGateway>();
            register<RequestFactory,StubRequestFactory>();
        }

        static ConstructorSelection current_strategy(Type item)
        {
            return new GreedyConstructorParameterStrategy().apply_to;
        }

        static void initialize_core_components()
        {
            current_container =
                new BasicDependencyContainer(new DefaultDependencyFactories(all_factories, missing_factory));
            Container.active_resolver = () => current_container;
            register(current_container);
        }

        static DependencyFactory missing_factory(Type type_that_has_no_factory)
        {
            throw new NotImplementedException(string.Format("The type {0} has no factory", type_that_has_no_factory.Name));
        }
    }
}