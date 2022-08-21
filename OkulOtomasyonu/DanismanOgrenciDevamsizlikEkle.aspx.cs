using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class DanismanOgrenciDevamsizlikEkle : System.Web.UI.Page
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
                    TextOgrId.Text = Request.QueryString["OgrenciID"];
                    TextOgrNo.Text = Request.QueryString["OgrenciNo"];
                    TextDevTarih.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                }
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlTransaction transaction1;
            transaction1 = baglanti.BeginTransaction();
            SqlCommand komut1 = new SqlCommand();
            komut1.Transaction = transaction1;

            try
            {


                komut1.Connection = baglanti;
                komut1.CommandText = "Insert Into Devamsizlik (OgrenciID,DevamsizlikTarihi,DevamsizlikDurumu,OgrenciNo) values (@p1,@p2,@p3,@p4)";
                komut1.Parameters.AddWithValue("@p1", TextOgrId.Text);
                komut1.Parameters.AddWithValue("@p2", TextDevTarih.Text);
                komut1.Parameters.AddWithValue("@p3", TextDevDurum.Text);
                komut1.Parameters.AddWithValue("@p4", TextOgrNo.Text);

                komut1.ExecuteNonQuery();

                transaction1.Commit();
                Label1.Text = "Devamsızlık eklendi. Öğrenci Devamsızlık Listesine Yönlendiriliyorsunuz...";
                Response.AppendHeader("Refresh", "1;url=DanismanOgrenciDevamsizlikListesi.aspx");
              
            }
            catch (Exception)
            {
                transaction1.Rollback();
                Response.Redirect("DanismanDefault.aspx");
            }
            finally
            {
                baglanti.Close();
                komut1.Dispose();
            }
        }
    }
}