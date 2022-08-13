using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class DanismanDersOgrenciKayitliListesi : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=OkulOtomasyonu;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["KullaniciAdi"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select Ogrenci.OgrenciID,OgrenciNo,OgrenciAd,OgrenciSoyad,OgrenciMail,OgrenciTel,Bolum,Sinif from OgrenciDers Inner Join Ogrenci ON Ogrenci.OgrenciID = OgrenciDers.OgrenciId Where DersId = @p1", baglanti);
                komut.Parameters.AddWithValue("@p1", Request.QueryString["DersId"]);
                SqlDataReader dr = komut.ExecuteReader();
                Repeater1.DataSource = dr;
                Repeater1.DataBind();
                baglanti.Close();
                komut.Dispose();
            }

        }
    }
}