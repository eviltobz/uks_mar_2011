using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public delegate KeyValuePair<string, object> TokenFactory<ReportModel, PropertyType>(ReportModel model, PropertyAccessor<ReportModel, PropertyType> accessor);
}