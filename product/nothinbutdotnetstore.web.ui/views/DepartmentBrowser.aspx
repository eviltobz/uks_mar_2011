<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.utility" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application.catalogbrowsing" %>
<%@ Import Namespace="nothinbutdotnetstore.web.core" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
              <%
                  report_model.visit_all_items_using(department =>
                  {
%>
              <tr class="ListItem">
                 <td><a href="<%=CommandUrl.to_run<ViewTheDepartmentsInADepartment>()
                                            .include(department, builder => builder.with_detail(x => x.name))%>"><%=department.name%></a></td>
           	  </tr>        
                           <%
                  });%>
      	    </table>            
</asp:Content>