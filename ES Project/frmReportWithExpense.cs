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
    public partial class frmReportWithExpense : Form
    {
        
        public frmReportWithExpense()
        {
            InitializeComponent();
        }

        private void frmReportWithExpense_Load(object sender, EventArgs e)
        {
            this.ExpenseTableAdapter.Fill(this.Sales.Expense, DateTimePickerFrom.Value.ToShortDateString(), dateTimePickerTo.Value.ToShortDateString());

            this.reportViewer1.RefreshReport();
        }

        private void populateComboBoxes()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.ExpenseTableAdapter.Fill(this.Sales.Expense, DateTimePickerFrom.Value.ToShortDateString(), dateTimePickerTo.Value.ToShortDateString());

            this.reportViewer1.RefreshReport();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
