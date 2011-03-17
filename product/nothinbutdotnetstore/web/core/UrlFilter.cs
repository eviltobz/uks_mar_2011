using System;

namespace nothinbutdotnetstore.web.core
{
    public class UrlFilter
    {
        public static bool Matches<T>(Request request)
        {
            return request.url.Contains(typeof(T).Name);
        }
    }
}