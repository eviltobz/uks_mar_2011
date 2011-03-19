using System.Collections.Specialized;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public interface HttpContextTokenStoreMapper : Mapper<NameValueCollection, TokenStore<string, string>>
    {
    }
}