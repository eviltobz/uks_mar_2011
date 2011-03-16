<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application.model" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
              <%--each department should go here--%>
              <% foreach (var department in ((IEnumerable<Department>)Context.Items["blah"]))
                 {

%>
              <tr class="ListItem">
                 <td><%= department.name %></td>
           	  </tr>        
              <%
                 }%>
      	    </table>            
</asp:Content>

