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
using System.Globalization;

namespace ELEE_1149_Phase_3_Assignment
{
    public partial class CalendarForm : Form
    {
        String userJob; //initialize string userjob
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        // initialize connection string to loginDatabase
        public static int static_month, static_year;
        //initializes 2 global variables used for setting the date
        public CalendarForm()
        {
            InitializeComponent();
            con.Open(); //open the connection
            
        }

        private void btnBack_Click(object sender, EventArgs e)  //on button click
        {
            SqlCommand command = new SqlCommand("select Role from Login where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            //command using parameters that gets the role value from therow in the login table where the collumn active has a value of true
            command.ExecuteNonQuery();
            //execute the command

            SqlDataAdapter sda = new SqlDataAdapter(command);   //creates a data adapter utilizing the command

            DataTable dtJ = new DataTable("Login"); //creates new data table

            sda.Fill(dtJ);  //fills the data table using the adapter

            userJob = dtJ.Rows[0]["Role"].ToString();   //sets the value of userRole to that in the 1st row of the data table

            if (userJob == "Receptionist")  //check is userRole is set to receptionist
            {
                new receptionistMenu().Show();  //open receptionist menu form
                this.Close();   //close this form
            }
            else    //otherwise
            {
                new nurseDoctorMenu().Show();   //open the nurseDoctor menu form
                this.Close();   //close this form
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)    //on button press
        {
            SqlCommand command = new SqlCommand("Update login set Active = @logout where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.Parameters.Add("@logOut", SqlDbType.NChar);
            command.Parameters["@logOut"].Value = "False";

            SqlDataAdapter sda = new SqlDataAdapter(command);

            DataTable dtJ = new DataTable("Login");

            sda.Fill(dtJ);
            new login().Show();
            this.Close();
            con.Close();
        }

        private void Calendar_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;    //set now to the current date and time

            int month = now.Month;  //initialize variable month to the current month
            int year = now.Year;    //initialize variable year to the current year
            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            //initializes string monthname and sets it to the name of the current month based of int month

            lblMonthYear.Text = monthName + " " + year; //sets the text of lbl month year to the current month and year
            static_month = month;   //sets the value of global variable static_month to month
            static_year = year;     //sets the value of global variable static_year to year
            DateTime startOfTheMonth = new DateTime(now.Year, now.Month, 1);
            //uses the current year and month to set the start of the month

            int days = DateTime.DaysInMonth(now.Year, now.Month);
            //initializes the variable days to the number of days in the current month

            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) + 1;
            //initializes dayOfTheWeek  and uses startOfTheMonth to set what day of the week the month starts on

            for (int i = 1; i < dayOfTheWeek; i++)  //this for loop tells the user that for every day before the day of the week the month starts on insert a blank user control
            {
                UserControlBlank ucBlank = new UserControlBlank();
                CalendarContainer.Controls.Add(ucBlank);
            }
            for (int i = 1; i <= days; i++) ///this for loop tells the user that for every day until the end of the month insert a user control that shows the day of the month
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                CalendarContainer.Controls.Add(ucDays);
            }           
        }
    }
}
