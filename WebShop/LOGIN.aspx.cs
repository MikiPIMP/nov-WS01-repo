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
            rezultat = x.Provera_Korisnika(TextBox1.Text, TextBox2.Text);  // na prvo email, na drugo loz

            if (rezultat != 0) {
                Response.Write("Niste prijavljeni!");
            } else if (rezultat == 0) {
                Session["Korisnik_Email"] = TextBox1.Text;      // BILO: Korisnik_Email, txtime.Text
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void Button7_Click(object sender, EventArgs e)     // na dugme za prijavu admina
        {
            Response.Redirect("LOGIN_ADMIN.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
} 