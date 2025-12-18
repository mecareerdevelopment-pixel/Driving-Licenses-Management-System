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
    public partial class frmIssueNewDrivingLicenseFirstTime : Form
    {
        private clsLocalLicense _BackingNewLocalLicense = new clsLocalLicense();

        public frmIssueNewDrivingLicenseFirstTime(int LDLAppID)
        {
            InitializeComponent();

            ctrlLocalDrivingLicenseApplicationInfo1.FillControl(LDLAppID);

            _FillBackingNewLocalLicenseData(clsNewLocalDrivingLicenseApplication.Find(LDLAppID));
        }

        private void _FillBackingNewLocalLicenseData(clsNewLocalDrivingLicenseApplication LDLApp)
        {
            _BackingNewLocalLicense.ApplicationID = LDLApp.ApplicationID;
            _BackingNewLocalLicense.IssuedByUserID = clsGlobalSettings.CurrentLoggedInUserID;

            _BackingNewLocalLicense.IsActive = true;        // the new issued license is active initially by default
            _BackingNewLocalLicense.IssueReason = enmLocalLicenseIssueReason.FirstTime;

            _BackingNewLocalLicense.LicenseClassID = LDLApp.LicenseClassID;
            _BackingNewLocalLicense.PaidFees = LDLApp.LicenseClass.Fees;

            label3.Text = _BackingNewLocalLicense.PaidFees.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _BackingNewLocalLicense.Notes = textBox1.Text.Trim();

            if (_BackingNewLocalLicense.IssueForFirstTime())
            {
                MessageBox.Show($"New Local Driving License Has Been Issued Successfully.\nLicense ID : {_BackingNewLocalLicense.ID}", "Successful License Issuing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show($"System Error while trying to add the license to the database.", "Failing License Issuing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            button2.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
