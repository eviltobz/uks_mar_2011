using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlFormattingVistor : UrlFormattingVisitor
    {
        StringBuilder builder;
        string active_token_separator = "?";

        public DefaultUrlFormattingVistor(StringBuilder builder)
        {
            this.builder = builder;
        }

        public void process(KeyValuePair<string, object> item)
        {
            if(builder.Length == 0)
            {
                builder.AppendFormat("{0}.uk{1}", item.Value,active_token_separator);
                active_token_separator = "&";
            }
            else
            {
                builder.AppendFormat("{0}={1}{2}", item.Key, item.Value,active_token_separator);
            }
        }

        public string get_result()
        {
            return builder.ToString();
        }
    }
}