using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicTier;

namespace DVLD_Application
{
    public partial class frmManageTestAppointments : Form
    {
        private int _LDLAppID;
        private enmTestTypes _TestType;

        public frmManageTestAppointments(int LDLAppID, enmTestTypes TestType)
        {
            InitializeComponent();

            _LDLAppID = LDLAppID;
            _TestType = TestType;
            this.Text = $"Manage {_TestType} Test Appointments";

            label1.Text = $"{_TestType} Test Appointments";
            pictureBox1.Image = (_TestType == enmTestTypes.Vision ? Properties.Resources.Vision_Test_32 : (_TestType == enmTestTypes.Written ? Properties.Resources.Written_Test_32_Sechdule : Properties.Resources.Street_Test_32));
        }

        private void _RetrieveAppointmentsData()
        {
            dataGridView1.DataSource = clsTestAppointment.GetAllAppointmentsForLDLAndTestType(_LDLAppID, _TestType).DefaultView;
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.Columns["Appointment Date"].Width = 100;
            dataGridView1.Columns["paid fees"].Width = 100;
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplication1.FillControl(_LDLAppID);

            _RetrieveAppointmentsData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.IsThereActiveTestAppointment(_LDLAppID, _TestType, out int TestAppointmentID))
            {
                MessageBox.Show($"Can NOT reserve another test appointment while there is active (Unlocked) test appointment for the same test type.\nExisting Test Appointment is with ID : {TestAppointmentID}", "Can note reserve another appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (clsNewLocalDrivingLicenseApplication.DoesLocalDrivingLicenseApplicationPassThatTestType(_LDLAppID, _TestType))
            {
                MessageBox.Show($"The Applicant Person Already Passed This Test Successfully.\nApplicant Can Only Retake Tests Which He Failed In Them", "Can NOT Retake Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            frmAddUpdateTestAppointment frm = new frmAddUpdateTestAppointment(_LDLAppID, _TestType);

            frm.ShowDialog();

            _RetrieveAppointmentsData();
        }

        private void editAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateTestAppointment frm = new frmAddUpdateTestAppointment(clsTestAppointment.Find((int)dataGridView1.CurrentRow.Cells[0].Value));

            frm.ShowDialog();

            _RetrieveAppointmentsData();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmSetTestResult(clsTestAppointment.Find((int)dataGridView1.CurrentRow.Cells[0].Value));

            frm.ShowDialog();

            frmTestAppointments_Load(null, null);
        }
    }
}
