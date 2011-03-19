using System.Collections.Generic;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core.urls
{
    public interface UrlFormattingVisitor  : ValueReturningVisitor<KeyValuePair<string,object>,string>
    {
    }
}