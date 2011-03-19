using System.Web;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public interface HttpContextTokenStoreMapper : Mapper<HttpContext,TokenStore<string,string>>
    {
        
    }
}