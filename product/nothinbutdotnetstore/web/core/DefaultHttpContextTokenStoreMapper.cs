using System.Collections.Specialized;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
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
            context_parameters.AllKeys.visit_all_items_using(x => visitor(x,token_store));
            return token_store;
        }
    }
}