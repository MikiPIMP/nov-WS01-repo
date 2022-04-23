<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SIGNUP.aspx.cs" Inherits="WebShop.SIGNUP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <hr color="red" />
        <div>
            SIGN UP:<br />

            Ime:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtime" runat="server"></asp:TextBox><br />
            Prezime: <asp:TextBox ID="txtprezime" runat="server"></asp:TextBox><br />
            Lozinka: <asp:TextBox ID="txtlozinka" runat="server" TextMode="Password"></asp:TextBox><br />
            E.Posta: <asp:TextBox ID="txtemail" runat="server" TextMode="Email"></asp:TextBox><br />
            Drzava:&nbsp; <asp:TextBox ID="txtdrzava" runat="server" ></asp:TextBox><br />
            Grad:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtgrad" runat="server" ></asp:TextBox><br />
            Opstina: <asp:TextBox ID="txtopstina" runat="server" ></asp:TextBox><br />
            Postanski broj:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtpostabroj" runat="server" TextMode="Number"></asp:TextBox><br />
            Adresa:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtadresa" runat="server" ></asp:TextBox><br />
            Tip korisnika:(1 - admin ili 2 - ne)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txttip" Text="" Enabled="true" runat="server" ></asp:TextBox><br />
            Pol:(Musko ili Zensko)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtpol" Text="" Enabled="true" runat="server" ></asp:TextBox><br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="SIGN UP ME" OnClick="Button1_Click" />
            <br />
            <br />
        </div>
          <hr color="red" />
        <div>
            <asp:Button ID="Button2" runat="server" Text="Prikaz Svih korisnika" OnClick="Button2_Click" />
            <hr color="red" />
        </div>
        </div>
    </form>
</body>
</html>
