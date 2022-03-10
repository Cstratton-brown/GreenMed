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
using ELEE_1149_Phase_3_Assignment;

namespace GreenMed
{
    public partial class AddAppointment : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        //initialize connection string

        public AddAppointment()
        {
            
            con.Open(); //open connection using connection string
            InitializeComponent();
            SqlCommand command = new SqlCommand("select fullName from Patients", con);  //command to get fullName values from Patients database using the connection
            SqlDataAdapter sda = new SqlDataAdapter(command);   //data adapter initialized using the command
            DataTable dt = new DataTable("Patient");    //new datatable created
            sda.Fill(dt);   //fill datatable with data from the dataadapter

            cbName.DataSource = dt; //sets source of data for the choicebox name
            cbName.ValueMember = dt.Columns[0].ColumnName;
            cbName.DisplayMember = dt.Columns[0].ColumnName;
            //sets the display and value data using the data from the fullName collumn of the created datatable

            SqlCommand check = new SqlCommand("select Practitioner from Login where CONVERT(VARCHAR, Role) <> 'Receptionist'", con); //new command to get practitioner from the login database where the role is not receptionist
            SqlDataAdapter sda2 = new SqlDataAdapter(check); //creates new dataadapter with the new command
            DataTable dtp = new DataTable("Practitioner");  //new datatable for the new command
            sda2.Fill(dtp); //filling the new datatable with the data from the new data adapter from the new command

            cbPractitioner.DataSource = dtp;
            cbPractitioner.ValueMember = dtp.Columns[0].ColumnName;
            cbPractitioner.DisplayMember = dtp.Columns[0].ColumnName;
            // assign data source for choice box and then set the values it displays and can be selected from the 1st collumn in the database

            if (receptionistMenu.receptionist == true)  //checks if global variable receptionist from the receptionist menu form is true
            {
                txtDate.Enabled = true; //allows txtDate text to be changed by the user
            }
            else   //if it is not
            {
                txtDate.Text = UserControlDays.static_day + "/" + CalendarForm.static_month + "/" + CalendarForm.static_year;   //sets text of txtDate to the selected date from the calendar using global variables from the calendar form
                txtDate.Enabled = false;    //stops txtDate text from being changed
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)    //on button click
        {   
            if (receptionistMenu.receptionist == true)  //check the value of global bool receptionist from receptionist menu form, if it is true
            {
                new receptionistMenu().Show();  //show receptionist menu
                receptionistMenu.receptionist = false;  //set it to false
                this.Close();   //close current form
            }
            else    //if its not true
            {
            new CalendarForm().Show();  //show calendar form
            this.Close();       //close current form
            }
            
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Appointments (fullName, date, startTime, endTime, Practitioner) values (@name, @date, @start, @end, @practitioner)", con);
            //command to insert new row into the appointments database using the connection,first brackets say what collumns to insert data into the 2nd lot of brackets is the values to be inserted

            command.Parameters.Add("@name", SqlDbType.NChar);
            command.Parameters.Add("@date", SqlDbType.NChar);
            command.Parameters.Add("@start", SqlDbType.NChar);
            command.Parameters.Add("@end", SqlDbType.NChar);
            command.Parameters.Add("@practitioner", SqlDbType.NChar);
            //adds the parametres and sets there data types
            command.Parameters["@name"].Value = cbName.Text;
            command.Parameters["@date"].Value = txtDate.Text;
            command.Parameters["@start"].Value = txtStart.Text;
            command.Parameters["@end"].Value = txtEnd.Text;
            command.Parameters["@practitioner"].Value = cbPractitioner.Text;
            //sets the values of each of the above parametres to their respective choice box/text box text values

            command.ExecuteNonQuery();  //executes the command
            MessageBox.Show("Appointemnt Added", "Alert", MessageBoxButtons.OK);    //shows a message box that says an appointment has been added
            con.Close();    //closes he connection
            if (receptionistMenu.receptionist == true)  //check if global variable receptionist is true
            {
                new receptionistMenu().Show();  //open receptionist menu form
                receptionistMenu.receptionist = false;  //set receptionist to false
                this.Close();   //close current form

            }
            else    //otherwise
            {
                new CalendarForm().Show();  //open calendar form
                this.Close();   //close current form
            }
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {

        }
        

        private void btnCancel_Click_1(object sender, EventArgs e)  //on button click
        {
            if (receptionistMenu.receptionist == true)  //check if global variablt receptionist is true
            {
                new receptionistMenu().Show();  //if it is open receptionist form
                receptionistMenu.receptionist = false;  //set it to false
                this.Close();       //close current form
            }
            else     //otherwise
            {
                new CalendarForm().Show();  //open calendar form
                this.Close();   //close current form
            }
        }
    }
}
