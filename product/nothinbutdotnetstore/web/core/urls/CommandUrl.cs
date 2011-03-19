using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.web.core.urls
{
    public class CommandUrl
    {
        public static UrlBuilder to_run<Behaviour>() where Behaviour : ApplicationBehaviour
        {
            return Container.resolve.an<UrlBuilderFactory>()(typeof(Behaviour));
        }
    }
}