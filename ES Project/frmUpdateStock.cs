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
    public partial class frmUpdateStock : Form
    {
        SqlConnection objc;
        SqlCommand objcmd;
        SqlDataAdapter objda;
        DataSet objds;
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;

        public frmUpdateStock()
        {
            InitializeComponent();
        }

        private void frmUpdateStock_Load(object sender, EventArgs e)
        {
            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select canUpdateStock from Login where UserName = '"+Class1.LoggedInUsername+"'", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "Login");
            if (objds.Tables["Login"].Rows[0][0].ToString() == "No")
            {
                MessageBox.Show("Only Admin Can Edit Stock Information on this System, Contact Administrator!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }

            
            try
            {
                loadComboBox();
                SelectData();
            }
            catch { MessageBox.Show("Error Loading Products from Database, Try Again", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
           
        }

        private void loadComboBox()
        {
            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select SrNo from Add_New_Item", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "tbl");

            cbox_.DataSource = objds.Tables["tbl"].DefaultView;
            cbox_.DisplayMember = "SrNo";
        }

        private void SelectData()
        {
            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select SrNo AS 'PRODUCT ID', Product_Name AS 'PRODUCT NAME', Quantity AS 'ITEMS AVAILABLE', Purchase_Price AS 'ORIGINAL PRICE', DESCRIPTION AS 'DESCRIPTION', USERNAME AS 'INSERTED BY', DATE AS 'DATE OF CREATION' from Add_New_Item", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "Login");

            dataGridView2.DataSource = objds.Tables["Login"].DefaultView;
        }

        private void btnUProductName_Click(object sender, EventArgs e)
        {
            if (tb_Name_New.Text.Trim() == "")
            {
                MessageBox.Show("Enter New Value in New Field", "New Value Missing", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {
                try
                {
                    objc = new SqlConnection(c);
                    objcmd = new SqlCommand("update Add_New_Item set Product_Name='" + tb_Name_New.Text.Trim() + "' where SrNo='" + cbox_.Text + "'", objc);
                    objc.Open();
                    objcmd.ExecuteNonQuery();
                    objc.Close();
                    tb_Name_New.Clear();
                    SelectData();
                    MessageBox.Show("Value Changed Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadComboBox();
                }
                catch { MessageBox.Show("Database Connection Error, Process Failed", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
        }

        private void btnUPriceWS_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUPriceR_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUQty_Click(object sender, EventArgs e)
        {
            if (tb_qty_new.Text.Trim() == "")
            {
                MessageBox.Show("Enter New Value in New Field", "New Value Missing", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    objc = new SqlConnection(c);
                    objcmd = new SqlCommand("update Add_New_Item set Quantity='" + tb_qty_new.Text.Trim() + "' where SrNo='" + cbox_.Text + "'", objc);
                    objc.Open();
                    objcmd.ExecuteNonQuery();
                    objc.Close();
                    tb_qty_new.Clear();
                    SelectData();

                    MessageBox.Show("Value Changed Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadComboBox();
                }
                catch { MessageBox.Show("Database Connection Error, Process Failed", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
        }

        private void btnUDel_Click(object sender, EventArgs e)
        {
            try
            {
                objc = new SqlConnection(c);
                objcmd = new SqlCommand("delete from Add_New_Item where SrNo='" + cbox_.Text + "'", objc);
                objc.Open();
                objcmd.ExecuteNonQuery();
                objc.Close();
                tb_qty_new.Clear();
                SelectData();
                MessageBox.Show("Product deleted Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadComboBox();
                
            }
            catch { MessageBox.Show("Database Connection Error, Process Failed", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void cbox__SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //purchasePrice

            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select Purchase_Price from Add_New_Item where SrNo='" + cbox_.Text + "'", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "tbl");


            try
            {
                tbP_PurchasePrice.Text = objds.Tables["tbl"].Rows[0][0].ToString();
            }
            catch { }

            //prpduct name

            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select Product_Name from Add_New_Item where SrNo='" + cbox_.Text + "'", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "tbl");


            try
            {
                tb_U_ProductName.Text = objds.Tables["tbl"].Rows[0][0].ToString();
            }
            catch { }


           
        

            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select Quantity from Add_New_Item where SrNo='" + cbox_.Text + "'", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "tbl");
            try
            {
                tb_U_ProductQuantity.Text = objds.Tables["tbl"].Rows[0][0].ToString();
            }
            catch { }

            ////Delete

            tb_U_Delete_PName.Text = tb_U_ProductName.Text;
        }

        private void btnPurchasePrice_Click(object sender, EventArgs e)
        {
            if (tbN_PurchasePrice.Text.Trim() == "")
            {
                MessageBox.Show("Enter New Value in New Field", "New Value Missing", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    objc = new SqlConnection(c);
                    objcmd = new SqlCommand("update Add_New_Item set Purchase_Price='" + tbN_PurchasePrice.Text.Trim() + "' where SrNo='" + cbox_.Text + "'", objc);
                    objc.Open();
                    objcmd.ExecuteNonQuery();
                    objc.Close();
                    tb_qty_new.Clear();
                    SelectData();
                    MessageBox.Show("Value Changed Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbN_PurchasePrice.Clear();
                    loadComboBox();
                }
                catch { MessageBox.Show("Database Connection Error, Process Failed", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
        }

        private void tb_qty_new_MouseLeave(object sender, EventArgs e)
        {
            //restrict zero value
            if (tb_qty_new.Text.Trim() == "0")
            {
                MessageBox.Show("Not valid input for quantity. Quantity can't be Zero", "Quantity can't be Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_qty_new.Clear();
                tb_qty_new.Focus();
            }
        }

        private void tb_qty_new_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tb_Name_New_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allows only string, white space and backspace key
            if (!char.IsLetterOrDigit(e.KeyChar) && (!char.IsWhiteSpace(e.KeyChar) && (!char.IsControl(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        private void tbN_PurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tbN_PurchasePrice_TextChanged(object sender, EventArgs e)
        {
            //restrict zero value
            if (tbN_PurchasePrice.Text.Trim() == "0")
            {
                MessageBox.Show("Not valid input for Purchase Price. Purchase Price can't be Zero", "Purchase Price can't be Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbN_PurchasePrice.Clear();
                tbN_PurchasePrice.Focus();

            }
        }

        private void frmUpdateStock_MouseHover(object sender, EventArgs e)
        {
           
            
               
            
        }

        private void frmUpdateStock_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void frmUpdateStock_Activated(object sender, EventArgs e)
        {
            toolTip1.Show("Click below list and select the product to update", lbl_1, 5000);
        }
    }
}
