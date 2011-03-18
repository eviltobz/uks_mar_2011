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
    	    return (Dependency) an(typeof(Dependency));
    	}

        public object an(Type dependency)
        {
            try
            {
                return dependency_factories.get_factory_that_can_create(dependency).create();
            }
            catch (Exception ex)
            {
                throw new DependencyCreationException(dependency,  ex);
            }
        }
    }
}