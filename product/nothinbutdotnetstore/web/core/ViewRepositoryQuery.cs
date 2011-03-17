using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public delegate ReportModel ViewRepositoryQuery<ReportModel>(StoreCatalog catalog,Request request);
}