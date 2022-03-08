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
    public partial class Patients : Form
    {
        String userJob; //initialize string userJob
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        //initialize connection string
        public Patients()
        {
            
            InitializeComponent();

            con.Open(); //open connection
            SqlCommand newPatient = new SqlCommand("select Role from Login where Active = @active", con);
            newPatient.Parameters.Add("@active", SqlDbType.NChar);
            newPatient.Parameters["@active"].Value = "True";
            //command to check which role has true in the Active collumn in the login database using the connection string
            newPatient.ExecuteNonQuery();
            //executes the command

            SqlDataAdapter sda = new SqlDataAdapter(newPatient);    //creates data adapter using the command

            DataTable dtJ = new DataTable("Login"); //creates new database

            sda.Fill(dtJ);  //fills database with data from the data adapter
            userJob = dtJ.Rows[0]["Role"].ToString();   //assigns the value from the Role colluimn to userJob

            if (userJob == "Receptionist")  //if userJob is Receptionist
            {
                btnAddPatient.Visible = true;   //show the add and aremove patients buttons
                btnRemove.Visible = true;
            }
            else     //otherwise
            {
                btnAddPatient.Visible = false;      //dont show the buttons
                btnRemove.Visible = false;
            }

            SqlDataReader reader = null;    //initialize the data reader as null

            
            try    //try the following code
            {
                
                SqlCommand command = new SqlCommand("select fullName, Age, Gender, DateofBirth from Patients", con);
                //command to select fullName, Age, Gender, DateofBirth data from Patients table
                reader = command.ExecuteReader();   //start reading the data retrieved by the command

                while (reader.Read())// while it is reading the date
                {
                    object[] row = { reader[0], reader[1], reader[2], reader[3] };  // insert the values from each collumn into their respective collumns
                    dgPatients.Rows.Add(row);   //then add a new row
                }
            }
            finally //once that is done
            {
                if (reader != null) //if the reader is not null, which it wont be because it was set to start reading the data
                {  
                    reader.Dispose();   //clear all the resources it used
                    reader = null;  //set the reader back to null
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)  //on button click
        {

            SqlCommand command = new SqlCommand("select Role from Login where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.ExecuteNonQuery();
            // command to check the login table for where the collumn active has a value of true

            SqlDataAdapter sda = new SqlDataAdapter(command);   // new data adapter using the above command

            DataTable dtJ = new DataTable("Login"); //new data table
               
            sda.Fill(dtJ);  //fill the data table with data from the data adapter
            userJob = dtJ.Rows[0]["Role"].ToString(); //set userJob to the role value returned in the datatable

            if (userJob == "Receptionist")  //checks if the value of userJob is Receptionist
            {
                new receptionistMenu().Show();  //show the receptionist form
                this.Close();   //close this form
            }
            else   //otherwise
            {
                new nurseDoctorMenu().Show();   //open the nurseDoctor form
                this.Close();   //close this form
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)    //on button click
        {
            
            SqlCommand command = new SqlCommand("Update login set Active = @logout where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.Parameters.Add("@logOut", SqlDbType.NChar);
            command.Parameters["@logOut"].Value = "False";
            // command to update the login table where the collumn active has a value of true to a value of false

            SqlDataAdapter sda = new SqlDataAdapter(command);   //creates data adapter for the command

            DataTable dtJ = new DataTable("Login"); //creates table

            sda.Fill(dtJ);  //fill datatable using data adapter
            new login().Show(); //open the login form
            this.Close();   //close this form
            con.Close();    //close the connection
        }

        private void btnRemove_Click(object sender, EventArgs e)    //on button click
        {
            this.Close();   //close this form
            new RemovePatient().Show(); //open remove patient form
        }

        private void btnAddPatient_Click(object sender, EventArgs e)    //on button click
        {
            this.Close();   //close this form
            new AddPatient().Show();    //open add patient form
        }
    }
}
