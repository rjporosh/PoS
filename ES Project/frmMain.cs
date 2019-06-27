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
    public partial class frmMain : Form
    {
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Class1.isLoggedIn == true)
            {
                if (Properties.Settings.Default["isActivated"].Equals("True"))
                {
                    registerSoftwareToolStripMenuItem.Enabled = false;
                }
                profile.Enabled = true;
                //lbl_uname.Text = Class1.LoggedInUsername;
                profile.Text = "Profile: " + Class1.LoggedInUsername;
                //toolStrip_Logout.Text = "Logout: " + Class1.LoggedInUsername;
                toolStrip_login.Enabled = true;
                // groupBox1.Enabled = true;

                if (Class1.roles == "Sale Person")
                {
                    //  groupBox1.Enabled = false;
                    this.Text = "Point of Sale Software - Salesperson Login - " + Class1.LoggedInUsername;
                    //btnCreateSP.Enabled = false;
                   // toolTip.Show("Click here to start", button1, 5000, 30, 5000);
                }
                else
                {
                    this.Text = "Point of Sale Software - Administrator Login - " + Class1.LoggedInUsername;
                   // toolTip.Show("Click here to start", button1, 5000, 0, 5000);
                }

            }
            else
            {
               // lbl_uname.Text = "Not Logged In";
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSale frm = new frmSale();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCreateSP frm= new frmCreateSP();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmUpdateStock frm = new frmUpdateStock();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmAddNewItem frm = new frmAddNewItem();
            
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmViewStock frm = new frmViewStock();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Daily_Report dp = new Daily_Report();
            dp.ShowDialog();
        }

        private void toolStrip_Logout_Click(object sender, EventArgs e)
        {

            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to Log Out and EXIT? ", Class1.LoggedInUsername, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                
                e.Cancel = false;
            }
            else { e.Cancel = true; }
        }

        private void toolStrip_Logout_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log Out and EXIT? ", Class1.LoggedInUsername, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
            else { }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.Focus();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void notifyIcon1_Click_1(object sender, EventArgs e)
        {
            this.Show();
            this.Focus();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            //toolTip.Show("Click here to start", button1, 5000, 30, 5000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBackupRestore frm = new frmBackupRestore();
            frm.ShowDialog();

        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmExpense frm = new frmExpense();
            frm.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmReportWithExpense frm = new frmReportWithExpense();
            frm.ShowDialog();
        }

        private void saleHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Daily_Report dp = new Daily_Report();
            dp.Show();
        }

        private void expenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportWithExpense frm = new frmReportWithExpense();
            frm.Show();
        }

        private void toolStrip_login_Click(object sender, EventArgs e)
        {
            frmExpense frm = new frmExpense();
            frm.ShowDialog();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            frmReportWithExpense f = new frmReportWithExpense();
            f.Show();
        }

        private void takeBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackupRestore frm = new frmBackupRestore();
            frm.ShowDialog();
        }

        private void restoreBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackupRestore frm = new frmBackupRestore();
            frm.ShowDialog();
        }

        private void showCompleteStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewStock frm = new frmViewStock();
            frm.ShowDialog();
        }

        private void createOrEditAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreateSP frm = new frmCreateSP();
            frm.ShowDialog();
        }

        private void clearDataInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Class1.roles == "Sale Person")
            {
                MessageBox.Show("Only Administrator can perform this action.", "Contact Admin", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                frmClearRecords frm = new frmClearRecords();
                frm.ShowDialog();

            }
        }

        private void deleteAccountsOrChangePasswordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreateSP frm = new frmCreateSP();
            frm.ShowDialog();
        }

        private void trackCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.ShowDialog();
        }

        private void clearCustomersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Class1.roles == "Sale Person")
            {
                MessageBox.Show("Only Administrator can perform this action.", "Contact Admin", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {

                frmClearRecords frm = new frmClearRecords();
                frm.ShowDialog();
            }
            
        }

        private void insertNewStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewItem frm = new frmAddNewItem();
            frm.ShowDialog();
        }

        private void updateExistingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateStock frm = new frmUpdateStock();
            frm.ShowDialog();
        }

        private void deleteCompleteStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Class1.roles == "Sale Person")
            {
                MessageBox.Show("Only Administrator can perform this action.", "Contact Admin", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                frmClearRecords frm = new frmClearRecords();
                frm.ShowDialog();

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            frmSale frm = new frmSale();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnCreateSP_Click(object sender, EventArgs e)
        {
            frmCreateSP frm = new frmCreateSP();
            frm.ShowDialog();
        }

        private void btnNewStock_Click(object sender, EventArgs e)
        {
            frmAddNewItem frm = new frmAddNewItem();

            frm.ShowDialog();
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            frmUpdateStock frm = new frmUpdateStock();
            frm.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            frmViewStock frm = new frmViewStock();
            frm.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            frmSaleHistory frm = new frmSaleHistory();
            frm.ShowDialog();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            if (Class1.roles == "Sale Person")
            {
                MessageBox.Show("Only Administrator can perform this action.", "Contact Admin", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                frmClearRecords frm = new frmClearRecords();
                frm.ShowDialog();

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            frmExpense frm = new frmExpense();
            frm.ShowDialog();
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.ShowDialog();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            frmReportWithExpense frm = new frmReportWithExpense();
            frm.ShowDialog();
        }

        private void viewPendingOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPendingManage frm = new frmPendingManage();
            frm.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Daily_Report dp = new Daily_Report();
            dp.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmReportWithExpense frm = new frmReportWithExpense();
            frm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //temp_frm frm = new temp_frm();
            //frm.ShowDialog();
        }

        private void viewPendingOrdersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPendingManage frm = new frmPendingManage();
            frm.ShowDialog();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSale frm = new frmSale();
            frm.MdiParent = this;
            frm.Show();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            
        }

        private void registerSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Properties.Settings.Default["isActivated"].ToString());
            InsertKey ik = new InsertKey();
            ik.button1.Visible = true;
            ik.ShowDialog();
            
            
            
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            chart c = new chart();
            c.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();
        }

        private void aboutSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();

        }
    }
}
