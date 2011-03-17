using System;

namespace nothinbutdotnetstore.web.core
{
    public class CommandUrl
    {
        public static UrlBuilderFactory url_builder_factory = delegate
        {
            throw new NotImplementedException("This needs to be configured by the startup model");
        };

        public static UrlBuilder to_run<Behaviour>() where Behaviour : ApplicationBehaviour
        {
            return url_builder_factory(typeof(Behaviour));
        }
    }
}