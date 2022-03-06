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

        public AddPatient()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            new Patients().Show();
            this.Close();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("insert into Patients (fullName, Age, Gender, DateofBirth) values (@name, @age, @gender, @dateofbirth)", con);
            command.Parameters.Add("@name", SqlDbType.NChar);
            command.Parameters.Add("@age", SqlDbType.NChar);
            command.Parameters.Add("@gender", SqlDbType.NChar);
            command.Parameters.Add("@dateofbirth", SqlDbType.NChar);
            command.Parameters["@name"].Value = txtName.Text;
            command.Parameters["@age"].Value = txtAge.Text;
            command.Parameters["@gender"].Value = txtGender.Text;
            command.Parameters["@dateofbirth"].Value = txtDateofBirth.Text;
            command.ExecuteNonQuery();
            con.Close();
            new Patients().Show();
            this.Close();
        }
    }
}
