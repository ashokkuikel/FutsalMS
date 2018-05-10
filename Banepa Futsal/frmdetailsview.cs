using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogicLayer;

namespace Banepa_Futsal
{
    public partial class frmdetailsview : Form
    {
        public frmdetailsview()
        {
            
            InitializeComponent();
            ComboFill();
        }
        BLLBooking booking = new BLLBooking();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void ComboFill()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string sql = "select Package from tblRate";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                cmbPackage.Items.Add(DR[0]);
            }
        }

        private void dgvViewAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            int i = 0;
                   
           int BookID = Convert.ToInt32(txtBookID.Text);
            string RName = txtRegName.Text;
            string TName = txtTName.Text;
            DateTime BTime = Convert.ToDateTime(txtBTim.Text);
            string CNumber = txtCNumber.Text;
            string Address = txtAddress.Text;
            string Package = cmbPackage.Text;
            DateTime ETime = DateTime.Now;
            i = booking.UpdateBooking(BookID, RName, TName, BTime, CNumber, Address, Package, ETime);
            if (i > 0)
            {
                MessageBox.Show("Successfully Updated");
                DataTable dt = booking.DescendingView();
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("No Records Found !!!");
                }
                cmbPackage.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Unsuccessfully to Updated.Please Try again.");
            }
            
        }

        private void frmbookedview_Load(object sender, EventArgs e)
        {
            DataTable dt = booking.DescendingView();
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
            cmbPackage.SelectedIndex = 0;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBTme_ValueChanged(object sender, EventArgs e)
        {
            txtBTime.ShowUpDown = true;
            txtBTime.CustomFormat = "MMMM dd, yyyy hh+:00 tt";
            txtBTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            string RName = txtSearchByName.Text;
            DataTable dt = booking.GetScheduleByName(RName);
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
        }

        private void txtBTim_ValueChanged(object sender, EventArgs e)
        {
            txtBTim.ShowUpDown = true;
            txtBTim.CustomFormat = "MMMM dd, yyyy hh:'00' tt";
            txtBTim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtBookID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtRegName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtBTim.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtCNumber.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtAddress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cmbPackage.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
    }
    }
