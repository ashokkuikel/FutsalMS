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
    public partial class frmPackageDelete : Form
    {
        public frmPackageDelete()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            BLLRate package = new BLLRate();
            String Package = txtPackage.Text;
            int i = 0;
             i =  package.PackageDelete(Package);
            if (i >= 0)
            {
                MessageBox.Show("Successfully Deleted");
            }
            else
            {
                MessageBox.Show("Cannot Delete Try again");
            }
        }


    }
}
