using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu.Sidebar
{
    public partial class PersonelOgrenciGuncelle : System.Web.UI.Page
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
                        SqlCommand komut = new SqlCommand("Select OgrenciID,OgrenciNo,OgrenciAd,OgrenciSoyad,OgrenciMail,OgrenciTel,Bolum,KullaniciAdi,Sifre,Danisman,Sinif,DanismanAd as DanismanAdSoyad from Ogrenci INNER join Login ON Ogrenci.LoginID = login.ID Inner join Danisman ON Ogrenci.Danisman = Danisman.DanismanId  where OgrenciID=@OgrenciID", baglanti);
                        komut.Parameters.AddWithValue("@OgrenciID", Request.QueryString["OgrenciID"].ToString());   
                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            TextOgrenciNo.Text = dr["OgrenciNo"].ToString();
                            TextOgrenciAd.Text = dr["OgrenciAd"].ToString();
                            TextOgrenciSoyad.Text = dr["OgrenciSoyad"].ToString();
                            TextOgrenciBolum.Text = dr["Bolum"].ToString();
                            TextOgrenciTelefon.Text = dr["OgrenciTel"].ToString();
                            TextOgrenciMail.Text = dr["OgrenciMail"].ToString();
                            TextOgrenciSinif.Text = dr["Sinif"].ToString();
                            drpDanisman.SelectedValue = dr["Danisman"].ToString();
                            //drpDanisman.SelectedIndex = drpDanisman.Items.IndexOf(drpDanisman.Items.FindByText(dr["DanismanAdSoyad"].ToString()));
                            TextOgrenciSifre.Text = dr["Sifre"].ToString();


                            baglanti.Close();
                            komut.Dispose();
                        }

                    }
                    catch (Exception)
                    {
                        baglanti.Close();
                        TextOgrenciNo.Text = "Hata";
                        Response.AppendHeader("Refresh", "2;url=PersonelOgrenciListesi.aspx");
                    }
                }
            }
        }

        protected void Unnamed10_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlTransaction transaction1;
            transaction1 = baglanti.BeginTransaction();
            SqlCommand komut2 = new SqlCommand();
            komut2.Transaction = transaction1;
            try
            {
                komut2.Connection = baglanti;
                komut2.CommandText = "UPDATE Ogrenci SET OgrenciAd = @p1, OgrenciSoyad= @p2, Bolum= @p3, OgrenciTel= @p4, OgrenciMail =  @p5, Sinif = @p6, Danisman = @p7 WHERE OgrenciID = @p8";
               
                komut2.Parameters.AddWithValue("@p1", TextOgrenciAd.Text);
                komut2.Parameters.AddWithValue("@p2", TextOgrenciSoyad.Text);
                komut2.Parameters.AddWithValue("@p3", TextOgrenciBolum.Text);
                komut2.Parameters.AddWithValue("@p4", TextOgrenciTelefon.Text);
                komut2.Parameters.AddWithValue("@p5", TextOgrenciMail.Text);
                komut2.Parameters.AddWithValue("@p6", int.Parse(TextOgrenciSinif.Text));
                komut2.Parameters.AddWithValue("@p7", drpDanisman.SelectedValue);
                komut2.Parameters.AddWithValue("@p8", Request.QueryString["OgrenciID"].ToString());
                komut2.ExecuteNonQuery();

                komut2.CommandText = "UPDATE Login SET Sifre = @b1 WHERE KullaniciAdi = @b2";
                komut2.Parameters.AddWithValue("@b1", TextOgrenciSifre.Text);
                komut2.Parameters.AddWithValue("@b2", TextOgrenciNo.Text);
                komut2.ExecuteNonQuery();

                transaction1.Commit();
                Label1.Text = "Kayıt Başarıyla Güncellendi. Öğrenci Listesi Sayfasına Yönlendiriliyorsunuz...";
                Response.AppendHeader("Refresh", "2;url=PersonelOgrenciListesi.aspx");

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