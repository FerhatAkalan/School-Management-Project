using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class PersonelOgrenciEkle : System.Web.UI.Page
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
                    SqlCommand komut = new SqlCommand("Select Max(OgrenciNo) as Numara from Ogrenci", baglanti);
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        TextOgrenciNo.Text = ((int)dr["Numara"] + 1).ToString();
                        komut.Dispose();
                        dr.Close();
                    }
                    SqlCommand komut6 = new SqlCommand("SELECT *, DanismanAd + ' ' + DanismanSoyad+ ' - ' + DanismanBolum as DanismanAdSoyad FROM [Danisman]", baglanti);
                    SqlDataReader dr6 = komut6.ExecuteReader();
                    drpDanisman.DataTextField = "DanismanAdSoyad";
                    drpDanisman.DataValueField = "DanismanId";
                    drpDanisman.DataSource = dr6;
                    drpDanisman.DataBind();
                    drpDanisman.Items.Insert(0, new ListItem("Danışman Seçiniz", ""));
                    baglanti.Close();

               


                }
            }

        }

        protected void Unnamed11_Click(object sender, EventArgs e)
        {
            if (Session["KullaniciAdi"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut1 = new SqlCommand("Insert Into Ogrenci (OgrenciNo,OgrenciAd,OgrenciSoyad,Bolum,OgrenciMail,OgrenciTel,Cinsiyet,Sinif,Danisman) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglanti);

                komut1.Parameters.AddWithValue("@p1", TextOgrenciNo.Text);
                komut1.Parameters.AddWithValue("@p2", TextOgrenciAd.Text);
                komut1.Parameters.AddWithValue("@p3", TextOgrenciSoyad.Text);
                komut1.Parameters.AddWithValue("@p4", TextOgrenciBolum.Text);
                komut1.Parameters.AddWithValue("@p5", TextOgrenciMail.Text);
                komut1.Parameters.AddWithValue("@p6", TextOgrenciTelefon.Text);
                komut1.Parameters.AddWithValue("@p7", TextOgrenciCinsiyet.Text);
                komut1.Parameters.AddWithValue("@p8", TextOgrenciSinif.Text);
                komut1.Parameters.AddWithValue("@p9", drpDanisman.SelectedValue);
                komut1.ExecuteNonQuery();

                SqlCommand komut2 = new SqlCommand("Insert Into Login (KullaniciAdi,Sifre,Rol,Durum) values (@k1,@k2,@k3,@k4)", baglanti);
                komut2.Parameters.AddWithValue("@k1", TextOgrenciNo.Text);
                komut2.Parameters.AddWithValue("@k2", TextOgrenciSifre.Text);
                komut2.Parameters.AddWithValue("@k3", "Ogrenci");
                komut2.Parameters.AddWithValue("@k4", true);
                komut2.ExecuteNonQuery();

                SqlCommand komut3 = new SqlCommand("Select ID from Login where KullaniciAdi=@numara", baglanti);
                komut3.Parameters.AddWithValue("@numara", TextOgrenciNo.Text);
                SqlDataReader dr = komut3.ExecuteReader();
                dr.Read();
                SqlCommand komut5 = new SqlCommand("Update Ogrenci set LoginID = @k5 where OgrenciNo=@k6", baglanti);
                komut5.Parameters.AddWithValue("@k5", (int)dr["ID"]);
                dr.Close();
                komut5.Parameters.AddWithValue("@k6", TextOgrenciNo.Text);
                komut5.ExecuteNonQuery();

                baglanti.Close();
                komut1.Dispose();
                komut2.Dispose();
                komut3.Dispose();
                komut5.Dispose();

                Label1.Text = "Kayıt Başarıyla Eklenmiştir. Öğrenci Listesi Sayfasına Yönlendiriliyorsunuz...";
                Response.AppendHeader("Refresh", "5;url=PersonelOgrenciListesi.aspx");

            }
        }
    }
}
