using System.Web;
using nothinbutdotnetstore.utility.mapping;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestFactory : RequestFactory
    {
        MappingGateway mapping_gateway;
        HttpContextTokenStoreMapper http_context_token_store_mapper;

        public DefaultRequestFactory(MappingGateway mapping_gateway,
                                     HttpContextTokenStoreMapper http_context_token_store_mapper)
        {
            this.mapping_gateway = mapping_gateway;
            this.http_context_token_store_mapper = http_context_token_store_mapper;
        }

        public Request create_from(HttpContext the_current_context)
        {
            return new DefaultRequest(http_context_token_store_mapper.map(the_current_context.Request.Params),
                mapping_gateway, the_current_context.Request.RawUrl);
        }
    }
}