using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore
{
    public class DefaultUrlRegistry :UrlRegistry,PathRegistration
    {
        public IDictionary<Type, string> paths = new Dictionary<Type, string>();

        public string get_path(Type type)
        {
            return paths[type];
        }

        public void register_path_to(Type page_type, string path)
        {
            paths[page_type] = path;
        }
    }
}