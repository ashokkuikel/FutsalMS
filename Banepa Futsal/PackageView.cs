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
    public partial class frmPackageView : Form
    {
        public frmPackageView()
        {
            InitializeComponent();
        }
        BLLRate package = new  BLLRate();
        private void PackageView_Load(object sender, EventArgs e)
        {
            DataTable dt = package.PackageView();
            dgvPackageView.DataSource = dt;           
            if (dt.Rows.Count > 0)
            {
                dgvPackageView.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
            
            
        }

        private void dgvPackageView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
