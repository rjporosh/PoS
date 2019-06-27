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
    public partial class frmSaleHistory : Form
    {
        SqlConnection sqlconnect;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlda;
        DataSet sqlds;
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;

        public frmSaleHistory()
        {
            InitializeComponent();
        }

        private void frmSaleHistory_Load(object sender, EventArgs e)
        {
            //sqlconnect = new SqlConnection(c);
            //sqlcmd = new SqlCommand("select canInsertNewStock from Login where UserName = '" + Class1.LoggedInUsername + "'", sqlconnect);
            //sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            //sqlds = new DataSet();
            //sqlda.Fill(sqlds);

            //if (sqlds.Tables[0].Rows[0][0].ToString() == "No")
            //{
            //    MessageBox.Show("Access Denied by Admin, Contact Administrator!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    this.Close();
            //    return;
            //}

            loadData();
        }

        private void loadData()
        {
            sqlconnect = new SqlConnection(c);
            sqlcmd = new SqlCommand("select * from tblSale", sqlconnect);
            sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            sqlds = new DataSet();
            sqlda.Fill(sqlds, "Login2");

            saleGridView.DataSource = sqlds.Tables["Login2"].DefaultView;
        }

        private void tbProductID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlconnect = new SqlConnection(c);
                sqlcmd = new SqlCommand("select * from Sales where ProductID LIKE '" + tbProductID.Text.Trim() + "'+'%'", sqlconnect);
                sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
                sqlds = new DataSet();
                sqlda.Fill(sqlds, "Login2");

                saleGridView.DataSource = sqlds.Tables["Login2"].DefaultView;
            }
            catch { }
        }

        private void tbProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlconnect = new SqlConnection(c);
                sqlcmd = new SqlCommand("select * from Sales where ProductName LIKE '" + tbProductName.Text.Trim() + "'+'%'", sqlconnect);
                sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
                sqlds = new DataSet();
                sqlda.Fill(sqlds, "Login2");

                saleGridView.DataSource = sqlds.Tables["Login2"].DefaultView;
            }
            catch { }
        }

        private void cbSalePerson_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Daily_Report dp = new Daily_Report();
            dp.ShowDialog();
        }
    }
}
