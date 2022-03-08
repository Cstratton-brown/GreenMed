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

namespace ELEE_1149_Phase_3_Assignment
{
    public partial class receptionistMenu : Form
    {
        public static bool receptionist;    //initialize global bool receptionist
        public static int menu;             //initialize global int menu
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        //initialize connection string
        public receptionistMenu()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)    //on button press
        {
            con.Open(); //opens connection
            SqlCommand command = new SqlCommand("Update login set Active = @logout where Active = @active", con);   //command to update login database using connection string
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";   //sets the current value of active to search for as true
            command.Parameters.Add("@logOut", SqlDbType.NChar); 
            command.Parameters["@logOut"].Value = "False";     //sets the value to change in the active collumn to false

            SqlDataAdapter sda = new SqlDataAdapter(command);   //initialize dataadapter using the command
            
            DataTable dtJ = new DataTable("Login"); //new datatable login

            sda.Fill(dtJ);  //fill login using data adapter
            con.Close();    //close the connection
            new login().Show(); //show login form
            this.Close();   //close current form
        }

        private void bntPatients_Click(object sender, EventArgs e)  //on button press
        {
            new Patients().Show();  //open patients form
            this.Close();       //close current form
        }

        private void btnMedication_Click(object sender, EventArgs e)    //on button press
        {
            new Pescriptions().Show();  //open pescription form
            this.Close();   //close current form
        }

        private void btnAppointments_Click(object sender, EventArgs e)  //on button press
        {
            new CalendarForm().Show();  //open calendar form
            this.Close();   //close current form
        }

        private void btnNewAppointment_Click(object sender, EventArgs e)    //on button press
        {
            menu = 1;       //set global int menu to 1
            receptionist = true;    //set global bool receptionist to false
            new AddAppointment().Show();    //show add appointment form
            this.Close();   //close current form
        }

        private void btnRemove_Click(object sender, EventArgs e)    //on button press
        {
            new RemoveAppointment().Show(); // open remove appointment form
            this.Close();   //close current form
        }

        private void receptionistMenu_Load(object sender, EventArgs e)  //on button press
        {
            menu = 0;   //sets global variable menu to 0
            receptionist = false;   //sets global bool receptionist to false
        }
    }
}
