using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using BusinessLogicLayer;


namespace Banepa_Futsal
{
    public partial class frmViewSchedule : Form
    {
        public frmViewSchedule()
        {
            InitializeComponent();
        }
        BLLBooking booking = new BLLBooking();
        
        private void dgvSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void frmViewSchedule_Load(object sender, EventArgs e)
        {

            DataTable dt = booking.DescendingView();
            dgvSchedule.DataSource = dt;
            
            txtTotal.Text = Convert.ToString(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                dgvSchedule.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime BTime = DateTime.Now;
            
            DataTable dt = booking.GetScheduleByDate(BTime);
            dgvSchedule.DataSource = dt;

            txtTotal.Text = Convert.ToString(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                dgvSchedule.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime Btom = DateTime.Today;
           
            DataTable dt = booking.GetScheduleBytom(Btom);
            dgvSchedule.DataSource = dt;

            txtTotal.Text = Convert.ToString(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                dgvSchedule.DataSource = dt;
               
            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }

        }

        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{
        //    // 
        //}

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            string RName = txtSearchByName.Text;
            DataTable dt = booking.GetScheduleByName(RName);
            dgvSchedule.DataSource = dt;
            txtTotal.Text = Convert.ToString(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                dgvSchedule.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
        }

       

        private void dgvSchedule_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = booking.DescendingVsch();
            dgvSchedule.DataSource = dt;

            txtTotal.Text = Convert.ToString(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                dgvSchedule.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }

        }

        private void txtsearchbydate_TextChanged(object sender, EventArgs e)
        {


            string SDate = Convert.ToString(txtsearchbydate.Text);
            DataTable dt = booking.searchbydate(SDate);

            dgvSchedule.DataSource = dt;

            txtTotal.Text = Convert.ToString(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                dgvSchedule.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
        }
    }

    }

