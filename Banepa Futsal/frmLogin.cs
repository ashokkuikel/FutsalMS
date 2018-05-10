using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace Banepa_Futsal
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        BLLUser user = new BLLUser();
        frmMain main = new frmMain();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (user.IsValidUser(txtUserName.Text, txtPassword.Text))
            {

                main.Show();
                //wcuser.LblWelcomeUser.Text = "Welcome " + txtUserName.Text;
                this.Hide();

            }
            else if(txtUserName.Text == "" && txtPassword.Text== "")
            {
                MessageBox.Show("Username and Password are required");
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show("Username required");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Password required");
            }
            else
            {
                MessageBox.Show("Connection cannot be established");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Thank you for using service");
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
