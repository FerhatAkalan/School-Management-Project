using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OkulOtomasyonu
{
    public partial class PersonelProfil : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=OkulOtomasyonu;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    if (Session["KullaniciAdi"] == null)
                    {
                        Response.Redirect("Login.aspx");


                    }
                    else
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("Select * from Login INNER JOIN Personel ON Login.ID = Personel.LoginID where KullaniciAdi = @p1 ", baglanti);

                        komut.Parameters.AddWithValue("@p1", Session["KullaniciAdi"].ToString());
                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            TextPerID.Text = dr["PersonelID"].ToString();
                            TextPerAd.Text = dr["PersonelAd"].ToString();
                            TextPerSoyad.Text = dr["PersonelSoyad"].ToString();
                            TextPerMail.Text = dr["PersonelMail"].ToString();
                            TextPerTelefon.Text = dr["PersonelTel"].ToString();
                            TextPerKullaniciAdi.Text = dr["KullaniciAdi"].ToString();
                            TextPerSifre.Text = dr["Sifre"].ToString();
                            komut.Dispose();
                            baglanti.Close();

                        }
                    }
                }
                catch (Exception)
                {
                    TextPerID.Text = "Veritabanına bağlanamadı!.";
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
                komut2.CommandText = "UPDATE Personel SET PersonelAd = @k1, PersonelSoyad = @k2, PersonelMail = @k3, PersonelTel = @k4 WHERE PersonelID = @k5";
                komut2.Parameters.AddWithValue("@k1", TextPerAd.Text);
                komut2.Parameters.AddWithValue("@k2", TextPerSoyad.Text);
                komut2.Parameters.AddWithValue("@k3", TextPerMail.Text);
                komut2.Parameters.AddWithValue("@k4", TextPerTelefon.Text);
                komut2.Parameters.AddWithValue("@k5", TextPerID.Text);
                komut2.ExecuteNonQuery();

                
                komut2.CommandText = "UPDATE Login SET Sifre = @b1 WHERE KullaniciAdi = @b2";
                komut2.Parameters.AddWithValue("@b1", TextPerSifre.Text);
                komut2.Parameters.AddWithValue("@b2", TextPerAd.Text + " " + TextPerSoyad.Text);
                komut2.ExecuteNonQuery();

                transaction1.Commit();
                Label1.Text = "Kayıt Başarıyla Güncellendi. Personel Profil Sayfasına Yönlendiriliyorsunuz...";
                Response.AppendHeader("Refresh", "3;url=PersonelProfil.aspx");

            }
            catch (Exception)
            {
                transaction1.Rollback();
                Response.Redirect("PersonelDefault.aspx");
               
            }
            finally
            {
                baglanti.Close();
                komut2.Dispose();
           
            }
        }

    }
}
