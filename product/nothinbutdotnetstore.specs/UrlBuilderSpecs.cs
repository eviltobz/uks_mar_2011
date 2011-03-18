using System;
using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class UrlBuilderSpecs
    {
        public abstract class concern : Observes<UrlBuilder,
                                            DefaultUrlBuilder>
        {
        }

        [Subject(typeof(DefaultUrlBuilder))]
        public class when_constructed : concern
        {
            Establish c = () =>
            {
                provide_a_basic_sut_constructor_argument(typeof(Blah));
                token_store = the_dependency<TokenStore<string,object>>();
            };

            It should_store_a_token_representing_the_command_to_run = () =>
                token_store.received(x => x.register(Arg<KeyValuePair<string,object>>.Matches(y => y.Value.Equals(typeof(Blah)))));

            static TokenStore<string,object> token_store;
            static KeyValuePair<string, object> the_token_for_the_command_to_run;
        }

        public class when_including_an_item_that_has_potential_payload_information : concern
        {
            Establish c = () =>
            {
                token_store = the_dependency<TokenStore<string,object>>();
                the_payload_builder = an<PayloadBuilder<TheReportModel>>();
                payload_builder_factory = the_dependency<PayloadBuilderFactory>();
                the_payload_builder = an<PayloadBuilder<TheReportModel>>();
                payload_builder_factory = the_dependency<PayloadBuilderFactory>();
                some_report_model = new TheReportModel();

                payload_builder_factory.setup(x => x.create_for(some_report_model,token_store)).Return(the_payload_builder);

            };

            Because b = () =>
                result=sut.include(some_report_model, builder => visited_builder = builder);

            It should_apply_the_payload_visitor_against_the_created_payload_builder = () =>
                visited_builder.ShouldEqual(the_payload_builder);

            It should_return_the_url_builder = () =>
                result.ShouldEqual(sut);
  

            static UrlBuilder result;
            static TheReportModel some_report_model;
            static PayloadBuilder<TheReportModel> the_payload_builder;
            static PayloadBuilderFactory payload_builder_factory;
            static TokenStore<string,object> token_store;
            static PayloadBuilder<TheReportModel> visited_builder;
        }

        [Subject(typeof(DefaultUrlBuilder))]
        public class when_rendering_as_a_string : concern
        {
            Establish c = () =>
            {
                the_result = "blah";
                token_store = the_dependency<TokenStore<string,object>>();
                url_formatting_visitor = the_dependency<UrlFormattingVisitor>();
                all_tokens = Enumerable.Range(1, 100).Select(x => new KeyValuePair<string,object>(x.ToString(), x)).ToList();

                token_store.setup(x => x.GetEnumerator()).Return(all_tokens.GetEnumerator);

                url_formatting_visitor.setup(x => x.get_result()).Return(the_result);
            };

            Because b = () =>
               result = sut.ToString();


            It should_return_the_result_of_the_visitor = () =>
                result.ShouldEqual(the_result);
  

            static UrlFormattingVisitor url_formatting_visitor;
            static IEnumerable<KeyValuePair<string,object>> all_tokens;
            static TokenStore<string,object> token_store;
            static string result;
            static string the_result;
        }


        public class Blah : ApplicationBehaviour
        {
            public void process(Request request)
            {
            }
        }

        public class TheReportModel
        {
        }
    }
}
