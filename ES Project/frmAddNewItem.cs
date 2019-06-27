using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ES_Project
{
    public partial class frmAddNewItem : Form
    {
        DataSet detailsDS = new DataSet();
        //string queryToExecute;
        public int id;
        string ConStr = DBConnection.ConStr;
        SqlConnection objc;
        SqlCommand objcmd;
        SqlDataAdapter objda;
        DataSet objds;
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;
        int n;
        public frmAddNewItem()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            //if ((tbId.Text == "") || (tbName.Text == "") || (tbQty.Text == "") || (tbPurchasePrice.Text == ""))
            //{

            //    MessageBox.Show("Fields marked with * are mandatory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    try
            //    {
            //        objc = new SqlConnection(c);
            //        string id = Convert.ToString(tbId.Text).Trim();
            //        string name = Convert.ToString(tbName.Text).Trim();
            //        int q = Convert.ToInt32(tbQty.Text.Trim());
            //        int p_price = Convert.ToInt32(tbPurchasePrice.Text.Trim());
            //       // int s_price = Convert.ToInt32(tbRSPrice.Text.Trim());
            //        string des = Convert.ToString(tbNarration.Text.Trim());
            //       // int w_price = Convert.ToInt32(tbWSPrice.Text.Trim());
            //        objcmd = new SqlCommand("select * from Add_New_Item where SrNo='" + id + "'", objc);
            //        objda = new SqlDataAdapter(objcmd.CommandText, objc);
            //        objds = new DataSet();
            //        objda.Fill(objds, "student");
            //        n = objds.Tables["student"].Rows.Count;
            //        if (n > 0)
            //        {
            //            MessageBox.Show("Product ID already Exist in stock, Please Change Product ID or Try Updating Existing Item", "Item Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            tbId.Clear();
            //            tbId.Focus();
                        
            //        }
            //        else
            //        {
            //            DateTime dt = DateTime.Now;
            //            string date = dt.ToLongTimeString();
                        
                        
            //            objc = new SqlConnection(c);
            //            objcmd = new SqlCommand("insert into Add_New_Item(SrNo,Product_Name,Quantity,Purchase_Price,Description, Username, date) values ('" + id + "','" + name + "','" + q + "','" + p_price + "','"  + des + "', '"+Class1.LoggedInUsername+"', '"+dt.ToString()+"')", objc);
            //            objc.Open();
            //            objcmd.ExecuteNonQuery();
            //            objc.Close();

                        
            //            //textBox2.Clear();
            //            tbQty.Clear();
            //            tbPurchasePrice.Clear();
            //            //tbRSPrice.Clear();
            //           // tbWSPrice.Clear();
            //            tbNarration.Clear();
                        
            //            MessageBox.Show("Item information successfully saved under Name " + tbName.Text + "", tbId.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            tbName.Clear();
            //            tbId.Clear();
            //            //refresh gridview

            //            objc = new SqlConnection(c);
            //            objcmd = new SqlCommand("select SrNo AS 'PRODUCT ID', Product_Name AS 'PRODUCT NAME', Quantity AS 'ITEMS AVAILABLE', Purchase_Price AS 'ORIGINAL PRICE', DESCRIPTION AS 'DESCRIPTION', USERNAME AS 'INSERTED BY', DATE AS 'DATE OF CREATION' from Add_New_Item", objc);
            //            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            //            objds = new DataSet();
            //            objda.Fill(objds, "Login");

            //            dataGridView2.DataSource = objds.Tables["Login"].DefaultView;
           
            
            //        }
            //    }
            //    catch { MessageBox.Show("Database Error, Item Can not be added in stock, Contact Administrator", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //}
        }

        private void frmAddNewItem_Load(object sender, EventArgs e)
        {
            detailsDS.Clear();
            loadGrid();
            

            
            
        }

        private void loadGrid()
        {
            detailsDS.Clear();
            detailsDS = clsStock.loadData();
            dataGridView2.DataSource = detailsDS.Tables[1].DefaultView;
        }

        private void fetchInteliSense()
        {

            try
            {
                using (var con = new SqlConnection(ConStr))
                {
                    string query = "SELECT Name,ProductID FROM tblStock WHERE CatID=@catid";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@catid", SqlDbType.Int).Value = int.Parse(cbCat.SelectedValue.ToString());
                        SqlDataReader reader = cmd.ExecuteReader();
                        
                        SqlDataAdapter da = new SqlDataAdapter();
                        AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                        while (reader.Read())
                        {
                            MyCollection.Add(reader.GetString(0));
                            
                        }
                        tbName.AutoCompleteCustomSource = MyCollection;
                        //comboBox1.AutoCompleteCustomSource = MyCollection;
                        
                        
                    }
                }
            }
            catch 
            {
            }
        }
    

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)

        {
            //allows only alphabets, digits and backspace key
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            tbId.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allows only string, white space and backspace key
            if(!char.IsLetterOrDigit(e.KeyChar) && (!char.IsWhiteSpace(e.KeyChar) && (!char.IsControl(e.KeyChar))))
            {
                e.Handled=true;
               
            }
            //this will make field in uppercase
            tbName.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        
        {
            //this will put item name in description also(as default)
            tbNarration.Text = tbName.Text;
            tbNarration.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if(!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }

        }

        private void textBox3_ControlRemoved(object sender, ControlEventArgs e)
        {
            
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            fetchInteliSense();
            
            
        }

        

        private void tbName_Leave(object sender, EventArgs e)
        {
            if (tbName.Text.Trim()==string.Empty)
            {
                return;
            }
            using (var con = new SqlConnection(ConStr))
            {
                string query = "SELECT ProductID FROM tblStock WHERE Name=@name";
                using (var cmd = new SqlCommand(query,con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = tbName.Text.Trim();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count==0)
                    {
                        tbId.Clear();
                        id = CreateDBID.CreateID("tblStock", "ProductID");
                        tbId.Text = id.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Product Already Exist in stock. Please Review Name or UPDATE QUANTITY of previously available product\nProduct ID is:  "+ds.Tables[0].Rows[0][0].ToString(), "Product Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbName.Clear();
                        tbName.Focus();
                        tbId.Clear();
                        return;

                    }

                }
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
           
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbId_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Space)
            {
                tbName.AppendText("-");
            }
        }

        private void tbName_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void numQty_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            if (numQty.Value.ToString()=="")
            {
                numQty.Value = 0;
            }
        }

        public void cbCat_Click(object sender, EventArgs e)
        {
            loadCategory();
        }

        public void loadCategory()
        {
            DataSet details = clsStock.loadData();
            cbCat.DataSource = details.Tables[0].DefaultView;
            cbCat.DisplayMember = "Name";
            cbCat.ValueMember = "CatID";
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text.Trim()!=string.Empty)
            {
                if (cbCat.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select category first.", "Category not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbName.Clear();
                    cbCat.Focus();
                    return;
                } 
            }
        }

        private void btn_submit_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTimee.Value.ToShortDateString());
            if (tbSalePrice.Text.Trim() == string.Empty || tbSalePrice.Text.Trim() == "0" || tbSalePrice.Text.Trim() == "0.00")
            {
                tbSalePrice.Text = "0";
            }
            if (tbName.Text.Trim() == string.Empty || numQty.Value == 0 || tbPurchasePrice.Text.Trim() == string.Empty || tbPurchasePrice.Text.Trim() == "0" || tbPurchasePrice.Text.Trim() == "0.00" ||numQty.Value.ToString()==string.Empty)
            {
                MessageBox.Show("Input validation error.Please check product information and try again\nDetails:\n1. Product Name not provided\n2. Product Quantity not provided or Provided as 0.\n3. Purchase Price not provided or provided as 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var con = new SqlConnection(ConStr))
                {
                    string queryToExecute = @"INSERT INTO [dbo].[tblStock]
                         ([ProductID]
                         ,[CatID]
                         ,[Name]
                         ,[Qty]
                         ,[PurchasePrice]
                         ,[SalePrice]
                         ,[UserID]
                         ,[InsertionDate]
                         ,[Narration]) VALUES(@productId,@catId,@name,@qty,@purchasePrice, @salePrice,@userId,@insertionDate,@narration)";
                    using (var cmd = new SqlCommand(queryToExecute, con))
                    {
                        
                        con.Open();
                        cmd.Parameters.AddWithValue("@productId", SqlDbType.Int).Value = tbId.Text.Trim();
                        cmd.Parameters.AddWithValue("@catId", SqlDbType.Int).Value = cbCat.SelectedValue.ToString();
                        cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = tbName.Text.Trim();
                        cmd.Parameters.AddWithValue("@qty", SqlDbType.Int).Value = numQty.Value;
                        cmd.Parameters.AddWithValue("@purchasePrice", SqlDbType.Decimal).Value = decimal.Parse(tbPurchasePrice.Text);
                        cmd.Parameters.AddWithValue("@salePrice", SqlDbType.Decimal).Value = decimal.Parse(tbSalePrice.Text);
                        cmd.Parameters.AddWithValue("@userId", SqlDbType.Int).Value = int.Parse(lbluserid.Text.Trim());
                        cmd.Parameters.AddWithValue("@narration", SqlDbType.NVarChar).Value = tbNarration.Text.Trim();
                        cmd.Parameters.AddWithValue("@insertionDate", SqlDbType.Date).Value = DateTimee.Value; ;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New Product Saved Successfully in system\nProduct Details: \nProduct ID: " + tbId.Text.Trim() + "\nName: " + tbName.Text + "\nCategory: " + cbCat.Text.Trim() + "\nPurchase Price: PKRS: " + tbPurchasePrice.Text + ".00" + "\nSale Price: PKRS: " + tbSalePrice.Text + ".00" + "\nDescription: " + tbNarration.Text.Trim(), "Saved Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbNarration.Clear(); tbName.Clear(); tbId.Clear(); tbPurchasePrice.Clear(); tbSalePrice.Clear();
                        tbName.Focus();
                        loadGrid();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error occurred while inserting new product in system\nDetails: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }
        private void tbPurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tbSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
          
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmModifyStock frm = new frmModifyStock();
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                frm.tbName.Text = row.Cells["ProductName"].Value.ToString();
                frm.tbId.Text = row.Cells["ProductID"].Value.ToString();
                frm.tbPurchasePrice.Text = row.Cells["PurchasePrice"].Value.ToString();
                frm.tbSalePrice.Text = row.Cells["SalePrice"].Value.ToString();
                frm.tbNarration.Text = row.Cells["Narration"].Value.ToString();

                frm.numQty.Value = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                frm.cbCat.Text = row.Cells["Category"].Value.ToString();

                frm.ShowDialog();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddNewItem_Activated(object sender, EventArgs e)
        {
           detailsDS.Clear();
            loadGrid();
        }

        private void tbFilterCategory_TextChanged(object sender, EventArgs e)
        {
            DataView dv = detailsDS.Tables[1].DefaultView;
            dv.RowFilter = "Category LIKE '%" + tbFilterCategory.Text.Trim()+ "%'";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            detailsDS.Clear();
            loadGrid();
        }

        private void tbFilterProductName_TextChanged(object sender, EventArgs e)
        {
            DataView dv = detailsDS.Tables[1].DefaultView;
            dv.RowFilter = "ProductName LIKE '%" + tbFilterProductName.Text.Trim() + "%'";
        }

        private void tbFilterID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tbFilterID_Leave(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataView dv = detailsDS.Tables[1].DefaultView;
            dv.RowFilter = "ProductID = " + tbFilterID.Text.Trim() + "";
        } 

        
        }
    }

