namespace nothinbutdotnetstore.utility.containers.basic
{
    public class BasicDependencyContainer : DependencyContainer
    {
    	Dependencies dependencies;

    	public BasicDependencyContainer(Dependencies dependencies)
    	{
    		this.dependencies = dependencies;
    	}

    	public Dependency an<Dependency>()
    	{
    		return (Dependency)dependencies.get_factory_that_can_create(typeof(Dependency)).create();
    	}
    }
}