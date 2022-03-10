using ELEE_1149_Phase_3_Assignment;
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
using ELEE_1149_Phase_3_Assignment;
using GreenMed;
using System.Globalization;

namespace GreenMed
{
    public partial class DailyAppointments : Form
    {
        int menuCheck;  //initilialize int menucheck
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        //initialize connection string
        public DailyAppointments()
        {
            con.Open(); //open connection
            InitializeComponent();
            menuCheck = nurseDoctorMenu.menu; //set value of int menuCheck to that of global int menu from the nurseDoctorForm
            if (menuCheck == 0) //if the value of menucheck is 0
            {

                DateTime date = DateTime.UtcNow;    //initialize date to current date and time
                lblDate.Text = date.ToString("d/M/yyyy");   //set text of lblDate to the value of date, converted to string and formatted into d/m/yyyy format to remove 0s


            }
            else if (menuCheck == 1)        //else if it is 1
            {
                lblDate.Text = UserControlDays.static_day + "/" + CalendarForm.static_month + "/" + CalendarForm.static_year;   //sets the value of lblDate to that of the selected date using global strings from the Calendar form
            }

            SqlDataReader reader = null;    //initialize new sql data reader with a null value


            try//try to do the following code
            {
               SqlCommand command = new SqlCommand("select Appointment.fullName, Appointment.date, Appointment.startTime, Appointment.endTime, Appointment.Practitioner, Login.Active from Appointment, Login where Login.Practitioner = Appointment.Practitioner and Active=@active and date=@date order by Appointment.startTime", con);
                //the above command selects fullName,date,startTime,endTime,Practitioner values from the Appointments table and active values from the Login database where Practitioner in the login database is the same as Practitioner in the Appointments database
                //and where the value in the active collumn is the same as that of @active and the value of the date collumn is the same as that of @date, then oder them by the start time from the appointments database
               command.Parameters.Add("@date", SqlDbType.NChar);
               command.Parameters["@date"].Value = lblDate.Text;    //assigns @date value to that of lblDate.Text, which gets set to the current date
               command.Parameters.Add("@active", SqlDbType.NChar);
               command.Parameters["@active"].Value = true;      //assigns the value of @active to true

               reader = command.ExecuteReader();    //starts the datareader using the above command 

               while (reader.Read())    //while the data reader is reading rows of the table
               {
                    object[] row = { reader[0], reader[1], reader[2], reader[3] };  //add the data in the row read by the reader to the corresponding collumn it was read from
                    dgPatients.Rows.Add(row);   //add new row
                }
            }
            finally//after trying the above code
            {
                if (reader != null) // if the value of reader is not null
                {
                    reader.Dispose();   //removes all resources used from reader
                    reader = null;      //set reader to null
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)  //on button click
        {

            if (menuCheck == 0)     //checks the value of menuCheck, if it is 0
            {
                new nurseDoctorMenu().Show();   //open nurseDoctor form
                this.Close();   //close current form
            }
            else if (menuCheck == 1)    //else if it is 1
            {
                new CalendarForm().Show();  //open calendar form
                menuCheck = 0;  //reset menuCheck to 0
                this.Close();   //close curent form
            }
            
        }

        private void btnLogOut_Click(object sender, EventArgs e)//on button click
        {

            SqlCommand command = new SqlCommand("Update login set Active = @logout where Active = @active", con); // command to update the row in Login database the value in the active collumn from @active to @logout 
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";   //sets the value of @active to True
            command.Parameters.Add("@logOut", SqlDbType.NChar);
            command.Parameters["@logOut"].Value = "False";  //sets the value of @logout to False

            SqlDataAdapter sda = new SqlDataAdapter(command);   //data adapter uses the command

            DataTable dtJ = new DataTable("Login"); //creates datatable

            sda.Fill(dtJ);  //fills datatable using adapter
            new login().Show(); //shows login form
            this.Close();   //closes current form
            con.Close();    //close connection using connection string
        }

        private void DailyAppointments_Load(object sender, EventArgs e)
        {
           
        }
    }
}
