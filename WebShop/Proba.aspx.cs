using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace WebShop
{
    public partial class Proba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            webshop x = new webshop();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            webshop x = new webshop();
            int rezultat;
            rezultat = x.Provera_Korisnika(TextBox1.Text, TextBox2.Text);

            if (rezultat != 0)
            {
                Response.Write("Ponovite upis !!!");
            }
            else
            {
                Session["Korisnik_Email"] = txtime.Text;
                Response.Redirect("control_panel.aspx");
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            webshop x = new webshop();
            int rezultat;
            rezultat = x.Upis_Korisnika(txtime.Text, txtprezime.Text, txtlozinka.Text, txtemail.Text, txtdrzava.Text, txtgrad.Text, txtopstina.Text, Convert.ToInt32(txtpostabroj.Text), txtadresa.Text, Convert.ToInt32(txttip.Text), txtpol.Text);

            
            if (rezultat != 0)
            {
                Response.Write("Ponovite upis !!!");
            }
            else
            {
                Session["Korisnik_Email"]= txtime.Text;
                Response.Write("Upis je ok!!!");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
            
                webshop svi_korisnici = new webshop();
                DataSet ds = new DataSet();

                ds = svi_korisnici.Korisnici_Svi();

                try
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        Response.Write(ds.Tables[0].Rows[i]["ime_korisnik"]);

                        Response.Write(ds.Tables[0].Rows[i]["prezime_korisnik"]);


                        Response.Write(ds.Tables[0].Rows[i]["email"]);


                        Response.Write(ds.Tables[0].Rows[i]["pol"]);

                        Response.Write("<a href=bacanjekorisnika.aspx?id=" + ds.Tables[0].Rows[i]["korisnik_id"] + ">");

                        Response.Write("Bacanje");

                        Response.Write("</a>");
                        Response.Write("<br>");

                    }


                }
                catch (Exception x)
                {

                }
                Response.Write("<tbody>");

            


        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }
    }
}