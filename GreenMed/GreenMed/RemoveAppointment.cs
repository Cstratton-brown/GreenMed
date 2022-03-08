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

namespace GreenMed
{
    public partial class RemoveAppointment : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True"); String patientName;
        //initialize connection string
        public RemoveAppointment()
        {
            InitializeComponent();
            con.Open(); //open connection using connection string

            SqlCommand command = new SqlCommand("select fullName, date, startTime, Practitioner from Appointments", con);//make command to get fullName, date, startTime, Practitioner values from Appointments datatable using the connection string
            SqlDataAdapter sda = new SqlDataAdapter(command);   //adapt the data from that command
            DataTable dt = new DataTable("Patient");    //makes new datatable
            sda.Fill(dt);   //fills datatable with adapted data retrieved by the command
             

            cbName.DataSource = dt;
            cbName.ValueMember = dt.Columns[0].ColumnName;
            cbName.DisplayMember = dt.Columns[0].ColumnName;
            cbDate.DataSource = dt;
            cbDate.ValueMember = dt.Columns[1].ColumnName;
            cbDate.DisplayMember = dt.Columns[1].ColumnName;
            cbStart.DataSource = dt;
            cbStart.ValueMember = dt.Columns[2].ColumnName;
            cbStart.DisplayMember = dt.Columns[2].ColumnName;
            cbPractitioner.DataSource = dt;
            cbPractitioner.ValueMember = dt.Columns[3].ColumnName;
            cbPractitioner.DisplayMember = dt.Columns[3].ColumnName;
            //sets the datasource of all the choice boxes, then sets their display and actual values to those in the respective collumns of the datasource

        }

        private void btnCancel_Click(object sender, EventArgs e)    //on button click
        {
            new receptionistMenu().Show();  //open recetionist menu
            this.Close();   //close current form
        }

        private void btnRemoveAppointment_Click(object sender, EventArgs e)
        {
            var confirmRemoval = MessageBox.Show("Confirm removal of this Appointment from the database?", "Confirm Removal", MessageBoxButtons.OKCancel);
            // confirmation message box to ensure they want this appointment removed
            if (confirmRemoval == DialogResult.OK)  //if they click okay
            {
                SqlCommand command = new SqlCommand("delete from Appointment where fullName = @name, date = @date, startTime = @startTime, Practitioner = @practitioner", con);
                command.Parameters.Add("@name", SqlDbType.NChar);
                command.Parameters["@name"].Value = cbName.SelectedValue;
                command.Parameters.Add("@date", SqlDbType.NChar);
                command.Parameters["@date"].Value = cbDate.SelectedValue;
                command.Parameters.Add("@startTime", SqlDbType.NChar);
                command.Parameters["@startTime"].Value = cbStart.SelectedValue;
                command.Parameters.Add("@practitioner", SqlDbType.NChar);
                command.Parameters["@practitioner"].Value = cbPractitioner.SelectedValue;
                //command with parameters to remove the fullname, date, start time and practitioner from the appointment data table where they match all the values in the choice boxes
                command.ExecuteNonQuery();
                //executes above command
                new receptionistMenu().Show();  //opens new receptionist menu form
                this.Close();   //closes current form
            }
        }
    }
}
