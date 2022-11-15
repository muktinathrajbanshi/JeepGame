using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeepGameOk
{
    public partial class SplashScreen : Form
    {
        int progress = 0;
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Loading....";
            progressSplash.Value = 0;
            timerProgress.Enabled = true;
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            progress++;
            progressSplash.Value = progress;
            lblStatus.Text = "Loading...(" + progress + "%loaded)";
            if(progress >= 100)
            {
                timerProgress.Enabled = false;
                Login  form = new Login();
                this.Hide();
                form.Show();
            }
        }
    }
}
