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
    public partial class Login : Form
    {
        // Check user login
        bool isLoginValid(string user_name, string password)
        {
            // Connect to database and check username and password
            string user = "muktinath";
            string pwd = "12345";
            if(user_name == user && password == pwd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Login()
        {
            InitializeComponent();
        }
          
        private void Login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(isLoginValid(txtUserName.Text, txtPassword.Text))
            {
                lblError.Visible = false;
                Instruction mukti = new Instruction();
                this.Hide();
                mukti.Show();
            }
            else
            {
                lblError.Visible = true;
            }
        }
    }
}
