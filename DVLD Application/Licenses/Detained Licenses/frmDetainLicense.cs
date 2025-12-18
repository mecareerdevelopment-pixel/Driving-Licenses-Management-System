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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD_Application.Licenses.Forms
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Today.ToString("dd/MMM/yyyy");
            lblUser.Text = clsGlobalSettings.CurrentLoggedInUser.Username;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && textBox1.Text.Contains("."))));
        }

        private void ctrlLocalLicenseInfoWithFilter1_OnLicenseDoesNotExist()
        {
            linkLabel1.Enabled = btnDetain.Enabled = groupBox1.Enabled = false;

            lblLID.Text = "[????]";
            textBox1.Text = "";
        }

        private void ctrlLocalLicenseInfoWithFilter1_OnLicenseExists(int ExistantLocalLicenseID)
        {
            textBox1.Text = "";

            linkLabel1.Enabled = true;

            btnDetain.Enabled = groupBox1.Enabled = false;

            lblLID.Text = ExistantLocalLicenseID.ToString();

            if (!ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.IsActive)
            {
                MessageBox.Show($"The License is Inactive.\nOnly the active licenses can be detained\n\nGet the last active license for the user form license history.", "Detention Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.IsDetained)
            {
                MessageBox.Show($"The License is already detained.", "Detention Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // once reaches here it menas that the local license eligable for detention
            btnDetain.Enabled = groupBox1.Enabled = true;
            textBox1.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.ApplicantPerson);
            frm.ShowDialog();

            ctrlLocalLicenseInfoWithFilter1.FillDriverLicenseInfo();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are You Sure That You Want To Detain that Local License?", "Detaining License Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int DetainID = ctrlLocalLicenseInfoWithFilter1.SelectedLocalLicense.Detain(Convert.ToSingle(textBox1.Text), clsGlobalSettings.CurrentLoggedInUserID);

                if (DetainID != -1)
                {
                    ctrlLocalLicenseInfoWithFilter1.FillDriverLicenseInfo();        // to refresh the is detained info
                    ctrlLocalLicenseInfoWithFilter1.LockFilter();

                    btnDetain.Enabled = textBox1.Enabled = false;

                    lblDID.Text = DetainID.ToString();

                    MessageBox.Show($"Local Licnese Has Been Detained Successfully.\n\nDetain Operation ID : [{DetainID}]", "Successful Detaining", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show($"Error Happened in the system when Trying To Detain the License.\nThe Form Will Be Closed.", "Failed Detaining", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Enter The Applied Fine On The License.");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(textBox1, null);
            }
        }
    }
}
