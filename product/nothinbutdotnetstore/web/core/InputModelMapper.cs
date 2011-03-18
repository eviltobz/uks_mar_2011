using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface InputModelMapper<InputModel>
    {
        InputModel map(IEnumerable<KeyValuePair<string, string>> iterator);
    }
}