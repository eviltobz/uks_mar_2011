using System.Web;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public interface ViewFor<ReportModel> : IHttpHandler
    {
        ReportModel report_model { get; set; }
    }
}