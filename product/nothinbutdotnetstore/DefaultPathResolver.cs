using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore
{
    public class DefaultPathResolver: PathResolver
    {
        UrlRegistry url_registry;

        public DefaultPathResolver(UrlRegistry url_registry)
        {
            this.url_registry = url_registry;
        }

        public string get_path_for_view_that_can_display<ReportModel>()
        {
           return url_registry.get_path(typeof(ReportModel));
        }
    }
}