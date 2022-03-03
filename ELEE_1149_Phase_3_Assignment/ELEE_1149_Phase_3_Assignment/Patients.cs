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
        String userJob;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Charles\Documents\Visual Studio Projects\ELEE_1149_Phase_3_Assignment\ELEE_1149_Phase_3_Assignment\loginDatabase.mdf; Integrated Security = True");
        
        
        public Patients()
        {
            
            InitializeComponent();

            con.Open();
            SqlCommand newPatient = new SqlCommand("select Role from Login where Active = @active", con);
            newPatient.Parameters.Add("@active", SqlDbType.NChar);
            newPatient.Parameters["@active"].Value = "True";
            newPatient.ExecuteNonQuery();
            
            SqlDataAdapter sda = new SqlDataAdapter(newPatient);

            DataTable dtJ = new DataTable("Login");

            sda.Fill(dtJ);
            userJob = dtJ.Rows[0]["Role"].ToString();

            if (userJob == "Receptionist")
            {
                btnAddPatient.Visible = true;
                btnRemove.Visible = true;
            }
            else
            {
                btnAddPatient.Visible = false;
                btnRemove.Visible = false;
            }

            SqlDataReader reader = null;

            
            try
            {
                
                SqlCommand command = new SqlCommand("select fullName, Age, Gender, DateofBirth from Patients", con);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    object[] row = { reader[0], reader[1], reader[2], reader[3] };
                    dgPatients.Rows.Add(row);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("select Role from Login where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(command);

            DataTable dtJ = new DataTable("Login");

            sda.Fill(dtJ);
            userJob = dtJ.Rows[0]["Role"].ToString();

            if (userJob == "Receptionist")
            {
                new receptionistMenu().Show();
                this.Close();
            }
            else
            {
                new nurseDoctorMenu().Show();
                this.Close();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            
            SqlCommand command = new SqlCommand("Update login set Active = @logout where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.Parameters.Add("@logOut", SqlDbType.NChar);
            command.Parameters["@logOut"].Value = "False";

            SqlDataAdapter sda = new SqlDataAdapter(command);

            DataTable dtJ = new DataTable("Login");

            sda.Fill(dtJ);
            new login().Show();
            this.Close();
            con.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Close();
            new RemovePatient().Show();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            this.Close();
            new AddPatient().Show();
        }
    }
}
