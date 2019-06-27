using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ES_Project
{
    public partial class frmExpenseDetails : Form
    {
        public frmExpenseDetails()
        {
            InitializeComponent();
        }

        private void frmExpenseDetails_Load(object sender, EventArgs e)
        {
            //loadCbox();
        }

        public void loadCbox()
        {
            cboxExpense.DataSource = clsExpense.loadData().Tables[0];
            cboxExpense.DisplayMember = "Title";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cboxExpense.Text.Trim() == "" || tbAmount.Text.Trim() == "")
            {
                MessageBox.Show("Fields marked with * are mandatory. try again", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            contextMenuStrip.Show(btnCreate, btnCreate.Width, btnCreate.Height);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsExpense.updateExp(int.Parse(lblid.Text.Trim()), cboxExpense.Text.Trim(), decimal.Parse(tbAmount.Text.Trim()), tbDesc.Text.Trim(), DateTimee.Value);
            MessageBox.Show("Values updated successfully");
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
