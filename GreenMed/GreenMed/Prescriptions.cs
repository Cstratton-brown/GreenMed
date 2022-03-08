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
    public partial class Pescriptions : Form
    {
        String userJob; //initialize string userJob
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        //Initialize the connection string to the loginDatabase
        public Pescriptions()
        {
            InitializeComponent();

            con.Open(); //open the connection
            SqlCommand prescription = new SqlCommand("select Role from Login where Active = @active", con);
            prescription.Parameters.Add("@active", SqlDbType.NChar);
            prescription.Parameters["@active"].Value = "True";
            //command to get the value of Role in the row where active has a value of true in the Login table

            prescription.ExecuteNonQuery();
            //execute the command
            SqlDataAdapter sda = new SqlDataAdapter(prescription);    //initialize new data adapter using the command

            DataTable dtJ = new DataTable("Login");     //create new data table

            sda.Fill(dtJ);  //fill the data table using data from the data adapter
            userJob = dtJ.Rows[0]["Role"].ToString();   // set the value of userJob to that in the 1st collumn of the data table

            if (userJob == "Doctor")    //checks if the value of userJob is doctor
            {
                btnAddPescription.Visible = true;   //show the add and remove pescription buttons
                btnRemove.Visible = true;
            }
            else   //otherwise if it isnt
            {
                btnAddPescription.Visible = false;  //hide the add and remove pescription buttons
                btnRemove.Visible = false;
            }

            SqlDataReader reader = null;    //initialize the data reader as null


            try  //try the following code
            {

                SqlCommand command = new SqlCommand("select fullName, Pescription, startDate, endDate, Instructions from Pescriptions", con);
                //command to grab the values  in the collumns fullName, Pescription, startDate, endDate, Instructions from Pescriptions table using the connection string
                reader = command.ExecuteReader();
                //start the reader using the above command

                while (reader.Read())   //while the reader is reading data
                {
                    object[] row = { reader[0], reader[1], reader[2], reader[3], reader[4] };   //set the data in their respective collumns on the row as it is being read
                    dgPatients.Rows.Add(row);   //create new row
                }
            }
            finally //once there is no more data to read
            {
                if (reader != null) //if the reader is not set to null
                {
                    reader.Dispose();   //clear the resources the reader used
                    reader = null;      //set the reader to null
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)  //on button click
        {

            SqlCommand command = new SqlCommand("select Role from Login where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            //command to get the role from the row in the login database that has the value true in the active collumn
            command.ExecuteNonQuery();
            //executes the command

            SqlDataAdapter sda = new SqlDataAdapter(command);   //creates new data adapter using the command

            DataTable dtJ = new DataTable("Login"); //creates new data table

            sda.Fill(dtJ);  //fills the datatable using the data adapter
            userJob = dtJ.Rows[0]["Role"].ToString();   //sets the value of userJob to that in the 1st row and collumn of the datatable

            if (userJob == "Receptionist")  //checks if userJobs value is Receptionist
            {
                new receptionistMenu().Show();  //show recepotionist menu form
                this.Close();   //close this form
            }
            else    //otherwise
            {
                new nurseDoctorMenu().Show();// show nurseDoctorMenu form
                this.Close();      //close this form,
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)    //on button click
        {
            SqlCommand command = new SqlCommand("Update login set Active = @logout where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.Parameters.Add("@logOut", SqlDbType.NChar);
            command.Parameters["@logOut"].Value = "False";
            //command using parameters to update the value in the active collum of the login database from true to false using the connection string

            SqlDataAdapter sda = new SqlDataAdapter(command);   //creates new data adapter using the command above

            DataTable dtJ = new DataTable("Login"); //creates new data table
               
            sda.Fill(dtJ);  //fill the data table using the data adapter
            new login().Show(); //show the login form
            this.Close();   //close this form
            con.Close();    //close the connection
        }

        private void btnAddPescription_Click(object sender, EventArgs e)    //on button click
        {
            this.Close();   //close this form
            new AddPescription().Show();    //open remove prescription form
        }

        private void btnRemove_Click(object sender, EventArgs e)    //on button click
        {
            this.Close();   //close this form
            new RemovePescription().Show(); //open remove prescription form
        }
    }
}
