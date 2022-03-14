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
    public partial class AddPescription : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
       //initializes the connection string to loginDatabase
        public AddPescription()
        {
            con.Open(); //opens the connection
            InitializeComponent();
            dpStart.Format = DateTimePickerFormat.Custom;
            // Display the date as "9/3/2022".  
            dpStart.CustomFormat = "d/M/yyyy";
            dpStart.MinDate = DateTime.Now;
            dpEnd.MinDate = DateTime.Now;
            SqlCommand command = new SqlCommand("select fullName from Patients",con);   //command to get the full name values from the patients table using the connection string
            SqlDataAdapter sda = new SqlDataAdapter(command);   //create data adapter using that command
            DataTable dt = new DataTable("Patient");    //create new datatable
            sda.Fill(dt);   //fill datatable using the data adapter

            cbName.DataSource = dt;
            cbName.ValueMember = dt.Columns[0].ColumnName;
            cbName.DisplayMember = dt.Columns[0].ColumnName;
            //sets the data source for the choice box and then sets the value and display values to those in the 1st collumn of the datatable
        }

        private void btnCancel_Click(object sender, EventArgs e)    //on button press
        {
            new Pescriptions().Show();  //open prescriptions form
            this.Close();   //close current form
        }

        private void btnAddPescription_Click(object sender, EventArgs e)    //on button click
        {
            con.Open(); //opens the connection
            SqlCommand command = new SqlCommand("insert into Pescriptions (fullName, Pescription, startDate, endDate, Instructions) values (@name, @pescription, @start, @end, @Instructions)", con);
            command.Parameters.Add("@name", SqlDbType.NChar);
            command.Parameters.Add("@pescription", SqlDbType.NChar);
            command.Parameters.Add("@start", SqlDbType.NChar);
            command.Parameters.Add("@end", SqlDbType.NChar);
            command.Parameters.Add("@instructions", SqlDbType.NVarChar);
            command.Parameters["@name"].Value = cbName.SelectedValue;
            command.Parameters["@pescription"].Value = txtPescription.Text;
            command.Parameters["@start"].Value = txtStart.Text;
            command.Parameters["@end"].Value = txtEnd.Text;
            command.Parameters["@Instructions"].Value = txtInstructions.Text;
            //command that inserts the values in the choice box and text boxes into the pescriptions database using the connection string
            command.ExecuteNonQuery();
            //executes command

            con.Close();    //close connection

            new Pescriptions().Show();  // opens pescriptions form
            this.Close();   // close current form
        }


    }
}
