using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class UrlFormattingVisitorSpecs
    {
        public abstract class concern : Observes<UrlFormattingVisitor,
                                            DefaultUrlFormattingVistor>
        {
            Establish c = () =>
            {
                builder = new StringBuilder();
                provide_a_basic_sut_constructor_argument(builder);
            };

            protected static StringBuilder builder;
        }

        [Subject(typeof(DefaultUrlFormattingVistor))]
        public class when_created_and_no_visits_have_been_made : concern
        {
            It should_return_an_empty_string_when_get_result_is_called = () =>
                builder.ToString().ShouldEqual(string.Empty);
        }

        


        [Subject(typeof(DefaultUrlFormattingVistor))]
        public class when_visiting_the_first_item : concern
        {

            Establish c = () =>
            {
                command_name = "anycommand";
                token = new KeyValuePair<string, object>(string.Empty, command_name);
            };

            Because b = () =>
                sut.process(token);

            It should_append_to_the_builder_the_command_name_appended_with_dot_uk = () =>
                builder.ToString().ShouldEqual(command_name + ".uk");

            static KeyValuePair<string, object> token;
            static string command_name;
        }

        [Subject(typeof(DefaultUrlFormattingVistor))]
        public class when_visiting_two_items : concern
        {
            Establish c = () =>
            {
                command_name = "anycommand";
                first_token = new KeyValuePair<string, object>(string.Empty, command_name);
                key = "anykey";
                value = "anyValue";
                second_token = new KeyValuePair<string, object>(key, value);
            };

            Because b = () =>
            {
                sut.process(first_token);
                after_first_token = builder.ToString();
                sut.process(second_token);
            };


            It should_append_to_the_builder_a_question_mark_followed_by_the_key_value_pair = () => 
                builder.ToString().ShouldEqual(after_first_token + "?" + key + "=" + value);
                

            static string command_name;
            static KeyValuePair<string, object> first_token;
            static KeyValuePair<string, object> second_token;
            static string after_first_token;
            static string key;
            static string value;
        }

        [Subject(typeof(DefaultUrlFormattingVistor))]
        public class when_visiting_more_than_two_items : concern
        {
            Establish c = () =>
            {
                add_pipeline_behaviour_against_sut(x =>
                {
                    x.process(new KeyValuePair<string, object>(string.Empty, "any_command"));
                    x.process(new KeyValuePair<string, object>("first_key", "first_value"));
                });

                subsequent_tokens =
                    Enumerable.Range(1, 5).Select(x => new KeyValuePair<string, object>("key_" + x.ToString(), x)).ToList();

            };

            Because b = () =>
                subsequent_tokens.ForEach(token => sut.process(token));

            It should_append_to_the_builder_a_question_mark_followed_by_the_key_value_pair = () => { };
//                builder.ToString().ShouldEqual(after_first_token + "?" + key + "=" + value);

            static List<KeyValuePair<string, object>> subsequent_tokens;
        }




    }
}
