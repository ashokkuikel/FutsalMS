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
    public partial class frmbooking : Form
    {
        public frmbooking()
        {
            InitializeComponent();
            ComboFill();
            ComboFill2();
        }
        BLLBooking booking = new BLLBooking();
        //public void TimePicker()
        //{
        //    DateTimePicker time;
        //    time = new DateTimePicker();
        //    time.Format = DateTimePickerFormat.Time;
        //    time.ShowUpDown = true;
        //    time.Location = new Point(160, 225);
        //    time.Width = 100;
        //    Controls.Add(time);
        //}
        public void ClearControls()
        {
            txtReservantName.Text = string.Empty;
            txtTeamName.Text = String.Empty;
            txtPhone.Text = string.Empty;
            txtBTime.Text = String.Empty;
            txtAddress.Text = String.Empty;
           cmbPackage.SelectedIndex = 0;
            cmbAmount.Text = String.Empty;
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

        public void ComboFill2()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string sql = "select Rate from tblRate";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                cmbAmount.Items.Add(DR[0]);

            }
        }

        private void frmbooking_Load(object sender, EventArgs e)
        {
           cmbPackage.SelectedIndex = 0;
            cmbAmount.SelectedIndex = 0;
            txtBTime.Text = Convert.ToString(DateTime.Now);
            // view showing code
            DataTable dt = booking.View();
            dgvViewall.DataSource = dt;
            txtTotal.Text = Convert.ToString(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                dgvViewall.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timePortionDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLLBooking booking = new BLLBooking();
            int i = 0;
            DateTime test = DateTime.Now.AddHours(1);
            DateTime btime = Convert.ToDateTime(txtBTime.Text);
            int amount = int.Parse(cmbAmount.Text);
            string SDate = Convert.ToString(btime);
            ///txtBTime
         
            DateTime etime = DateTime.Now;
            
            if (booking.IsValidBooking(btime) &&  btime>=test)
            {
                MessageBox.Show("Invalid Booking time.");
                ClearControls();
            }
            //else if(txtReservantName.Text!=null || txtTeamName.Textbtime, txtPhone.Text, txtAddress.Text, cmbPackage.Text, etime)
           

            else
            {
                i = booking.Booking(txtReservantName.Text, txtTeamName.Text,btime, txtPhone.Text, txtAddress.Text, cmbPackage.Text, etime,amount,SDate);

                if (i >= 1)
                {
                    MessageBox.Show("Booking has been successful.");
                    if (MessageBox.Show("Booking has been Register. Do you want to continue", "Book Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ClearControls();
                        txtReservantName.Focus();
                    }

                    DataTable dt = booking.View();
                    dgvViewall.DataSource = dt;
                    txtTotal.Text = Convert.ToString(dt.Rows.Count);
                    if (dt.Rows.Count > 0)
                    {
                        dgvViewall.DataSource = dt;

                    }
                    else
                    {
                        MessageBox.Show("No Records Found !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Unsuccessful to book time.");

                }
                
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            

        }

        private void cmbPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
            string sql = "select Package from tblRate  where Package = '"+cmbPackage.Text+"' ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            //while (DR.Read())
            //{
            //    string rt = DR.GetString("Rate");
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtReservantName_TextChanged(object sender, EventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            txtBTime.ShowUpDown = true;
            txtBTime.CustomFormat = "MMMM dd, yyyy h':00' tt";
            txtBTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }

        private void Amount_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvViewall_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmrateview view = new frmrateview();
            view.Location = new Point(1075,200);
            view.Show();
           
        }
    }
    }


