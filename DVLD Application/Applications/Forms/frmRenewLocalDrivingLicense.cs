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

namespace DVLD_Application.Applications.Forms
{
    public partial class frmRenewLocalDrivingLicense : Form
    {
        private clsLocalLicense _BackingLocalLicense = null;

        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlLocalLicenseInfoWithFilter1_OnLicenseExists(int LocalDrivingLicenseID)
        {
            _BackingLocalLicense = clsLocalLicense.Find(LocalDrivingLicenseID);

            txtNotes.Text = _BackingLocalLicense.Notes;
            lblLdlId.Text = _BackingLocalLicense.ID.ToString();
            lblLicenseClassFees.Text = clsLicenseClass.Find(_BackingLocalLicense.LicenseClass.ID).Fees.ToString();//get the new peice for the license
            lblExpDate.Text = DateTime.Today.AddYears(clsLicenseClass.Find(_BackingLocalLicense.LicenseClass.ID).ValidityLength).ToString("dd/MMM/yyyy");
            lblTotalFees.Text = (Convert.ToDouble(lblAppFees.Text) + Convert.ToDouble(lblLicenseClassFees.Text)).ToString();
            btnRenew.Enabled = txtNotes.Visible = label10.Visible = false;

            linkLabel1.Enabled = groupBox1.Enabled = true;

            if (!_BackingLocalLicense.IsActive)
            {
                MessageBox.Show($"The Local License With ID : [{LocalDrivingLicenseID}] Is NOT Active.\n\nLicense May Be Replaced For Damaged Or Lost Or Renewed.", "Not-Active Local License", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!_BackingLocalLicense.IsExpired())
            {
                MessageBox.Show($"The Local License With ID : [{LocalDrivingLicenseID}] Is NOT Expired Yet, It Will Be Expired On {_BackingLocalLicense.ExpirationDate.ToString("dd/MMM/yyyy")}.\n\nOnly Expired Licenses Can Be Renewed.", "Not-Expired Local License", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_BackingLocalLicense.IsDetained)
            {
                MessageBox.Show($"The Local License With ID : [{LocalDrivingLicenseID}] Is Detained.\n\nLicense Must be released first.", "Detained Local License", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            // if reached here then the local license is the active license for the person (last issued license for him AND the license is not expired) ..... so we can renew it

            btnRenew.Enabled = txtNotes.Visible = label10.Visible = true;
        }

        private void ctrlLocalLicenseInfoWithFilter1_OnLicenseDoesNotExist()
        {
            linkLabel1.Enabled = linkLabel2.Enabled = btnRenew.Enabled = txtNotes.Visible = label10.Visible = groupBox1.Enabled = false;

            lblLdlId.Text = lblTotalFees.Text = lblLicenseClassFees.Text = "[????]";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(_BackingLocalLicense.ApplicantPerson);
            frm.ShowDialog();

            ctrlLocalLicenseInfoWithFilter1.FillDriverLicenseInfo();
        }

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            lblIssue.Text = lblAppDate.Text = DateTime.Today.ToString("dd/MMM/yyyy");
            lblAppFees.Text = clsApplicationType.Find(Convert.ToInt32(enmApplicationType.Renew)).Fees.ToString();
            lblUser.Text = clsGlobalSettings.CurrentLoggedInUser.Username;
            
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            // the _BackingLocalLicense (this) Wil be the new license in other words, the renewd version

            if (MessageBox.Show($"Are You Sure That You Want To Renew that Local License?", "Renewing License Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _BackingLocalLicense.Notes = txtNotes.Text;


                if (_BackingLocalLicense.Renew(clsGlobalSettings.CurrentLoggedInUserID))        
                {
                    ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.IsActive = false;
                    ctrlLocalLicenseInfoWithFilter1.FillDriverLicenseInfo();

                    btnRenew.Enabled = txtNotes.Enabled = label10.Enabled = false;
                    linkLabel2.Enabled = true;

                    lblAppID.Text = _BackingLocalLicense.ApplicationID.ToString();
                    lblRLID.Text = _BackingLocalLicense.ID.ToString();


                    ctrlLocalLicenseInfoWithFilter1.LockFilter();
                    MessageBox.Show($"Local Licnese Has Been Renewed Successfully.\n\nNew License ID : [{_BackingLocalLicense.ID}]", "Successfull Renewing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show($"Error In Trying To Renew the License.\nThe Form Will Be Closed.", "Renewing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_BackingLocalLicense.ID);
            frm.ShowDialog();
        }
    }
}
