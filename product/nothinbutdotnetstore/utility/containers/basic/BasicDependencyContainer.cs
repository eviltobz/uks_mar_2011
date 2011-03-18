using System;

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
            try
            {
                return (Dependency) dependencies.get_factory_that_can_create(typeof(Dependency)).create();
            }
            catch (Exception ex)
            {
                throw new DependencyCreationException(typeof(Dependency), ex);
            }
    	}
    }
}