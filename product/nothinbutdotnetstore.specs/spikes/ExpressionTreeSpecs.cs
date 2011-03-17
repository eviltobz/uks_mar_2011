using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs.spikes
{
    public class ExpressionTreeSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(Expression))]
        public class when_messing_around_with_expressions : concern
        {
            It should_be_able_to_get_the_name_of_a_property_being_pointed_at = () =>
            {
                Expression<Func<Person, string>> name_pointer = x => x.name;

                name_pointer.Body.downcast_to<MemberExpression>().Member.Name.ShouldEqual("name");
            };

            It should_be_able_to_create_a_block_of_code_dynamically = () =>
            {
                Predicate<int> is_even = x => x%2 == 0;
                is_even(2).ShouldBeTrue();

                ConstantExpression the_number_2 = Expression.Constant(2);
                ParameterExpression the_parameter = Expression.Parameter(typeof(int),"x");
                BinaryExpression modulus = Expression.Modulo(the_parameter,the_number_2);
                BinaryExpression is_equal_to_0 = Expression.Equal(modulus,Expression.Constant(0));

                Expression<Predicate<int>> is_even_dynamic = Expression.Lambda<Predicate<int>>(is_equal_to_0,the_parameter);

                is_even_dynamic.Compile()(2).ShouldBeTrue();
            };


        }

        public class Person
    {
            public string name { get; set; }
    }
    }

}
