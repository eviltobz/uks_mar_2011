namespace nothinbutdotnetstore.web.core
{
    public interface PayloadBuilder<ItemWithProperty>
    {
        void with_detail<PropertyType>(PropertyAccessor<ItemWithProperty, PropertyType> accessor);
    }
}