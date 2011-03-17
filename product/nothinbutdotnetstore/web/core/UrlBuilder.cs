using System;
using System.Linq.Expressions;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class UrlBuilder
    {
        StringBuilder url;

        public UrlBuilder(Type behaviour)
        {
            this.url = new StringBuilder(string.Format("{0}.uk", behaviour.Name));
        }

        public UrlParameterBuilder<ReportModel> include<ReportModel>(ReportModel report_model)
        {
            return new UrlParameterBuilder<ReportModel>(this, report_model);
        }

        public override string ToString()
        {
            return url.ToString();
        }


        public class UrlParameterBuilder<ReportModel>
        {
            UrlBuilder url_builder;
            ReportModel report_model;

            public UrlParameterBuilder(UrlBuilder url_builder, ReportModel report_model)
            {
                this.url_builder = url_builder;
                this.report_model = report_model;
            }

            public UrlBuilder with_detail<PropertyType>(Expression<Func<ReportModel, PropertyType>> property)
            {
                string property_name = ((MemberExpression)property.Body).Member.Name;
                url_builder.url.AppendFormat("?{0}={1}", property_name, property.Compile()(report_model));
                return url_builder;
            }
        }

    }
}