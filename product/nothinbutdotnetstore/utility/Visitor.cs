namespace nothinbutdotnetstore.utility
{
    public interface Visitor<ItemToVisit>
    {
        void process(ItemToVisit item);
    }
}