using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Application
{
    public partial class frmShowNewLocalDrivingLicenseApplicationDetails : Form
    {
        public frmShowNewLocalDrivingLicenseApplicationDetails(int LDLAppID)
        {
            InitializeComponent();

            ctrlLocalDrivingLicenseApplicationInfo1.FillControl(LDLAppID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
