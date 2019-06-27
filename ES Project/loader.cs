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
    public partial class loader : Form
    {
        public int timeLeft { get; set; }
        public loader()
        {
            InitializeComponent();
        }

        private void loader_Load(object sender, EventArgs e)
        {
            timeLeft = 39;
            timer1.Start();

            progressBar1.Maximum = 40;
            progressBar1.Minimum = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                progressBar1.Value++;

            }
            else
            {
                timer1.Stop();
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
                //this.Close();
            }
        }
    }
}
