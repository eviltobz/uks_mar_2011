using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface HttpContextTokenStoreMapper : Mapper<HttpContext,TokenStore<string,string>>
    {
        
    }
}