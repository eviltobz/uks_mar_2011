using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore
{
    public class DefaultUrlRegistry : Dictionary<Type,string> ,UrlRegistry
    {
        public string get_path(Type type)
        {
            return this[type];
        }
    }
}