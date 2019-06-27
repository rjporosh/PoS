using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ES_Project
{
    public partial class frmLogin : Form
    {
        string c = ConfigurationManager.ConnectionStrings["c"].ConnectionString;

        SqlConnection sqlconnect;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlda;
        DataSet sqlds;

        int n;

        public frmLogin()
        {
            InitializeComponent();
        }
        

        private void frmLogin_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Contact for advanced login system with full encryption and security");
            //try
            //{
            //    populateStartupAccounts();
            //    if(comboBox1.Text=="")
            //    {
            //        lbl_DB_Error.Visible = true;
            //    }
                

            //    tb_login_password.Focus();
            //    lbl.Text = "Server Name: " + SystemInformation.ComputerName;
            //}
            //catch
            //{
            //    MessageBox.Show("Database Connection Error, Select the database and click Restore Or contact Admin", "Database not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    frmBackupRestore frm = new frmBackupRestore();
            //    frm.ShowDialog();
            //}

            
        }

        private void populateStartupAccounts()
        {
            //sqlconnect = new SqlConnection(c);
            //sqlcmd = new SqlCommand("select UserName from Login", sqlconnect);
            //sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
            //sqlds = new DataSet();
            //sqlda.Fill(sqlds, "Login");
            //comboBox1.DataSource = sqlds.Tables["Login"].DefaultView;
            //comboBox1.DisplayMember = "UserName";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Select your account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (tb_login_password.Text.Trim() == "")
            {
                MessageBox.Show("Please Type your Account Password", "Error", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                tb_login_password.Clear();
                tb_login_password.Focus();
                return;
            }
            else
            {

                sqlconnect = new SqlConnection(c);
                sqlcmd = new SqlCommand("select * from login where UserName='" + comboBox1.Text + "'", sqlconnect);
                sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
                sqlds = new DataSet();
                sqlda.Fill(sqlds, "login");
                n = Convert.ToInt32(sqlds.Tables["login"].Rows.Count);
                if (sqlds.Tables["login"].Rows[0][1].ToString() == tb_login_password.Text.Trim()) //login
                {
                    Class1.roles = sqlds.Tables["Login"].Rows[0][2].ToString();
                    Class1.LoggedInUsername = comboBox1.Text;
                    Class1.isLoggedIn = true;

                    trialVersionSecurity();
                    
                }
                else //login
                {
                    if (MessageBox.Show("Invalid Passowrd, Please Click Retry & Enter Correct Password or Contact Admin!", "Wrong Password", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        Class1.isLoggedIn = false;
                        tb_login_password.Clear();
                        tb_login_password.Focus();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void trialVersionSecurity()
        {
            //security
            if (Properties.Settings.Default["isActivated"].Equals("False"))//isActivated
            {
                sqlconnect = new SqlConnection(c);
                sqlcmd = new SqlCommand("insert into Log(id) values (1)", sqlconnect);
                sqlconnect.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconnect.Close();

                sqlconnect = new SqlConnection(c);
                sqlcmd = new SqlCommand("select * from Log", sqlconnect);
                sqlda = new SqlDataAdapter(sqlcmd.CommandText, sqlconnect);
                sqlds = new DataSet();
                sqlda.Fill(sqlds, "login");

                int count = Convert.ToInt32(sqlds.Tables["login"].Rows.Count);
                if (count > 300)
                {
                    InsertKey ik = new InsertKey();
                    ik.ShowDialog();
                    this.Hide();
                }
                else
                {
                    frmMain mainform = new frmMain();
                    mainform.Show();
                    this.Hide();
                }

            }
            else //isActivated
            {

                frmMain mainform = new frmMain();
                mainform.Show();
                this.Hide();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_login_password.Clear();
            tb_login_password.Focus();
        }
    }
}
