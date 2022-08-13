using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class OgrenciNotListesi : System.Web.UI.Page
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

                SqlCommand komut = new SqlCommand("Select Notlar.DersID,DersAd,DersKredi,DersVize,DersFinal,DersNotu,Durum from Notlar Inner Join Ders On Ders.DersId = Notlar.DersID where OgrenciNo = @OgrenciNo", baglanti);
                komut.Parameters.AddWithValue("@OgrenciNo", Session["KullaniciAdi"].ToString());
                SqlDataReader dr = komut.ExecuteReader();
                Repeater1.DataSource = dr;
                Repeater1.DataBind();
                dr.Close();
                Control FooterTemplate = Repeater1.Controls[Repeater1.Controls.Count - 1].Controls[0];
                Label Label1 = FooterTemplate.FindControl("Label1") as Label;
                SqlCommand komut2 = new SqlCommand("Select Avg(Convert(float,DersNotu)) as GANO from Notlar where OgrenciNo = @OgrenciNo", baglanti);
                komut2.Parameters.AddWithValue("@OgrenciNo", Session["KullaniciAdi"].ToString());
                SqlDataReader dr2 = komut2.ExecuteReader();
                if (dr2.Read())
                {
                    Label1.Text = "Genel Ağırlıklı Not Ortalaması: " + dr2["GANO"].ToString();
                    dr2.Close();
                }

                baglanti.Close();
                komut.Dispose();
            }

        }
    }
}