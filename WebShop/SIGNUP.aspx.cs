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

        protected void Button1_Click(object sender, EventArgs e) {   //NA DUGME: SIGN UP ME
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
    }
}