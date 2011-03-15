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
}
