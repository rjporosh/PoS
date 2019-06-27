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
    public partial class frmBackupRestore : Form
    {
        //string activeDB;
        private SqlConnection sqlconnect;
        private SqlCommand sqlcmd;
        private SqlDataReader dr;
        string sql = "";
        string c = "";
        public frmBackupRestore()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmBackupRestore_Load(object sender, EventArgs e)
        {
            
            // tbDSource.Text = SystemInformation.ComputerName;
            try
            {
               //string c = "Data Source = " + tbDSource.Text + ";integrated Security=true;";
               // c = "Data Source = .\SQLEXPRESS\Dell-Laptop;integrated Security=true;";
                c = ConfigurationManager.ConnectionStrings["connStringBackupAndRestore"].ConnectionString;
                sqlconnect = new SqlConnection(c);
                sqlconnect.Open();
                sql = " SELECT * from sys.databases d where d.database_id>4 ";
                sqlcmd = new SqlCommand(sql, sqlconnect);
                dr = sqlcmd.ExecuteReader();
                cboxDBSelection.Items.Clear();
                while (dr.Read())
                {
                    cboxDBSelection.Items.Add(dr[0].ToString());
                }
                
                if (Class1.isLoggedIn == false)
                {
                    cboxDBSelection.Items.Add("ElectricStore");
                }
                cboxDBSelection.SelectedItem = "ElectricStore";
                tbDBPath.Enabled = true;
                tbDSource.Enabled = true;
                tbRestorePath.Enabled = true;

                cboxDBSelection.Enabled = true;
                btnBackup.Enabled = true;
                btnBrowse.Enabled = true;
                btnRestoreBrowse.Enabled = true;
                btnRestoreRestore.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                
                    sqlconnect = new SqlConnection(c);
                    sqlconnect.Open();
                    sql = "BACKUP DATABASE "+cboxDBSelection.Text+" TO DISK ='"+tbDBPath.Text+"\\"+cboxDBSelection.Text.Trim()+"-"+DateTime.Now.Ticks.ToString()+".bak'";
                    sqlcmd = new SqlCommand(sql, sqlconnect);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Backup Created Successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbDBPath.Clear();
                    //pictureBox1.Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                tbDBPath.Text = dlg.SelectedPath;
            }
        }

        private void btnRestoreBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Database Files(*.bak)|*.bak";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbRestorePath.Text = ofd.FileName;
            }
        }

        private void btnRestoreRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboxDBSelection.Text.Trim() == "")
                {
                    MessageBox.Show("Plese Select database to be restored", "Select Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {  
                    if(Class1.isLoggedIn==false)
                {
                    sqlconnect = new SqlConnection(c);
                    sqlconnect.Open();
                    sql = "Restore Database " + cboxDBSelection.Text + " FROM Disk='" + tbRestorePath.Text + "'WITH REPLACE;";
                    sqlcmd = new SqlCommand(sql, sqlconnect);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Database Restoration Completed Successfully! Plesae start Application Again", "Restore Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                    sqlconnect = new SqlConnection(c);
                    sqlconnect.Open();
                    sql = "use master";
                    sql += " ALTER DATABASE " + cboxDBSelection.Text + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                    sql += "Restore Database "+cboxDBSelection.Text+" FROM Disk='"+tbRestorePath.Text+"'WITH REPLACE;";
                    sqlcmd = new SqlCommand(sql, sqlconnect);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Database Restoration Completed Successfully!", "Restore Complete",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
   
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBackupRestore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Class1.isLoggedIn==false)
            {
                Application.Exit();
            }
        }

       
    }
}
