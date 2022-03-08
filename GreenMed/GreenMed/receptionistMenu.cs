﻿using System;
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
        public static bool receptionist;
        public static int menu;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\loginDatabase.mdf; Integrated Security = True");
        public receptionistMenu()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("Update login set Active = @logout where Active = @active", con);
            command.Parameters.Add("@active", SqlDbType.NChar);
            command.Parameters["@active"].Value = "True";
            command.Parameters.Add("@logOut", SqlDbType.NChar);
            command.Parameters["@logOut"].Value = "False";

            SqlDataAdapter sda = new SqlDataAdapter(command);

            DataTable dtJ = new DataTable("Login");

            sda.Fill(dtJ);
            con.Close();
            new login().Show();
            this.Close();
        }

        private void bntPatients_Click(object sender, EventArgs e)
        {
            new Patients().Show();
            this.Close();
        }

        private void btnMedication_Click(object sender, EventArgs e)
        {
            new Pescriptions().Show();
            this.Close();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            new CalendarForm().Show();
            this.Close();
        }

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            menu = 1;
            receptionist = true;
            new AddAppointment().Show();
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            new RemoveAppointment().Show();
            this.Close();
        }

        private void receptionistMenu_Load(object sender, EventArgs e)
        {
            menu = 0;
            receptionist = false;
        }
    }
}
