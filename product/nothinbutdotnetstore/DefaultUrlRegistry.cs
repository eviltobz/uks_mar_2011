using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore
{
    public class DefaultUrlRegistry :UrlRegistry
    {
        IDictionary<Type, string> paths;

        public DefaultUrlRegistry(IDictionary<Type, string> paths)
        {
            this.paths = paths;
        }

        public string get_path(Type type)
        {
            return paths[type];
        }
    }
}