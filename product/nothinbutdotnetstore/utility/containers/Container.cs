namespace nothinbutdotnetstore.utility.containers
{
    public class Container
    {
        public static ContainerResolver active_resolver = () => { throw new ContainerUnconfiguredException(); };

        public static DependencyContainer resolve
        {
            get { return active_resolver(); }
        }
    }
}