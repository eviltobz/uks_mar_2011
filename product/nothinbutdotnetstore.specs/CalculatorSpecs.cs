using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator,DefaultCalculator>
        {

            Establish c = () =>
            {
               provide_a_basic_sut_constructor_argument(2); 
            };
        }


        public class when_shutting_down_and_they_are_not_in_the_right_role : concern
        {
            Establish c = () =>
            {
                fake_principal = an<IPrincipal>();

                fake_principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

                change(() => Thread.CurrentPrincipal).to(fake_principal);
            };

            Because b = () =>
                catch_exception(() => sut.shut_down());

            It should_throw_a_security_exception = () =>
                exception_thrown_by_the_sut.ShouldBeAn<SecurityException>();


            static IPrincipal fake_principal;
        }
        public class when_attempting_to_shut_down_the_calculator_and_they_are_in_the_correct_security_role : concern
        {
            Establish c = () =>
            {
                fake_principal = an<IPrincipal>();

                fake_principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

                change(() => Thread.CurrentPrincipal).to(fake_principal);
            };

            Because b = () =>
                sut.shut_down();

            It should_not_do_anything = () => { };

            static IPrincipal fake_principal;
        }
        public class when_attempting_to_add_a_negative_number : concern
        {
            Because b = () =>
                catch_exception(() => sut.add(-2, 3));

            It should_throw_an_argument_exception = () =>
                exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();
  

        }
        public class when_adding_two_numbers : concern
        {
            Establish c = () =>
            {
                connection = the_dependency<IDbConnection>();
                command = an<IDbCommand>();

                connection.setup(x => x.CreateCommand()).Return(command);
            };

            Because b = () =>
                result = sut.add(2, 3);

            It should_return_the_sum_of_the_numbers = () =>
                result.ShouldEqual(5);

            It should_connect_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_a_stored_procedure = () =>
                command.received(x => x.ExecuteNonQuery());

  

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }
    }
}