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
    public partial class frmCustomers : Form
    {
        SqlConnection sqlconnect;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlda;
        DataSet sqlds;
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void tbCustomerName_TextChanged(object sender, EventArgs e)
        {
            sqlconnect = new SqlConnection(c);
            sqlcmd = new SqlCommand("select * from Customers where CustomerName LIKE '" + tbCustomerName.Text.Trim() + "'+'%'", sqlconnect);
            sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            sqlds = new DataSet();
            sqlda.Fill(sqlds, "Login2");

            dataGridView2.DataSource = sqlds.Tables["Login2"].DefaultView;
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            LoadCustomersInGridView();
        }

        private void LoadCustomersInGridView()
        {
            sqlconnect = new SqlConnection(c);
            sqlcmd = new SqlCommand("select * from tblCustomer", sqlconnect);
            sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            sqlds = new DataSet();
            sqlda.Fill(sqlds, "Login2");

            dataGridView2.DataSource = sqlds.Tables["Login2"].DefaultView;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadCustomersInGridView();
        }

        private void btnCName_Click(object sender, EventArgs e)
        {
            
        }

        private void tbCustomerName_Click(object sender, EventArgs e)
        {
            tbCustomerCell.Clear();
            tbCustomerName.Clear();
            tbProductPurchased.Clear();
        }

        private void tbCustomerCell_TextChanged(object sender, EventArgs e)
        {
            sqlconnect = new SqlConnection(c);
            sqlcmd = new SqlCommand("select * from Customers where CustomerCell LIKE '" + tbCustomerCell.Text.Trim() + "'+'%'", sqlconnect);
            sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            sqlds = new DataSet();
            sqlda.Fill(sqlds, "Login2");

            dataGridView2.DataSource = sqlds.Tables["Login2"].DefaultView;
        }

        private void tbProductPurchased_TextChanged(object sender, EventArgs e)
        {
            sqlconnect = new SqlConnection(c);
            sqlcmd = new SqlCommand("select * from Customers where ProductName LIKE '" + tbProductPurchased.Text.Trim() + "'+'%'", sqlconnect);
            sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            sqlds = new DataSet();
            sqlda.Fill(sqlds, "Login2");

            dataGridView2.DataSource = sqlds.Tables["Login2"].DefaultView;
        }

        private void tbProductPurchased_Click(object sender, EventArgs e)
        {
            tbCustomerCell.Clear();
            tbCustomerName.Clear();
            tbProductPurchased.Clear();
        }

        private void tbCustomerCell_Click(object sender, EventArgs e)
        {
            tbCustomerCell.Clear();
            tbCustomerName.Clear();
            tbProductPurchased.Clear();
        }
    }
}
