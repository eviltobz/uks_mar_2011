using System;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.utility.containers.basic;

namespace nothinbutdotnetstore.specs
{
    public class BasicDependencyFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            BasicDependencyFactory>
        {
        }

        [Subject(typeof(BasicDependencyFactory))]
        public class when_creating_a_dependency : concern
        {
            Establish c = () =>
            {
                the_item = new object();
                provide_a_basic_sut_constructor_argument<Func<object>>(() => the_item);
            };

            Because b = () =>
                result = sut.create();

            It should_return_the_item_created_by_the_block = () =>
                result.ShouldEqual(the_item);

            static object result;
            static object the_item;
        }
    }
}