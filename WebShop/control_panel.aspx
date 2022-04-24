<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="control_panel.aspx.cs" Inherits="WebShop.control_panel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Sadrzaj kontrol panela za Admina....</h4>
    <hr color="red" />
    <br />
    <div>
        <asp:Button ID="Button1" runat="server" Text="PRIKAZ SVIH KORISNIKA" OnClick="Button1_Click" />
    </div>
</asp:Content>
