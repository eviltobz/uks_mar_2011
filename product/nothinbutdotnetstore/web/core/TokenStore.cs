using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface TokenStore : IEnumerable<KeyValuePair<string,object>>
{
    void register(KeyValuePair<string, object> token_pair);
}
}