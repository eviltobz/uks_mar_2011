using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.utility;
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
        public class when_mapping_a_token_store_from_a_http_context : concern
        {
            Establish c = () =>
            {
                context_parameters = an<NameValueCollection>();
                token_store = an<TokenStore<string, string>>();
                visitor =
                    x => token_store.register(new KeyValuePair<string, string>(x, context_parameters[x].ToString()));

                provide_a_basic_sut_constructor_argument(visitor);
            };

            Because b = () =>
            {
                result = sut.map(context_parameters);
            };

            It should_iterate_the_namevaluecollection_and_visit_the_values_building_the_token_store = () =>
            {
                token_store.received(x => x.register(Arg<KeyValuePair<string, string>>.Is.Anything()));
            };

            static NameValueCollection context_parameters;
            static TokenStore<string, string> result;
            static TokenStore<string, string> token_store;
            static ContextToTokenStoreRegistrationVisitor visitor;
        }
    }

    public class DefaultHttpContextTokenStoreMapper : HttpContextTokenStoreMapper
    {
        ContextToTokenStoreRegistrationVisitor visitor;

        public DefaultHttpContextTokenStoreMapper(ContextToTokenStoreRegistrationVisitor visitor)
        {
            this.visitor = visitor;
        }

        public TokenStore<string, string> map(NameValueCollection context_parameters)
        {
            var token_store = new DefaultTokenStore<string, string>();
            context_parameters.AllKeys.visit_all_items_using<string>(x => token_store.register(new KeyValuePair<string,string>(x, context_parameters[x].ToString())));
            return token_store;
        }
    }

    public delegate void ContextToTokenStoreRegistrationVisitor(string key);
}
