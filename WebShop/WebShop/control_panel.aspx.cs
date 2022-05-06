using System;
using System.Collections.Generic;
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
            if(Session["Korisnik_Email"] == "")
            {
                Response.Redirect("default.aspx");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            webshop upis_artikla = new webshop();
            string strstring = artikal_ime.Text;
            string str = strstring.Replace(" ", "");
            int upis = upis_artikla.Upis_Artikla(artikal_ime.Text, Convert.ToInt32(artikal_cena.Text), Convert.ToInt32(artikal_vidljivo.Text), Convert.ToInt32(artikal_kategorija.Text), artikal_opis.Text, Convert.ToInt32(artikal_kolicina.Text),str);


            if (upis != 0)
            {
                Response.Redirect("greska.aspx");
            }
            else
            {
                
                Session["Galerija_ime"] = artikal_ime.Text;
                Session["Galerija_link"] = str;
                Response.Redirect("galerija.aspx");
            }


        //    strstring = TextBox1.Text
        //str = Replace(strstring, " ", "")
        }

        protected void artikal_kolicina_TextChanged(object sender, EventArgs e)
        {

        }
    }
}