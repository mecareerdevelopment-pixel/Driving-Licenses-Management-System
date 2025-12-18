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
    public partial class frmSetTestResult : Form
    {
        public frmSetTestResult(clsTestAppointment TestAppointment)
        {
            InitializeComponent();

            ctrlSetTestResult1.FillSetTestResultUserControlWithTestAppointmentData(TestAppointment);
        }

        private void ctrlSetTestResult1_SavingTrialFinished()
        {
            this.Close();
        }

        private void ctrlSetTestResult1_OnSavingSuccessfully(int AppointmentIDToBeLocked)
        {
            clsTestAppointment.LockAppointment(AppointmentIDToBeLocked);
        }
    }
}
