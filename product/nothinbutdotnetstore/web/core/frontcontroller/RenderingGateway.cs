namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface RenderingGateway
    {
        void render<ReportModel>(ReportModel report_model);
    }
}