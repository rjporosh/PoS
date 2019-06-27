using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ES_Project
{
    public class clsCreateSP
    {
        static string ConStr = DBConnection.ConStr;

        public static DataSet fetchRole()
        {
            using (var con = new SqlConnection(ConStr))
            {
                string query = "SELECT RoleID,Name FROM tblRole;";
                query += @" 
                SELECT tblUser.UserID, tblRole.Name AS 'Access', tblUser.Name, tblUser.Password, tblUser.Cell, tblUser.City, tblUSer.Address, tblUser.Narration, tblUserStatus.Name AS'Status', tblUser.Date
                FROM tblUser 
                LEFT OUTER JOIN tblRole ON tblUser.RoleID=tblRole.RoleID
                LEFT OUTER JOIN tblUserStatus ON tblUser.UserStatusID=tblUserStatus.UserStatusID;";
                query += @" SELECT UserStatusID,Name FROM tblUserStatus";
                using (var cmd = new SqlCommand(query,con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                   
                }
            }
        }

        public static void insertDetails(int id, int roleId, string name, string pass, string address, string city, string cell, string narration, DateTime dt, int statusID)
        {
            using (var con = new SqlConnection (ConStr))
            {
                string query = @"INSERT INTO [dbo].[tblUser]
           ([UserID]
           ,[RoleID]
           ,[Name]
           ,[Password]
           ,[Address]
           ,[City]
           ,[Cell]
           ,[Narration]
           ,[Date]
            ,[UserStatusID])
            VALUES(@id, @roleId, @name, @pass, @address, @city, @cell, @narration, @date, @statusID)";
                using (var cmd = new SqlCommand(query,con))
                {
                    con.Open();

                    

                    cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.AddWithValue("@roleId", SqlDbType.Int).Value = roleId;
                    cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.AddWithValue("@pass", SqlDbType.NVarChar).Value = pass;
                    cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = address;
                    cmd.Parameters.AddWithValue("@city", SqlDbType.NVarChar).Value = city;
                    cmd.Parameters.AddWithValue("@cell", SqlDbType.NVarChar).Value = cell;
                    cmd.Parameters.AddWithValue("@narration", SqlDbType.NVarChar).Value = narration;
                    cmd.Parameters.AddWithValue("@date", SqlDbType.Date).Value = dt;
                    cmd.Parameters.AddWithValue("@statusID", SqlDbType.Date).Value = statusID;

                    cmd.ExecuteNonQuery();

                }
            }
        }
        public static void deleteAccount(int accountId)
        {
            using (var con = new SqlConnection(ConStr))
            {
                string query = "DELETE FROM tblUser WHERE UserID=@accountId";
                using (var cmd = new SqlCommand(query,con))
                {
                    con.Open();
                    cmd.Parameters.Add("@accountId", SqlDbType.Int).Value = accountId;
                    cmd.ExecuteNonQuery();
                }
            }
        }
         public static void updateAccount(int AccountID, int roleId, string name, string pass, string address, string city, string cell, string narration, int statusid)
         {
             using (var con = new SqlConnection(ConStr))
             {
                 string query = @"UPDATE tblUser SET Name=@name, Password=@pass, Cell=@cell, City=@city, Address=@address, narration=@narration, RoleID=@roleId, UserStatusID=@statusid
                 WHERE UserID=@accountID";
                 using (var cmd = new SqlCommand(query,con))
                 {
                     con.Open();
                     cmd.Parameters.AddWithValue("@roleId", SqlDbType.Int).Value = roleId;
                     cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
                     cmd.Parameters.AddWithValue("@pass", SqlDbType.NVarChar).Value = pass;
                     cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = address;
                     cmd.Parameters.AddWithValue("@city", SqlDbType.NVarChar).Value = city;
                     cmd.Parameters.AddWithValue("@cell", SqlDbType.NVarChar).Value = cell;
                     cmd.Parameters.AddWithValue("@accountID", SqlDbType.Int).Value = AccountID;
                     cmd.Parameters.AddWithValue("@narration", SqlDbType.NVarChar).Value = narration;
                     cmd.Parameters.AddWithValue("@statusid", SqlDbType.Int).Value = statusid;

                     cmd.ExecuteNonQuery();
                 }
             }
         }
    }
}
