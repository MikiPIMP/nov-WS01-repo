<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LOGIN_ADMIN.aspx.cs" Inherits="WebShop.LOGIN_ADMIN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADMIN-LOGIN</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>LOG IN za Admine: <br /><br />
            Email:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> <br />
            Lozinka: <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox> <br /><br />
            <asp:Button ID="Button1" runat="server" Text="LOG IN ME" OnClick="Button1_Click" style="height: 26px" />
        </div>
        <hr color="red" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="BACK" Width="97px" />
    </form>
</body>
</html>


<!--Ovaj aspx fajl sa svim povezanim fajlovima koji idu uz njega treba izbrisati,
    kad se baza odradi na drugaciji nacin-->