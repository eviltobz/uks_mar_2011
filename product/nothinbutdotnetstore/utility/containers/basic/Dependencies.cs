using System;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public interface Dependencies
    {
        DependencyFactory get_factory_that_can_create(Type type);
    }
}