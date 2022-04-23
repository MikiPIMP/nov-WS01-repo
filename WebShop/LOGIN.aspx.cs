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

            if (rezultat != 0) {
                Response.Write("Ponovite upis!");
            }
            else {
                Session["Korisnik_Email"] = TextBox1.Text;      // BILO: txtime.Text
                Response.Redirect("control_panel.aspx");
            }
        }
    }
}