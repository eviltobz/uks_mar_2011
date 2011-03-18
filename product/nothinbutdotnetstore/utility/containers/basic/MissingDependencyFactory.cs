using System;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public delegate DependencyFactory MissingDependencyFactory(Type type_that_has_no_factory);
}