using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop
{
    public partial class control_panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            webshop w = new webshop();
        }

        protected void Button1_Click(object sender, EventArgs e)   // NA DUGME: "PRIKAZ SVIH KORISNIKA"
        {
            webshop svi_korisnici = new webshop();
            DataSet ds = new DataSet();

            ds = svi_korisnici.Korisnici_Svi();

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Response.Write(ds.Tables[0].Rows[i]["ime_korisnik"]);
                    Response.Write("<br>");

                    Response.Write(ds.Tables[0].Rows[i]["prezime_korisnik"]);
                    Response.Write("<br>");

                    Response.Write(ds.Tables[0].Rows[i]["email"]);
                    Response.Write("<br>");

                    Response.Write(ds.Tables[0].Rows[i]["pol"]);
                    Response.Write("<br>");

                    Response.Write("<a href=bacanjekorisnika.aspx?id=" + ds.Tables[0].Rows[i]["korisnik_id"] + ">");

                    Response.Write("</a>");
                    Response.Write("<br>");
                }
            }
            catch (Exception x)
            {
                Response.Write(x.Message);
            }
            Response.Write("<tbody>");

        }
    }
}