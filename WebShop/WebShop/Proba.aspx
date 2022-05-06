<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Proba.aspx.cs" Inherits="WebShop.Proba" %>
 <%@ Import Namespace="System.Data" %>
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
        <div>PROVERA KORISNIKA :<br />
         Email:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            Lozinka:<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" style="height: 26px" />

        </div>
        <hr color="red" />
        <div>
            UNOS KORISNIKA :
            Ime :<asp:TextBox ID="txtime" runat="server"></asp:TextBox><br />
            Prezime :<asp:TextBox ID="txtprezime" runat="server"></asp:TextBox><br />
            Lozinka:<asp:TextBox ID="txtlozinka" runat="server" TextMode="Password"></asp:TextBox><br />
            E.Posta:<asp:TextBox ID="txtemail" runat="server" TextMode="Email"></asp:TextBox><br />
            Drzava:<asp:TextBox ID="txtdrzava" runat="server" ></asp:TextBox><br />
            Grad:<asp:TextBox ID="txtgrad" runat="server" ></asp:TextBox><br />
            Opstina:<asp:TextBox ID="txtopstina" runat="server" ></asp:TextBox><br />
            Postanski broj:<asp:TextBox ID="txtpostabroj" runat="server" TextMode="Number"></asp:TextBox><br />
            Adresa :<asp:TextBox ID="txtadresa" runat="server" ></asp:TextBox><br />
            Tip korisnika :<asp:TextBox ID="txttip" Text="1" Enabled="false" runat="server" ></asp:TextBox><br />
            Pol :<asp:TextBox ID="txtpol" Text="Musko" Enabled="false" runat="server" ></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />

        </div>
          <hr color="red" />
        <div>
            <asp:Button ID="Button3" runat="server" Text="Svi korisnici" OnClick="Button3_Click" />
            <br />
          <hr color="red" />
        </div>
        <div style="height: 490px">
            <br />
            UNOS ARTIKLA:<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Naziv artikla"></asp:Label>
            :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Height="16px" style="margin-left: 2px" Width="188px"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Cena:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 0px" Width="191px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Status:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox5" runat="server" Width="196px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Kategorija:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox6" runat="server" Width="197px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Opis:"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <textarea id="TextArea1" cols="20" name="S1" rows="1"></textarea><br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Kolicina:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox8" runat="server" Width="197px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Unesite Slike:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="File1" type="file" /><br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" Text="DODAJ ARTIKAL" Width="137px" OnClick="Button5_Click" />
        </div>
        <hr color="red" />
        <div>Artikal 
            <div>
                Ime :<asp:TextBox ID="artikal_ime" runat="server"></asp:TextBox><br />
                Cena :<asp:TextBox ID="artikal_cena" runat="server" TextMode="Number" ></asp:TextBox>
                <br />
                Status :<asp:DropDownList ID="artikal_vidljivo" runat="server" DataSourceID="SqlDataSource1" DataTextField="is_vidljivo" DataValueField="statusArtikla_id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:webshop1ConnectionString %>" SelectCommand="Pregled_Status" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <br />
                Kategorija :<asp:DropDownList ID="artikal_kategorija" runat="server" DataSourceID="SqlDataSource2" DataTextField="kategorija_ime" DataValueField="kategorija_id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:webshop1ConnectionString %>" SelectCommand="Pregled_Kategorija" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                Opis :<br />
                <asp:TextBox ID="artikal_opis" runat="server" Height="96px" MaxLength="250" TextMode="MultiLine" Width="434px"></asp:TextBox>
                <br />
                <br />
                Kolicina :<asp:TextBox ID="artikal_kolicina" runat="server" Width="248px"></asp:TextBox>
                <br />
                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" />
                <br />
            </div>
        </div>
        <div>
            <%
                WebShop.webshop svi_artikli = new WebShop.webshop();
                DataSet ds = new DataSet();


                ds = svi_artikli.Artikal_Svi();
                 Response.Write("<table>");
                Response.Write("<tbody>");
                try
                {
                    for (int i=0; i< ds.Tables[0].Rows.Count;i++)
                    {
                        Response.Write("<tr>");
                        Response.Write("<td>");
                        Response.Write(ds.Tables[0].Rows[i]["Ime"]);
                        Response.Write("</td>");
                        Response.Write("<td>");
                        Response.Write( ds.Tables[0].Rows[i]["Cena"] );
                        Response.Write("</td>");

                        Response.Write("<td>");
                        Response.Write("<a href=edit.aspx?id=" + ds.Tables[0].Rows[i]["Artikal_id"] +">");

                        Response.Write("Бацање");

                        Response.Write("</a>");
                        Response.Write("</td>");

                        Response.Write("</tr>");
                    }


                }
                catch (Exception x)
                {

                }
                Response.Write("<tbody>");
                 Response.Write("</table>");

                %>

        </div>
    </form>
</body>
</html>
