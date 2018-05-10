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
    public partial class frmUserUpdate : Form
    {
        public frmUserUpdate()
        {
            InitializeComponent();
        }
        BLLUser user = new BLLUser();
        private void frmUserUpdate_Load(object sender, EventArgs e)
        {
            DataTable dt = user.View();
            dgvUser.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dgvUser.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUser_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtUserID.Text = dgvUser.CurrentRow.Cells[0].Value.ToString();
            txtUserName.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;
            int i = 0;
            i = user.UpdateUser(UserName, Password);
            if (i > 0)
            {
                MessageBox.Show("Update sucessfully.");
            }
            else
            {
                MessageBox.Show("Unsucessful to Update");
            }
        }
    }
}
