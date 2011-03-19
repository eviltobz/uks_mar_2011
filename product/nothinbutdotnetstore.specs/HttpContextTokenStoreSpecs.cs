using System;
using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
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
        public class when_mapping_a_token_store_from_a_http_context : concern
        {
            It first_observation = () =>
            {
                
            };
        }
    }

    public class DefaultHttpContextTokenStoreMapper : HttpContextTokenStoreMapper
    {
        public TokenStore<string, string> map(HttpContext item)
        {
            item.Request.Params();
            throw new NotImplementedException();
        }
    }
}
