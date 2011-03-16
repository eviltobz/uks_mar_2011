namespace nothinbutdotnetstore.web.core.aspnet
{
    public interface PathResolver 
    {
        string get_path_for_view_that_can_display<ReportModel>();
    }
}