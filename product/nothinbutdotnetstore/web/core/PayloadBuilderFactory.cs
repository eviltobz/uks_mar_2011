namespace nothinbutdotnetstore.web.core
{
    public interface PayloadBuilderFactory
    {
        PayloadBuilder<ReportModel> create_for<ReportModel>(ReportModel some_report_model,TokenStore token_store);
    }
}