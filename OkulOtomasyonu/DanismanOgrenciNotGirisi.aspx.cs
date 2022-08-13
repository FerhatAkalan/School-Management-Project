using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class DanismanOgrenciNotGirisi : System.Web.UI.Page
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
                SqlCommand komut = new SqlCommand("Select DersID,Ogrenci.OgrenciID,Sinif,Ogrenci.OgrenciNo,OgrenciAd,OgrenciSoyad,Bolum,DersVize,DersFinal from Ogrenci Inner Join Notlar ON Ogrenci.OgrenciID = Notlar.OgrenciId where DersID = @p1", baglanti);
                komut.Parameters.AddWithValue("@p1", Request.QueryString["DersId"]);
                SqlDataReader dr = komut.ExecuteReader();

                Repeater1.DataSource = dr;
                Repeater1.DataBind();
                baglanti.Close();
                komut.Dispose();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

        }
    }
}