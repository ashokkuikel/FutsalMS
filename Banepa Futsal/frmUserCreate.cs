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
    public partial class frmUserCreate : Form
    {
        public frmUserCreate()
        {
            InitializeComponent();
        }
        BLLUser user = new BLLUser();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int  i = 0;
            if(txtPassword.Text == txtPasswordRe.Text && txtPassword.Text.Length >= 6  )
            {
                i = user.CreateUser(txtUserName.Text,txtPassword.Text);
                if (i > 0)
                {
                    MessageBox.Show("User is create sucessfully.");
                }
                else
                {
                    MessageBox.Show("Unable to create user try again.");
                }

                }
            else
            {
                   MessageBox.Show("Password should be Retyped correctly.");
            }

          }






        }
    }

