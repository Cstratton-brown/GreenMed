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
using ELEE_1149_Phase_3_Assignment;

namespace GreenMed
{
    public partial class AddAppointment : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");

        public AddAppointment()
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
            SqlCommand check = new SqlCommand("select Practitioner from Login where CONVERT(VARCHAR, Role) <> 'Receptionist'", con);
            SqlDataAdapter sda2 = new SqlDataAdapter(check);
            DataTable dtp = new DataTable("Practitioner");
            sda2.Fill(dtp);
            cbPractitioner.DataSource = dtp;
            cbPractitioner.ValueMember = dtp.Columns[0].ColumnName;
            cbPractitioner.DisplayMember = dtp.Columns[0].ColumnName;
            
            
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (receptionistMenu.receptionist == true)
            {
                new receptionistMenu().Show();
                receptionistMenu.receptionist = false;
                this.Close();
            }
            else
            {
            new CalendarForm().Show();
            this.Close();
            }
            
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            Form addAppointment = (Form)this.Parent;
            SqlCommand command = new SqlCommand("insert into Appointments (fullName, date, startTime, endTime, Practitioner) values (@name, @date, @start, @end, @practitioner)", con);
            command.Parameters.Add("@name", SqlDbType.NChar);
            command.Parameters.Add("@date", SqlDbType.NChar);
            command.Parameters.Add("@start", SqlDbType.NChar);
            command.Parameters.Add("@end", SqlDbType.NChar);
            command.Parameters.Add("@practitioner", SqlDbType.NChar);
            command.Parameters["@name"].Value = cbName.Text;
            command.Parameters["@date"].Value = txtDate.Text;
            command.Parameters["@start"].Value = txtStart.Text;
            command.Parameters["@end"].Value = txtEnd.Text;
            command.Parameters["@practitioner"].Value = cbPractitioner.Text;
            command.ExecuteNonQuery();
            MessageBox.Show("Appointemnt Added", "Alert", MessageBoxButtons.OK);
            con.Close();
            if (receptionistMenu.receptionist == true)
            {
                new receptionistMenu().Show();
                receptionistMenu.receptionist = false;
                this.Close();

            }
            else
            {
                new CalendarForm().Show();
                this.Close();
            }
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            if (receptionistMenu.receptionist == false)
            {
                txtDate.Text = UserControlDays.static_day + "/" + CalendarForm.static_month + "/" + CalendarForm.static_year;
                txtDate.Enabled = false;
            }
            else
            {
                txtDate.Enabled = true;

            }
        }
        

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            if (receptionistMenu.receptionist == true)
            {
                new receptionistMenu().Show();
                receptionistMenu.receptionist = false;

                this.Close();
            }
            else
            {
                new CalendarForm().Show();
                this.Close();
            }
        }
    }
}
