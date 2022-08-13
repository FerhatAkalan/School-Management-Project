using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class PersonelOgrenciListesi : System.Web.UI.Page
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
                SqlCommand komut = new SqlCommand("Select OgrenciID,OgrenciNo,OgrenciAd,OgrenciSoyad,OgrenciMail,OgrenciTel,Bolum,KullaniciAdi,Sifre,DanismanAd + ' ' + DanismanSoyad as DanismanAdSoyad,Sinif from Ogrenci INNER join Login ON Ogrenci.LoginID = login.ID Left join Danisman ON Ogrenci.Danisman = Danisman.DanismanId Where Durum=1", baglanti);
                SqlDataReader dr = komut.ExecuteReader();

                Repeater1.DataSource = dr;
                Repeater1.DataBind();
                baglanti.Close();
                komut.Dispose();
            }
        }
    }
}