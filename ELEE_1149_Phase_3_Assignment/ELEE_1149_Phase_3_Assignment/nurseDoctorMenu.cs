﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELEE_1149_Phase_3_Assignment
{
    public partial class nurseDoctorMenu : Form
    {
        public nurseDoctorMenu()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Close();
        }
    }
}
