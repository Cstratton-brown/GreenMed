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
    public partial class RemovePatient : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");

        public RemovePatient()
        {
            con.Open();
            InitializeComponent();
            SqlCommand command = new SqlCommand("select fullName from Patients", con);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Patient");
            sda.Fill(dt);
            cbName.DataSource = dt;     //sets data source for the coice box
            cbName.ValueMember = dt.Columns[0].ColumnName;      //sets the values in the choice box to those in the collumn 0 of the datasource
            cbName.DisplayMember = dt.Columns[0].ColumnName;    //sets the displayed values of the choice box to the values in the collumn 0 of the datasource
        }

        private void btnCancel_Click(object sender, EventArgs e)    //on button click
        {
            new Patients().Show();      //show patients form
            this.Close();               //close this form
        }

        private void btnRemovePatient_Click(object sender, EventArgs e)     //when the remove patient button is clicked
        {
            var confirmRemoval = MessageBox.Show("Confirm removal of this patient, their appointments and pescriptions from the database?", "Confirm Removal", MessageBoxButtons.OKCancel);     // send up confirmation message box to check they want to remove this patient and their related data from the database
            if (confirmRemoval == DialogResult.OK)  //if they click ok
            {        
                SqlCommand command = new SqlCommand("delete from Patients where fullName = @name", con);        //command to remove the patients data from all tables where the collumn fullName is the same as @name
                command.Parameters.Add("@name", SqlDbType.NChar);   //sets variable type of @name
                command.Parameters["@name"].Value = cbName.SelectedValue;   //sets value of @name to that of the value selected in the choice box
                command.ExecuteNonQuery();  //executes the command

                SqlCommand delete = new SqlCommand("delete from Appointment where fullName = @name", con);        //command to remove the patients data from all tables where the collumn fullName is the same as @name
                delete.Parameters.Add("@name", SqlDbType.NChar);   //sets variable type of @name
                delete.Parameters["@name"].Value = cbName.SelectedValue;   //sets value of @name to that of the value selected in the choice box
                delete.ExecuteNonQuery();  //executes the command

                new Patients().Show();  //shows patient form
                this.Close();   //close current form


            }

            
            
        }
    }
}
