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
    public partial class frmcancelbooking : Form
    {
        public frmcancelbooking()
        {
            InitializeComponent();
          
        }
        BLLBooking booking = new BLLBooking();

        private void frmcancelbooking_Load(object sender, EventArgs e)
        {
            DataTable dt = booking.DescendingView();
            dgvCancelview.DataSource = dt;


            if (dt.Rows.Count > 0)
            {
                dgvCancelview.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvCancelview.CurrentRow.Cells[0].Value.ToString();
            txtRName.Text = dgvCancelview.CurrentRow.Cells[1].Value.ToString();
            txtTName.Text = dgvCancelview.CurrentRow.Cells[2].Value.ToString();
            txtBTime.Text = dgvCancelview.CurrentRow.Cells[3].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            if (txtID.Text == "")
            {
                MessageBox.Show("Booked ID is mising");
                this.Close();
                frmcancelbooking can = new frmcancelbooking();
                can.Show();
            }
                int BookID = Convert.ToInt32(txtID.Text);
                string RName = Convert.ToString(txtRName.Text);
                int i = 0;
                i = booking.CancelBooking(BookID, RName);
                if (i > 0)
                {
                    MessageBox.Show("Successfully deleted");
                    DataTable dt = booking.DescendingView();
                    dgvCancelview.Refresh();
                    dgvCancelview.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        dgvCancelview.DataSource = dt;

                    }
                    else
                    {
                        MessageBox.Show("No Records Found !!!");
                    }

                }
                else
                {
                    if (txtID.Text == "")
                    {
                        MessageBox.Show("Booked ID is mising");
                    }
                    else if (txtRName.Text == "")
                    {
                        MessageBox.Show("Registrant name is mising");
                    }
                    else if (txtID.Text == "" && txtRName.Text == "")
                    {
                        MessageBox.Show("Booked ID & Registrant name is mising");
                    }
                    else
                    {
                        MessageBox.Show("Unsuccessfull to delete.Please Try again.");
                    }
                }


            }
        

        private void txtBTime_ValueChanged(object sender, EventArgs e)
        {
            txtBTime.ShowUpDown = true;
            txtBTime.CustomFormat = "MMMM dd, yyyy hh:'00' tt";
            txtBTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }

        private void dgvCancelview_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtID.Text = dgvCancelview.CurrentRow.Cells[0].Value.ToString();
            txtRName.Text = dgvCancelview.CurrentRow.Cells[2].Value.ToString();
            txtTName.Text = dgvCancelview.CurrentRow.Cells[1].Value.ToString();
            txtBTime.Text = dgvCancelview.CurrentRow.Cells[3].Value.ToString();
        }

        private void txtTName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

