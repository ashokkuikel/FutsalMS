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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        BLLBooking booking = new BLLBooking();
       
        private void frmMain_Load(object sender, EventArgs e)
        {
           // TextBoxFillCurrent();
            //TextBoxFillNext();

        }
        //public void TextBoxFillCurrent()
        //{
        //    DateTime now = DateTime.Now;
        //    DateTime hour = Convert.ToDateTime(now.Hour);
        //    DateTime nexthour = hour.AddHours(1);
        //    if (booking.IsTime(hour))
        //    {
        //        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
        //        string sql = "select Package from tblBoking";
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        SqlDataReader DR = cmd.ExecuteReader();
        //        while (DR.Read())
        //        {
        //            string id = DR.GetInt32(BookID).ToString();
        //            string team = DR.GetString(BookID);
        //            string time = DR.GetDateTime(BookID).ToString();
        //            string contact = DR.GetString(BookID);
        //            txtID1.Text = id;
        //            txtTName1.Text = team;
        //            txtTime1.Text = time;
        //            txtCNumber1.Text = contact;
        //        }

        //    }
        //}
        //    public void TextBoxFillNext()
        //    {
        //    DateTime now = DateTime.Now;
        //    DateTime hour = Convert.ToDateTime(now.Hour);
        //    DateTime nexthour = hour.AddHours(1);
        //              if (booking.IsTime(nexthour))
        //    {
        //        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]);
        //        string sql = "select Package from tblBoking";
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        SqlDataReader DR = cmd.ExecuteReader();
        //        while (DR.Read())
        //        {
        //            string id = DR.GetInt32(BookID).ToString();
        //            string team = DR.GetString(BookID); 
        //            string time = DR.GetDateTime(BookID).ToString();
        //            string contact = DR.GetString(BookID);
        //            txtID2.Text = id;
        //            txtTName2.Text = team;
        //            txtTime2.Text = time;
        //            txtCNumber2.Text = contact;
        //        }
        //    }
        //    }
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmPackageView view = new frmPackageView();
            view.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmPackageCreate create = new frmPackageCreate();
            create.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmPackageUpdate update = new frmPackageUpdate();
            update.Show();

        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void memoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void toolstripnew_Click(object sender, EventArgs e)
        {
           frmbooking frmnew = new frmbooking();
           frmnew.MdiParent = this;
            frmnew.Show();
        }

        private void dmonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dbtnloout_Click(object sender, EventArgs e)
        {
            
            this.Close();
          
            frmLogin flogin = new frmLogin();
            flogin.Show();

        }

        private void dbtnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really want to close.", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close(); 
            }
                   
            
        }

        private void toolbarhome_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain frmmainpage = new frmMain();
            frmmainpage.Show();
        }

        private void statusBar1_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            wb.AllowNavigation = true;
            wb.Navigate("http://www.google.com/");
            
          
        }

        private void calculatorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            frmdetailsview frmdetails = new frmdetailsview();
            frmdetails.MdiParent = this;
            frmdetails.Show();

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            frmViewSchedule frmschedule = new frmViewSchedule();
            frmschedule.MdiParent = this;
            frmschedule.Show();

        }

        private void dbtncancelbooking_Click(object sender, EventArgs e)
        {
            frmcancelbooking frmcancel = new frmcancelbooking();
            frmcancel.MdiParent = this;
            frmcancel.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPackageDelete delete = new frmPackageDelete();
            delete.Show();
        }

        private void dashpanelview_Paint(object sender, PaintEventArgs e)
        {

        }

        public int BookID { get; set; }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusBar1.Panels[0].Text = DateTime.Now.ToString("MMMM dd, yyyy h:mm tt");
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
