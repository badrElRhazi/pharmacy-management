using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacie
{
    public class Cnx
    {
        public SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-F2S5KPP;Initial Catalog=Pharmacie;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataSet ds=new DataSet();
        public SqlDataAdapter dap = new SqlDataAdapter();
        public void ouvrircnx()
        {
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
        }
        public void fermercnx()
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }
    }
}