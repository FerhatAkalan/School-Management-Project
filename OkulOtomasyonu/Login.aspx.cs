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
    public partial class Login : System.Web.UI.Page
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=OkulOtomasyonu;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            
          
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * from Login where KullaniciAdi=@p1 and Sifre=@p2 and durum = 1", baglanti);
                komut.Parameters.AddWithValue("@p1", TxtNumara.Text);
                komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    Session.Add("KullaniciAdi", TxtNumara.Text);
                    
                    String rol = dr["Rol"].ToString();
                    if (rol == "Personel")
                    {
                        Response.Redirect("PersonelDefault.aspx");

                    }
                    else if (rol == "Ogrenci")
                    {
                        Response.Redirect("OgrenciDefault.aspx");

                    }
                    else
                    {
                        Response.Redirect("DanismanDefault.aspx");
                    }
                }
                else
                {
                    Label1.Text = "Kullanıcı Adı veya Şifre Yanlış! (Hesabınız aktif olmayabilir!)";
                }
                komut.Dispose();
                baglanti.Close();

            }
            catch (Exception)
            {
                Label1.Text = "Veritabanına Bağlanılamadı.";
               
            }
        }
    }
}