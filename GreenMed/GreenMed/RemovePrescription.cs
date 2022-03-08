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
        // initialize connection string
        public RemovePescription()
        {
            InitializeComponent();
            con.Open(); //open connection using connection string

            SqlCommand command = new SqlCommand("select fullName, Pescription from Pescriptions", con);
            //command to get the patients fullname and pescription collumn values from database pescription, using the connection string

            SqlDataAdapter sda = new SqlDataAdapter(command);   //makes dataadapter using the above command
            DataTable dt = new DataTable("Pescriptions");//makes new datatable
            sda.Fill(dt);   //fills datatable using data from the datadapter

            cbName.DataSource = dt;
            cbName.ValueMember = dt.Columns[0].ColumnName;
            cbName.DisplayMember = dt.Columns[0].ColumnName;
            //sets source of data for choicebox, then assigns the data shown and what it represents using a specifice collumn of that data source
            cbPescription.DataSource = dt;
            cbPescription.ValueMember = dt.Columns[1].ColumnName;
            cbPescription.DisplayMember = dt.Columns[1].ColumnName;
            //sets source of data for choicebox, then assigns the data shown and what it represents using a specifice collumn of that data source
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            new Pescriptions().Show();  //on button click open pescriptions 
            this.Close();               //then close this form
        }

        private void btnRemovePescription_Click(object sender, EventArgs e)
        {
            var confirmRemoval = MessageBox.Show("Confirm removal of this pescription from the databse?", "Confirm Removal", MessageBoxButtons.OKCancel);   //on butto click send up a message box confimation prompt
            if (confirmRemoval == DialogResult.OK)  //if they clicked ok on message box, run the following code
            {
                {
                    SqlCommand command = new SqlCommand("delete from Pescriptions where fullName = @name, Pescription = @pescription", con);    
                    command.Parameters.Add("@name", SqlDbType.NChar);
                    command.Parameters["@name"].Value = cbName.SelectedValue;
                    command.Parameters.Add("@pescription", SqlDbType.NChar);
                    command.Parameters["@pescription"].Value = cbPescription.SelectedValue;
                    command.ExecuteNonQuery();
                    //this section of code tells the datatable to remove the pescription from the Pescriptions datatable where in 1 row the collumns fullName and Pescription are the same value as those selected by choice boxs name and pescription

                    new Pescriptions().Show();  //show pescriptions form
                    this.Close();           //close current form
                }
            }
        }
    }
}
