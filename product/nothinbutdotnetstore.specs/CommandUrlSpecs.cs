 using Machine.Specifications;
 using developwithpassion.specifications.rhino;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
	public class CommandUrlSpecs
	{
		public abstract class concern : Observes<CommandUrl>
		{
        
		}

		[Subject(typeof(CommandUrl))]
		public class when_requesting_a_url_for_a_given_command : concern
		{
			It should_return_the_correct_url = () =>
			{
				url = CommandUrl.to_run<SomeCommandType>();
				url.ShouldEqual("http://server/SomeCommandType.uk");
			};

			static string url;
		}
	}

	public class SomeCommandType
	{
	}
}
