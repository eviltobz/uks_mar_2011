namespace nothinbutdotnetstore.web.core
{
    public delegate PropertyType PropertyAccessor<ItemToAccessThePropertyOn, PropertyType>(
        ItemToAccessThePropertyOn item);

}