using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacie
{
    public partial class Q2_Page_Acceuill : System.Web.UI.Page
    {
        Cnx c = new Cnx();
        DataTable dt=new DataTable();
        
       
        public void remplirGRID2()
        {
            
            c.cmd = new SqlCommand("select * from medecin",c.cnx);
            /*c.dap = new SqlDataAdapter("select * from medecin", c.cnx);
            c.dap.Fill(c.ds,"med");
            GridView2.DataSource = c.ds.Tables["med"];*/
            SqlDataReader dr = c.cmd.ExecuteReader();
            dt.Load(dr);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dr.Close();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["idMD"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            c.ouvrircnx();
            SqlDataAdapter dap1 = new SqlDataAdapter("select * from Medecin", c.cnx);
            dap1.Fill(c.ds, "medecin");
            PatientListe.DataSource = c.ds.Tables["medecin"];
            PatientListe.DataTextField = "NomMd";
            PatientListe.DataValueField = "NumMedecin";
            PatientListe.DataBind();
            //è---------------------------------------------------------------
            /*c.cmd.CommandText = "select * from Patient";
            c.cmd.Connection = c.cnx;
            c.dr = c.cmd.ExecuteReader();
            while (c.dr.Read())
            {
                PatientListe.Items.Add(c.dr["NomP"].ToString());
            }*/
            //c.dr.Close();

            // Remplissage Grid View
            DataTable dt = new DataTable();
            SqlCommand cmd2 = new SqlCommand($"select do.NumOrdonnance, do.NumMedicament,ord.DateOrdonnance from DetailOrdonnance do " +
                "inner join Ordonnance ord on ord.NumOrdonnance=do.NumOrdonnance" +
                "inner join Medecin m on m.NumMedecin=ord.NumMedecin where  m.loginMD="+Session["idMD"]+"", c.cnx) ;
            /*cmd2.Parameters.AddWithValue("@a", PatientListe.SelectedItem);
            cmd2.Parameters.AddWithValue("@b", Session["idMD"]);*/
            try
            {
                SqlDataReader dr2 = cmd2.ExecuteReader();
                dt.Load(dr2);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
            if (!Page.IsPostBack)
            {
                remplirGRID2();
            }
            
            GridView2.Columns.Clear();
            
        }
        public int Existance()
        {
            c.ouvrircnx();
            int cpt;
            SqlCommand cmd = new SqlCommand("select count(NumMedecin) from medecin where NumMedecin='" + TextBox1.Text + "' ", c.cnx);
            cpt = (int)cmd.ExecuteScalar();
            c.fermercnx();
            return cpt;
        }
        public void ajouter()
        {
            c.ouvrircnx();

            c.cmd.CommandText = string.Format("insert into medecin values({0},'{1}','{2}','{3}','{4}','{5}')", TextBox1.Text, TextBox2.Text
                , TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text);
            c.cmd.Connection = c.cnx;
            if (Existance()!=0)
            {
                
                Response.Write("<script>alert('Ce medecin exist deja :///////');</script>");
                return;
            }
            else
            {
                 c.cmd.ExecuteNonQuery();
                 Response.Write("<script>alert('Bien ajouté !!!!!!!!!');</script>");
            }
            
            
            //GridView2.DataSource = null;
            remplirGRID2();
        }

        protected void btnADD_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text=="" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "")
            {
                Response.Write("<script>alert('Remplir tous les champs !!!!!!!!!');</script>");
                return;
            }
            ajouter();
        }

        

        protected void GridView2_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            int code = Convert.ToInt32(GridView2.Rows[a].Cells[5].Text);
            c.ouvrircnx();
            c.cmd.CommandText = "delete from medecin where NumMedecin='" + code + "' ";
            c.cmd.Connection = c.cnx;
            c.cmd.ExecuteNonQuery();
            remplirGRID2();
            c.fermercnx();
            
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.NewEditIndex = 1;
            //int code = Convert.ToInt32(GridView2.Rows[a].Cells[1].Text);
            c.ouvrircnx();
            c.cmd.CommandText = "Update medecin set NomMd=@a,prenomMD=@b,specialité=@c,loginMD=@d,passMD=@e  where NumMedecin=@nm ";
            c.cmd.Parameters.AddWithValue("@a", TextBox2.Text);
            c.cmd.Parameters.AddWithValue("@b", TextBox3.Text);
            c.cmd.Parameters.AddWithValue("@c", TextBox4.Text);
            c.cmd.Parameters.AddWithValue("@d", TextBox5.Text);
            c.cmd.Parameters.AddWithValue("@e", TextBox6.Text);
            c.cmd.Parameters.AddWithValue("@nm", TextBox1.Text);
            c.cmd.Connection = c.cnx;
            c.cmd.ExecuteNonQuery();
            remplirGRID2();
            c.fermercnx();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView2_RowEditing(object sender, GridViewUpdateEventArgs e)
        {

        }

        /*protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int r = e.NewSelectedIndex;
            TextBox1.Text = GridView2.Rows[r].Cells[0].Text;
            TextBox2.Text = GridView2.Rows[r].Cells[1].Text;
            TextBox3.Text = GridView2.Rows[r].Cells[2].Text;
            TextBox4.Text = GridView2.Rows[r].Cells[3].Text;
            TextBox5.Text = GridView2.Rows[r].Cells[4].Text;
            TextBox6.Text = GridView2.Rows[r].Cells[5].Text;
        }*/
    }
}