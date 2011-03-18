using System;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.basic;

namespace nothinbutdotnetstore.specs
{   
    public class DependencyContainerSpecs
    {
        public abstract class concern : Observes<DependencyContainer,
                                            BasicDependencyContainer>
        {

            Establish c = () =>
            {
                dependency_factories = the_dependency<DependencyFactories>();
                item_factory = an<DependencyFactory>();
                dependency_factories.setup(x => x.get_factory_that_can_create(typeof(CreatedItem))).Return(item_factory);
            };

            protected static DependencyFactories dependency_factories;
            protected static DependencyFactory item_factory;
        }

        [Subject(typeof(BasicDependencyContainer))]
        public class when_resolving_an_dependency : concern
        {
            Establish c = () =>
            {
                the_created_item = new CreatedItem();

                item_factory.setup(x => x.create()).Return(the_created_item);
            };

            Because b = () =>
                result = sut.an<CreatedItem>();


            It should_return_the_instance_created_by_the_dependencies_factory = () =>
                result.ShouldEqual(the_created_item);
            

            static CreatedItem result;
            static CreatedItem the_created_item;
        }


        public class when_resolving_an_dependency_at_runtime : concern
        {
            Establish c = () =>
            {
                the_created_item = new CreatedItem();

                item_factory.setup(x => x.create()).Return(the_created_item);
            };

            Because b = () =>
                result = sut.an(typeof(CreatedItem));


            It should_return_the_instance_created_by_the_dependencies_factory = () =>
                result.ShouldEqual(the_created_item);
            

            static object result;
            static CreatedItem the_created_item;
        }
        public class when_the_factory_for_a_dependency_throws_an_error_on_item_creation : concern
        {
            Establish c = () =>
            {
                the_inner_exception = new Exception();
                item_factory.setup(x => x.create()).Throw(the_inner_exception);
            };

            Because b = () =>
                catch_exception(() => sut.an<CreatedItem>());


            It should_throw_a_dependency_creation_exception_with_access_to_the_underlying_exception = () =>
            {
                var item = exception_thrown_by_the_sut.ShouldBeAn<DependencyCreationException>();
                item.InnerException.ShouldEqual(the_inner_exception);
                item.type_that_could_not_be_created.ShouldEqual(typeof(CreatedItem));
            };
            

            static Exception the_inner_exception;
        }

        public class CreatedItem : DependencyFactory
    {
        	public object create()
        	{
        		throw new NotImplementedException();
        	}
    }
    }

}
