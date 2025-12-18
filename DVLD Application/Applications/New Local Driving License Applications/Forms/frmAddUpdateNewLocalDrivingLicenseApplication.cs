using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessLogicTier;
using System.Windows.Forms;

namespace DVLD_Application
{
    public partial class frmAddUpdateNewLocalDrivingLicenseApplication : Form
    {
        private enmMode _FormMode = enmMode.AddNew;

        private clsNewLocalDrivingLicenseApplication _BackingNewLocalDrivingLicenseApplication;

        private void _SetFormForAddNewApplication() // When Add New 
        {
            comboBox1.SelectedIndex = 2;
            _BackingNewLocalDrivingLicenseApplication.LicenseClassID = 3;


            _BackingNewLocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            lblAppDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            _BackingNewLocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(clsApplicationType.Find((int)enmApplicationType.NewLocalDrivingLicense).Fees);
            lblApplicationFees.Text = _BackingNewLocalDrivingLicenseApplication.PaidFees.ToString();

            _BackingNewLocalDrivingLicenseApplication.CreatedByUserID = clsGlobalSettings.CurrentLoggedInUserID;
            lblUser.Text = _BackingNewLocalDrivingLicenseApplication.CreatedByUser.Username;    // here composition hepled us
        }

        private void _FillFormWithBackingData()     // When Update 
        {
            ctrlPersonInformationWithFindByFilter1.FillPersonDetailsControlAndFillFilter(clsPerson.Find(_BackingNewLocalDrivingLicenseApplication.ApplicantPersonID));

            lblAppID.Text = _BackingNewLocalDrivingLicenseApplication.NewLocalDrivingLicenseApplicationID.ToString();
            lblUser.Text = _BackingNewLocalDrivingLicenseApplication.CreatedByUser.Username;    // here composition hepled us
            lblAppDate.Text = _BackingNewLocalDrivingLicenseApplication.ApplicationDate.ToString("MM/dd/yyyy");
            lblApplicationFees.Text = _BackingNewLocalDrivingLicenseApplication.PaidFees.ToString();
            comboBox1.SelectedIndex = (int)_BackingNewLocalDrivingLicenseApplication.LicenseClassID - 1;

        }

        private void _LoadClassesToComboBox()
        {
            comboBox1.DataSource = clsLicenseClass.GetLicenseClassesList();

            comboBox1.DisplayMember = "classname";
        }

        public frmAddUpdateNewLocalDrivingLicenseApplication()      // NEW local driving license application
        {
            InitializeComponent();

            _BackingNewLocalDrivingLicenseApplication = new clsNewLocalDrivingLicenseApplication();
        }

        public frmAddUpdateNewLocalDrivingLicenseApplication(int NewLocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _FormMode = enmMode.Update;

            _BackingNewLocalDrivingLicenseApplication = clsNewLocalDrivingLicenseApplication.Find(NewLocalDrivingLicenseApplicationID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void ctrlPersonInformationWithFindByFilter1_OnPersonFound(BusinessLogicTier.clsPerson obj)
        {
            _BackingNewLocalDrivingLicenseApplication.ApplicantPersonID = obj.ID;

            ctrlPersonInformationWithFindByFilter1.FillPersonDetailsControl(obj);
        }

        private void ctrlPersonInformationWithFindByFilter1_OnPersonNotFound()
        {
            _BackingNewLocalDrivingLicenseApplication.ApplicantPersonID = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_BackingNewLocalDrivingLicenseApplication.ApplicantPersonID == -1)
            {
                e.Cancel = true;

                ctrlPersonInformationWithFindByFilter1.SetFocusToSearchBox();

                MessageBox.Show("Choose Person First");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Visible = (tabControl1.SelectedIndex == 1);
        }

        private void frmAddUpdateNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadClassesToComboBox();

            if (_FormMode == enmMode.Update)
            {
                _FillFormWithBackingData();

                label3.Text = "Update New Local Driving License Application";

                tabControl1.SelectedIndex = 1;
            }

            else
            {
                _SetFormForAddNewApplication();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _BackingNewLocalDrivingLicenseApplication.LicenseClassID = (byte)(comboBox1.SelectedIndex + 1);

            if (_BackingNewLocalDrivingLicenseApplication.LicenseClass.MinimumAllowedAge > _BackingNewLocalDrivingLicenseApplication.ApplicantPerson.Age)
            {
                MessageBox.Show($"The Person is Younger than the minimum allowed age for selected License : {_BackingNewLocalDrivingLicenseApplication.LicenseClass.Name}.\nMinimum Allowed Age For The Chosen License is {_BackingNewLocalDrivingLicenseApplication.LicenseClass.MinimumAllowedAge}\nAge Of Applicant : {_BackingNewLocalDrivingLicenseApplication.ApplicantPerson.Age}", "Under Age Applicant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_BackingNewLocalDrivingLicenseApplication.DoesApplicantHaveLDLOfSameLicenseClass())
            {
                MessageBox.Show("The Person Already Has an Issued License of the selected License Class.", "License Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int AppID = _BackingNewLocalDrivingLicenseApplication.DoesApplicantHaveNonCancelledNewLDLApplicationOfSameLicenseClass();

            if (AppID != -1)
            {
                MessageBox.Show("Choose Another License Class.\nThe Selected Person already Has an ACTIVE (NON Cancelled) Application For The Choosen license class\nApplication ID : " + AppID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_BackingNewLocalDrivingLicenseApplication.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Successful Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_FormMode == enmMode.AddNew)
                {
                    _FormMode = enmMode.Update;
                    lblAppID.Text = _BackingNewLocalDrivingLicenseApplication.NewLocalDrivingLicenseApplicationID.ToString();
                    label3.Text = "Update New Local Driving License Application";
                    ctrlPersonInformationWithFindByFilter1.DisableFilter();
                }
            }

            else
            {
                MessageBox.Show("Data is NOT saved.", "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddUpdateNewLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonInformationWithFindByFilter1.SetFocusToSearchBox();
        }
    }
}
