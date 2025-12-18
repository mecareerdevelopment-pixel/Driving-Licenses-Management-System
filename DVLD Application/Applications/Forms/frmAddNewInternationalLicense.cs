using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessLogicTier;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DVLD_Application.Licenses.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Application.Applications.Forms
{
    public partial class frmAddNewInternationalLicense : Form
    {
        private clsInternationalLicense _BackingInternationalLicense;

        private int _BackingInternationalLicenseID;

        private clsLocalLicense _BackingLocalLicense;

        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are You Sure That You Want To Issue New International License Regarding This Local License ?", "Issuing International License Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _BackingInternationalLicense = new clsInternationalLicense();
                _BackingInternationalLicense.CreatedByUserID = clsGlobalSettings.CurrentLoggedInUserID;

                _BackingInternationalLicense.DriverID = _BackingLocalLicense.DriverID;
                _BackingInternationalLicense.IssuedDueToLocalLicenseID = _BackingLocalLicense.ID;

                if (_BackingInternationalLicense.IssueNewInternationalLicense())
                {
                    btnIssue.Enabled = false;

                    lblIlAppID.Text = _BackingInternationalLicense.ApplicationID.ToString();
                    lblIlID.Text = _BackingInternationalLicense.InternationalLicenseID.ToString();
                    ctrlLocalLicenseInfoWithFilter1.LockFilter();
                    groupBox2.Enabled = true;

                    linkLabel2.Enabled = true;
                    _BackingInternationalLicenseID = _BackingInternationalLicense.InternationalLicenseID;

                    MessageBox.Show($"A New International Driving License Has Been Issued Regarding That Local License.\n\nNew International License ID : {_BackingInternationalLicense.InternationalLicenseID}", "Successfull Issuing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show($"Error In Trying To Save the Internatinal License.\nThe Form Will Be Closed.", "Issuing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(_BackingLocalLicense.ApplicantPerson);

            frm.ShowDialog();

            ctrlLocalLicenseInfoWithFilter1.FillDriverLicenseInfo();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_BackingInternationalLicenseID);
            frm.ShowDialog();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            lblIssue.Text = lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblExpDate.Text = DateTime.Now.AddYears(1).ToString("dd/MMM/yyyy");
            lblFees.Text = clsApplicationType.Find(Convert.ToInt32(enmApplicationType.NewInternationalLicense)).Fees.ToString();
            lblUser.Text = clsGlobalSettings.CurrentLoggedInUser.Username;
        }

        private void ctrlLocalLicenseInfoWithFilter1_OnLicenseDoesNotExist()
        {
            linkLabel1.Enabled = linkLabel2.Enabled = btnIssue.Enabled = false;
            lblLdlId.Text = "[????]";
        }

        private void ctrlLocalLicenseInfoWithFilter1_OnLicenseExists(int _BackingLocalLicenseID)
        {
            _BackingLocalLicense = clsLocalLicense.Find(_BackingLocalLicenseID);

            lblLdlId.Text = _BackingLocalLicenseID.ToString();

            linkLabel1.Enabled = true;

            linkLabel2.Enabled = btnIssue.Enabled = false;


            if (_BackingLocalLicense.LicenseClass.ID != 3)
            {
                MessageBox.Show($"The Local License With ID : [{_BackingLocalLicense.ID}] Is Not From [{clsLicenseClass.Find(3).Name}].\n\nIn Orer To Issue International License, A Class 3 License Should Be Related To It.", "Irrelevant Class", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_BackingLocalLicense.IsExpired())
            {
                MessageBox.Show($"The Local License With ID : [{_BackingLocalLicense.ID}] Is Expired Since : [{_BackingLocalLicense.ExpirationDate.ToString("dd/MMM/yyyy")}]\n\nIn Orer To Issue International License, Person Have to have an Active Non-Expired Local License.\n\nRenew It And Return.", "Expired License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_BackingLocalLicense.IsActive)
            {
                MessageBox.Show($"The Local License With ID : [{_BackingLocalLicense.ID}] Is Inactive", "InActive License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ActiveNonExpiredInternationalLicenseID = clsInternationalLicense.GetActiveAndNonExpiredInternationalLicenseID(_BackingLocalLicense.DriverID);
            if (ActiveNonExpiredInternationalLicenseID != -1)     // means that there is an active and non-expired international license
            {
                linkLabel2.Enabled = true;
                _BackingInternationalLicenseID = ActiveNonExpiredInternationalLicenseID;

                MessageBox.Show($"There is an Active Non-Expired International License With ID : [{ActiveNonExpiredInternationalLicenseID}] Issued Due To The Entered Local Driving License ID : [{_BackingLocalLicense.ID}]\nCan NOT have another international license Issued due to the local license.\n\nTo Show The International License Reagarding The Entered Local License Click the link below", "Active Non-Expired International License Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_BackingLocalLicense.IsDetained)
            {
                MessageBox.Show($"The Local License With ID : [{_BackingLocalLicense.ID}] Is Detained\nRelease It First", "Detained License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            // if reached here then the local license is eligable to be attached with international driving license
            btnIssue.Enabled = true;
        }
    }
}
