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

namespace ELEE_1149_Phase_3_Assignment
{
    public partial class login : Form
    {
        
        String userPassword;
        String userID;
        String userJob;
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Charles\Documents\Visual Studio Projects\ELEE_1149_Phase_3_Assignment\ELEE_1149_Phase_3_Assignment\loginDatabase.mdf;Integrated Security = True");
            con.Open();
            String query = "select LoginID, LoginPassword, Role from dbo.Login where LoginID='" + txtID.Text + "'and LoginPassword='" + txtPassword.Text +"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable("Login");
            sda.Fill(dt);

            userID = dt.Rows[0]["LoginID"].ToString();
            userPassword = dt.Rows[0]["LoginPassword"].ToString();
            userJob = dt.Rows[0]["Role"].ToString();
        
           if (userJob == "Receptionist")
           {
                this.Hide();
                new receptionistMenu().Show();
           }
           else if (userJob == "Doctor")
           {
                this.Hide();
                new nurseDoctorMenu().Show();
           }
           else if (userJob == "Nurse")
            {
                this.Hide();
                new nurseDoctorMenu().Show();
            }

            /*if (dt.Rows[0][0].ToString() == "1" && dt.Rows[0]["Role"].ToString() == "1")
            {
                this.Hide();
                new receptionistMenu().Show();
            }
            else if (dt.Rows[0][0].ToString() == "1" && dt.Rows[0]["Role"].ToString() == "2")
            {
                this.Hide();
                new nurseDoctorMenu().Show();
            }*/
            else
            {
                MessageBox.Show("Please enter correct ID and Password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
