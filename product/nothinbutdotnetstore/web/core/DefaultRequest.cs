namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        TokenStore<string, string> payload;
        MappingGateway mapping_gateway;
        public string url { private set; get; }

        public DefaultRequest(TokenStore<string, string> payload, MappingGateway mapping_gateway, string raw_request_url)
        {
            this.url = raw_request_url;
            this.payload = payload;
            this.mapping_gateway = mapping_gateway;
        }

        public InputModel map<InputModel>()
        {
            return mapping_gateway.map<TokenStore<string, string>, InputModel>(payload);
        }
    }
}