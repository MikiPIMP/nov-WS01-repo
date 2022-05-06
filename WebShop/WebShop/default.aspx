<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebShop._default" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card">
                <div class="card-body">
            <%
                WebShop.webshop svi_artikli = new WebShop.webshop();
                DataSet ds = new DataSet();


                ds = svi_artikli.Artikal_Svi();
                Response.Write("<table class=table>");
                Response.Write("<thead>");
                Response.Write("<tr>");
                Response.Write("<th>Artikal ime</th>");
                Response.Write("<th>Artikal cena</th>");
                Response.Write("<th>Kupi</th>");
                Response.Write("<th>Aktivno</th>");
                Response.Write("<th>Katetegorija</th>");
                Response.Write("<th>Galerija</th>");
                Response.Write("</tr>");
                Response.Write("</thead>");
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
                        Response.Write( ds.Tables[0].Rows[i]["Cena"]+"&nbsp;&nbsp; Eura" );
                        Response.Write("</td>");

                        Response.Write("<td>");
                        Response.Write("<a href=card.aspx?id=" + ds.Tables[0].Rows[i]["Artikal_id"] +">");

                        Response.Write("<img src=images/shopping.png />");

                        Response.Write("</a>");
                        Response.Write("</td>");

                        Response.Write("<td>");
                        Response.Write( ds.Tables[0].Rows[i]["Is_Vidljivo"] );
                        Response.Write("</td>");
                        Response.Write("<td>");
                        Response.Write( ds.Tables[0].Rows[i]["kategorija_ime"] );
                        Response.Write("</td>");
                            Response.Write("<td>");
                        Response.Write("<a href=galerija_prikaz.aspx?id=" + ds.Tables[0].Rows[i]["link"] +">");

                        Response.Write("<img src=images/gallery.png />");

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
          </div>
</asp:Content>
