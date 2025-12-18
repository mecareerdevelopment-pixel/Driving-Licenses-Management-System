using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicTier;

namespace DVLD_Application.Applications.Forms
{
    public partial class frmReplacementForLostOrDamagedLicense : Form
    {
        private int _BackingLocalLicenseID;     // if the license is replaced successfully ....... this field beocmes the new replacing local license id

        public frmReplacementForLostOrDamagedLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReplacementForLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            lblUser.Text = clsGlobalSettings.CurrentLoggedInUser.Username;

            lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");

            lblAppFees.Text = "[????]";
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamaged.Checked)
            {
                label3.Text = "Replacement For Damaged License";

                lblAppFees.Text = clsApplicationType.Find(Convert.ToInt32(enmApplicationType.RepDamaged)).Fees.ToString();
            }
        }
        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLost.Checked)
            {
                label3.Text = "Replacement For Lost License";

                lblAppFees.Text = clsApplicationType.Find(Convert.ToInt32(enmApplicationType.RepLost)).Fees.ToString();
            }
        }

        private void ctrlLocalLicenseInfoWithFilter1_OnLicenseDoesNotExist()
        {
            linkLabel1.Enabled = linkLabel2.Enabled = btnIssueReplacement.Enabled = groupBox2.Enabled = groupBox1.Enabled = false;
            lblLdlId.Text = "[????]";
        }

        private void ctrlLocalLicenseInfoWithFilter1_OnLicenseExists(int LocalLicenseID)
        {
            _BackingLocalLicenseID = LocalLicenseID;

            lblLdlId.Text = LocalLicenseID.ToString();

            linkLabel1.Enabled = true;

            btnIssueReplacement.Enabled = groupBox2.Enabled = groupBox1.Enabled = false;

            if (!ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.IsActive)
            {
                MessageBox.Show($"The Local License With ID : [{_BackingLocalLicenseID}] Is NOT Active, It May Be Replaced For Damaged Or Lost Or Renewed.\n\nOnly Active Licenses Can be Replaced.", "Inactive Local License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.IsExpired())
            {
                MessageBox.Show($"The Local License With ID : [{_BackingLocalLicenseID}] Is Expired Since [{ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.ExpirationDate.ToString("dd/MMM/yyyy")}], Renew it first.", "Not-Expired Local License", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.IsDetained)
            {
                MessageBox.Show($"The Local License With ID : [{_BackingLocalLicenseID}] Is Detained.\n\nLicense Must be released first.", "Detained Local License", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // if reached here then the license can be replaced
            btnIssueReplacement.Enabled = groupBox2.Enabled = groupBox1.Enabled = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (!rbDamaged.Checked && !rbLost.Checked)
            {
                MessageBox.Show("Choose The Replacement Purpose First From the \"Replacement For Section\"", "Missing Replacement Purpose", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are You Sure That You Want To Issue Replacement for that Local License?", "Replacing License Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsLocalLicense NewLocalLicense = ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.IssueReplacement(clsGlobalSettings.CurrentLoggedInUserID, rbLost.Checked); ;

                if (NewLocalLicense != null)
                {
                    ctrlLocalLicenseInfoWithFilter1.FillDriverLicenseInfo();

                    btnIssueReplacement.Enabled = groupBox1.Enabled = false;

                    linkLabel2.Enabled = true;
                    _BackingLocalLicenseID = NewLocalLicense.ID;

                    lblAppID.Text = NewLocalLicense.ApplicationID.ToString();
                    lblRLID.Text = NewLocalLicense.ID.ToString();

                    ctrlLocalLicenseInfoWithFilter1.LockFilter();
                    MessageBox.Show($"Local Licnese Has Been Replaced Successfully.\n\nNew Replacing License ID : [{NewLocalLicense.ID}]", "Successful Replacement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show($"Error In Trying To Issue License Replacement the License.\nThe Form Will Be Closed.", "Replacing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.ApplicantPerson);
            frm.ShowDialog();

            ctrlLocalLicenseInfoWithFilter1.FillDriverLicenseInfo();  // always the person is up to date
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_BackingLocalLicenseID);
            frm.ShowDialog();
        }

    }
}
