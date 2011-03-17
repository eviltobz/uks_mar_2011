namespace nothinbutdotnetstore.utility
{
    public interface ValueReturningVisitor<ItemToVisit,ReturnType> : Visitor<ItemToVisit>
    {
        ReturnType get_result();
    }
}