using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicTier;

namespace DVLD_Application
{
    public partial class frmShowLicenseInfo : Form
    {
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();

            ctrlDriverLicenseInfo1.FillWithLicenseInfo(clsLocalLicense.Find(LicenseID));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
