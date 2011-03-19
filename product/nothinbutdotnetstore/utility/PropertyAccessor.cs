namespace nothinbutdotnetstore.utility
{
    public delegate PropertyType PropertyAccessor<ItemToAccessThePropertyOn, PropertyType>(
        ItemToAccessThePropertyOn item);
}