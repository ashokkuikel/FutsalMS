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
    public partial class frmPackageCreate : Form
    {
        public frmPackageCreate()
        {
            InitializeComponent();
        }
        BLLRate package = new BLLRate();
        private void button1_Click(object sender, EventArgs e)
        {
            int i= 0; 
            double rate = Convert.ToDouble(txtRate.Text);
            
                i = package.AddPackage(txtPackage.Text,rate);

                if (i >= 1)
                {
                    MessageBox.Show("Addind has been successful.");
                   

                }
                else
                {
                    MessageBox.Show("Unsuccessful to Add package.");

                }
        }
    }
}
