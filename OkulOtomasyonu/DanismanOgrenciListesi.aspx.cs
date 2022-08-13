using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class DanismanOgrenciListesi : System.Web.UI.Page
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
                baglanti.Open();
                string DanismanId ="";
                SqlCommand komut = new SqlCommand("Select DanismanId from Login INNER JOIN Danisman ON Login.ID = Danisman.LoginID where KullaniciAdi = @p1 ", baglanti);
                komut.Parameters.AddWithValue("@p1", Session["KullaniciAdi"].ToString());
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    DanismanId = dr["DanismanID"].ToString();
                    baglanti.Close();
                    komut.Dispose();
                }
                dr.Close();

                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("Select OgrenciID,OgrenciNo,OgrenciAd,OgrenciSoyad,OgrenciMail,OgrenciTel,Bolum,Sinif from Ogrenci INNER join Login ON Ogrenci.LoginID = login.ID Where Durum=1 and Danisman=@danismanid", baglanti);
                komut2.Parameters.AddWithValue("@danismanid", DanismanId);
                SqlDataReader dr2 = komut2.ExecuteReader();
                Repeater1.DataSource = dr2;
                Repeater1.DataBind();
                baglanti.Close();
                komut2.Dispose();
            }
        }
    }
}