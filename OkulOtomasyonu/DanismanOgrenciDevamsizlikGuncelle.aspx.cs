using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class DanismanOgrenciDevamsizlikGuncelle : System.Web.UI.Page
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
                        SqlCommand komut = new SqlCommand("Select DevamsizId,DevamsizlikTarihi,DevamsizlikDurumu from Devamsizlik where DevamsizId = @DevamsizId", baglanti);
                        komut.Parameters.AddWithValue("@DevamsizId", Request.QueryString["DevamsizId"].ToString());
                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            TextDevId.Text = dr["DevamsizId"].ToString();
                            TextDevTarihi.Text = dr["DevamsizlikTarihi"].ToString();
                            TextDevDurum.Text = dr["DevamsizlikDurumu"].ToString();
                            baglanti.Close();
                            komut.Dispose();
                        }

                    }
                    catch (Exception)
                    {
                        baglanti.Close();
                        Response.Redirect("DanismanDefault.aspx");
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
                komut2.CommandText = "UPDATE Devamsizlik SET DevamsizlikDurumu = @p1 WHERE DevamsizId = @DevamsizId";
                komut2.Parameters.AddWithValue("@p1", TextDevDurum.Text);
                komut2.Parameters.AddWithValue("@DevamsizId", Request.QueryString["DevamsizId"].ToString());
                komut2.ExecuteNonQuery();
                
                transaction1.Commit();

                Label1.Text = "Kayıt Başarıyla Güncellendi. Devamsızlık Listesi Sayfasına Yönlendiriliyorsunuz...";
                Response.AppendHeader("Refresh", "1;url=DanismanOgrenciListesi.aspx");


            }
            catch (Exception)
            {
                transaction1.Rollback();
                Response.Redirect("DanismanDefault.aspx");

            }
            finally
            {
                baglanti.Close();
                komut2.Dispose();

            }
        }
    }
}