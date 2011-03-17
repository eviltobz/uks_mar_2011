using System.Collections.Generic;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public interface UrlFormattingVisitor  : ValueReturningVisitor<KeyValuePair<string,object>,string>
    {
    }
}