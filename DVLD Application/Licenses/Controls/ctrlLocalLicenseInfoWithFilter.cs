using System;
using System.Windows.Forms;
using BusinessLogicTier;

namespace DVLD_Application.Licenses.Controls
{
    public partial class ctrlLocalLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseExists;
        public event Action OnLicenseDoesNotExist;

        public clsLocalLicense SelectedLocalLicense
        {
            get
            {
                return _SelectedLocalLicense;
            }
        }
        private clsLocalLicense _SelectedLocalLicense;

        public ctrlLocalLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void LockFilter()
        {
            groupBox1.Enabled = false;
        }

        public void FillDriverLicenseInfo()       // if entered here then there is absolutely a local driving license exist
        {
            // Handles the case of editing the person through the show Person license history
            ctrlDriverLicenseInfo1.FillWithLicenseInfo(_SelectedLocalLicense);
        }

        public void FillWithLocalLicenseDataAndLock(int LocalLicenseID)
        {
            textBox1.Text = LocalLicenseID.ToString();
            _SelectedLocalLicense = clsLocalLicense.Find(LocalLicenseID);
            FillDriverLicenseInfo();
            LockFilter();

            OnLicenseExists?.Invoke(LocalLicenseID);
        }

        private void btnFindLicenseWithID_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                ctrlDriverLicenseInfo1.FillWithDefaultValues();
                _SelectedLocalLicense = null;
                OnLicenseDoesNotExist?.Invoke();

                MessageBox.Show("Enter Local License ID To Search For It.", "No Entered License ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLocalLicense.DoesLicenseWithIDExist(Convert.ToInt32(textBox1.Text)))
            {
                _SelectedLocalLicense = clsLocalLicense.Find(Convert.ToInt32(textBox1.Text));
                ctrlDriverLicenseInfo1.FillWithLicenseInfo(_SelectedLocalLicense);
                OnLicenseExists?.Invoke(Convert.ToInt32(textBox1.Text));
            }

            else
            {
                ctrlDriverLicenseInfo1.FillWithDefaultValues();
                _SelectedLocalLicense = null;
                OnLicenseDoesNotExist?.Invoke();

                MessageBox.Show($"The Local License With ID : [{textBox1.Text}] Does NOT Exist On the System.", "Non-Existant Local Driving License ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlFindLicenseWithFilter_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));

            if (e.KeyChar == (char)13)      // enter key
            {
                btnFindLicenseWithID.PerformClick();
            }
        }

    }
}
