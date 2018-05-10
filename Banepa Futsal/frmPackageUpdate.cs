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
    public partial class frmPackageUpdate : Form
    {
        public frmPackageUpdate()
        {
            InitializeComponent();
        }
        BLLRate package = new BLLRate();
        private void dgvPckageUpdate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPckageUpdate_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtPackage.Text = dgvPackageUpdate.CurrentRow.Cells[1].Value.ToString();
            txtRate.Text = dgvPackageUpdate.CurrentRow.Cells[2].Value.ToString();
            
        }

        private void frmPackageUpdate_Load(object sender, EventArgs e)
        {
            DataTable dt = package.PackageView();
            dgvPackageUpdate.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dgvPackageUpdate.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No Records Found !!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Package = txtPackage.Text;
            double Rate = Convert.ToDouble(txtRate.Text);
            int i = 0;
            i = package.PackageUpdate(package, Rate);
            if(i > 0)
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
