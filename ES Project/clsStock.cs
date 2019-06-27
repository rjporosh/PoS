using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ES_Project
{
    public class clsStock
    {
        private static string ConStr = DBConnection.ConStr;
        public static DataSet loadData()
          {
              using (var con = new SqlConnection(ConStr))
              {
                  string query = "SELECT CatID,Name FROM tblCategory;";
                  query += @" SELECT tblStock.[ProductID]
                 ,tblCategory.[Name] AS 'Category'
                 ,tblStock.[Name] AS 'ProductName'
                 ,tblStock.[Qty] AS 'Quantity'
                  ,tblStock.[PurchasePrice]
                  ,tblStock.[SalePrice]
                  ,tblUser.[Name] AS 'InsertedBy'
                  ,tblStock.[InsertionDate]
                  ,tblStock.[Narration]
                     FROM tblStock
                   LEFT OUTER JOIN tblCategory ON tblStock.CatID=tblCategory.CatID
                      LEFT OUTER JOIN tblUser ON tblStock.UserID = tblUser.UserID";
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
      public static void updateProduct(int productId, int catId, string name, int qty, decimal purchasePrice, decimal salePrice,string narration)
        {
            using (var con = new SqlConnection (ConStr))
            {
                string query = @"UPDATE [dbo].[tblStock]
   SET [CatID] = @catid
      ,[Name] = @name
      ,[Qty] = @qty
      ,[PurchasePrice] =@purchasePrice
      ,[SalePrice] = @salePrice,
      
      [Narration] = @narration
       WHERE ProductID=@productid";
                using (var cmd = new SqlCommand(query,con))
                {
                    con.Open();
                    
                    cmd.Parameters.AddWithValue("@productid", SqlDbType.Int).Value = productId;
                    cmd.Parameters.AddWithValue("@catId", SqlDbType.Int).Value = catId;
                    cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.AddWithValue("@qty", SqlDbType.Int).Value = qty;
                    cmd.Parameters.AddWithValue("@purchasePrice", SqlDbType.Decimal).Value = purchasePrice;
                    cmd.Parameters.AddWithValue("@salePrice", SqlDbType.Decimal).Value = salePrice;
                    //cmd.Parameters.AddWithValue("@userId", SqlDbType.Int).Value = userId;
                    cmd.Parameters.AddWithValue("@narration", SqlDbType.NVarChar).Value = narration;

                    cmd.ExecuteNonQuery();
                    
                }

            }
        }
        
        public static void deleteProduct(int id)
      {
          using (var con = new SqlConnection(ConStr))
          {
              string query = "DELETE FROM tblStock WHERE ProductID=@proid";
              using (var cmd = new SqlCommand(query,con))
              {
                  con.Open();
                  cmd.Parameters.AddWithValue("@proid", SqlDbType.Int).Value = id;

                  cmd.ExecuteNonQuery();
              }
          }
      }

    }
}
