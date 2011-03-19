 
using System;
using System.Reflection;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.utility.containers.basic;

namespace nothinbutdotnetstore.specs
{
    public class GreedyConstructorParameterStrategySpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(GreedyConstructorParameterStrategy))]
        public class when_ripping_the_given_type : concern
        {
            Because b = () =>
            {
                result = GreedyConstructorParameterStrategy.get_the_greediest_constructor_info<NaughtyConstructorOverload>();
            };

            It should_return_the_constructor_info_for_the_constructor_taking_up_the_most_parameters_that_can_be_found_on_the_type = () =>
            {
                result.GetParameters().Length.ShouldEqual(3);
            };

            static ConstructorInfo result;
        }

        class NaughtyConstructorOverload
        {
            public NaughtyConstructorOverload() {}

            public NaughtyConstructorOverload(int a) {}
            public NaughtyConstructorOverload(int a, string b) { }
            public NaughtyConstructorOverload(int a, int b) { }
            public NaughtyConstructorOverload(int a, DateTime d, long l) { }
        }
    }
}
