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
    public partial class frmdetailsvie : Form
    {
        public frmdetailsvie()
        {
            InitializeComponent();
            ComboFill();
        }
        BLLBooking booking = new BLLBooking();
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvViewAll_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            txtBookID.Text = dgvViewAll.CurrentRow.Cells[0].Value.ToString();
            txtRegName.Text = dgvViewAll.CurrentRow.Cells[1].Value.ToString();
            txtTName.Text = dgvViewAll.CurrentRow.Cells[2].Value.ToString();
            txtBTime.Text = dgvViewAll.CurrentRow.Cells[3].Value.ToString();
            txtPhone.Text = dgvViewAll.CurrentRow.Cells[4].Value.ToString();
            txtAddress.Text = dgvViewAll.CurrentRow.Cells[5].Value.ToString();
        }

        private void frmdetailsview_Load(object sender, EventArgs e)
        {
            DataTable dt = booking.DescendingView();
            dgvViewAll.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dgvViewAll.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
            cmbPackage.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            int i = 0;
            int BookID = Convert.ToInt32(txtBookID.Text);
            string RName = txtRegName.Text;
            string TName = txtTName.Text;
            DateTime BTime = Convert.ToDateTime(txtBTime.Text);
            string CNumber = txtPhone.Text;
            string Address = txtAddress.Text;
            string Package = cmbPackage.Text;
            DateTime ETime = DateTime.Now;
            i = booking.UpdateBooking(BookID,RName, TName, BTime, CNumber, Address, Package, ETime);
            if (i > 0)
            {
                MessageBox.Show("Successfully Updated");
                DataTable dt = booking.DescendingView();
                dgvViewAll.Refresh();
                dgvViewAll.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dgvViewAll.DataSource = dt;

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
            dgvViewAll.Refresh();
        }

        private void dgvViewAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtRName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBTime_ValueChanged(object sender, EventArgs e)
        {
            txtBTime.ShowUpDown = true;
            txtBTime.CustomFormat = "MMMM dd, yyyy h:mm tt";
            txtBTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }

        private void cmbPackage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
