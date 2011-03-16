namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubMissingCommandFactory
    {
        public RequestCommand create()
        {
            return new StubMissingCommand();
        }

        class StubMissingCommand : RequestCommand
        {
            public void process(Request request)
            {
            }

            public bool can_handle(Request request)
            {
                return false;
            }
        }
    }
}