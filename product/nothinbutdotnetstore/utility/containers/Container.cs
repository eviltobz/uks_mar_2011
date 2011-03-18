using System;

namespace nothinbutdotnetstore.utility.containers
{
    public class Container
    {
        public static ContainerResolver active_resolver = () =>
        {
            throw new NotImplementedException("This needs to be set by the startup pipeline");
        };

        public static DependencyContainer resolve { get
        {
            throw new NotImplementedException(); 
        } }
    }
}