using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacie
{
    public partial class Login : System.Web.UI.Page
    {
        Cnx c = new Cnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (RadPahrma.Checked == true)
            {
                c.ouvrircnx();
                c.cmd.CommandText = "select * from Pharmacien where loginPh=@a and passPh=@b";
                c.cmd.Connection = c.cnx;
                c.cmd.Parameters.AddWithValue("@a", Login1.UserName);
                c.cmd.Parameters.AddWithValue("@b", Login1.Password);
                c.dr = c.cmd.ExecuteReader();
                if (c.dr.HasRows==true)
                {
                    Session["idPH"] = Login1.UserName;
                    e.Authenticated = true;
                    Response.Redirect("Page_Home.aspx");
                }
                else
                {
                    e.Authenticated = false;
                }
                c.fermercnx();
            }
            if (RadMedcin.Checked == true)
            {
                c.ouvrircnx();
                c.cmd.CommandText = "select * from where loginMD=@a and passMd=@b";
                c.cmd.Connection = c.cnx;
                c.cmd.Parameters.AddWithValue("@a", Login1.UserName);
                c.cmd.Parameters.AddWithValue("@b", Login1.Password);
                if (c.dr.HasRows == true)
                {
                    Session["idMD"] = Login1.UserName;
                    e.Authenticated = true;
                    Response.Redirect("Q2_Page_Acceuill.aspx");
                }
                else
                {
                    e.Authenticated = false;
                }
            }
        }
    }
}