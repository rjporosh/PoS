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
    public partial class InsertKey : Form
    {
        public InsertKey()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
               
                if (Properties.Settings.Default["activationKey"].Equals(textBox1.Text))
                {
                    //MessageBox.Show(Properties.Settings.Default["isActivated"].ToString());
                    Properties.Settings.Default["isActivated"] = "True";
                    Properties.Settings.Default.Save();
                    if (Properties.Settings.Default["isActivated"].Equals("True"))
                    {
                        MessageBox.Show("Product Key Accepted,Thank You", "Activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        frmMain frm = new frmMain();
                        frm.ShowDialog();
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Invalid Product Key, Try Again or Contact Marvel Solutions\nVoice: +92336-6536339", "Activation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            
            
            
        }

        private void InsertKey_Load(object sender, EventArgs e)
        {
            
        }

        private void InsertKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
