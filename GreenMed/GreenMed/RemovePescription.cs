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
    public partial class RemovePescription : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True"); String patientName;
        String pescriptionName;
        Boolean patientNameCheck = false;
        Boolean pescriptionNameCheck = false;
        public RemovePescription()
        {
            con.Open();
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            new Pescriptions().Show();
            this.Close();
        }

        private void btnRemovePescription_Click(object sender, EventArgs e)
        {
            var confirmRemoval = MessageBox.Show("Confirm removal of this pescription from the databse?", "Confirm Removal", MessageBoxButtons.OKCancel);
            if (confirmRemoval == DialogResult.OK)
            {
                SqlCommand check = new SqlCommand("select fullName, Pescription from Pescriptions where fullName = @name and Pescription = @pescription", con);
                check.Parameters.Add("@name", SqlDbType.NChar);
                check.Parameters["@name"].Value = txtName.Text;
                check.Parameters.Add("@pescription", SqlDbType.NVarChar);
                check.Parameters["@pescription"].Value = txtPescription.Text;
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
                try
                {
                    pescriptionName = dt.Rows[0]["fullName"].ToString();
                    pescriptionNameCheck = true;
                }
                catch
                {
                    MessageBox.Show("Please enter valid Pescription", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (patientNameCheck == true && pescriptionNameCheck == true)    
                {
                    SqlCommand command = new SqlCommand("delete from Pescriptions where fullName = @name and Pescription = @pescription", con);
                    command.Parameters.Add("@name", SqlDbType.NChar);
                    command.Parameters["@name"].Value = txtName.Text;
                    command.Parameters.Add("@pescription", SqlDbType.NVarChar);
                    command.Parameters["@pescription"].Value = txtPescription.Text;
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
}
