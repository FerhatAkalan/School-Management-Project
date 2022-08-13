using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class DanismanOgrenciDersKaydet : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=OkulOtomasyonu;Integrated Security=True");
        string DanismanId = null;
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

                            TextDersAd.Text = dr["DersAd"].ToString();        
                            komut.Dispose();
                            dr.Close();
                            baglanti.Close();
                        }
                        baglanti.Open();
                        SqlCommand komut5 = new SqlCommand("Select DanismanId from Danisman  Inner join Login ON Login.ID = Danisman.LoginID where KullaniciAdi = @Kullanici", baglanti);
                        komut5.Parameters.AddWithValue("@Kullanici", Session["KullaniciAdi"].ToString());
                        SqlDataReader dr5 = komut5.ExecuteReader();
                        if (dr5.Read())
                        {
                            DanismanId = dr5["DanismanId"].ToString();
                            komut5.Dispose();
                            dr5.Close();
                        }
                        SqlCommand komut6 = new SqlCommand("Select *,Convert(nvarchar,OgrenciNo)+ ' - ' + OgrenciAd + ' ' + OgrenciSoyad as OgrenciAdSoyad from Ogrenci INNER join Login ON Ogrenci.LoginID = login.ID Where Durum=1 and Danisman= @Danisman",baglanti);
                        komut6.Parameters.AddWithValue("@Danisman", DanismanId);
                        SqlDataReader dr6 = komut6.ExecuteReader();
                        drpOgrenciNo.DataTextField = "OgrenciAdSoyad";
                        drpOgrenciNo.DataValueField = "OgrenciNo";
                        drpOgrenciNo.DataSource = dr6;
                        drpOgrenciNo.DataBind();
                        drpOgrenciNo.Items.Insert(0, new ListItem("Öğrenci Seçiniz", ""));
                        baglanti.Close();

                    }
                    catch (Exception)
                    {
                        baglanti.Close();
                        Response.Redirect("DanismanDefault.aspx");
                    }
                }
            }

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlTransaction transaction1;
            transaction1 = baglanti.BeginTransaction();
            SqlCommand komut1 = new SqlCommand();
            SqlCommand komut2 = new SqlCommand();
            SqlCommand komut3 = new SqlCommand();
            SqlCommand komut4 = new SqlCommand();

            komut1.Transaction = transaction1;
            komut2.Transaction = transaction1;
            komut3.Transaction = transaction1;
            komut4.Transaction = transaction1;
           
            try
            {
                string OgrenciID = null;

                komut1.Connection = baglanti;
                komut1.CommandText = "Select OgrenciID From Ogrenci where OgrenciNo =@k1";
                komut1.Parameters.AddWithValue("@k1", drpOgrenciNo.SelectedValue);
                SqlDataReader dr = komut1.ExecuteReader();
                if (dr.Read())
                {
                    OgrenciID = dr["OgrenciID"].ToString();
                    dr.Close();
                    komut4.Connection = baglanti;
                    komut4.CommandText = "Select * from OgrenciDers Where DersId = @e1 and OgrenciId = @e2";
                    komut4.Parameters.AddWithValue("@e2", OgrenciID);
                    komut4.Parameters.AddWithValue("@e1", Request.QueryString["DersId"].ToString());
                    SqlDataReader dr2 = komut4.ExecuteReader();

                    if (!dr2.Read())
                    {
                        dr2.Close();

                        komut2.Connection = baglanti;
                        komut2.CommandText = "Insert Into OgrenciDers (OgrenciId,DersId) values (@p1,@p2)";
                        komut2.Parameters.AddWithValue("@p1", OgrenciID);
                        komut2.Parameters.AddWithValue("@p2", Request.QueryString["DersId"].ToString());

                        komut2.ExecuteNonQuery();

                        komut3.Connection = baglanti;
                        komut3.CommandText = "Insert Into Notlar (OgrenciID,OgrenciNo,DersID) values (@b1,@b2,@b3)";
                        komut3.Parameters.AddWithValue("@b1", OgrenciID);
                        komut3.Parameters.AddWithValue("@b2", drpOgrenciNo.SelectedValue);
                        komut3.Parameters.AddWithValue("@b3", Request.QueryString["DersId"].ToString());
                        komut3.ExecuteNonQuery();



                        komut1.Dispose();
                        komut2.Dispose();
                        komut3.Dispose();

                        transaction1.Commit();

                        Label1.Text = "Kayıt Başarıyla Eklenmiştir. Ders Listesi Sayfasına Yönlendiriliyorsunuz...";
                        Response.AppendHeader("Refresh", "1;url=DanismanOgrenciDersListesi.aspx");
                    }
                    else
                    {
                        dr.Close();
                        dr2.Close();
                        transaction1.Rollback();
                        Label1.Text = "Böyle Bir Numara Yok veya Kayıtlı Öğrenci";
                        Response.AppendHeader("Refresh", "1;url=DanismanOgrenciDersListesi.aspx");
                    }

                }
                else
                {
                    dr.Close();
                    transaction1.Rollback();
                    Label1.Text = "Böyle Bir Numara Yok veya Kayıtlı Öğrenci";
                    Response.AppendHeader("Refresh", "1;url=DanismanOgrenciDersListesi.aspx");
                }
            }
            catch (Exception)
            {
                transaction1.Rollback();
                Response.Redirect("DanismanDefault.aspx");
            }
            finally
            {
                baglanti.Close();

            }

        }
    }
}
