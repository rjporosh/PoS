using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ES_Project
{
    public partial class frmModifyStock : Form
    {
        string ConStr = DBConnection.ConStr;
        public frmModifyStock()
        {
            InitializeComponent();
        }

        private void frmModifyStock_Load(object sender, EventArgs e)
        {
            frmAddNewItem frm = new frmAddNewItem();
            //load categories
            DataSet details = clsStock.loadData();
            cbCat.DataSource = details.Tables[0].DefaultView;
            cbCat.DisplayMember = "Name";
            cbCat.ValueMember = "CatID";


        }

        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (tbSalePrice.Text.Trim() == string.Empty || tbSalePrice.Text.Trim() == "0" || tbSalePrice.Text.Trim() == "0.00")
            {
                tbSalePrice.Text = "0";
            }
            if (tbName.Text.Trim() == string.Empty || numQty.Value == 0 || tbPurchasePrice.Text.Trim() == string.Empty || tbPurchasePrice.Text.Trim() == "0" || tbPurchasePrice.Text.Trim() == "0.00" || numQty.Value.ToString() == string.Empty)
            {
                MessageBox.Show("Input validation error.Please check product information and try again\nDetails:\n1. Product Name not provided\n2. Product Quantity not provided or Provided as 0.\n3. Purchase Price not provided or provided as 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            contextMenuStrip.Show(btn_submit, btn_submit.Width, btn_submit.Height);
           

            
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

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsStock.updateProduct(int.Parse(tbId.Text), int.Parse(cbCat.SelectedValue.ToString()), tbName.Text.Trim(), int.Parse(numQty.Value.ToString()), decimal.Parse(tbPurchasePrice.Text.Trim()), decimal.Parse(tbSalePrice.Text.Trim()), tbNarration.Text.Trim());
            MessageBox.Show("Product "+tbName.Text.Trim() +" updated successfully","Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                clsStock.deleteProduct(int.Parse(tbId.Text.Trim()));
                MessageBox.Show("Product Deleted from stock successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Information deletion error, try again\n"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }

        private void tbName_Leave(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(ConStr))
            {
                string query = "SELECT ProductID FROM tblStock WHERE Name=@name";
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = tbName.Text.Trim();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        //tbId.Clear();
                        //id = CreateDBID.CreateID("tblStock", "ProductID");
                        //tbId.Text = id.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Product Already Exist in stock. Please Review Name or UPDATE QUANTITY of previously available product\nProduct ID is:  " + ds.Tables[0].Rows[0][0].ToString(), "Product Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbName.Clear();
                        tbName.Focus();
                        //tbId.Clear();
                        return;

                    }

                }
            }
        }
    }
}
