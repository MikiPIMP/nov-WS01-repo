using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop
{
    public partial class galerija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Korisnik_Email"] == "")
            {
                Response.Redirect("default.aspx");

            }
            if (Session["Galerija_ime"] == "")
            {
                Response.Redirect("default.aspx");

            }
            if (Session["Galerija_Link"] == "")
            {
                Response.Redirect("default.aspx");

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            webshop unosslike = new webshop();

            if (FileUpload1.HasFile)
            {
                string fileextension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (fileextension.ToLower() != ".png")
                {
                    lblmessage.Text = "Molim Vas Fajl nije PNG !";
                }
                else
                {
                    int filesize = FileUpload1.PostedFile.ContentLength;
                    if (filesize > 2242880)
                    {
                        lblmessage.Text = "Maksimalna velicina je 2mg !";
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("./Uploads/" + FileUpload1.FileName));
                        string adresa = "./Uploads/" + FileUpload1.FileName;

                        int rezultat = unosslike.Upis_Slika(Convert.ToString(Session["Galerija_Link"]), adresa);

                        if (rezultat == 0)
                        {
                            lblmessage.Text = "Fajl je prebacen !";
                        }
                        else
                        {
                            lblmessage.Text = "Fajl nije prebacen !";
                        }




                    }
                }
            }
            else
            {
                lblmessage.Text = "Molim Vas Fajl izaberite !";
            }

        }
    }

        
}

       
    