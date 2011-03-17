using System.Collections.Generic;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class UrlTokenStoreSpecs
    {
        public abstract class concern : Observes<TokenStore, DefaultTokenStore>
        {
        }


        public class when_adding_tokens_to_store : concern
        {
            Establish c = () =>
            {
                first = new KeyValuePair<string, object>();
                second = new KeyValuePair<string, object>();
            };

            Because b = () =>
            {
                sut.add(first);
                sut.add(second);
            };

            It should_return_those_items_in_order_they_were_added_so_that_the_url_builder_will_result_in_a_search_engine_friendly_url = () =>
            {
                IEnumerator<KeyValuePair<string, object>> enumerator = sut.GetEnumerator();
                enumerator.MoveNext();
                enumerator.Current.ShouldEqual(first);
                enumerator.MoveNext();
                enumerator.Current.ShouldEqual(second);
           };

            static KeyValuePair<string, object> first;
            static KeyValuePair<string, object> second;
        }
    }

    
}