using System.Web;
using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.core
{
    public interface HttpContextTokenStoreMapper : Mapper<NameValueCollection,TokenStore<string,string>>
    {
        
    }
}