using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class DanismanProfil : System.Web.UI.Page
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
                    SqlCommand komut = new SqlCommand("Select * from Login INNER JOIN Danisman ON Login.ID = Danisman.LoginID where KullaniciAdi = @p1 ", baglanti);

                    komut.Parameters.AddWithValue("@p1", Session["KullaniciAdi"].ToString());
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        TextDanID.Text = dr["DanismanID"].ToString();
                        TextDanAd.Text = dr["DanismanAd"].ToString();
                        TextDanSoyad.Text = dr["DanismanSoyad"].ToString();
                        TextDanMail.Text = dr["DanismanMail"].ToString();
                        TextDanTelefon.Text = dr["DanismanTelefon"].ToString();
                        TextDanKullaniciAdi.Text = dr["KullaniciAdi"].ToString();
                        TextDanSifre.Text = dr["Sifre"].ToString();
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
                komut2.CommandText = "UPDATE Danisman SET DanismanAd = @k1, DanismanSoyad= @k2, DanismanMail = @k3, DanismanTelefon = @k4 WHERE DanismanID = @k5";
                komut2.Parameters.AddWithValue("@k1", TextDanAd.Text);
                komut2.Parameters.AddWithValue("@k2", TextDanSoyad.Text);
                komut2.Parameters.AddWithValue("@k3", TextDanMail.Text);
                komut2.Parameters.AddWithValue("@k4", TextDanTelefon.Text);
                komut2.Parameters.AddWithValue("@k5", TextDanID.Text);
                komut2.ExecuteNonQuery();



                komut2.CommandText = "UPDATE Login SET Sifre = @b1 WHERE KullaniciAdi = @b2";
                komut2.Parameters.AddWithValue("@b1", TextDanSifre.Text);
                komut2.Parameters.AddWithValue("@b2", TextDanKullaniciAdi.Text);
                komut2.ExecuteNonQuery();

                transaction1.Commit();
                Label1.Text = "Kayıt Başarıyla Güncellendi. Danışman Profil Sayfasına Yönlendiriliyorsunuz...";
                Response.AppendHeader("Refresh", "3;url=DanismanProfil.aspx");

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