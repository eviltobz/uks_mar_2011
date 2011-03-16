using System;

namespace nothinbutdotnetstore.web.core.stubs
{
    public static class Stub
    {
        public static ReturnType with<ReturnType>()
        {
            return (ReturnType) Activator.CreateInstance(typeof(ReturnType));
        }

        public static StubCriteria<ReturnType> with1<ReturnType>()
        {
            return new DefaultStubCriteria<ReturnType>();
        }
    }

    public class DefaultStubCriteria<ReturnType> : StubCriteria<ReturnType>
    {
        public StubCriteria<ReturnType> until(string dateTime)
        {
            throw new NotImplementedException();
        }
    }

    public interface StubCriteria<ReturnType>
    {

        StubCriteria<ReturnType> until(string dateTime);
    }
}