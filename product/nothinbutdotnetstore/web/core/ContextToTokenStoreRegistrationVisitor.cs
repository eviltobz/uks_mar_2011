using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public delegate void ContextToTokenStoreRegistrationVisitor(string key,string value,TokenStore<string,string> tokens);
}