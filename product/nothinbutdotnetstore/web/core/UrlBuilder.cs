namespace nothinbutdotnetstore.web.core
{
    public interface UrlBuilder
    {
        PayloadBuilder<ItemWithProperty> include<ItemWithProperty>(ItemWithProperty some_report_model);
    }
}