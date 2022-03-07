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
using GreenMed;
using System.Globalization;

namespace GreenMed
{
    public partial class DailyAppointments : Form
    {
        int menuCheck;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        public DailyAppointments()
        {
            con.Open();
            InitializeComponent();
            

            SqlDataReader reader = null;


            try
            {
                SqlCommand command = new SqlCommand("select Appointments.fullName, Appointments.date, Appointments.startTime, Appointments.endTime, Appointments.Practitioner, Login.Active from Appointments, Login where Login.Practitioner = Appointments.Practitioner and Active=@active and date=@date order by Appointments.startTime", con);
                command.Parameters.Add("@date", SqlDbType.NChar);
                command.Parameters["@date"].Value = lblDate.Text;
                command.Parameters.Add("@active", SqlDbType.NChar);
                command.Parameters["@active"].Value = true;

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

            if (menuCheck == 0)
            {
                new nurseDoctorMenu().Show();
                this.Close();
            }
            else if (menuCheck == 1)
            {
                new CalendarForm().Show();
                menuCheck = 0;
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

        private void DailyAppointments_Load(object sender, EventArgs e)
        {
            menuCheck = nurseDoctorMenu.menu;
            if (menuCheck == 0)
            {

                DateTime date = DateTime.UtcNow;
                lblDate.Text = date.ToString("d/M/yyyy");


            }
            else if (menuCheck == 1)
            {
                lblDate.Text = UserControlDays.static_day + "/" + CalendarForm.static_month + "/" + CalendarForm.static_year;
            }
        }
    }
}
