namespace nothinbutdotnetstore.web.core
{
    public interface PayloadBuilder<ItemWithProperty>
    {
        string with_detail<PropertyType>(PropertyAccessor<ItemWithProperty, PropertyType> accessor);
    }
}