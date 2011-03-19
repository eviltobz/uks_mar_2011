using System.Web;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface RequestFactory
    {
        Request create_from(HttpContext the_current_context);
    }
}