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
using GreenMed;

namespace ELEE_1149_Phase_3_Assignment
{
    public partial class nurseDoctorMenu : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        //initialize connection string for loginDatabase
        public static int menu; //initialize variable menu
        public nurseDoctorMenu()
        {
            InitializeComponent();

        }

        private void btnLogOut_Click(object sender, EventArgs e)    //on button click
        {
            con.Open(); // opens the connection using the connection string
            SqlCommand command = new SqlCommand("Update login set Active = @logout where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.Parameters.Add("@logOut", SqlDbType.NChar);
            command.Parameters["@logOut"].Value = "False";
            command.ExecuteNonQuery();
            //executes command that updates the login table, changing where the collumn active has a true value to a false value

            con.Close();    //close connection
            new login().Show(); //show login form
            this.Close();   //close this form
        }

        private void btnPatients_Click(object sender, EventArgs e)  //on button click
        {
            new Patients().Show();  //show patients form
            this.Close();   //close this form
            
        }

        private void btnMedication_Click(object sender, EventArgs e)    //on button click
        {
            new Pescriptions().Show();  //open prescriptions form
            this.Close();   //close this form
        }

        private void button4_Click(object sender, EventArgs e)  //on button click
        {
            new CalendarForm().Show();  //show the calendar form
            menu = 1;   //set menu to 1
            this.Close();   //close this form
        }

        private void button5_Click(object sender, EventArgs e)  //on button click
        {
            new DailyAppointments().Show(); //show the daily appointments form
            menu = 0;   //set menu to o
            this.Close();   //close the current form
        }

        private void nurseDoctorMenu_Load(object sender, EventArgs e)
        {
            menu = 0;   //set value of menu to 0
        }
    }
}
