using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore
{
    public class DefaultUrlRegistry :UrlRegistry
    {
        public IDictionary<Type, string> paths = new Dictionary<Type, string>();

        public string get_path(Type type)
        {
            return paths[type];
        }
    }
}