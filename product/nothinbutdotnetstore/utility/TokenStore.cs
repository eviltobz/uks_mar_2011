using System.Collections.Generic;

namespace nothinbutdotnetstore.utility
{
    public interface TokenStore<Key, Value> : IEnumerable<KeyValuePair<Key, Value>>
    {
        void register(KeyValuePair<Key, Value> token_pair);
    }
}