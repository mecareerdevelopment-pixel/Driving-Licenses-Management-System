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
    public partial class ctrlScheduleTest : UserControl
    {
        private clsTestAppointment _BackingTestAppointment = new clsTestAppointment();
        private clsRetakeTestApplication _BackingRetakeTestApplication;
        private clsNewLocalDrivingLicenseApplication _LDLApp;       // l.d. license application realted with the appointment

        public ctrlScheduleTest()
        {
            InitializeComponent();

            dateTimePicker1.MinDate = DateTime.Today;
        }

        private void _FillMainTestAppointmentData()
        {
            lblAppID.Text = _LDLApp.NewLocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = _LDLApp.LicenseClass.Name;
            lblName.Text = _LDLApp.ApplicantPerson.FullName;
            lblTrial.Text = clsTestAppointment.GetPrevTestingTrialsCount(_BackingTestAppointment.LocalDrivingLicenseApplicationID, _BackingTestAppointment.TestType).ToString();
            lblFees.Text = _BackingTestAppointment.Fees.ToString();
        }

        private void _FillBackingTestAppointment(int LDLAppID, enmTestTypes TestType)
        {
            _BackingTestAppointment.LocalDrivingLicenseApplicationID = LDLAppID;
            _BackingTestAppointment.TestType = TestType;
            _BackingTestAppointment.Fees = clsTestType.Find((int)TestType).Fees;
            _BackingTestAppointment.CreatedByUserID = clsGlobalSettings.CurrentLoggedInUserID;
        }

        public void FillScheduleTestWithTestAppointmentData(int LDLAppID, enmTestTypes TestType)
        {
            groupBox1.Text = "Schedule " + TestType.ToString() + " Test";
            pictureBox1.Image = _BackingTestAppointment.TestType == enmTestTypes.Vision ? Properties.Resources.Vision_Test_32 : (_BackingTestAppointment.TestType == enmTestTypes.Written ? Properties.Resources.Written_Test_32_Sechdule : Properties.Resources.Street_Test_32);

            _FillBackingTestAppointment(LDLAppID, TestType);

            _LDLApp = clsNewLocalDrivingLicenseApplication.Find(_BackingTestAppointment.LocalDrivingLicenseApplicationID);


            if (clsTestAppointment.IsTherePreviousTestAppointment(_BackingTestAppointment.LocalDrivingLicenseApplicationID, _BackingTestAppointment.TestType))
            {
                label1.Text = "Schedule Retake " + _BackingTestAppointment.TestType.ToString() + " Test";

                groupBox2.Enabled = true;
                _BackingRetakeTestApplication = new clsRetakeTestApplication(_LDLApp.ApplicantPersonID, clsGlobalSettings.CurrentLoggedInUserID);
                lblFees2.Text = clsApplicationType.Find((int)enmApplicationType.RetakeTest).Fees.ToString();

                lblTotalFees.Text = (_BackingTestAppointment.Fees + clsApplicationType.Find((int)enmApplicationType.RetakeTest).Fees).ToString();
            }

            else
            {
                label1.Text = $"Schedule {_BackingTestAppointment.TestType.ToString()} Test";

                lblTotalFees.Text = _BackingTestAppointment.Fees.ToString();
            }

            _FillMainTestAppointmentData();
        }

        public void FillScheduleTestWithTestAppointmentData(clsTestAppointment TestAppointment) // when EDIT or UPDATE
        {
            _BackingTestAppointment = TestAppointment;
            groupBox1.Text = "Schedule " + _BackingTestAppointment.TestType.ToString() + " Test";
            pictureBox1.Image = _BackingTestAppointment.TestType == enmTestTypes.Vision ? Properties.Resources.Vision_Test_32 : (_BackingTestAppointment.TestType == enmTestTypes.Written ? Properties.Resources.Written_Test_32_Sechdule : Properties.Resources.Street_Test_32);


            if (_BackingTestAppointment.IsLocked)       // so the opening is to view only
            {
                dateTimePicker1.MinDate = _BackingTestAppointment.Date;

                label11.Visible = true;
                dateTimePicker1.Enabled = button1.Enabled = false;

                MessageBox.Show("The Test for that appointment was taken and result was determined\n It will be opened but you can only view it", "Can not edit the Appointment Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            _LDLApp = clsNewLocalDrivingLicenseApplication.Find(_BackingTestAppointment.LocalDrivingLicenseApplicationID);

            lblAppID.Text = _LDLApp.NewLocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = _LDLApp.LicenseClass.Name;
            lblName.Text = _LDLApp.ApplicantPerson.FullName;
            lblTrial.Text = clsTestAppointment.GetPrevTestingTrialsCount(_BackingTestAppointment.LocalDrivingLicenseApplicationID, _BackingTestAppointment.TestType).ToString();
            lblFees.Text = _BackingTestAppointment.Fees.ToString();

            if (_BackingTestAppointment.Date < dateTimePicker1.MinDate)
            {
                MessageBox.Show($"Date Of That Appointment Went out and it will be automatically edited to today.\nIts old date is {_BackingTestAppointment.Date.ToString("MM/dd/yyyy")} and it will be {DateTime.Today.ToString("MM/dd/yyyy")} or you can choose another date in future.\n\nPRESS SAVE IF YOU WANT TO COMMIT THAT CHANGE.", "Appointment Date Change", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _BackingTestAppointment.Date = DateTime.Today;
            }

            dateTimePicker1.Value = _BackingTestAppointment.Date;




            if (_BackingTestAppointment.RetakeTestApplicationID == -1)
            {
                label1.Text = $"Schedule {_BackingTestAppointment.TestType.ToString()} Test";

                lblTotalFees.Text = _BackingTestAppointment.Fees.ToString();
            }

            else
            {
                label1.Text = "Schedule Retake " + _BackingTestAppointment.TestType.ToString() + " Test";

                groupBox2.Enabled = true;

                lblRTAppID.Text = _BackingTestAppointment.RetakeTestApplicationID.ToString();

                double PaidFeesOfRetakeTestApplicationAtTimeOfApplying = clsRetakeTestApplication.Find(_BackingTestAppointment.RetakeTestApplicationID).RetakeTestApplication.PaidFees;
                lblFees2.Text = PaidFeesOfRetakeTestApplicationAtTimeOfApplying.ToString();
                lblTotalFees.Text = (_BackingTestAppointment.Fees + PaidFeesOfRetakeTestApplicationAtTimeOfApplying).ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _BackingTestAppointment.Date = dateTimePicker1.Value;

            if (_BackingRetakeTestApplication == null)
            {
                if (_BackingTestAppointment.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Successful Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error While Saving", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (_BackingRetakeTestApplication.Save())
            {
                _BackingTestAppointment.RetakeTestApplicationID = _BackingRetakeTestApplication.RetakeTestApplication.ApplicationID;
                lblRTAppID.Text = _BackingTestAppointment.RetakeTestApplicationID.ToString();

                if (_BackingTestAppointment.Save())
                {
                    _BackingRetakeTestApplication.SetCompleted();
                    MessageBox.Show("Data Saved Successfully.", "Successful Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error While Saving", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Error While Saving", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
