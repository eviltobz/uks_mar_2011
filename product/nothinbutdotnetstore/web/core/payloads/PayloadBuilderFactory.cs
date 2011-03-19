namespace nothinbutdotnetstore.web.core.payloads
{
    public interface PayloadBuilderFactory
    {
        PayloadBuilder<ReportModel> create_for<ReportModel>(ReportModel report_model, TokenStore<string,object> token_store);
    }
}