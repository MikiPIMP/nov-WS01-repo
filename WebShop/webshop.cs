using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebShop
{

    public class webshop {      /* MM: Radio u 19h, 24.04.2022. */

        SqlConnection conn = new SqlConnection();
        string wqbConfig = ConfigurationManager.ConnectionStrings["WebShop"].ConnectionString;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();


        public int Provera_Korisnika(string email, string lozinka) {

            conn.ConnectionString = wqbConfig;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Korisnik_Login";
            // kolekcija Parameters
            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@lozinka_hash", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            return Ret;
        }


        public int Upis_Korisnika(string ime, string prezime, string lozinka,string email, string drzava,string grad,string opstina,int postanski_br,string adresa,int tipk,string pol) {

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Korisnik_Insert";

            comm.Parameters.Add(new SqlParameter("@ime_korisnik", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm.Parameters.Add(new SqlParameter("@prezime_korisnik", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm.Parameters.Add(new SqlParameter("@lozinka_hash", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@drzava", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, drzava));
            comm.Parameters.Add(new SqlParameter("@grad", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, grad));
            comm.Parameters.Add(new SqlParameter("@opstina", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, opstina));
            comm.Parameters.Add(new SqlParameter("@postanski_br", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, postanski_br));
            comm.Parameters.Add(new SqlParameter("@adresa", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, adresa));
            comm.Parameters.Add(new SqlParameter("@tip_korisnik_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, tipk));
            comm.Parameters.Add(new SqlParameter("@pol", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pol));

            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }

        public DataSet Korisnici_Svi() {

            conn.ConnectionString = wqbConfig;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Korisnici_Svi";

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
            return (ds);
        }


        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/


        public int Provera_Artikla(string email, string lozinka) {     // ovu funkciju treba odraditi..

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.";

            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@loz", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }


        public int Upis_Artikla(string ime, int cena, int statusArtikla, int kategorija, int slika, string opis, int magacin) {

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Artikal_Insert";
            /* ----------------------- Parametri konekcije ------------------------ */

            comm.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm.Parameters.Add(new SqlParameter("@cena", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cena));
            comm.Parameters.Add(new SqlParameter("@statusArtikla_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, statusArtikla));
            comm.Parameters.Add(new SqlParameter("@kategorija_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, kategorija));
            //comm.Parameters.Add(new SqlParameter("@slika_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, slika));
            comm.Parameters.Add(new SqlParameter("@opis", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, opis));
            comm.Parameters.Add(new SqlParameter("@magacin", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, magacin));

            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }

        public DataSet Artikal_Svi() {

            conn.ConnectionString = wqbConfig;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Artikal_Svi";

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
            return (ds);
        }


        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/


        public int Provera_Kategorija(string email, string lozinka) {     // ovu funkciju treba odraditi..

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.";


            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@loz", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }


        public int Upis_Kategorija(string imeKategorije) {

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Kategorija_Insert";
            /* ----------------------- Parametri konekcije ------------------------ */

            comm.Parameters.Add(new SqlParameter("@kategorija_ime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, imeKategorije));

            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }

        public DataSet Kategorija_Svi() {

            conn.ConnectionString = wqbConfig;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Kategorija_Svi";

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
            return (ds);
        }


        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/


        public int Provera_StatusArtikla(string email, string lozinka) {     // ovu funkciju treba odraditi.. 

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.";
            
            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@loz", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }


        public int Upis_StatusArtikla(bool jeVidljivo) {

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.StatusArtikla_Insert";
            /* ----------------------- Parametri konekcije ------------------------ */

            comm.Parameters.Add(new SqlParameter("@is_vidljivo", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, jeVidljivo));  // ovo proveriti

            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }

        public DataSet StatusArtikla_Svi() {

            conn.ConnectionString = wqbConfig;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "StatusArtikla_Svi";

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
            return (ds);
        }



        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/



        public int Provera_Slika(string email, string lozinka) {     // ovu funkciju treba odraditi..

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.";
            
            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@loz", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }


        public int Upis_Slika(string slika_ref) {

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Slika_Insert";
            /* ----------------------- Parametri konekcije ------------------------ */

            comm.Parameters.Add(new SqlParameter("@slika_ref", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, slika_ref));

            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }

            return rezultat;
        }

        public DataSet Slika_Svi() {

            conn.ConnectionString = wqbConfig;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Slika_Svi";

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
            return (ds);
        }




        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/




        public int Provera_Porudzbina(string email, string lozinka) {     // ovu funkciju treba odraditi..

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.";
            // kolekcija Parameters
            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@loz", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }


        public int Upis_Porudzbina(int korisnik, int artikal, bool jeZavrseno, string vremePorudzbina, int kolicinaKupovine) {

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Porudzbina_Insert";
            /* ----------------------- Parametri konekcije ------------------------ */

            comm.Parameters.Add(new SqlParameter("@korisnik_id", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, korisnik));
            comm.Parameters.Add(new SqlParameter("@artikal_id", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, artikal));
            comm.Parameters.Add(new SqlParameter("@is_zavrseno", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, jeZavrseno));
            comm.Parameters.Add(new SqlParameter("@vreme_porudzbina", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vremePorudzbina));
            comm.Parameters.Add(new SqlParameter("@kolicina_kupovine ", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, kolicinaKupovine));

            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }

        public DataSet Porudzbina_Svi() { 

            conn.ConnectionString = wqbConfig;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Porudzbina_Svi";

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
            return (ds);
        }



        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------*/



        public int Provera_TipKorisnik(string email, string lozinka) {     // ovu funkciju treba odraditi..

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.";

            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@loz", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }


        public int Upis_TipKorisnik(bool jeAdmin) {

            conn.ConnectionString = wqbConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.TipKorisnik_Insert";
            /* ----------------------- Parametri konekcije ------------------------ */

            comm.Parameters.Add(new SqlParameter("@is_administrator", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, jeAdmin));

            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;

            if (Ret == 0) {
                rezultat = 0;
            } else {
                rezultat = 1;
            }
            return rezultat;
        }


        public DataSet TipKorisnik_Svi() {

            conn.ConnectionString = wqbConfig;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "TipKorisnik_Svi";

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
            return (ds);
        }


    }
}