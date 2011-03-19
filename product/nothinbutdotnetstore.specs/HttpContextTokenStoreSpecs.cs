using System.Collections.Specialized;
using System.Linq;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class HttpContextTokenStoreSpecs
    {
        public abstract class concern : Observes<HttpContextTokenStoreMapper,
                                            DefaultHttpContextTokenStoreMapper>
        {
        }

        [Subject(typeof(DefaultHttpContextTokenStoreMapper))]
        public class when_mapping_a_token_store_from_a_name_value_collection : concern
        {
            Establish c = () =>
            {
                context_parameters = new NameValueCollection();
                Enumerable.Range(1, 100).each(x => context_parameters.Add(x.ToString(), x.ToString()));

                visitor =
                    (just_give_me, the, dll) =>
                    {
                        just_give_me.ShouldNotBeNull();
                        the.ShouldNotBeNull();
                        dll.ShouldNotBeNull();
                    };

                provide_a_basic_sut_constructor_argument(visitor);
            };

            Because b = () =>
                result = sut.map(context_parameters);

            It should_return_the_right_amount_of_parameters = () =>
                result.ShouldNotBeNull();

            static NameValueCollection context_parameters;
            static TokenStore<string, string> result;
            static ContextToTokenStoreRegistrationVisitor visitor;
        }
    }
}