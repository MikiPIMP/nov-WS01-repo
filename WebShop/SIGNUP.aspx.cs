using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop
{
    public partial class SIGNUP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            webshop obj = new webshop();
        }

        protected void Button1_Click(object sender, EventArgs e) {  //NA DUGME: SIGN UP ME
            webshop obj = new webshop();
            int rez;
            rez = obj.Upis_Korisnika(txtime.Text, txtprezime.Text, txtlozinka.Text, txtemail.Text,
                                     txtdrzava.Text, txtgrad.Text, txtopstina.Text,
                                     Convert.ToInt32(txtpostabroj.Text), txtadresa.Text,
                                     Convert.ToInt32(txttip.Text), txtpol.Text);

            if (rez != 0) { // 1
                Response.Write("Ponovite upis!");
            }
            else { // 0
                Session["Korisnik_Email"] = txtime.Text;
                Response.Write("Upis je okej!");
                Response.Redirect("HomePage.aspx");
            }

        }
    

        protected void Button2_Click(object sender, EventArgs e) {  //NA DUGME: Prikaz svih Korisnika/Admina
            webshop svi_korisnici = new webshop();
            DataSet ds = new DataSet();

            ds = svi_korisnici.Korisnici_Svi();

            try {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {

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
            catch (Exception x) {
                Response.Write(x.Message);
            }
            Response.Write("<tbody>");
        }
    }
}