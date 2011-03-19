using nothinbutdotnetstore.web.core.payloads;

namespace nothinbutdotnetstore.web.core
{
    public delegate void WithDetailBuilder<ItemWithProperty>(PayloadBuilder<ItemWithProperty> a);
}