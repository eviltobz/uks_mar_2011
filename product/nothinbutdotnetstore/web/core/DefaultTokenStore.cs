using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultTokenStore : TokenStore
    {
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void add(KeyValuePair<string, object> token_pair)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}