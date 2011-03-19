using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.web.core
{
    public class CommandUrl
    {
        public static UrlBuilder to_run<Behaviour>() where Behaviour : ApplicationBehaviour
        {
            return Container.resolve.an<UrlBuilderFactory>()(typeof(Behaviour));
        }
    }
}