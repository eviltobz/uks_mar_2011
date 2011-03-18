namespace nothinbutdotnetstore.web.core
{
    public interface UrlBuilder
    {
         UrlBuilder include<ItemWithProperty>(ItemWithProperty some_report_model,PayloadBuilderVisitor<ItemWithProperty> visitor);

    }
}
