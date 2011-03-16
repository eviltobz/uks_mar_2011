namespace nothinbutdotnetstore.web.core.stubs
{
    public static class Stub
    {
        public static ReturnType with<ReturnType>() where ReturnType : new()
        {
            return new ReturnType();
        }
    }
}