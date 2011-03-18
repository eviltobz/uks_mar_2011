using System;

namespace nothinbutdotnetstore
{
    public interface UrlRegistry
    {
        string get_path(Type type);
    }
}