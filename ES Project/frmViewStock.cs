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
    public partial class frmViewStock : Form
    {

        SqlConnection objc;
        SqlCommand objcmd;
        SqlDataAdapter objda;
        DataSet objds;
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;
        
        public frmViewStock()
        {
            InitializeComponent();
        }

        private void frmViewStock_Load(object sender, EventArgs e)
        {
            //
           
            objc = new SqlConnection(c);
            //objcmd = new SqlCommand("select SrNo AS 'PRODUCT ID', Product_Name AS 'PRODUCT NAME', Quantity AS 'ITEMS AVAILABLE', Purchase_Price AS 'ORIGINAL PRICE', DESCRIPTION AS 'DESCRIPTION', USERNAME AS 'INSERTED BY', DATE AS 'DATE OF CREATION' from tblStock", objc);
            objcmd = new SqlCommand("select * from tblStock", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "Login");

            int n = Convert.ToInt32(objds.Tables["login"].Rows.Count);
            if (n > 0)
            {
                dataGridView2.DataSource = objds.Tables["Login"].DefaultView;

            }
            else
            {
                MessageBox.Show("No Products found in Stock", "Nothing in Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select SrNo AS 'PRODUCT ID', Product_Name AS 'PRODUCT NAME', Quantity AS 'ITEMS AVAILABLE', Purchase_Price AS 'ORIGINAL PRICE', DESCRIPTION AS 'DESCRIPTION', USERNAME AS 'INSERTED BY', DATE AS 'DATE OF CREATION' from Add_New_Item", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "Login");

            int n = Convert.ToInt32(objds.Tables["login"].Rows.Count);
            if (n > 0)
            {
                dataGridView2.DataSource = objds.Tables["Login"].DefaultView;
                MessageBox.Show(n + " Products found","Products found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Products found against " + textBox1.Text + "", "Product Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select SrNo AS 'PRODUCT ID', Product_Name AS 'PRODUCT NAME', Quantity AS 'ITEMS AVAILABLE', Purchase_Price AS 'ORIGINAL PRICE', DESCRIPTION AS 'DESCRIPTION', USERNAME AS 'INSERTED BY', DATE AS 'DATE OF CREATION' from Add_New_Item", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "Login");

            int n = Convert.ToInt32(objds.Tables["login"].Rows.Count);
            if (n > 0)
            {
                dataGridView2.DataSource = objds.Tables["Login"].DefaultView;

            }
            else
            {
                MessageBox.Show("No Products found in Stock", "Nothing in Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            objc = new SqlConnection(c);
            objcmd = new SqlCommand("select SrNo AS 'PRODUCT ID', Product_Name AS 'PRODUCT NAME', Quantity AS 'ITEMS AVAILABLE', Purchase_Price AS 'ORIGINAL PRICE', DESCRIPTION AS 'DESCRIPTION', USERNAME AS 'INSERTED BY', DATE AS 'DATE OF CREATION' from Add_New_Item where Product_Name LIKE '" + textBox1.Text.Trim() + "'+'%' OR SrNo LIKE '"+textBox1.Text.Trim()+"'+'%'", objc);
            objda = new SqlDataAdapter(objcmd.CommandText, objc);
            objds = new DataSet();
            objda.Fill(objds, "Login2");



            dataGridView2.DataSource = objds.Tables["Login2"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
  
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmAddNewItem frm = new frmAddNewItem();
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmUpdateStock frm = new frmUpdateStock();
            frm.ShowDialog();
        }
    }
}
