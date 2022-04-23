<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Proba.aspx.cs" Inherits="WebShop.Proba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #File1 {
            width: 250px;
        }
        #TextArea1 {
            height: 90px;
            width: 211px;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>LOG IN: <br /><br />
            Email: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> <br />
            Lozinka: <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox> <br /><br />
            <asp:Button ID="Button1" runat="server" Text="LOG IN ME" OnClick="Button1_Click" style="height: 26px" />
        </div>
        <hr color="red" />
    </form>
</body>
</html>
