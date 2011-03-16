<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.ProductBrowser"
CodeFile="ProductBrowser.aspx.cs" MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application.model" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <form></form>
    <p id="noResultsParagraph" runat="server" visible="true">No Results Found</p>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Quantity</th>                   
                        <th>Price</th>                                                
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <% foreach (var product in this.report_model)
                   {

%>
                <!-- each product -->
        <tr class="nonShadedRow">                    
            <td class="ListItem">                    
                <a href='#'><%= product.name %></a>
            </td>
            <td><%= product.description %></td>
            <td><input type="text" class="normalTextBox" value="1" /></td>
            <td><%= product.price %></td>               
            <td><input type="checkbox" class="normalCheckBox" /></td>
            <td><input type="button" value="Add To cart"/></td>

        </tr>
    						
                <%
                   }%>
    	</table>	
								<table>
									<tr>
										<td>
                      <input type="button" value="Add Selected Items To Cart" />
										<td>
                      <input type="button" value="Go To Shopping Cart" />
										<td>
                      <input type="button" value="Continue to checkout" />
										</td>
									</tr>

								</table>							
								    
								
							
		</asp:Content>
