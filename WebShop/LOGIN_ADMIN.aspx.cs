using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop
{
    public partial class LOGIN_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            webshop x = new webshop();
        }

        protected void Button1_Click(object sender, EventArgs e)  // OVDE IMA LOGICKA GRESKA
        {                                                         // Vratiti se i ispraviti to
            webshop x = new webshop();
            int rezultat;
            rezultat = x.Provera_Korisnika(TextBox1.Text, TextBox2.Text);  // na prvo email, na drugo loz

            if (rezultat != 0)
            {
                Response.Write("Niste ADMIN!");
            }
            else if (rezultat == 0)  // ovde prima svakog, nevezano da li je 1 ili 2 po tipKorID
            {
                Session["Korisnik_Email_Admin"] = TextBox1.Text;      // BILO: txtime.Text
                Response.Redirect("control_panel.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)      //back dugme
        {
            Response.Redirect("LOGIN.aspx");
        }
    }
}