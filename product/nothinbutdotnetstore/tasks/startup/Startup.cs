using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.basic;
using nothinbutdotnetstore.utility.mapping;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using nothinbutdotnetstore.web.core.frontcontroller;
using nothinbutdotnetstore.web.core.payloads;
using nothinbutdotnetstore.web.core.stubs;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        static Dictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();
        static DependencyContainer current_container;

        public static void run()
        {
            initialize_core_components();
            initialize_front_controller();
            initialize_application_components();
            initialize_application_behaviours();
            initialize_view_paths();
            initialize_service_layer_components();

        }

        static void initialize_application_components()
        {
            register<Mapper<TokenStore<string, string>, Department>, StubDepartmentMapper>();
        }

        static void initialize_service_layer_components()
        {
            register<StoreCatalog,StubStoreCatalog>();
        }

        static void initialize_view_paths()
        {
            var path_registration = current_container.an<PathRegistration>();
            path_registration.register_path_to(typeof(IEnumerable<Department>),create_view_path("DepartmentBrowser"));
            path_registration.register_path_to(typeof(IEnumerable<Product>),create_view_path("DepartmentBrowser"));
        }

        static string create_view_path(string page_name)
        {
            return string.Format("~/views/{0}.aspx", page_name);
        }

        static void register<TypeOfContract>(TypeOfContract instance)
        {
            all_factories.Add(typeof(TypeOfContract), new BasicDependencyFactory(() => instance));
        }

        static void register<TypeOfImplementation>()
        {
            register<TypeOfImplementation, TypeOfImplementation>();
        }

        static void register<TypeOfContract, TypeOfImplementation>() where TypeOfImplementation : TypeOfContract
        {
            all_factories.Add(typeof(TypeOfContract),
                              new AutomaticDependencyFactory(current_strategy(typeof(TypeOfImplementation)),
                                                             typeof(TypeOfImplementation), current_container));
        }

        static void initialize_front_controller()
        {
            register<FrontController, DefaultFrontController>();
            register<CommandRegistry, DefaultCommandRegistry>();
            register<PathResolver, DefaultPathResolver>();
            register<RequestFactory, DefaultRequestFactory>();
            register<PageFactory>(BuildManager.CreateInstanceFromVirtualPath);
            register<CurrentContextResolver>(() => HttpContext.Current);
            register<IEnumerable<RequestCommand>, StubSetOfCommands>();
            register<PayloadBuilderFactory, DefaultPayloadBuilderFactory>();

            //TODO - If this is the only thing you learn from this week!!!
            register<ContextToTokenStoreRegistrationVisitor>((heres,the,dll) => dll.register(new KeyValuePair<string,string>(heres,the))); //dll

            register<HttpContextTokenStoreMapper,DefaultHttpContextTokenStoreMapper>();

            var default_url_registry = new DefaultUrlRegistry();
            register<UrlRegistry>(default_url_registry);
            register<PathRegistration>(default_url_registry);
            register<UrlBuilderFactory>(create_builder);
            register<MissingCommandFactory>(create_missing_command);
            register<PropertyExpressionTokenFactory,DefaultPropertyExpressionTokenFactory>();
            register<RenderingGateway,WebFormRenderer>();
            register<WebFormViewFactory, DefaultWebFormViewFactory>();
        }

        static RequestCommand create_missing_command()
        {
            throw new NotImplementedException("Command not found for request");
        }

        static UrlBuilder create_builder(Type command_behaviour)
        {
            return new DefaultUrlBuilder(command_behaviour,
                                         current_container.an<PayloadBuilderFactory>(),
                                         new DefaultTokenStore<string, object>(),
                                         new DefaultUrlFormattingVistor(new StringBuilder()));
        }

        static void initialize_application_behaviours()
        {
            register<ViewTheMainDepartmentsInTheStore>();
            register<ViewTheDepartmentsInADepartment>();
            register<ViewTheProductsInADepartment>();
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
            register<MappingGateway, DefaultMappingGateway>();
            register<MissingDependencyFactory>(missing_factory);
        }

        static DependencyFactory missing_factory(Type type_that_has_no_factory)
        {
            throw new NotImplementedException(string.Format("The type {0} has no factory", type_that_has_no_factory.Name));
        }
    }
}