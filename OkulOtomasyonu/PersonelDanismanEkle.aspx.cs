using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class PersonelDanismanEkle : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=OkulOtomasyonu;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["KullaniciAdi"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("Select Max(DanismanId) as Numara from Danisman", baglanti);

                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        TextDanismanId.Text = ((int)dr["Numara"] + 1).ToString();
                        baglanti.Close();
                        komut.Dispose();
                    }
                }
            }

        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Insert Into Danisman (DanismanAd,DanismanSoyad,DanismanBolum,DanismanMail,DanismanTelefon) values (@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut1.Parameters.AddWithValue("@p2", TextDanismanAd.Text);
            komut1.Parameters.AddWithValue("@p3", TextDanismanSoyad.Text);
            komut1.Parameters.AddWithValue("@p4", TextDanismanBolum.Text);
            komut1.Parameters.AddWithValue("@p5", TextDanismanMail.Text);
            komut1.Parameters.AddWithValue("@p6", TextDanismanTelefon.Text);
            komut1.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("Insert Into Login (KullaniciAdi,Sifre,Rol,Durum) values (@k1,@k2,@k3,@k4)", baglanti);
            komut2.Parameters.AddWithValue("@k1", (TextDanismanAd.Text + " " + TextDanismanSoyad.Text));
            komut2.Parameters.AddWithValue("@k2", TextDanismanSifre.Text);
            komut2.Parameters.AddWithValue("@k3", "Danisman");
            komut2.Parameters.AddWithValue("@k4", true);
            komut2.ExecuteNonQuery();

            SqlCommand komut3 = new SqlCommand("Select ID from Login where KullaniciAdi=@Kullanici", baglanti);
            komut3.Parameters.AddWithValue("@Kullanici", (TextDanismanAd.Text + " " + TextDanismanSoyad.Text));
            SqlDataReader dr = komut3.ExecuteReader();
            dr.Read();
            SqlCommand komut5 = new SqlCommand("Update Danisman set LoginID = @k5 where DanismanId=@k6", baglanti);
            komut5.Parameters.AddWithValue("@k5", (int)dr["ID"]);
            dr.Close();
            komut5.Parameters.AddWithValue("@k6", TextDanismanId.Text);



            komut5.ExecuteNonQuery();

            baglanti.Close();
            komut1.Dispose();
            komut2.Dispose();
            komut3.Dispose();
            komut5.Dispose();

            Label1.Text = "Kayıt Başarıyla Eklenmiştir. Danışman Listesi Sayfasına Yönlendiriliyorsunuz...";
            Response.AppendHeader("Refresh", "5;url=PersonelDanismanListesi.aspx");
        }

      
    }
}