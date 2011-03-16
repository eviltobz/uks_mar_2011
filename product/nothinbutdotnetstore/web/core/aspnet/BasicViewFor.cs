using System.Web.UI;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class BasicViewFor<ReportModel> : Page,ViewFor<ReportModel>
    {
        public ReportModel report_model { get; set; }
    }
}