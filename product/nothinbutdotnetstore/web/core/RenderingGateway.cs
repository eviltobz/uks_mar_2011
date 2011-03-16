namespace nothinbutdotnetstore.web.core
{
    public interface RenderingGateway
    {
        void render<ReportModel>(ReportModel report_model);
    }
}