<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="galerija_prikaz.aspx.cs" Inherits="WebShop.galerija_prikaz" %>
 <%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        string link = Convert.ToString(Request.QueryString["id"]);

        WebShop.webshop pretraga = new WebShop.webshop();
        DataSet zapis = new DataSet();

        zapis = pretraga.Slika_Naziv(link);

        Response.Write("<tbody>");
                          try
                          {
                              for (int i=0; i< zapis.Tables[0].Rows.Count;i++)
                              {
                                  Response.Write("<tr>");
                                  Response.Write("<td>");
                                  Response.Write("<img src=" + zapis.Tables[0].Rows[i]["slika_ref"] + " >&nbsp;&nbsp;");
                                  Response.Write("</td>");
                                  Response.Write("</tr>");






                              }


                          }
                          catch (Exception ex)
                          {
                              Response.Write(ex.Message[404]);
                          }
                          Response.Write("<tbody>");

                          %>
                    



        
</asp:Content>
