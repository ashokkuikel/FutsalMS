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
using System.Data.SqlClient;
using System.Configuration;


namespace Banepa_Futsal
{
    public partial class frmcancelbook : Form
    {
        public frmcancelbook()
        {
            InitializeComponent();
        }
        BLLBooking booking = new BLLBooking();
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvCancel_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            txtID.Text = dgvCancel.CurrentRow.Cells[0].Value.ToString();
            txtRName.Text = dgvCancel.CurrentRow.Cells[1].Value.ToString();
            txtTName.Text = dgvCancel.CurrentRow.Cells[2].Value.ToString();
            txtBTime.Text = dgvCancel.CurrentRow.Cells[3].Value.ToString();
            
        }

        private void frmcancelbooking_Load(object sender, EventArgs e)
        {
            DataTable dt = booking.DescendingView();
            dgvCancel.DataSource = dt;

      
            if (dt.Rows.Count > 0)
            {
                dgvCancel.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int BookID = Convert.ToInt32(txtID.Text);
            string RName = txtRName.Text;           
            int i = 0;
            i = booking.CancelBooking(BookID,RName);
            if (i >= 0)
            {
                MessageBox.Show("Successfully Deleted");
                DataTable dt = booking.DescendingView();
                dgvCancel.Refresh();
                dgvCancel.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dgvCancel.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("No Records Found !!!");
                }
               
            
        }
            else
            {
                MessageBox.Show("Cannot Delete Try again");
            }
           
        }

        private void dgvCancel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvCancel_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtID.Text = dgvCancel.CurrentRow.Cells[0].Value.ToString();
            txtRName.Text = dgvCancel.CurrentRow.Cells[1].Value.ToString();
            txtTName.Text = dgvCancel.CurrentRow.Cells[2].Value.ToString();
            txtBTime.Text = dgvCancel.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
