using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public delegate void ContextToTokenStoreRegistrationVisitor(string key,TokenStore<string,string> tokens);
}