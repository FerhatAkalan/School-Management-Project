using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class PersonelDanismanOgrenciListesi : System.Web.UI.Page
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
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select OgrenciID,OgrenciNo,OgrenciAd,OgrenciSoyad,OgrenciMail,OgrenciTel,Bolum,KullaniciAdi,Sifre,Sinif from Ogrenci INNER join Login ON Ogrenci.LoginID = login.ID Where Durum=1 and Danisman=@Danisman", baglanti);
                komut.Parameters.AddWithValue("@Danisman", Request.QueryString["DanismanId"]);
                SqlDataReader dr = komut.ExecuteReader();

                Repeater1.DataSource = dr;
                Repeater1.DataBind();
                baglanti.Close();
                komut.Dispose();
            }

        }
    }
}