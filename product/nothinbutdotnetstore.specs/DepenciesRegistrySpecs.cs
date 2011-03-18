using System;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{   
    public class DepenciesRegistrySpecs
    {
        public abstract class concern : Observes<DependenciesRegistry,
                                            DefaultDependenciesRegistry>
        {
        
        }

        [Subject(typeof(DefaultDependenciesRegistry))]
        public class when_getting_the_dependency_for_a_registered_type : concern
        {
            Because b = () =>
                result = sut.get_dependency_for(the_type_to_look_up);

            It should_return_the_registered_dependency = () => { };

            static Type the_type_to_look_up;
            static object result;
        }

    }

    public class DefaultDependenciesRegistry : DependenciesRegistry
    {
        public object get_dependency_for(Type the_type_to_look_up)
        {
            throw new NotImplementedException();
        }
    }

    public interface DependenciesRegistry
    {
        object get_dependency_for(Type the_type_to_look_up);
    }
}
