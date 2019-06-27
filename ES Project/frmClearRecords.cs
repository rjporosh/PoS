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
using System.Configuration;

namespace ES_Project
{
    public partial class frmClearRecords : Form
    {
        SqlConnection objc;
        SqlCommand objcmd;
        //SqlDataAdapter objda;
        //DataSet objds;
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;
        public frmClearRecords()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(button1, 5, button1.Height);
        }

        private void showAllSaleHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Daily_Report dp = new Daily_Report();
            dp.ShowDialog();
        }

        private void clearAllSaleHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If you clear this You will not be able to RETURN or Check any Previous Transactions. Are you sure you want to delete complete sale history? ", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objc = new SqlConnection(c);
                    objcmd = new SqlCommand("Delete from tblSale", objc);
                    objc.Open();
                    objcmd.ExecuteNonQuery();
                    objc.Close();
                    MessageBox.Show("Records Cleared Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error in database connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                this.Close();
            }

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button2, 5, button2.Height);
        }

        private void showAvailableStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewStock frm = new frmViewStock();
            frm.ShowDialog();
        }

        private void clearAlStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear Complete Stock? ", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objc = new SqlConnection(c);
                    objcmd = new SqlCommand("Delete from tblStock", objc);
                    objc.Open();
                    objcmd.ExecuteNonQuery();
                    objc.Close();
                    MessageBox.Show("Stock Cleared Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch
                {
                    MessageBox.Show("Error in database connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                this.Close();
            }

        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClearRecords_Load(object sender, EventArgs e)
        {
            lbl_uname.Text = "Username " + Class1.LoggedInUsername;
            lbl_role.Text = "Role " + Class1.roles;

            label1.Text = "Server Name: " + SystemInformation.ComputerName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(button3, 5, button2.Height);
        }

        private void showCustomerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.ShowDialog();
        }

        private void clearAllCustomersInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear All Customer Information? ", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objc = new SqlConnection(c);
                    objcmd = new SqlCommand("Delete from tblCustomer", objc);
                    objc.Open();
                    objcmd.ExecuteNonQuery();
                    objc.Close();
                    MessageBox.Show("Customer's Info Cleared Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch
                {
                    MessageBox.Show("Error in database connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showAllExpenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportWithExpense frm = new frmReportWithExpense();
            frm.ShowDialog();
        }

        private void closeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearAllExpenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear All Expence Information? ", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    objc = new SqlConnection(c);
                    objcmd = new SqlCommand("Delete from Expense", objc);
                    objc.Open();
                    objcmd.ExecuteNonQuery();
                    objc.Close();
                    MessageBox.Show("Expence Info Cleared Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch
                {
                    MessageBox.Show("Error in database connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            contextMenuStrip3.Show(button4, 5, button3.Height);
        }
    }
}
