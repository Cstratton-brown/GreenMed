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
    public partial class AddPescription : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");

        public AddPescription()
        {
            con.Open();
            InitializeComponent();
            SqlCommand command = new SqlCommand("select fullName from Patients",con);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Patient");
            sda.Fill(dt);
            cbName.DataSource = dt;
            cbName.ValueMember = dt.Columns[0].ColumnName;
            cbName.DisplayMember = dt.Columns[0].ColumnName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            new Pescriptions().Show();
            this.Close();
        }

        private void btnAddPescription_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("insert into Pescriptions (fullName, Pescription, startDate, endDate, Instructions) values (@name, @pescription, @start, @end, @Instructions)", con);
            command.Parameters.Add("@name", SqlDbType.NChar);
            command.Parameters.Add("@pescription", SqlDbType.NChar);
            command.Parameters.Add("@start", SqlDbType.NChar);
            command.Parameters.Add("@end", SqlDbType.NChar);
            command.Parameters.Add("@instructions", SqlDbType.NVarChar);
            command.Parameters["@name"].Value = cbName.SelectedValue;
            command.Parameters["@pescription"].Value = txtPescription.Text;
            command.Parameters["@start"].Value = txtStart.Text;
            command.Parameters["@end"].Value = txtEnd.Text;
            command.Parameters["@Instructions"].Value = txtInstructions.Text;
            command.ExecuteNonQuery();
            con.Close();
            new Pescriptions().Show();
            this.Close();
        }


    }
}
