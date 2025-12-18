using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicTier;

namespace DVLD_Application
{
    public partial class ctrlLocalLicenseInfo : UserControl
    {


        public ctrlLocalLicenseInfo()
        {
            InitializeComponent();
        }


        public void FillWithLicenseInfo(clsLocalLicense License)
        {
            clsPerson ApplicantPerson = License.ApplicantPerson;

            lblClass.Text = License.LicenseClass.Name;
            lblDateOfBirth.Text = ApplicantPerson.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDriverID.Text = License.DriverID.ToString();
            lblExpDate.Text = License.ExpirationDate.ToString("dd/MMM/yyyy");
            lblGend.Text = ApplicantPerson.Gender ? "Female" : "Male";

            if (ApplicantPerson.ImagePath == "")
            {
                pbPersonImage.Image = lblGend.Text == "Female" ? Properties.Resources.Female_512 : Properties.Resources.Male_512;
            }

            else
            {
                pbPersonImage.ImageLocation = ApplicantPerson.ImagePath;
            }

            lblIsActive.Text = License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = License.IsDetained ? "Yes" : "No";

            lblIssueDate.Text = License.IssuingDate.ToString("dd/MMM/yyyy");

            lblIssueReason.Text = License.IssueReasonString;

            lblLicenseID.Text = License.ID.ToString();

            lblName.Text = ApplicantPerson.FullName;
            lblNNo.Text = ApplicantPerson.NationalNumber;
            lblNotes.Text = (License.Notes == "" ? "No Notes." : License.Notes);
        }

        public void FillWithDefaultValues()
        {
            lblClass.Text = lblDateOfBirth.Text = lblDriverID.Text = lblExpDate.Text = lblGend.Text = lblIsActive.Text = lblIsDetained.Text = lblIssueDate.Text = lblIssueReason.Text = lblLicenseID.Text = lblName.Text = lblNNo.Text = lblNotes.Text = "....";
            pbPersonImage.ImageLocation = null;
        }

    }
}
