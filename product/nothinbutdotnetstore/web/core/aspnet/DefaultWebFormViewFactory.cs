using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class DefaultWebFormViewFactory : WebFormViewFactory
    {
        PathResolver path_resolver;
        PageFactory page_factory;

        public DefaultWebFormViewFactory():this(Stub.with<StubPathResolver>(),
            BuildManager.CreateInstanceFromVirtualPath)
        {
        }

        public DefaultWebFormViewFactory(PathResolver path_resolver, PageFactory page_factory)
        {
            this.path_resolver = path_resolver;
            this.page_factory = page_factory;
        }

        public IHttpHandler create_view_that_can_display<ReportModel>(ReportModel model)
        {
            var view =
                (ViewFor<ReportModel>) page_factory(path_resolver.get_path_for_view_that_can_display<ReportModel>(),
                                                    typeof(ViewFor<ReportModel>));
            view.report_model = model;
            return view;
        }
    }
}