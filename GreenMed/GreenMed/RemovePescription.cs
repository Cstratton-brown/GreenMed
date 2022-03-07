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
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        public RemovePescription()
        {
            InitializeComponent();
            con.Open();

            SqlCommand command = new SqlCommand("select fullName, Pescription from Pescriptions", con);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Pescriptions");
            sda.Fill(dt);
            cbName.DataSource = dt;
            cbName.ValueMember = dt.Columns[0].ColumnName;
            cbName.DisplayMember = dt.Columns[0].ColumnName;
            cbPescription.DataSource = dt;
            cbPescription.ValueMember = dt.Columns[1].ColumnName;
            cbPescription.DisplayMember = dt.Columns[1].ColumnName;
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
                {
                    SqlCommand command = new SqlCommand("delete from Pescriptions where fullName = @name, Pescription = @pescription", con);
                    command.Parameters.Add("@name", SqlDbType.NChar);
                    command.Parameters["@name"].Value = cbName.SelectedValue;
                    command.Parameters.Add("@pescription", SqlDbType.NChar);
                    command.Parameters["@pescription"].Value = cbPescription.SelectedValue;
                    command.ExecuteNonQuery();
                    new Pescriptions().Show();
                    this.Close();
                }
            }
        }
    }
}
