using System.Data;
using System.Reflection;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.basic;

namespace nothinbutdotnetstore.specs
{   
    public class AutomaticDependencyFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            AutomaticDependencyFactory>
        {
        
        }

        [Subject(typeof(AutomaticDependencyFactory))]
        public class when_resolving_a_dependency : concern
        {
            Establish c = () =>
            {
                the_constructor = ObjectFactory.get_the_constructor_on(() => new OurTypeWithDependencies(null,null));
                container = the_dependency<DependencyContainer>();
                provide_a_basic_sut_constructor_argument<ConstructorSelection>(x => the_constructor);
                provide_a_basic_sut_constructor_argument(typeof(OurTypeWithDependencies));
                the_connection = an<IDbConnection>();
                the_command = an<IDbCommand>();

                container.setup(x => x.an(typeof(IDbConnection))).Return(the_connection);
                container.setup(x => x.an(typeof(IDbCommand))).Return(the_command);
            };

            Because b = () =>
                result = sut.create();


            It should_return_the_instance_with_all_of_its_dependencies_satisfied = () =>
            {
                var item = result.ShouldBeAn<OurTypeWithDependencies>();
                item.connection.ShouldEqual(the_connection);
                item.command.ShouldEqual(the_command);
            };

            static object result;
            static IDbConnection the_connection;
            static IDbCommand the_command;
            static DependencyFactories factories;
            static DependencyContainer container;
            static ConstructorInfo the_constructor;
        }

        public class OurTypeWithDependencies
    {
            public IDbConnection connection;
            public IDbCommand command;

            public OurTypeWithDependencies(IDbConnection connection, IDbCommand command)
            {
                this.connection = connection;
                this.command = command;
            }
    }
    }

}
