using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class PersonelDanismanGuncelle : System.Web.UI.Page
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

                if (Page.IsPostBack == false)
                {
                    try
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("Select DanismanId,DanismanAd,DanismanSoyad,DanismanBolum,DanismanMail,DanismanTelefon,Sifre from Danisman INNER join Login ON Danisman.LoginID = login.ID where DanismanId=@DanismanId", baglanti);
                        komut.Parameters.AddWithValue("@DanismanId", Request.QueryString["DanismanId"].ToString());
                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            TextDanismanId.Text = dr["DanismanId"].ToString();
                            TextDanismanAd.Text = dr["DanismanAd"].ToString();
                            TextDanismanSoyad.Text = dr["DanismanSoyad"].ToString();
                            TextDanismanBolum.Text = dr["DanismanBolum"].ToString();
                            TextDanismanTelefon.Text = dr["DanismanTelefon"].ToString();
                            TextDanismanMail.Text = dr["DanismanMail"].ToString();
                            TextDanismanSifre.Text = dr["Sifre"].ToString();
                            baglanti.Close();
                            komut.Dispose();
                        }

                    }
                    catch (Exception)
                    {
                        baglanti.Close();
                        Response.Redirect("PersonelDefault.aspx");
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
                komut2.CommandText = "UPDATE Danisman SET DanismanAd = @p1, DanismanSoyad = @p2, DanismanBolum= @p3, DanismanTelefon = @p4, DanismanMail = @p5 WHERE DanismanId = @p6 ";

                komut2.Parameters.AddWithValue("@p1", TextDanismanAd.Text);
                komut2.Parameters.AddWithValue("@p2", TextDanismanSoyad.Text);
                komut2.Parameters.AddWithValue("@p3", TextDanismanBolum.Text);
                komut2.Parameters.AddWithValue("@p4", TextDanismanTelefon.Text);
                komut2.Parameters.AddWithValue("@p5", TextDanismanMail.Text);
                komut2.Parameters.AddWithValue("@p6", Request.QueryString["DanismanId"].ToString());
                komut2.ExecuteNonQuery();

                komut2.CommandText = "UPDATE Login SET Sifre = @b1 WHERE KullaniciAdi = @b2";
                komut2.Parameters.AddWithValue("@b1", TextDanismanSifre.Text);
                komut2.Parameters.AddWithValue("@b2", (TextDanismanAd.Text + " " + TextDanismanSoyad.Text));
                komut2.ExecuteNonQuery();

                transaction1.Commit();
                Label1.Text = "Kayıt Başarıyla Güncellendi. Danışman Listesi Sayfasına Yönlendiriliyorsunuz...";
                Response.AppendHeader("Refresh", "3;url=PersonelDanismanListesi.aspx");

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