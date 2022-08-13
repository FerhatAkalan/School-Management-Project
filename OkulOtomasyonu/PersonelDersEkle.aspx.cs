using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class PersonelDersEkle : System.Web.UI.Page
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
                    SqlCommand komut = new SqlCommand("Select Max(DersId) as Numara from Ders", baglanti);

                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        TextDersId.Text = ((int)dr["Numara"] + 1).ToString();
                        baglanti.Close();
                        komut.Dispose();
                    }
                }
            }
        }


        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Insert Into Ders (DersAd, DersKredi) values (@p1,@p2)", baglanti);


            komut1.Parameters.AddWithValue("@p1", TextDersAd.Text);
            komut1.Parameters.AddWithValue("@p2", TextDersKredi.Text);
           
            komut1.ExecuteNonQuery();

            baglanti.Close();
            komut1.Dispose();

            Label1.Text = "Kayıt Başarıyla Eklenmiştir. Ders Listesi Sayfasına Yönlendiriliyorsunuz...";
            Response.AppendHeader("Refresh", "10;url=PersonelDersListesi.aspx");



        }
    }
}