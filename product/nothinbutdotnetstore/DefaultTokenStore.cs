using System.Collections.Generic;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore
{
    public class DefaultTokenStore : List<KeyValuePair<string, object>>, TokenStore
    {
        public void register(KeyValuePair<string, object> token_pair)
        {
            Add(token_pair);
        }
    }
}