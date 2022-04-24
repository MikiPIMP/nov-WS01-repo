<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LOGIN.aspx.cs" Inherits="WebShop.Proba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGIN</title>
</head>

<body>
    <form id="form1" runat="server">
        <div>LOG IN za korisnike: <br /><br />
            Email:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> <br />
            Lozinka: <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox> <br /><br />
            <asp:Button ID="Button1" runat="server" Text="LOG IN ME" OnClick="Button1_Click" style="height: 26px" />
        </div>
        <hr color="red" /><br />
        <asp:Button ID="Button7" runat="server" Text="LOG FOR ADMIN" OnClick="Button7_Click" Width="149px" />
        <br />
        <br />
        <asp:Button ID="Button8" runat="server" Text="BACK" Width="95px" OnClick="Button8_Click" />
        <br />
    </form>
</body>

</html>
