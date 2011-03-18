using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultUrlFormattingVistor : UrlFormattingVisitor
    {
        StringBuilder builder;

        public DefaultUrlFormattingVistor(StringBuilder builder)
        {
            this.builder = builder;
        }

        public void process(KeyValuePair<string, object> item)
        {
            if(builder.Length == 0)
                builder.AppendFormat("{0}.uk", item.Value);
            else
            {
                builder.AppendFormat("?{0}={1}", item.Key, item.Value);
            }
        }

        public string get_result()
        {
            return string.Empty;
        }
    }
}