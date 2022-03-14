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

            dpDate.Format = DateTimePickerFormat.Custom;
            // Display the date as "9/3/2022".  
            dpDate.CustomFormat = "d/M/yyyy";
            dpDate.MinDate = DateTime.Now;
            SqlCommand command = new SqlCommand("select fullName from Patients", con);  //command to get fullName values from Patients database using the connection
            SqlDataAdapter sda = new SqlDataAdapter(command);   //data adapter initialized using the command
            DataTable dt = new DataTable("Patient");    //new datatable created
            sda.Fill(dt);   //fill datatable with data from the dataadapter

            cbName.DataSource = dt; //sets source of data for the choicebox name
            cbName.ValueMember = dt.Columns[0].ColumnName;
            cbName.DisplayMember = dt.Columns[0].ColumnName;
            //sets the display and value data using the data from the fullName collumn of the created datatable

            SqlCommand time = new SqlCommand("select time from Time", con);  //command to get time values from Time database using the connection
            SqlDataAdapter sdat = new SqlDataAdapter(time);   //data adapter initialized using the command
            DataTable dtT = new DataTable("Start");    //new datatable created
            sdat.Fill(dtT);   //fill datatable with data from the data adapter

            cbStart.DataSource = dtT; //sets source of data for the choicebox name
            cbStart.ValueMember = dtT.Columns[0].ColumnName;
            cbStart.DisplayMember = dtT.Columns[0].ColumnName;
            //sets the display and value data using the data from the fullName collumn of the created datatable

            SqlDataAdapter sdas = new SqlDataAdapter(time);   //data adapter initialized using the command
            DataTable dtS = new DataTable("Stop");    //new datatable created
            sdas.Fill(dtS);   //fill datatable with data from the data adapter

            cbEnd.DataSource = dtS; //sets source of data for the choicebox name
            cbEnd.ValueMember = dtS.Columns[0].ColumnName;
            cbEnd.DisplayMember = dtS.Columns[0].ColumnName;
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
                dpDate.Enabled = true;
            }
            else   //if it is not
            {
                dpDate.Text = UserControlDays.static_day + "/" + CalendarForm.static_month + "/" + CalendarForm.static_year;   //sets text of dpDate to the selected date from the calendar using global variables from the calendar form
                dpDate.Enabled = false;
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
            string startTime = cbStart.Text;
            string endTime = cbEnd.Text;
            DateTime date = DateTime.UtcNow;
            date.ToString("d/M/yyyy");

            SqlCommand check = new SqlCommand("select date, startTime, endTime, Practitioner from Appointment where date = @date and startTime = @start and Practitioner = @practitioner", con);

            check.Parameters.Add("@date", SqlDbType.NVarChar);
            check.Parameters.Add("@start", SqlDbType.NChar);
            check.Parameters.Add("@practitioner", SqlDbType.NVarChar);
            check.Parameters["@date"].Value = dpDate.Text;
            check.Parameters["@start"].Value = cbStart.SelectedValue;
            check.Parameters["@practitioner"].Value = cbPractitioner.SelectedValue;

            SqlDataAdapter sda = new SqlDataAdapter(check);   //data adapter initialized using the command
            DataTable dt = new DataTable("Patient");    //new datatable created
            sda.Fill(dt);   //fill datatable with data from the dataadapter

            string start;
            string end;
            string dateCheck;
            string practitioner;

            dateCheck = dt.Columns[0].ToString();
            start = dt.Columns[0].ToString();
            end = dt.Columns[0].ToString();
            practitioner = dt.Columns[0].ToString();

            
            if (dpDate.Text == dateCheck && String.Compare(end, startTime) > 0 && cbPractitioner.SelectedValue.ToString() == dt.Columns[0].ToString())
            {
                MessageBox.Show("Practitioner is scheduled already, please select a new time", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //if statement to check if practitioner is busy currentley ony the time check works
                
            }
            else
            {
                if (String.Compare(startTime, endTime) < 0)
                {
                    if (dpDate.Value >= date)
                    {
                        SqlCommand command = new SqlCommand("insert into Appointment (fullName, date, startTime, endTime, Practitioner) values (@name, @date, @start, @end, @practitioner)", con);
                        //command to insert new row into the appointments database using the connection,first brackets say what collumns to insert data into the 2nd lot of brackets is the values to be inserted

                        command.Parameters.Add("@name", SqlDbType.NVarChar);
                        command.Parameters.Add("@date", SqlDbType.NVarChar);
                        command.Parameters.Add("@start", SqlDbType.NChar);
                        command.Parameters.Add("@end", SqlDbType.NChar);
                        command.Parameters.Add("@practitioner", SqlDbType.NVarChar);
                        command.Parameters["@name"].Value = cbName.SelectedValue;
                        command.Parameters["@date"].Value = dpDate.Text;
                        command.Parameters["@start"].Value = cbStart.SelectedValue;
                        command.Parameters["@end"].Value = cbEnd.SelectedValue;
                        command.Parameters["@practitioner"].Value = cbPractitioner.SelectedValue;
                        //sets the values of each of the above parametres to their respective choice box/text box text values

                        command.ExecuteNonQuery();  //executes the command
                        MessageBox.Show("Appointment Added", "Alert", MessageBoxButtons.OK);    //shows a message box that says an appointment has been added
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
                    else
                    {
                        MessageBox.Show("Please enter valid Date for Appointment", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Start time must be Before End Time", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
