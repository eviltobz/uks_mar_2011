namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface Request
    {
        InputModel map<InputModel>();
        string url { get; }
    }


}