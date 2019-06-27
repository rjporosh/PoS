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
    public partial class frmUserDetails : Form
    {
        string ConStr = DBConnection.ConStr;
        public frmUserDetails()
        {
            InitializeComponent();
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            //fetchStatus();
        }

        public void fetchStatus()
        {
            cbStatus.DataSource = clsCreateSP.fetchRole().Tables[2].DefaultView;
            cbStatus.DisplayMember = "Name";
            cbStatus.ValueMember = "UserStatusID";
        }

        public void fetchAccess()
        {
            try
            {
                cbRole.DataSource = clsCreateSP.fetchRole().Tables[0].DefaultView;
                cbRole.DisplayMember = "Name";
                cbRole.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while getting Access from Database.\nDetails: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(button1, button1.Width, button1.Height);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                clsCreateSP.deleteAccount(int.Parse(lblID.Text.Trim()));
                MessageBox.Show("Account " + tbName.Text.Trim() + " deleted successfully from system", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error while deleting account " + tbName.Text.Trim() + " from system.\nDetails:" + ex.Message, "Error deleting account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == string.Empty || tbPass.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Some required fields are not provided. please try again.\nRequired fields: Name & Password.", "Missing fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string encryptedPass = Encryption.Encrypt(tbPass.Text.Trim(), true);
                clsCreateSP.updateAccount(int.Parse(lblID.Text.Trim()), int.Parse(cbRole.SelectedValue.ToString()), tbName.Text.Trim(), encryptedPass, tbAddress.Text.Trim(), tbCity.Text.Trim(), tbCell.Text.Trim(), tbNarration.Text.Trim(), int.Parse(cbStatus.SelectedValue.ToString()));
                MessageBox.Show("User details of " + tbName.Text.Trim() + " updated successfully.\nDetails: ", "Completed successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while updating user " + tbName.Text.Trim() + ".\nDetails: " + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }

        }

        private void frmUserDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
