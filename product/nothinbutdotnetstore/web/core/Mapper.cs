namespace nothinbutdotnetstore.web.core
{
    public interface Mapper<in Input, out Output>
    {
        Output map(Input item);
    }
}