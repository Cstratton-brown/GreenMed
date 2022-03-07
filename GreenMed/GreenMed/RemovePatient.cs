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
            cbName.DataSource = dt;
            cbName.ValueMember = dt.Columns[0].ColumnName;
            cbName.DisplayMember = dt.Columns[0].ColumnName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            new Patients().Show();
            this.Close();
        }

        private void btnRemovePatient_Click(object sender, EventArgs e)
        {
            var confirmRemoval = MessageBox.Show("Confirm removal of this patient, their appointments and pescriptions from the database?", "Confirm Removal", MessageBoxButtons.OKCancel);
            if (confirmRemoval == DialogResult.OK)
            {        
                SqlCommand command = new SqlCommand("delete from Patients, Pescriptions, Appointments where fullName = @name", con);
                command.Parameters.Add("@name", SqlDbType.NChar);
                command.Parameters["@name"].Value = cbName.SelectedValue;
                command.ExecuteNonQuery();
                new Patients().Show();
                this.Close();


            }

            
            
        }
    }
}
