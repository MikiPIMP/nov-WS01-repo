<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="galerija.aspx.cs" Inherits="WebShop.galerija" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Response.Write(Session["Galerija_ime"]+"<br>");
        %>

     <tr>
                      <td>PNG SLIKE :</td>
                      <td>
                          <asp:FileUpload runat="server" id="FileUpload1"></asp:FileUpload>
                         </td>
                  </tr>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />
    <asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label>
</asp:Content>
