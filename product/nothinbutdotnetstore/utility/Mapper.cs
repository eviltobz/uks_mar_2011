namespace nothinbutdotnetstore.utility
{
    public interface Mapper<in Input, out Output>
    {
        Output map(Input item);
    }
}