using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELEE_1149_Phase_3_Assignment;
using GreenMed;
using System.Data.SqlClient;

namespace GreenMed
{
    public partial class UserControlDays : UserControl
    {
        public static string static_day;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        String userJob;
        public UserControlDays()
        {
            InitializeComponent();
            con.Open();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            lblDays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select Role from Login where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(command);

            DataTable dt = new DataTable("Login");

            sda.Fill(dt);

            try
            {
                userJob = dt.Rows[0]["Role"].ToString();
            }
            catch (Exception)
            {
            }
            if (userJob == "Receptionist")
            {
                static_day = lblDays.Text;
                new AddAppointment().Show();
                this.ParentForm.Close();
            }
            else
            {
                new DailyAppointments().Show();
                this.ParentForm.Close();
            }

        }

        private void lblDays_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select Role from Login where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(command);

            DataTable dt = new DataTable("Login");

            sda.Fill(dt);

            try
            {
                userJob = dt.Rows[0]["Role"].ToString();
            }
            catch (Exception)
            { 
            }
            if (userJob == "Receptionist")
            {
                static_day = lblDays.Text;
                new AddAppointment().Show();
                this.ParentForm.Close();
            }
            else
            {
                new DailyAppointments().Show();
                this.ParentForm.Close();
            }

        }
    }
}
