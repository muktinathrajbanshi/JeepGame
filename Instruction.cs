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
    public partial class Instruction : Form
    {
        private int _ticks;
        public Instruction()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            this.Text = _ticks.ToString();

            if (_ticks == 20)
            {
                this.Text = "PLAY";
                geepGround obj = new geepGround();
                this.Hide();
                obj.Show();
                timer1.Stop();
            }
           
        }
    }
}
