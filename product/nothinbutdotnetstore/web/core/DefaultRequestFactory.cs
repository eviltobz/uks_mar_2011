using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestFactory : RequestFactory
    {
        DependencyContainer container;

        public DefaultRequestFactory(DependencyContainer container)
        {
            this.container = container;
        }

        public Request create_from(System.Web.HttpContext the_current_context)
        {
            return new DefaultRequest( container.an<TokenStore<string, string>>(), container.an<MappingGateway>(), the_current_context.Request.RawUrl);
        }
    }
}