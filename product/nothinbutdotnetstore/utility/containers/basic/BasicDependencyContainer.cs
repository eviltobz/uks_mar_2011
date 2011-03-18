using System;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public class BasicDependencyContainer : DependencyContainer
    {
    	DependencyFactories dependency_factories;

    	public BasicDependencyContainer(DependencyFactories dependency_factories)
    	{
    		this.dependency_factories = dependency_factories;
    	}

    	public Dependency an<Dependency>()
    	{
            try
            {
                return (Dependency) dependency_factories.get_factory_that_can_create(typeof(Dependency)).create();
            }
            catch (Exception ex)
            {
                throw new DependencyCreationException(typeof(Dependency), ex);
            }
    	}

        public object an(Type dependency)
        {
            throw new NotImplementedException();
        }
    }
}