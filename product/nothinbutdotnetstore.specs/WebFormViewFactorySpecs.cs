using System;
using System.Web;
using System.Web.UI;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.web.core.aspnet;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class WebFormViewFactorySpecs
    {
        public abstract class concern : Observes<WebFormViewFactory,
                                            DefaultWebFormViewFactory>
        {
        }

        [Subject(typeof(DefaultWebFormViewFactory))]
        public class when_creating_a_view_to_display_report_model : concern
        {
            Establish c = () =>
            {
                path_resolver = the_dependency<PathResolver>();
                the_path_to_the_page = "blah.aspx";
                view = an<ViewFor<SomeModel>>();
                provide_a_basic_sut_constructor_argument<PageFactory>((path,type) =>
                {
                    path_requested = path;
                    type_requested = type;
                    return view;
                });

                path_resolver.setup(x => x.get_path_for_view_that_can_display<SomeModel>())
                    .Return(the_path_to_the_page);

                model = new SomeModel();
            };

            Because b = () =>
                result = sut.create_view_that_can_display(model);


            It should_create_an_instance_of_the_page_from_its_path = () =>
            {
                path_requested.ShouldEqual(the_path_to_the_page);
                type_requested.ShouldEqual(typeof(ViewFor<SomeModel>));
            };

            It should_populate_the_view_with_its_model = () =>
                view.report_model.ShouldEqual(model);

            It should_return_the_view = () =>
                result.ShouldEqual(view);

  

  
                
  

            static SomeModel model;
            static PathResolver path_resolver;
            static string path_requested;
            static Type type_requested;
            static string the_path_to_the_page;
            static ViewFor<SomeModel> view;
            static IHttpHandler result;
        }

        public class SomeModel
        {
        }
    }
}