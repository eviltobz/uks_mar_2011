using System;
using System.Collections.Specialized;
using System.Data.Odbc;
using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.utility.mapping;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.specs
{   
    public class RequestFactorySpecs
    {
        public abstract class concern : Observes<RequestFactory,
                                            DefaultRequestFactory>
        {
        
        }

        [Subject(typeof(DefaultRequestFactory))]
        public class when_creating_a_request : concern
        {

            Establish c = () =>
            {
                the_context = ObjectFactory.create_http_context();
                the_payload = an<TokenStore<string, string>>();
                token_store_from_context_mapper = the_dependency<HttpContextTokenStoreMapper>();
                the_mapping_gateway = the_dependency<MappingGateway>();

                token_store_from_context_mapper.setup(x => x.map(the_context.Request.Params)).Return(the_payload);
            };

            Because b = () =>
                result = sut.create_from(the_context);


            It should_return_a_default_request_with_the_correct_information = () =>
            {
                var item = result.ShouldBeAn<DefaultRequest>();
                item.mapping_gateway.ShouldEqual(the_mapping_gateway);
                //HACK - This is an issue that needs to be fixed in machine specification
                the_payload.Equals(item.payload).ShouldBeTrue();
                item.url.ShouldEqual(the_context.Request.RawUrl);
            };

            static Request result;
            static MappingGateway the_mapping_gateway;
            static TokenStore<string, string> the_payload;
            static HttpContext the_context;
            static HttpContextTokenStoreMapper token_store_from_context_mapper;
        }
    }
}
