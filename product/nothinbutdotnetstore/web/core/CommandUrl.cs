namespace nothinbutdotnetstore.web.core
{
    public class CommandUrl
    {
        public static string to_run<Behaviour>() where Behaviour : ApplicationBehaviour
        {
            return string.Format("{0}.uk", typeof(Behaviour).Name);
        }
    }
}