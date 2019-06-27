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
    public partial class Bill_Rpt : Form
    {
        public Bill_Rpt()
        {
            InitializeComponent();
        }

        private void Bill_Rpt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ElectricStoreDataSet.Bill' table. You can move, or remove it, as needed.
            this.BillTableAdapter.Fill(this.ElectricStoreDataSet.Bill);

            this.reportViewer1.RefreshReport();
        }
    }
}
