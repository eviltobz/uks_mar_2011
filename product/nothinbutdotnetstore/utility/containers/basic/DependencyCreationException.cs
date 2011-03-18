using System;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public class DependencyCreationException : Exception
    {
        public DependencyCreationException(Type type, Exception ex) : base(ex.Message, ex)
        {
            this.type_that_could_not_be_created = type;
        }
        public Type type_that_could_not_be_created { get; private set; }
    }
}