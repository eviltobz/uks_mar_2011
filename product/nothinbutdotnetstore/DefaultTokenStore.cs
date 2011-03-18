using System.Collections.Generic;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore
{
    public class DefaultTokenStore<Key,Value> : List<KeyValuePair<Key, Value>>, TokenStore<Key,Value>
    {
        public void register(KeyValuePair<Key, Value> token_pair)
        {
            Add(token_pair);
        }
    }
}