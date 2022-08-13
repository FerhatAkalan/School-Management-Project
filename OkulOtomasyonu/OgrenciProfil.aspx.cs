using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class OgrenciProfil : System.Web.UI.Page
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=OkulOtomasyonu;Integrated Security=True");

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
                    SqlCommand komut = new SqlCommand("Select *,DanismanAd + ' ' + DanismanSoyad + ' - ' + DanismanBolum as OgrenciDanisman from Login INNER JOIN Ogrenci ON Login.ID = Ogrenci.LoginID  INNER JOIN Danisman ON Danisman.DanismanId = Ogrenci.Danisman where KullaniciAdi = @p1 ", baglanti);

                    komut.Parameters.AddWithValue("@p1", Session["KullaniciAdi"].ToString());
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        TextOgrID.Text = dr["OgrenciID"].ToString();
                        TextOgrDanisman.Text = dr["OgrenciDanisman"].ToString();
                        TextOgrAd.Text = dr["OgrenciAd"].ToString();
                        TextOgrSoyad.Text = dr["OgrenciSoyad"].ToString();
                        TextOgrMail.Text = dr["OgrenciMail"].ToString();
                        TextOgrTelefon.Text = dr["OgrenciTel"].ToString();
                        TextOgrKullaniciAdi.Text = dr["KullaniciAdi"].ToString();
                        TextOgrSifre.Text = dr["Sifre"].ToString();
                        komut.Dispose();
                        baglanti.Close();

                    }
                }
            }
        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlTransaction transaction1;
            transaction1 = baglanti.BeginTransaction();
            SqlCommand komut2 = new SqlCommand();
            komut2.Transaction = transaction1;
            try
            {
                komut2.Connection = baglanti;
                komut2.CommandText = "UPDATE Ogrenci SET OgrenciAd = @k1, OgrenciSoyad = @k2, OgrenciMail = @k3, OgrenciTel = @k4 WHERE OgrenciID = @k5";
                komut2.Parameters.AddWithValue("@k1", TextOgrAd.Text);
                komut2.Parameters.AddWithValue("@k2", TextOgrSoyad.Text);
                komut2.Parameters.AddWithValue("@k3", TextOgrMail.Text);
                komut2.Parameters.AddWithValue("@k4", TextOgrTelefon.Text);
                komut2.Parameters.AddWithValue("@k5", TextOgrID.Text);
                komut2.ExecuteNonQuery();


                komut2.CommandText = "UPDATE Login SET Sifre = @b1 WHERE KullaniciAdi = @b2";
                komut2.Parameters.AddWithValue("@b1", TextOgrSifre.Text);
                komut2.Parameters.AddWithValue("@b2", TextOgrKullaniciAdi.Text);
                komut2.ExecuteNonQuery();

                transaction1.Commit();
                Label1.Text = "Kayıt Başarıyla Güncellendi. Öğrenci Profil Sayfasına Yönlendiriliyorsunuz...";
                Response.AppendHeader("Refresh", "3;url=OgrenciProfil.aspx");

            }
            catch (Exception)
            {
                transaction1.Rollback();
                Response.Redirect("OgrenciDefault.aspx");

            }
            finally
            {
                baglanti.Close();
                komut2.Dispose();

            }
        }
    }
}