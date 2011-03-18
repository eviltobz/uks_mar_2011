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
        
        }

        [Subject(typeof(BasicDependencyContainer))]
        public class when_resolving_an_dependency : concern
        {
            Establish c = () =>
            {
                dependencies = the_dependency<Dependencies>();
                the_created_item = new CreatedItem();
                item_factory = an<DependencyFactory>();

                dependencies.setup(x => x.get_factory_that_can_create(typeof(CreatedItem))).Return(item_factory);
                item_factory.setup(x => x.create()).Return(the_created_item);
            };

            Because b = () =>
                result = sut.an<CreatedItem>();


            It should_return_the_instance_created_by_the_dependencies_factory = () =>
                result.ShouldEqual(the_created_item);
            

            static CreatedItem result;
            static CreatedItem the_created_item;
            static DependencyFactory item_factory;
            static Dependencies dependencies;
        }

        public class CreatedItem : DependencyFactory
    {
    }
    }

}
