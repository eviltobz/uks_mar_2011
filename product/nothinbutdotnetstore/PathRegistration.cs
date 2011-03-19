using System;

namespace nothinbutdotnetstore
{
    public interface PathRegistration
    {
        void register_path_to(Type page_type, string path);
    }
}