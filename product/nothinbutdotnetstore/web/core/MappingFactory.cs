using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface MappingFactory
    {
        InputModelMapper<InputModel> create_for<InputModel>();
    }
}