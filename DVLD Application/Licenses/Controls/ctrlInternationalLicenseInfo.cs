using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using BusinessLogicTier;
using System.Windows.Forms;

namespace DVLD_Application.Licenses.Controls
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void FillInternationalLicenseData(clsInternationalLicense InternationalLicense)
        {
            clsLocalLicense IssuedDueToLocalLicense = clsLocalLicense.Find(InternationalLicense.IssuedDueToLocalLicenseID);

            lblAppID.Text = InternationalLicense.ApplicationID.ToString();
            lblDateOfBirth.Text = IssuedDueToLocalLicense.ApplicantPerson.DateOfBirth.ToString("dd/MM/yyyy");
            lblNNo.Text = IssuedDueToLocalLicense.ApplicantPerson.NationalNumber;
            lblDriverID.Text = InternationalLicense.DriverID.ToString();
            lblName.Text = IssuedDueToLocalLicense.ApplicantPerson.FullName;
            lblIssueDate.Text = InternationalLicense.IssueDate.ToString("dd/MMM/yyyy");
            lblExpDate.Text = InternationalLicense.ExpirationDate.ToString("dd/MMM/yyyy");
            lblIsActive.Text = InternationalLicense.IsActive ? "Yes" : "No";
            lblLocalLicenseID.Text = InternationalLicense.IssuedDueToLocalLicenseID.ToString();
            lblGend.Text = IssuedDueToLocalLicense.ApplicantPerson.Gender ? "Female" : "Male";
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();

            if (IssuedDueToLocalLicense.ApplicantPerson.ImagePath == "")
            {
                pbPersonImage.Image = IssuedDueToLocalLicense.ApplicantPerson.Gender ? Properties.Resources.Female_512 : Properties.Resources.Male_512;
            }

            else
            {
                if (!File.Exists(IssuedDueToLocalLicense.ApplicantPerson.ImagePath))
                {
                    MessageBox.Show("Image Is Assigned To PErson, But it is not found in the system.", "Error in retrieving image", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                pbPersonImage.ImageLocation = IssuedDueToLocalLicense.ApplicantPerson.ImagePath;
            }
            
        }

    }
}
