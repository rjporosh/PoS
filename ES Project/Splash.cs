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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "TimerStart";
            progressBar1.Value = 20;
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            //progressBar1.Width = this.Width;
           

        }
    }
}
