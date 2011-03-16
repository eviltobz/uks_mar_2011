using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubPathResolver : PathResolver
    {
        public string get_path_for_view_that_can_display<ReportModel>()
        {
            if (typeof(ReportModel).Equals(typeof(IEnumerable<Department>))) return create_view_to("DepartmentBrowser");
            return create_view_to("ProductBrowser");
        }

        string create_view_to(string page)
        {
            return string.Format("~/views/{0}.aspx", page);
        }
    }
}