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
using ELEE_1149_Phase_3_Assignment;

namespace GreenMed
{
    public partial class DailyAppointments : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        string practitioner;
        public DailyAppointments()
        {
            con.Open();
            InitializeComponent();
            lblDate.Text = UserControlDays.static_day + "/" + Calendar.static_month + "/" + Calendar.static_year;
            SqlCommand check = new SqlCommand("select Practitioner from Login where Active = @active", con);
            check.Parameters.Add("@active", SqlDbType.NChar);
            check.Parameters["@active"].Value = "True";
            check.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(check);

            DataTable dtJ = new DataTable("Login");

            sda.Fill(dtJ);
            practitioner = dtJ.Rows[0]["Practitioner"].ToString();
            lblPractitioner.Text = practitioner;

            SqlDataReader reader = null;


            try
            {
                SqlCommand command = new SqlCommand("select fullName, date, startTime, endTime, Practitioner from Appointments where Practitioner =@practitioner and date=@date", con);
                command.Parameters.Add("@practitioner", SqlDbType.NChar);
                command.Parameters["@practitioner"].Value = lblPractitioner.Text;
                command.Parameters.Add("@date", SqlDbType.NChar);
                command.Parameters["@date"].Value = lblDate.Text;

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
            new nurseDoctorMenu().Show();
            this.Close();
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
    }
}
