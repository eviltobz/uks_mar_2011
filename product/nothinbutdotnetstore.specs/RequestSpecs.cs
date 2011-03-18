using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using System.Collections.Generic;

namespace nothinbutdotnetstore.specs
{   
    public class RequestSpecs
    {
        public abstract class concern : Observes<Request,DefaultRequest>
        {
        
        }

        [Subject(typeof(Request))]
        public class when_request_is_mapping_an_input_model : concern
        {

            Establish e
                = () =>
                {
                    the_mapper_factory = the_dependency<MappingFactory>();
                    the_context = the_dependency<IEnumerable<KeyValuePair<string, string>>>();
                    mapper = an<InputModelMapper<AnInputModelObject>>();
                    the_mapper_factory.setup(x => x.create_for<AnInputModelObject>()).Return(mapper);
                };

            Because b = () => result = sut.map<AnInputModelObject>();

            It should_return_an_object_of_the_input_model = () =>
                result.ShouldBeAn<AnInputModelObject>();

            It should_call_the_mapper_to_create_the_input_model = () =>
                mapper.received(x => x.map(the_context)); 

            static AnInputModelObject result;
            static InputModelMapper<AnInputModelObject> mapper;
            static MappingFactory the_mapper_factory;
            static IEnumerable<KeyValuePair<string, string>> the_context;
        }
    }

    public class AnInputModelObject
    {
    } 

    //public interface Request
    //{
    //    InputModel map<InputModel>();
    //    string url { get; }
    //}

}
