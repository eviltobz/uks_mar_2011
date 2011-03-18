using System;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public interface DependencyFactories
    {
        DependencyFactory get_factory_that_can_create(Type dependency_type);
    }
}