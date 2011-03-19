using System;
using System.Reflection;
using System.Linq;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public class GreedyConstructorParameterStrategy
    {
        public ConstructorInfo apply_to(Type type_with_constructor)
        {
            return type_with_constructor.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();
        }
    }
}