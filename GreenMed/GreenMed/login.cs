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

namespace ELEE_1149_Phase_3_Assignment
{
    public partial class login : Form
    {
        
        String userJob;
        public login()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
            
            
            con.Open();
            SqlCommand command = new SqlCommand("select LoginID, LoginPassword, Role, Active from dbo.Login where LoginID = @textID and LoginPassword = @textPassword; Update login set Active = 'True' where LoginID = @textID and LoginPassword = @textPassword ", con);
            command.Parameters.Add("@textID", SqlDbType.NChar);
            command.Parameters.Add("@textPassword", SqlDbType.NChar);
            command.Parameters["@textID"].Value = txtID.Text;
            command.Parameters["@textPassword"].Value = txtPassword.Text;
            command.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(command);

                DataTable dt = new DataTable("Login");

                sda.Fill(dt);

            try
            {
                userJob = dt.Rows[0]["Role"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct ID and Password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
