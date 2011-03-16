using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        Dictionary<string, string> get_parameters();
    }
}