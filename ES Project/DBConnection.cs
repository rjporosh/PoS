using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ES_Project
{
    public class DBConnection
    {
        public static string ConStr = ConfigurationManager.ConnectionStrings["c"].ConnectionString;

        //public static SqlConnection conn = new SqlConnection(c);
    }
}
