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
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        //sets connection string to link to local database

        String userJob;
        public login()
        {
            InitializeComponent();
            con.Open(); //opens connection using connection string
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            
            
            SqlCommand command = new SqlCommand("select LoginID, LoginPassword, Role, Active from dbo.Login where LoginID = @textID and LoginPassword = @textPassword; Update login set Active = 'True' where LoginID = @textID and LoginPassword = @textPassword ", con);
            command.Parameters.Add("@textID", SqlDbType.NChar);
            command.Parameters.Add("@textPassword", SqlDbType.NChar);
            command.Parameters["@textID"].Value = txtID.Text;
            command.Parameters["@textPassword"].Value = txtPassword.Text;
            command.ExecuteNonQuery();
            //command that grabs the LoginID, LoginPassword, Role, Active collumns data from the login table in the database where, the text typed into txtID and txtPassword is the same as the text under the loginID and loginPassword on a single row, it then sets the value in the active collumn of that row to true

            SqlDataAdapter sda = new SqlDataAdapter(command);
            //makes dataadapter using the above command
                DataTable dt = new DataTable("Login");
            //makes new datatable
                sda.Fill(dt);
            //fills datatable using data from the datadapter

            try
            {
                userJob = dt.Rows[0]["Role"].ToString();
                //sets the value in the Role collumn to that of userJob
                if (userJob == "Receptionist")              //this if function checks which role userjobs value is and uses it to determine which screen to open
                {
                    this.Hide();
                    new receptionistMenu().Show();  //if role is receptionist show receptionist menu
                }
                else
                {
                    this.Hide();
                    new nurseDoctorMenu().Show();       //if role is doctor or nurse show nurse menu
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct ID and Password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //if there is no value it throws an error, this catches it as an exception and sends a messagebox saying to enter correct log in data
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();       //when the button is clicked close the form
            Application.Exit(); // then close all forms that remain open
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
