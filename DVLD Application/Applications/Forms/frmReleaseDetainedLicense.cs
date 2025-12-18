using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessLogicTier;
using System.Windows.Forms;

namespace DVLD_Application.Applications.Forms
{
    public partial class frmReleaseDetainedLicense : Form
    {
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int LicenseID)     // when enter due to the context menu in the detained licenses list
        {
            InitializeComponent();

            ctrlLocalLicenseInfoWithFilter1.FillWithLocalLicenseDataAndLock(LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlLocalLicenseInfoWithFilter1_OnLicenseDoesNotExist()
        {
            btnRelease.Enabled = linkLabel1.Enabled = groupBox1.Enabled = false;
            lblDLID.Text = lblDID.Text = lblFine.Text = lblTotalFees.Text = lblUserD.Text = lblDDate.Text = "[????]";

        }

        private void ctrlLocalLicenseInfoWithFilter1_OnLicenseExists(int LocalLicenseID)
        {
            linkLabel1.Enabled = true;

            btnRelease.Enabled = groupBox1.Enabled = false;

            lblDLID.Text = lblDID.Text = lblFine.Text = lblTotalFees.Text = lblUserD.Text = lblDDate.Text = "[????]";

            if (!ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.IsDetained)
            {
                MessageBox.Show("The License is not detained it may be released or has never been detained.", "Non-detained license", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // if reached here then the license is detained and ready for releasing

            btnRelease.Enabled = groupBox1.Enabled = true;

            clsLicenseDetention LicenseDetention = clsLicenseDetention.FindByDetainedLicenseID(LocalLicenseID);

            lblDLID.Text = LicenseDetention.LicenseID.ToString();
            lblDID.Text = LicenseDetention.DetainID.ToString();
            lblFine.Text = LicenseDetention.FineFees.ToString();
            lblTotalFees.Text = (LicenseDetention.FineFees + clsApplicationType.Find((int)enmApplicationType.ReleaseDetained).Fees).ToString();
            lblUserD.Text = LicenseDetention.DetainingUser.Username;
            lblDDate.Text = LicenseDetention.DetentionDate.ToString("dd/MMM/yyyy");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.ApplicantPerson);
            frm.ShowDialog();

            ctrlLocalLicenseInfoWithFilter1.FillDriverLicenseInfo();
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            lblAppFees.Text = clsApplicationType.Find((int)enmApplicationType.ReleaseDetained).Fees.ToString();

            lblRDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblUserR.Text = clsGlobalSettings.CurrentLoggedInUser.Username;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are You Sure That You Want To Release Detention of that Local License?", "Release License Detention Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.ReleaseDetention(out int ReleaseDetainedLicenseApplicationID, clsGlobalSettings.CurrentLoggedInUserID))
                {
                    ctrlLocalLicenseInfoWithFilter1.FillDriverLicenseInfo();        // toshow that is detained = true

                    btnRelease.Enabled = false;
                    ctrlLocalLicenseInfoWithFilter1.LockFilter();

                    lblAppID.Text = ReleaseDetainedLicenseApplicationID.ToString();

                    MessageBox.Show($"Detained Local Licnese Has Been Released Successfully.", "Successfull Detention Releasing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show($"Error Occurred in the System When Trying To Release the License, The Proccess Did NOT executed successfuly.\nThe Form Will Be Closed.", "Failed Detention Releasing", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
            }
        }
    }
}
