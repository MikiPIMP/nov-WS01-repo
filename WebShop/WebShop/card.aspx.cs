using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop
{
    public partial class card : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Korisnik_Email"] == "")
            {
                Response.Redirect("default.aspx");

            }


            int broj_artikla = Convert.ToInt32(Request.QueryString["id"]);
            TextBox1.Text=broj_artikla.ToString();


            Response.Write(broj_artikla);
            //webshop istina = new webshop();
            //int rezultat = bacanje.Bacanje_Profesor(broj_komentar);

            //if (rezultat == 0)
            //{
            //    Response.Redirect("pregled_profesora.aspx");
            //}
            //else
            //{
            //    Response.Redirect("greska.aspx");
            //}
        }
    }
}