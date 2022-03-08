using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELEE_1149_Phase_3_Assignment;
using GreenMed;
using System.Data.SqlClient;

namespace GreenMed
{
    public partial class UserControlDays : UserControl
    {
        public static string static_day;    //initializes a global variable able to be used across forms
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
                        // sets connection string for local database loginDatabase
        String userJob; //initializes string userJob
        public UserControlDays()
        {
            InitializeComponent();
            con.Open(); //opens connection using connection string
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            lblDays.Text = numday + "";
            //sets the text of lblDays to the number day of the month
        }

        private void UserControlDays_Click(object sender, EventArgs e)  //when the user control is clicked, the following code is executed
        {
            SqlCommand command = new SqlCommand("select Role from Login where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.ExecuteNonQuery();
            //command to check in login database which role is active

            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Login");
            sda.Fill(dt);
            // makes and fills data table using data adapter which usses the command above to get its data

            try
            {
                userJob = dt.Rows[0]["Role"].ToString();    //assigns the role to userJob
            }
            catch (Exception)
            {
            }
            if (userJob == "Receptionist")          //if role is receptionist
            {
                static_day = lblDays.Text;          //set value of static day to that of the text value of lblDay, which would be the days number of the month
                new AddAppointment().Show();        //opens the add appointment form
                this.ParentForm.Close();            //then closes the parent form of this user control, this is the calendar form
            }
            else
            {
                static_day = lblDays.Text;      //when the role isnt receptionist
                new DailyAppointments().Show(); //open the daily appointments form
                this.ParentForm.Close();        //then closes the parent form of this user control, this is the calendar form
            }

        }

        private void lblDays_Click(object sender, EventArgs e)  //this is the exact same code as above only for when the label is clicked instead
        {
            SqlCommand command = new SqlCommand("select Role from Login where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
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
            }
            if (userJob == "Receptionist")
            {
                static_day = lblDays.Text;
                new AddAppointment().Show();
                this.ParentForm.Close();
            }
            else
            {
                static_day = lblDays.Text;
                new DailyAppointments().Show();
                this.ParentForm.Close();
            }

        }
    }
}
