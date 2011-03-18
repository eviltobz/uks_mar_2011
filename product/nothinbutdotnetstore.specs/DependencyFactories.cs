using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.utility.containers.basic;

namespace nothinbutdotnetstore.specs
{
    public class DepencyFactoriesSpecs
    {
        public abstract class concern : Observes<DependencyFactories,
                                            DefaultDependencyFactories>
        {
        }

        [Subject(typeof(DefaultDependencyFactories))]
        public class when_getting_the_factory_for_a_registered_type_and_it_has_the_factory : concern
        {
            Establish c = () =>
            {
                the_type_to_look_up = typeof(SqlConnection);
                the_registered_factory = an<DependencyFactory>();
                all_factories = new Dictionary<Type, DependencyFactory>();
                all_factories.Add(the_type_to_look_up, the_registered_factory);
                provide_a_basic_sut_constructor_argument(all_factories);
            };

            Because b = () =>
                result = sut.get_factory_that_can_create(the_type_to_look_up);

            It should_return_the_registered_dependency = () =>
                result.ShouldEqual(the_registered_factory);

            static Type the_type_to_look_up;
            static DependencyFactory result;
            static DependencyFactory the_registered_factory;
            static IDictionary<Type, DependencyFactory> all_factories;
        }

        public class when_getting_the_factory_for_a_registered_type_and_it_does_not_have_the_factory: concern
        {
            Establish c = () =>
            {
                special_case = an<DependencyFactory>();
                provide_a_basic_sut_constructor_argument<MissingDependencyFactory>(x =>
                {
                    x.ShouldEqual(typeof(SqlConnection));
                    return special_case;
                });
            };

            Because b = () =>
                result = sut.get_factory_that_can_create(typeof(SqlConnection));

            It should_return_the_special_case = () =>
                result.ShouldEqual(special_case);

            static DependencyFactory result;
            static DependencyFactory special_case;
        }
    }

}