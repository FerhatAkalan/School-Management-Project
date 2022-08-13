using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class PersonelDersGuncelle1 : System.Web.UI.Page
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
                        SqlCommand komut = new SqlCommand("Select DersId,DersAd,DersKredi from Ders where DersId = @DersId", baglanti);
                        komut.Parameters.AddWithValue("@DersId", Request.QueryString["DersId"].ToString());
                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            TextDersId.Text = dr["DersId"].ToString();
                            TextDersAd.Text = dr["DersAd"].ToString();
                            TextDersKredi.Text = dr["DersKredi"].ToString();
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

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlTransaction transaction1;
            transaction1 = baglanti.BeginTransaction();
            SqlCommand komut2 = new SqlCommand();
            komut2.Transaction = transaction1;
            try
            {
                komut2.Connection = baglanti;
                komut2.CommandText = "UPDATE Ders SET DersAd = @p1, DersKredi= @p2 WHERE DersId = @p3";
                komut2.Parameters.AddWithValue("@p1", TextDersAd.Text);
                komut2.Parameters.AddWithValue("@p2", TextDersKredi.Text);
                komut2.Parameters.AddWithValue("@p3", Request.QueryString["DersId"].ToString());
                komut2.ExecuteNonQuery();
                transaction1.Commit();
                Label1.Text = "Kayıt Başarıyla Güncellendi. Ders Listesi Sayfasına Yönlendiriliyorsunuz...";
                Response.AppendHeader("Refresh", "3;url=PersonelDersListesi.aspx");

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