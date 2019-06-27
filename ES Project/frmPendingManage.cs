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
    public partial class frmPendingManage : Form
    {
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;

        SqlConnection sqlconnect;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlda;
        DataSet sqlds;

        public frmPendingManage()
        {
            InitializeComponent();
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void tbInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void frmPendingManage_Load(object sender, EventArgs e)
        {
           
            try
            {
                populateForm();

            }
            catch
            {
                MessageBox.Show("Currently nothing in Pending List.");
                
            }
        }

        private void populateForm()
        {
            sqlconnect = new SqlConnection(c);
            sqlcmd = new SqlCommand("select Distinct InvoiceNo, CustomerName, CustomerCell, Date from Pending group by InvoiceNo, CustomerName, CustomerCell,Date", sqlconnect);
            sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            sqlds = new DataSet();
            sqlda.Fill(sqlds, "Login");



           

            comboBox1.DataSource = sqlds.Tables["Login"].DefaultView;
            comboBox1.DisplayMember = "InvoiceNo";

            pendingGridView.ClearSelection();

            //MessageBox.Show( pendingGridView.Rows[0].Cells[13].Value.ToString());
            tbTotalAmt.Text = pendingGridView.Rows[0].Cells[13].Value.ToString();
            tbPaidAmt.Text = pendingGridView.Rows[0].Cells[14].Value.ToString();
            tbBalance.Text = pendingGridView.Rows[0].Cells[15].Value.ToString();

            if(comboBox1.Text=="")
            {
                tbBalance.Text = "0";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            sqlconnect = new SqlConnection(c);
            sqlcmd = new SqlCommand("select * from Pending where InvoiceNo = '" + comboBox1.Text + "'", sqlconnect);
            sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            sqlds = new DataSet();
            sqlda.Fill(sqlds, "Login");
            pendingGridView.DataSource = sqlds.Tables["Login"].DefaultView;

            pendingGridView.ClearSelection();
            try
            {
                tbTotalAmt.Text = pendingGridView.Rows[0].Cells[13].Value.ToString();
                tbPaidAmt.Text = pendingGridView.Rows[0].Cells[14].Value.ToString();
                tbBalance.Text = pendingGridView.Rows[0].Cells[15].Value.ToString();
            }
            catch { }
            }
            catch
            {
                MessageBox.Show("Error in Loading Database contents. Try Again!", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (tbBalance.Text=="")
            {
                MessageBox.Show("Please Select Transaction from List then Click Process Button.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            if (int.Parse(tbBalance.Text) == int.Parse(tbPayNow.Text))
            {
                int rows = pendingGridView.Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    DateTime dt = DateTime.Now;
                    string date = dt.ToLongDateString();

                    string query;
                    sqlconnect = new SqlConnection(c);

                    query = "delete from Pending where InvoiceNo = '" + pendingGridView.Rows[i].Cells[10].Value.ToString() + "'";
                    query += "insert into Sales(ProductID,ProductName,PiecePrice,TransactionType,Margin, SalePerson, CustomerName, CustomerCell, PurchasePrice, InvoiceNo, SaleID, Date) values ('" + pendingGridView.Rows[i].Cells[0].Value.ToString() + "','" + pendingGridView.Rows[i].Cells[1].Value.ToString() + "'," + pendingGridView.Rows[i].Cells[2].Value.ToString() + ",'" + pendingGridView.Rows[i].Cells[3].Value.ToString() + "','" + pendingGridView.Rows[i].Cells[4].Value.ToString() + "','" + Class1.LoggedInUsername + "', '" + pendingGridView.Rows[i].Cells[7].Value.ToString() + "', '" + pendingGridView.Rows[i].Cells[8].Value.ToString() + "', '" + pendingGridView.Rows[i].Cells[9].Value.ToString() + "', '" + pendingGridView.Rows[i].Cells[10].Value.ToString() + "', '" + pendingGridView.Rows[i].Cells[11].Value.ToString() + "', '" + dt.ToString() + "')";

                    // query += "insert into Bill(SrNo,Product_Name,Piece_Price, SalePerson, CustomerName, CustomerCell, Margin,TransactionType, BillID, Mode, SID) values ('" + p_id + "','" + product_name + "','" + piece_price + "','" + Class1.LoggedInUsername + "', '" + customer_name + "', '" + customer_cell + "', '" + margin + "', '" + TransactionType + "', '" + labelID.Text + "', '" + Mode + "', '" + saleID + "')";
                    sqlcmd = new SqlCommand(query, sqlconnect);
                    sqlconnect.Open();
                    sqlcmd.ExecuteNonQuery();
                    sqlconnect.Close();

                    populateForm();
                    tbPayNow.Text = "0";

                    MessageBox.Show("Transaction Successful, Thank You!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(comboBox1.Items.Count==0)
                    {
                        MessageBox.Show("Nothing in Pending Items List!", "Nothing Here", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pendingGridView.DataSource = null;
                        pendingGridView.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Pay Now amount should be equal to Balance remaining, Type payment again.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPayNow.Focus();
            }
            
            
        }

        private void tbPayNow_TextChanged(object sender, EventArgs e)
        {
            if(tbPayNow.Text.Trim()=="")
            {
                tbPayNow.Text = "0";
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tbPayNow_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits 
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
