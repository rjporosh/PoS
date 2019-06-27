using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ES_Project
{
    class CreateDBID
    {
        public static SqlConnection con;
        public static SqlCommand cmd=new SqlCommand();
        public static SqlDataAdapter da=new SqlDataAdapter();
        public static DataSet ds;
        public static int id;

        public static string ConStr = ConfigurationManager.ConnectionStrings["c"].ConnectionString;
        public static int CreateID (string tbl, string c_id)
        {
            con = new SqlConnection(ConStr);
            con.Open();
            cmd = new SqlCommand("SELECT MAX("+c_id+") AS 'ID' FROM "+tbl, con);
            cmd.ExecuteNonQuery();
            ds = new DataSet();
            da = new SqlDataAdapter(cmd.CommandText, con);
            da.Fill(ds, "UID");
            if (ds.Tables["UID"].Rows[0][0].ToString()=="")
            {
                id = 0;
            }
            else
            {
                id = int.Parse(ds.Tables["UID"].Rows[0][0].ToString());
            }
            
             con.Close();
             return id+1;
            
        }
    }
}
