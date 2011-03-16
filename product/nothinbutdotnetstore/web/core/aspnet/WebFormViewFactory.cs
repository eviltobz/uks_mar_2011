using System.Web;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public interface WebFormViewFactory
    {
        IHttpHandler create_view_that_can_display<ReportModel>(ReportModel model);
    }
}