using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace nothinbutdotnetstore.specs.utility
{
    public class ObjectFactory
    {
        public static HttpContext create_http_context()
        {
            return new HttpContext(create_request(), create_response());
        }

        static HttpRequest create_request()
        {
            return new HttpRequest("blah.aspx", "http://local/balh.aspx", string.Empty);
        }

        static HttpResponse create_response()
        {
            return new HttpResponse(new StringWriter());
        }

        public static ConstructorInfo get_the_constructor_on<ItemToCreate>(Expression<Func<ItemToCreate>> ctor)
        {
            return ((NewExpression) ctor.Body).Constructor;
        }
    }
}