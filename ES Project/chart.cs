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
    public partial class chart : Form
    {
        public chart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series["price"].Points.AddXY("Samsung Galaxy S5", 35000);
            this.chart1.Series["price"].Points.AddXY("Nokia 1112", 1200);
            this.chart1.Series["price"].Points.AddXY("Nokia 3310", 900);
            this.chart1.Series["price"].Points.AddXY("Lumia Windows Phone", 14500);
            this.chart1.Series["price"].Points.AddXY("Samsung Galaxy S6 EDGE", 76000);
        }
    }
}
