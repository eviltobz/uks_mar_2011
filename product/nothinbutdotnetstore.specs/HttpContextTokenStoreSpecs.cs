using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

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
                Enumerable.Range(1,100).each(x => context_parameters.Add(x.ToString(),x.ToString()));
                token_store = an<TokenStore<string, string>>();

                visitor =
                    (x, y) =>
                    {
                        y.ShouldEqual(token_store);
                    };

                provide_a_basic_sut_constructor_argument(visitor);
            };

            Because b = () => { result = sut.map(context_parameters); };

            It should_visit_all_of_the_original_payload_items = () =>
                token_store.received(x => x.register(Arg<KeyValuePair<string,string>>.Is.NotNull))
                    .Times(context_parameters.Count);

            It should_return_the_right_amount_of_parameters = () =>
                result.Count().ShouldEqual(context_parameters.Count);
  
                

            static NameValueCollection context_parameters;
            static TokenStore<string, string> result;
            static TokenStore<string, string> token_store;
            static ContextToTokenStoreRegistrationVisitor visitor;
        }
    }
}