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
using GreenMed;
using System.Globalization;

namespace ELEE_1149_Phase_3_Assignment
{
    public partial class Calendar : Form
    {
        String userJob;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");

        public Calendar()
        {
            InitializeComponent();
            con.Open();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
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

        private void Calendar_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void displayDays()
        {
            DateTime now = DateTime.Now;

            int month = now.Month;
            int year = now.Year;
            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);

            lblMonthYear.Text = monthName + " " + year;

            DateTime startOfTheMonth = new DateTime(now.Year, now.Month, 1);

            int days = DateTime.DaysInMonth(now.Year, now.Month);

            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"))+1;
            for (int i = 1; i < dayOfTheWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                CalendarContainer.Controls.Add(ucBlank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                CalendarContainer.Controls.Add(ucDays);
            }
            
        }
    }
}
