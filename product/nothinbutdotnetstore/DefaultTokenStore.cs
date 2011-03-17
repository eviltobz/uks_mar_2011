using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore
{
    public class DefaultTokenStore:TokenStore
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

        public bool contains_token_with_key(string key)
        {
            throw new NotImplementedException();
        }
    }
}