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
    public partial class frmAddUpdateTestAppointment : Form
    {
        public frmAddUpdateTestAppointment(int LDLAppID, enmTestTypes TestType)        // Add New
        {
            InitializeComponent();

            ctrlScheduleTest1.FillScheduleTestWithTestAppointmentData(LDLAppID, TestType);
        }

        public frmAddUpdateTestAppointment(clsTestAppointment TestAppointment)
        {
            // When EDIT the test appointment

            InitializeComponent();

            ctrlScheduleTest1.FillScheduleTestWithTestAppointmentData(TestAppointment);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
