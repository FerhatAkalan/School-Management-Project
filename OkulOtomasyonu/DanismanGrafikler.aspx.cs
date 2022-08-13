using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class DanismanGrafikler : System.Web.UI.Page
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
                try
                {
                    if (!IsPostBack)
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("Execute Graf1", baglanti);
                        SqlDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            Chart1.Series["Bölümler"].Points.AddXY((dr[0].ToString()), int.Parse(dr[1].ToString()));
                        }
                        baglanti.Close();
                        dr.Close();
                        komut.Dispose();

                        baglanti.Open();
                        SqlCommand komut2 = new SqlCommand("Execute Graf2", baglanti);
                        SqlDataReader dr2 = komut2.ExecuteReader();
                        while (dr2.Read())
                        {
                            Chart2.Series["Cinsiyet"].Points.AddXY((dr2[0].ToString()), int.Parse(dr2[1].ToString()));
                        }
                        baglanti.Close();
                        dr2.Close();
                        komut2.Dispose();

                        baglanti.Open();
                        string danismanID = null;
                        SqlCommand komut5 = new SqlCommand("Select DanismanId from Danisman inner join Login on Login.ID = Danisman.LoginID where KullaniciAdi = @b1", baglanti);
                        komut5.Parameters.AddWithValue("@b1", Session["KullaniciAdi"].ToString());
                        SqlDataReader dr5 = komut5.ExecuteReader();
                        while (dr5.Read())
                        {
                            danismanID= dr5["DanismanId"].ToString();

                        }
                        baglanti.Close();
                        dr5.Close();
                        komut5.Dispose();

                        baglanti.Open();
                        SqlCommand komut3 = new SqlCommand("Select Count(*) as Toplam from Ogrenci INNER join Login ON Ogrenci.LoginID = login.ID Where Durum=1 and Danisman =@p1", baglanti);
                        komut3.Parameters.AddWithValue("@p1", danismanID);
                        SqlDataReader dr3 = komut3.ExecuteReader();
                        while (dr3.Read())
                        {
                            TextBox1.Text = "Danışmana Kayıtlı Toplam Aktif Öğrenci Sayısı: " + dr3["Toplam"].ToString();

                        }
                        baglanti.Close();
                        dr3.Close();
                        komut3.Dispose();

                        baglanti.Open();
                        SqlCommand komut4 = new SqlCommand("Select Count(*) as Toplam2 from Danisman INNER join Login ON Danisman.LoginID = login.ID Where Durum=1", baglanti);
                        SqlDataReader dr4 = komut4.ExecuteReader();
                        while (dr4.Read())
                        {
                            TextBox2.Text = "Toplam Aktif Danışman Sayısı: " + dr4["Toplam2"].ToString();

                        }
                        baglanti.Close();
                        dr4.Close();
                        komut4.Dispose();
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("DanismanDefault.aspx");

                }
            }
        }
    }
}