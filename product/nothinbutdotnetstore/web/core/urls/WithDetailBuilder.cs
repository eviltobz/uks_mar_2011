using nothinbutdotnetstore.web.core.payloads;

namespace nothinbutdotnetstore.web.core.urls
{
    public delegate void WithDetailBuilder<ItemWithProperty>(PayloadBuilder<ItemWithProperty> a);
}