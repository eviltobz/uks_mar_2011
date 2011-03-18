using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class RequestSpecs
    {
        public abstract class concern : Observes<Request, DefaultRequest>
        {
        }

        [Subject(typeof(Request))]
        public class when_request_is_mapping_an_input_model : concern
        {
            Establish e
                = () =>
                {
                    the_mapped_item = new AnInputModelObject();
                    payload = the_dependency<TokenStore<string, string>>();
                    the_mapper_gateway = the_dependency<MappingGateway>();

                    the_mapper_gateway.setup(x => x.map<TokenStore<string, string>, AnInputModelObject>(payload)).Return
                        (the_mapped_item);
                };

            Because b = () => result = sut.map<AnInputModelObject>();

            It should_return_the_model_mapped_by_the_mapping_gateway = () =>
                result.ShouldEqual(the_mapped_item);

            static AnInputModelObject result;
            static MappingGateway the_mapper_gateway;
            static TokenStore<string, string> payload;
            static AnInputModelObject the_mapped_item;
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