using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessLogicTier;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace DVLD_Application
{
    public partial class ctrlSetTestResult : UserControl
    {
        public event Action SavingTrialFinished;

        public event Action<int> OnSavingSuccessfully;

        private clsTest _BackingTest;
        private clsTestAppointment _BackingTestAppointment;

        public ctrlSetTestResult()
        {
            InitializeComponent();
        }

        private void _FillTestAppointmentData()
        {
            groupBox1.Text = $"{_BackingTestAppointment.TestType} Test Result";
            label1.Text = "Scheduled Test";
            clsNewLocalDrivingLicenseApplication _LDLApp = clsNewLocalDrivingLicenseApplication.Find(_BackingTestAppointment.LocalDrivingLicenseApplicationID);

            lblAppID.Text = _LDLApp.NewLocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = _LDLApp.LicenseClass.Name;
            lblName.Text = _LDLApp.ApplicantPerson.FullName;
            lblTrial.Text = clsTestAppointment.GetPrevTestingTrialsCount(_BackingTestAppointment.LocalDrivingLicenseApplicationID, _BackingTestAppointment.TestType).ToString();
            lblDate.Text = _BackingTestAppointment.Date.ToString("dd/MMM/yyyy");
            lblFees.Text = _BackingTestAppointment.Fees.ToString();

            pictureBox1.Image = (_BackingTestAppointment.TestType == enmTestTypes.Vision ? Properties.Resources.Vision_Test_32 : (_BackingTestAppointment.TestType == enmTestTypes.Written ? Properties.Resources.Written_Test_32_Sechdule : Properties.Resources.Street_Test_32));
        }

        private void _LoadBackingTestDataToTheControl()
        {
            _BackingTest = clsTest.FindByTestAppointmentID(_BackingTestAppointment.ID);
            radioButton1.Enabled = radioButton2.Enabled = false;

            radioButton1.Checked = _BackingTest.Result;
            radioButton2.Checked = !_BackingTest.Result;

            lblTestID.Text = _BackingTest.TestID.ToString();

            textBox1.Text = _BackingTest.Notes;

            label11.Visible = true;
        }

        public void FillSetTestResultUserControlWithTestAppointmentData(clsTestAppointment TestAppointment)
        {
            _BackingTestAppointment = TestAppointment;

            _FillTestAppointmentData();

            if (TestAppointment.IsLocked)       // Edit Notes (edit test record) UPDATE
            {
                _LoadBackingTestDataToTheControl();
            }

            else
            {
                _BackingTest = new clsTest();

                _BackingTest.TestAppointmentID = _BackingTestAppointment.ID;
                _BackingTest.CreatedByUserID = clsGlobalSettings.CurrentLoggedInUserID;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please, Set The Test Result (Pass / Fail).");
                return;
            }

            if (MessageBox.Show("Are You Sure You Want To Save The Test Result?\n\nThe Result (Pass / Fail) Can NOT be changed later once You save, Only Notes Can Be Updated.", "Saving Test Result Confirming", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _BackingTest.Result = radioButton1.Checked;
                _BackingTest.Notes = (string.IsNullOrWhiteSpace(textBox1.Text) ? "" : textBox1.Text);

                if (_BackingTest.Save())
                {
                    lblTestID.Text = _BackingTest.TestID.ToString();

                    MessageBox.Show("Data (Test Result & Test Notes) Has Been Saved Successfully.", "Successful Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (!_BackingTestAppointment.IsLocked)
                    {
                        OnSavingSuccessfully?.Invoke(_BackingTestAppointment.ID);
                    }
                }

                else
                {
                    MessageBox.Show("Error Occurred While Trying To Save Date.", "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("The Test Result Has Not Been Saved.", "Saving is cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            SavingTrialFinished?.Invoke();

        }

    }
}
