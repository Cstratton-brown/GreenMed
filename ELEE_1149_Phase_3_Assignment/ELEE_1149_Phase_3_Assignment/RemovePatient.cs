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
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Charles\Documents\Visual Studio Projects\ELEE_1149_Phase_3_Assignment\ELEE_1149_Phase_3_Assignment\loginDatabase.mdf; Integrated Security = True");
        String patientName;
        Boolean patientNameCheck = false;

        public RemovePatient()
        {
            con.Open();
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            new Patients().Show();
            this.Close();
        }

        private void btnRemovePatient_Click(object sender, EventArgs e)
        {
            SqlCommand check = new SqlCommand("select fullName from Patients where fullName = @name", con);
            check.Parameters.Add("@name", SqlDbType.NChar);
            check.Parameters["@name"].Value = txtName.Text;
            check.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(check);

            DataTable dt = new DataTable("Login");

            sda.Fill(dt);
            try
            {
                patientName = dt.Rows[0]["fullName"].ToString();
                patientNameCheck = true;
            }
            catch
            {
                MessageBox.Show("Please enter valid patient name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (patientNameCheck == true)
            {
                SqlCommand command = new SqlCommand("delete from Patients where fullName = @name", con);
                command.Parameters.Add("@name", SqlDbType.NChar);
                command.Parameters["@name"].Value = txtName.Text;
                command.ExecuteNonQuery();
                new Patients().Show();
                this.Close();
                
            }
            else
            {

            }

            
            
        }
    }
}
