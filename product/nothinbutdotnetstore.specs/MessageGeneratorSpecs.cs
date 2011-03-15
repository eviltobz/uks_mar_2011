 using developwithpassion.specifications.rhino;
 using Machine.Specifications;

namespace nothinbutdotnetstore.specs
{   
    public class MessageGeneratorSpecs
    {
        public abstract class concern : Observes<MessageGenerator>
        {
        
        }

        [Subject(typeof(MessageGenerator))]
        public class when_displaying_its_message : concern
        {
            Because b = () =>
                result = sut.greet();

            It should_say_hello = () =>
                result.ShouldEqual("Hello World");


            static string result;
                
        }
    }

    [Subject(typeof(Calculator))]
    public class CalculatorSpecs
    {

        public abstract class concern: Observes
        {
        }

        //context
        //context specifation style testing 
        // BDD.. same thing with slight difference...
        public class when_adding_two_numbers: concern
        {
            private Because b = () => result = Calculator.Add(2, 3);
            It should_return_the_sum_of_two_numbers = () => 
                result.ShouldEqual(5);

            static int result;
        }
    }
}
