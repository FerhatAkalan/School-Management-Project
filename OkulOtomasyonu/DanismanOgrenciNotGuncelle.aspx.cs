using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class DanismanOgrenciNotGuncelle1 : System.Web.UI.Page
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
                        SqlCommand komut = new SqlCommand("Select NotId,Notlar.DersID,DersAd,DersKredi,DersVize,DersFinal,DersNotu,Durum,OgrenciNo from Notlar Inner Join Ders On Ders.DersId = Notlar.DersID where NotId = @NotId", baglanti);
                        komut.Parameters.AddWithValue("@NotId", Request.QueryString["NotId"].ToString());
                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            TextOgrNo.Text = dr["OgrenciNo"].ToString();
                            TextDersId.Text = dr["DersId"].ToString();
                            TextDersAd.Text = dr["DersAd"].ToString();
                            TextDersKredi.Text = dr["DersKredi"].ToString();
                            TextDersVize.Text = dr["DersVize"].ToString();
                            TextDersFinal.Text = dr["DersFinal"].ToString();

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

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlTransaction transaction1;
            transaction1 = baglanti.BeginTransaction();
            SqlCommand komut2 = new SqlCommand();
            komut2.Transaction = transaction1;
            try
            {
                komut2.Connection = baglanti;
                komut2.CommandText = "UPDATE Notlar SET DersVize = @p1, DersFinal = @p2 WHERE NotId = @NotId";
                komut2.Parameters.AddWithValue("@p1", TextDersVize.Text);
                komut2.Parameters.AddWithValue("@p2", TextDersFinal.Text);
                komut2.Parameters.AddWithValue("@NotId", Request.QueryString["NotId"].ToString());
                komut2.ExecuteNonQuery();
                TextDersNotu.Text = ((int.Parse(TextDersVize.Text) + int.Parse(TextDersFinal.Text))/2).ToString();
                TextDersDurumu.Text = (int.Parse(TextDersNotu.Text) >= 60 && int.Parse(TextDersFinal.Text) >= 60) ? "1" : "0";
                komut2.CommandText = "UPDATE Notlar SET DersNotu = @b1, Durum = @b2 WHERE NotId = @NotId2";
                komut2.Parameters.AddWithValue("@b1", TextDersNotu.Text);
                komut2.Parameters.AddWithValue("@b2", TextDersDurumu.Text);
                komut2.Parameters.AddWithValue("@NotId2", Request.QueryString["NotId"].ToString());
                komut2.ExecuteNonQuery();
                transaction1.Commit();

                Label1.Text = "Kayıt Başarıyla Güncellendi. Öğrenci Listesi Sayfasına Yönlendiriliyorsunuz...";       
                Response.AppendHeader("Refresh", "1;url=DanismanOgrenciNotGoruntule.aspx?OgrenciNo=" + TextOgrNo.Text);


            }
            catch (Exception)
            {
                transaction1.Rollback();
                Response.Redirect("DanismanDefault.aspx");

            }
            finally
            {
                baglanti.Close();
                komut2.Dispose();

            }
        }
    }
}