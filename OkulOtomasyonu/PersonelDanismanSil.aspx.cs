using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class PersonelDanismanSil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=OkulOtomasyonu;Integrated Security=True");

            if (Session["KullaniciAdi"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {

                if (Page.IsPostBack == false)
                {

                    try
                    {

                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("UPDATE Login SET Durum = @p1 WHERE KullaniciAdi = @p2", baglanti);
                        komut.Parameters.AddWithValue("@p1", 0);
                        komut.Parameters.AddWithValue("@p2", Request.QueryString["KullaniciAdi"].ToString());
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        baglanti.Close();
                        Response.Redirect("PersonelDanismanListesi.aspx");

                    }
                    catch (Exception)
                    {
                        Response.Redirect("PersonelDefault.aspx");

                    }


                }

            }

        }
    }
}