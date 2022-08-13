using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class DanismanOgrenciDevamsizlikGoruntule : System.Web.UI.Page
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
                SqlCommand komut = new SqlCommand("Select DevamsizId,DevamsizlikTarihi,DevamsizlikDurumu from Devamsizlik Inner Join Ogrenci on Ogrenci.OgrenciID = Devamsizlik.OgrenciID where Ogrenci.OgrenciID = @OgrenciID", baglanti);
                komut.Parameters.AddWithValue("@OgrenciID", Request.QueryString["OgrenciID"]);
                SqlDataReader dr = komut.ExecuteReader();

                Repeater1.DataSource = dr;
                Repeater1.DataBind();

                baglanti.Close();
                komut.Dispose();
            }
        }
    }
}