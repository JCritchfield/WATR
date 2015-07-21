using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATR_GUI
{
    public partial class WATRSplashScreen : Form
    {
        public WATRSplashScreen()
        {
            InitializeComponent();
        }


        //This little thing is needed because I couldn't get the form to hide any other way -_-
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Hide();
        }
    }
}
