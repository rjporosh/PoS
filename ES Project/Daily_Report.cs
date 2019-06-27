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
    public partial class Daily_Report : Form
    {
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;

        SqlConnection sqlconnect;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlda;
        DataSet sqlds;

        public Daily_Report()
        {
            InitializeComponent();
        }

        private void Daily_Report_Load(object sender, EventArgs e)
        {
            //try { 
            //prepareFormLoad();
            //this.SalesTableAdapter.FillBy(this.Sales._Sales);
            //this.reportViewer1.RefreshReport();
            //}
            //catch
            //{
            //    MessageBox.Show("Database Connection Error, Please Try Again!", "Sale Reporting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            MessageBox.Show("Contact for complete software, muhammadwaqas_ali@outlook.com", "Trial", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void prepareFormLoad()
        {
            //sqlconnect = new SqlConnection(c);
            //sqlcmd = new SqlCommand("Select DISTINCT ProductName from tblSale", sqlconnect);
            //sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            //sqlds = new DataSet();
            //sqlda.Fill(sqlds, "Name");
            //cbox_ProductName.DataSource = sqlds.Tables["Name"].DefaultView;
            //cbox_ProductName.DisplayMember = "ProductName";

            //sqlcmd = new SqlCommand("Select DISTINCT TransactionType from tblSale", sqlconnect);
            //sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            //sqlds = new DataSet();
            //sqlda.Fill(sqlds, "Type");
            //cbox_TransactionType.DataSource = sqlds.Tables["Type"].DefaultView;
            //cbox_TransactionType.DisplayMember = "TransactionType";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.SalesTableAdapter.Fill(this.Sales._Sales, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), cbox_ProductName.Text, cbox_TransactionType.Text);

            //this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.SalesTableAdapter.FillBy(this.Sales._Sales);
            //this.reportViewer1.RefreshReport();
        }

        private void cbox_ProductName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
