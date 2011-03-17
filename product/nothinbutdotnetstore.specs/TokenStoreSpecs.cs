using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class TokenStoreSpecs
    {
        public abstract class concern : Observes<TokenStore,
                                            DefaultTokenStore>
        {
        
        }

        [Subject(typeof(DefaultTokenStore))]
        public class when_adding_a_new_token_to_the_tokenstore : concern
        {
            Establish c = () =>
            {
                the_token = new KeyValuePair<string, object>("key_blah", 42);
            };
            Because b = () =>
                sut.add(the_token);


            It should_store_the_token
                = () => sut.downcast_to<DefaultTokenStore>().contains_token_with_key(the_token.Key).ShouldBeTrue();

            static KeyValuePair<string, object> the_token;
        }
    }
}
