namespace nothinbutdotnetstore.web.core
{
    public class CommandUrl
    {
        public static UrlBuilder to_run<Behaviour>() where Behaviour : ApplicationBehaviour
        {
            return new UrlBuilder(typeof(Behaviour));
        }
    }
}