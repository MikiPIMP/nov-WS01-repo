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

            if (rezultat == 0) {
                Session["Korisnik_Email"] = TextBox1.Text;
                Response.Redirect("HomePage.aspx");
            } else if (rezultat == 2) {
                Session["Korisnik_Email_Admin"] = TextBox1.Text;
                Response.Redirect("control_panel.aspx");
            }
            else
            {
                Response.Write("Pogresan email ili sifra!");
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
} 