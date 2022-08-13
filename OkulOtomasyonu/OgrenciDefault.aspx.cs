using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkulOtomasyonu
{
    public partial class OgrenciDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["KullaniciAdi"] == null)
            {
                Response.Redirect("Login.aspx");
                Label1.Text = "Boş";

            }
            else
            {
                Label1.Text = "Hoşgeldin Sayın " + Session["KullaniciAdi"].ToString();
                Response.AppendHeader("Refresh", "1;url=OgrenciGrafikler.aspx");
            }
        }
        
    }
}