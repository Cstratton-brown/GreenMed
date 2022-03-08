using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenMed
{
    public partial class UserControlBlank : UserControl
    {
        public UserControlBlank()   //this form does nothing just used as a white spot in the calendar for days of the week that are part of the prior month
        {
            InitializeComponent();
        }
    }
}
