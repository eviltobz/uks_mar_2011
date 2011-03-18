using System.Collections.Generic;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class TokenStoreSpecs
    {
        public abstract class concern : Observes<TokenStore<string,object>,
                                            DefaultTokenStore<string,object>>
        {
        }

        [Subject(typeof(DefaultTokenStore<,>))]
        public class when_adding_a_new_token_to_the_tokenstore : concern
        {
            Establish c = () => { the_token = new KeyValuePair<string, object>("key_blah", 42); };

            Because b = () =>
                sut.register(the_token);

            It should_store_the_token
                = () => sut.ShouldContain(the_token);

            static KeyValuePair<string, object> the_token;
        }
    }
}