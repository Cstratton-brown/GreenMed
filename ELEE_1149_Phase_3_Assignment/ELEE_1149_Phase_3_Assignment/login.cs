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
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Charles\Documents\Visual Studio Projects\ELEE_1149_Phase_3_Assignment\ELEE_1149_Phase_3_Assignment\loginDatabase.mdf;Integrated Security = True");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from login where LoginID='" + txtID.Text + "'and LoginPassword='" + txtPassword.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1") 
            {
                this.Hide();
                new receptionistMenu().Show();
            }
            else
            {
                MessageBox.Show("Please enter correct Username and Password", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
