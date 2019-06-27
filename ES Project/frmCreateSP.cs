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
    public partial class frmCreateSP : Form
    {
        int id;
        string UpdateCanUpdateStock="No";
        string UpdateCanViewSaleHistory="No";
        string canUpdateStock="No";
        string canViewSaleHistory="No";
        string canInsertNewStock="No";
        string role;
        SqlConnection objc;
        SqlCommand objcmd;
        SqlDataAdapter objda;
        DataSet objds;
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;


        public frmCreateSP()
        {
            InitializeComponent();
        }

        private void frmCreateSP_Load(object sender, EventArgs e)
        {   
            id=int.Parse(CreateDBID.CreateID("tblUser", "UserID").ToString());

            cbRole.DataSource = clsCreateSP.fetchRole().Tables[0].DefaultView;
            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "RoleID";

            cbStatus.DataSource = clsCreateSP.fetchRole().Tables[2].DefaultView;
            cbStatus.DisplayMember = "Name";
            cbStatus.ValueMember = "UserStatusID";

            populateGrid();

        }

        private void populateGrid()
        {
            dataGridView1.DataSource = clsCreateSP.fetchRole().Tables[1].DefaultView;
        }

        private void rbNewAccount_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbUpdate_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbSaleperson_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }
        private void cb_view_sale_CheckedChanged(object sender, EventArgs e)
        {

            
        }

        private void cb_update_stock_CheckedChanged(object sender, EventArgs e)
        {

            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbUpdateInsertStock_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnUpdateAccess_Click(object sender, EventArgs e)
        {
            

        }

        private void cb_Update_InsertNewStock_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_InsertNewStock_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tbCell.Text.Trim() + "=");
            if (tbName.Text.Trim()==string.Empty || tbPass.Text.Trim()==string.Empty || tbPass2.Text.Trim()==string.Empty)
            {
                MessageBox.Show("Some required fields are not provided. please try again.\nRequired fields: Name, Password & Retype Password.", "Missing fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbPass.Text.Trim()!=tbPass2.Text.Trim())
            {
                MessageBox.Show("Password Miss-match. Check both passwords again", "Password not match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string encryptedPassword = Encryption.Encrypt(tbPass.Text.Trim(), true);
           

            try
            {
                MessageBox.Show(tbCell.Text.Trim() + "=");
                clsCreateSP.insertDetails(id, int.Parse(cbRole.SelectedValue.ToString()), tbName.Text.Trim(), encryptedPassword, tbAddress.Text.Trim(), tbCity.Text.Trim(), tbCell.Text.Trim(), tbNarration.Text.Trim(), DateTimee.Value, int.Parse(cbStatus.SelectedValue.ToString()));
                MessageBox.Show("New Account Created successfully.", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id = int.Parse(CreateDBID.CreateID("tblUser", "UserID").ToString());
                populateGrid(); tbName.Clear();
                MessageBox.Show(tbCell.Text.Trim() + "=");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while creating new user account\nDetails: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
       }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ID: " + id.ToString());
            MessageBox.Show("RoleID: " + cbRole.SelectedValue.ToString());
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            frmUserDetails frm = new frmUserDetails();
            try
            {
                string decryptedPass=Encryption.Decrypt(row.Cells["Password"].Value.ToString(), true);
                frm.tbName.Text = row.Cells["Name"].Value.ToString();
                frm.button1.Text = "Modify "+row.Cells["Name"].Value.ToString();
                frm.tbCity.Text = row.Cells["City"].Value.ToString();
                frm.tbAddress.Text = row.Cells["Address"].Value.ToString();
                frm.tbCell.Text = row.Cells["Cell"].Value.ToString();
                frm.tbNarration.Text = row.Cells["Narration"].Value.ToString();
                frm.lblID.Text = row.Cells["UserID"].Value.ToString();
                frm.tbPass.Text = decryptedPass;
                frm.cbRole.SelectedItem = row.Cells["Access"].Value.ToString();
                frm.fetchAccess();
                frm.cbRole.Text = row.Cells["Access"].Value.ToString();
                frm.fetchStatus();
                frm.cbStatus.Text = row.Cells["Status"].Value.ToString();
                
                
                frm.ShowDialog();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error while displaying details page. please verify user details and try again.\nDetails: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmCreateSP_Activated(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(cbStatus.SelectedValue.ToString());
        }

        private void frmCreateSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
