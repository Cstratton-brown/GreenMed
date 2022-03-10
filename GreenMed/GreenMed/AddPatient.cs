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
    public partial class AddPatient : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        //initialize connection string to loginDatabase
        public AddPatient()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)    //on button click
        {
            new Patients().Show();  //open Patients form
            this.Close();   //close this form
        }

        private void btnAddPatient_Click(object sender, EventArgs e)    //on button click
        {   
            con.Open(); //opens the connection
            SqlCommand command = new SqlCommand("insert into Patients (fullName, Age, Gender, DateofBirth) values (@name, @age, @gender, @dateofbirth)", con);
            command.Parameters.Add("@name", SqlDbType.NChar);
            command.Parameters.Add("@age", SqlDbType.NChar);
            command.Parameters.Add("@gender", SqlDbType.NChar);
            command.Parameters.Add("@dateofbirth", SqlDbType.NChar);
            command.Parameters["@name"].Value = txtName.Text;
            command.Parameters["@age"].Value = udAge.Value;
            command.Parameters["@gender"].Value = txtGender.Text;
            command.Parameters["@dateofbirth"].Value = txtDateofBirth.Text;
               //comnmand using parameters to insert the name,age, gender and date of birth values of their respective text boxes into their respective collumns in database patients
            command.ExecuteNonQuery();
            //executes the command

            con.Close();    //close the connection
            new Patients().Show();  //sjow patients form
            this.Close();   //close this form
        }
    }
}
