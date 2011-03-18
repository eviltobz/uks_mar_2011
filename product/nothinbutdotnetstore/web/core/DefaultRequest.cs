using System;
using System.Collections.Generic;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        IEnumerable<KeyValuePair<string, string>> the_current_context;
        MappingFactory mapping_factory;
        public DefaultRequest(IEnumerable<KeyValuePair<string, string>> the_current_context)
        {
            this.the_current_context = the_current_context;
        }

        public InputModel map<InputModel>()
        {
            return mapping_factory.create_for<InputModel>().map(the_current_context);
        }

        public string url
        {
            get { throw new NotImplementedException(); }
        }
    }
}