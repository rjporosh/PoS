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
    public partial class frmExpense : Form
    {
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;
        int id;
        SqlConnection sqlconnect;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlda;
        DataSet sqlds;

        public frmExpense()
        {
            InitializeComponent();
        }

        private void frmExpense_Load(object sender, EventArgs e)
        {
            try
            {
                //phase II
                loadGrid();
                loadCbox();
                generateId();

               
                ////load previous expense in cbox
                //loadDatainCbox();

                ////show date and time
                //DateTime dt = DateTime.Now;
                //string date = dt.ToLongTimeString();
                //tbDate.Text = dt.ToString();

                ////load user name
                //tbName.Text = Class1.LoggedInUsername;

                ////load role
                //tbRole.Text = Class1.roles;



                //selectDataInGrid();
                //dataGridView2.ClearSelection();


            }
            catch
            {
                MessageBox.Show("Database Connection Error", "Database not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
        }

        private void generateId()
        {
            id = CreateDBID.CreateID("tblExpense", "ExpenseID");
        }

        private void loadGrid()
        {
            dataGridView2.DataSource = clsExpense.loadData().Tables[1].DefaultView;
        }

        private void loadCbox()
        {
            cboxExpense.DataSource = clsExpense.loadData().Tables[0];
            cboxExpense.DisplayMember = "Title";
        }

        private void loadDatainCbox()
        {
            sqlconnect = new SqlConnection(c);
            sqlcmd = new SqlCommand("Select ExpenseTitle from Expense", sqlconnect);
            sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            sqlds = new DataSet();
            sqlda.Fill(sqlds, "Expense");
            cboxExpense.DataSource = sqlds.Tables["Expense"].DefaultView;
            cboxExpense.DisplayMember = "ExpenseTitle";
        }

        private void selectDataInGrid()
        {
            sqlconnect = new SqlConnection(c);
            sqlcmd = new SqlCommand("select ExpenceID AS 'ID', ExpenseTitle AS 'Expense Title', ExpenseAmount AS 'Amount Used (in Rps)', ExpenseDesc AS 'Expense Details', AccountName AS 'Account Used', Date AS 'Creation Date', Role AS 'Account Role' from Expense", sqlconnect);
            sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            sqlds = new DataSet();
            sqlda.Fill(sqlds, "Login");

            dataGridView2.DataSource = sqlds.Tables["Login"].DefaultView;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cboxExpense.Text.Trim()=="" || tbAmount.Text.Trim()=="")
            {
                MessageBox.Show("Fields marked with * are mandatory. try again", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                clsExpense.insertDetails(id, cboxExpense.Text.Trim(), decimal.Parse(tbAmount.Text.Trim()), tbDesc.Text.Trim(), DateTimee.Value, int.Parse(lbluserid.Text.Trim()));
                MessageBox.Show("Expense Created Successfully!", Class1.LoggedInUsername, MessageBoxButtons.OK,MessageBoxIcon.Information);
                tbAmount.Clear();
                tbDesc.Clear();
                loadCbox();
                loadGrid();
                dataGridView2.ClearSelection();
                generateId();
                
            }
        }

        private void tbAmount_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void cboxExpense_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            //    cboxExpense.Text = row.Cells["Expense Title"].Value.ToString();
            //    tbAmount.Text = row.Cells["Amount Used (in Rps)"].Value.ToString();
            //    tbDesc.Text = row.Cells["Expense Details"].Value.ToString();
            //    tbName.Text = row.Cells["Account Used"].Value.ToString();
            //    tbRole.Text = row.Cells["Account Role"].Value.ToString();
            //    tbDate.Text = row.Cells["Creation Date"].Value.ToString();
            //    //tb_10.Text = row.Cells["Vendor"].Value.ToString();
            //}
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                string id;
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                id = row.Cells["ID"].Value.ToString();
                if (MessageBox.Show("Are you sure you want to delete Expense with ID " + id, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        sqlconnect = new SqlConnection(c);
                        sqlcmd = new SqlCommand("delete from expense where ExpenceID='" + id + "'", sqlconnect);
                        sqlconnect.Open();
                        sqlcmd.ExecuteNonQuery();
                        sqlconnect.Close();
                        MessageBox.Show("Expense deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        selectDataInGrid();
                        dataGridView2.ClearSelection();
                        loadDatainCbox();

                        
                        tbAmount.Clear();  tbDesc.Clear(); 
                    }
                    catch
                    {
                        MessageBox.Show("Error, Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                        return;
                    }
                }
                else
                {
                   
                    dataGridView2.ClearSelection();
                    return;
                }
            }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbAmount_MouseLeave(object sender, EventArgs e)
        {
            //restrict zero value
            if (tbAmount.Text.Trim() == "0")
            {
                MessageBox.Show("Not valid input for this field. Value can't be Zero", "Value can't be Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbAmount.Clear();
                tbAmount.Focus();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReportWithExpense frm = new frmReportWithExpense();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                frmExpenseDetails frm = new frmExpenseDetails();
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                frm.loadCbox();
                frm.cboxExpense.Text = row.Cells["Title"].Value.ToString();
                frm.tbAmount.Text = row.Cells["Amount"].Value.ToString();
               frm.tbDesc.Text = row.Cells["Description"].Value.ToString();
               frm.DateTimee.Value = Convert.ToDateTime(row.Cells["Date"].Value);
               frm.lblid.Text = row.Cells["ExpenseID"].Value.ToString();
               

                frm.ShowDialog();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                return;
            }
        }
    }
}
