using nothinbutdotnetstore.web.core.payloads;

namespace nothinbutdotnetstore.web.core.urls
{
    public interface UrlBuilder
    {
         UrlBuilder include<ItemWithProperty>(ItemWithProperty some_report_model,PayloadBuilderVisitor<ItemWithProperty> visitor);

    }
}
