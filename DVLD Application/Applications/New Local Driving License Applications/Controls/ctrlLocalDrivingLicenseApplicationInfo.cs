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
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {
        private clsNewLocalDrivingLicenseApplication LDLApp;

        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ctrlLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
        }

        public void FillControl(int LDLAppID)
        {
            LDLApp = clsNewLocalDrivingLicenseApplication.Find(LDLAppID);

            ctrlApplicationBasicInfo1.FillApplicationBasicInfo(LDLApp.ApplicationID);

            lblID.Text = LDLAppID.ToString();
            lblClass.Text = clsLicenseClass.Find(LDLApp.LicenseClassID).Name;
            lblPassed.Text = LDLApp.GetNumberOfPassedTests().ToString() + "/3";

            linkLabel1.Enabled = clsLocalLicense.GetLicenseIDWhichIssuedDueToApplicationID(LDLApp.ApplicationID) != -1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(clsLocalLicense.GetLicenseIDWhichIssuedDueToApplicationID(LDLApp.ApplicationID));

            frm.ShowDialog();
        }
    }
}
