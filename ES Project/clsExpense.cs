using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ES_Project
{
    public class clsExpense
    {
        private static string ConStr = DBConnection.ConStr;
        public static DataSet loadData()
        {

            using (var con = new SqlConnection(ConStr))
            {
                string query = "Select Title from tblExpense;";
                query += " SELECT * FROM tblExpense;";
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }  
        }
        public static void insertDetails(int ExpId, string title, decimal amt, string desc, DateTime dt, int userid)
        {
            using (var con = new SqlConnection(ConStr))
            {
                string query = @"INSERT INTO [dbo].[tblExpense]
           ([ExpenseID]
           ,[Title]
           ,[Amount]
           ,[Description]
           ,[Date]
           ,[UserID])
            VALUES(@ExpId, @title,@amt,@desc,@date,@userid)";
                using (var cmd = new SqlCommand(query,con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ExpId", SqlDbType.Int).Value = ExpId;
                    cmd.Parameters.AddWithValue("@title", SqlDbType.Int).Value = title;
                    cmd.Parameters.AddWithValue("@amt", SqlDbType.Int).Value = amt;
                    cmd.Parameters.AddWithValue("@desc", SqlDbType.Int).Value = desc;
                    cmd.Parameters.AddWithValue("@date", SqlDbType.Int).Value = dt;
                    cmd.Parameters.AddWithValue("@userid", SqlDbType.Int).Value = userid;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void updateExp(int ExpId, string title, decimal amt, string desc, DateTime dt)
        {
            using (var con = new SqlConnection(ConStr))
            {
                string query = @"UPDATE [dbo].[tblExpense]
               SET [Title] = @title
               ,[Amount] = @amt
              ,[Description] = @desc
              ,[Date] = @date 
 WHERE ExpenseID=@ExpId";
                using (var cmd = new SqlCommand(query,con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ExpId", SqlDbType.Int).Value = ExpId;
                    cmd.Parameters.AddWithValue("@title", SqlDbType.Int).Value = title;
                    cmd.Parameters.AddWithValue("@amt", SqlDbType.Int).Value = amt;
                    cmd.Parameters.AddWithValue("@desc", SqlDbType.Int).Value = desc;
                    cmd.Parameters.AddWithValue("@date", SqlDbType.Int).Value = dt;

                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
