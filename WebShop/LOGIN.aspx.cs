using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            webshop x = new webshop();
            webshop y = new webshop();
            int rezultat;
            rezultat = x.Provera_Korisnika(TextBox1.Text, TextBox2.Text);

            if (rezultat == 0)
            {

                int rezultat_admin = y.Provera_Admin(TextBox1.Text, TextBox2.Text);
                if (rezultat_admin == 0)
                {
                    Session["Korisnik_Email"] = TextBox1.Text;
                    Response.Redirect("control_panel.aspx");
                }
                else
                {
                    Session["Korisnik_Email"] = TextBox1.Text;
                    Response.Redirect("default.aspx");
                }
            }
            else
            {
                Response.Redirect("greska.aspx");
            }

        }
    }
}