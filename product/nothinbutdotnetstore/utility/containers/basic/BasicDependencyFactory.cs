using System;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public class BasicDependencyFactory : DependencyFactory
    {
        readonly Func<object> dependency_creation_expression;

        public BasicDependencyFactory(Func<object> dependency_creation_expression)
        {
            this.dependency_creation_expression = dependency_creation_expression;
        }

        public object create()
        {
            return dependency_creation_expression();
        }
    }
}