using System;

namespace nothinbutdotnetstore.utility.containers
{
    public interface DependencyContainer
    {
        Dependency an<Dependency>();
        object an(Type dependency);
    }
}