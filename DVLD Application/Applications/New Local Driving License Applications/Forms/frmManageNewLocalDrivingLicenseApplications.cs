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

namespace DVLD_Application
{
    public partial class frmManageNewLocalDrivingLicenseApplications : Form
    {
        public frmManageNewLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void _FillDataGridView()
        {
            dataGridView1.DataSource = clsNewLocalDrivingLicenseApplication.GetAll().DefaultView;
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
            ((DataView)dataGridView1.DataSource).Table.Columns["Status"].ReadOnly = false;

            dataGridView1.Columns["Full Name"].Width = 300;
            dataGridView1.Columns["Driving Class"].Width = 250;
            dataGridView1.Columns["Application Date"].Width = 150;
            dataGridView1.Columns["status"].Width = 75;
            dataGridView1.Columns["Passed tests"].Width = 100;
            dataGridView1.Columns["L.D.l. AppID"].Width = 100;
        }

        private void _RestoreDefaultView()
        {
            comboBox1.Text = "None";

            _FillDataGridView();
        }

        private void frmManageNewLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RestoreDefaultView();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FillDataGridView();
            txtFilteringCriteria.Text = "";
            txtFilteringCriteria.Visible = !(comboBox1.Text == "Status" || comboBox1.Text == "None");

            if (comboBox1.Text == "Status")
            {
                comboBox2.Text = "All";
                comboBox2.Visible = true;
            }

            else
            {
                comboBox2.Visible = false; ;
            }
        }

        private void txtFilteringCriteria_TextChanged(object sender, EventArgs e)
        {
            if (txtFilteringCriteria.Text.Trim() == "")
            {
                ((DataView)(dataGridView1.DataSource)).RowFilter = "";
                lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();

                return;
            }

            switch (comboBox1.Text)
            {
                case "Full Name":
                    ((DataView)(dataGridView1.DataSource)).RowFilter = $"[Full Name] like '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "National No.":
                    ((DataView)(dataGridView1.DataSource)).RowFilter = $"[National No.] like '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "L.D.L. Application ID":
                    ((DataView)(dataGridView1.DataSource)).RowFilter = $"[L.D.L. AppID] = {txtFilteringCriteria.Text}";
                    break;

                default:
                    break;
            }

            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void txtFilteringCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "L.D.L. Application ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "All":
                    ((DataView)(dataGridView1.DataSource)).RowFilter = "";
                    break;

                default:
                    ((DataView)(dataGridView1.DataSource)).RowFilter = $"Status = '{comboBox2.Text}'";
                    break;
            }

            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewLocalDrivingLicenseApplication frm = new frmAddUpdateNewLocalDrivingLicenseApplication();

            frm.ShowDialog();

            _RestoreDefaultView();
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Cancel This Application ?\nCancelling it will change status to cancelled and all the process will stop.", "Confirm Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsNewLocalDrivingLicenseApplication.Find((int)dataGridView1.CurrentRow.Cells[0].Value).ChangeStatus(enmApplicationStatus.Cancelled))
                {
                    ((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row["Status"] = "Cancelled";

                    MessageBox.Show("The Application is Cancelled", "Successful Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                    MessageBox.Show("Error Occurred.\nThe Application is not Cancelled", "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            deleteToolStripMenuItem.Enabled = !(Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value));
            CancelToolStripMenuItem.Enabled = dataGridView1.CurrentRow.Cells[6].Value.ToString() == "New";
            editToolStripMenuItem.Enabled = !(dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Cancelled" || dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Completed" || (int)dataGridView1.CurrentRow.Cells[5].Value != 0);

            sceduletestsToolStripMenuItem.Enabled = ((int)dataGridView1.CurrentRow.Cells[5].Value != 3 && dataGridView1.CurrentRow.Cells[6].Value.ToString() == "New");
            visionTestToolStripMenuItem.Enabled = ((int)dataGridView1.CurrentRow.Cells[5].Value == 0);
            writtenTestToolStripMenuItem.Enabled = ((int)dataGridView1.CurrentRow.Cells[5].Value == 1);
            practicalStreetTestToolStripMenuItem.Enabled = ((int)dataGridView1.CurrentRow.Cells[5].Value == 2);

            issuelicenseToolStripMenuItem.Enabled = ((int)dataGridView1.CurrentRow.Cells[5].Value == 3 && dataGridView1.CurrentRow.Cells[6].Value.ToString() == "New");
            showDrivingLicenseToolStripMenuItem.Enabled = (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Completed");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewLocalDrivingLicenseApplication frm = new frmAddUpdateNewLocalDrivingLicenseApplication((int)dataGridView1.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RestoreDefaultView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure that you want to delete the selected New Local Driving License application ?\n[ID : {dataGridView1.CurrentRow.Cells[0].Value}] ", "Confirm Application Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsNewLocalDrivingLicenseApplication.Find((int)dataGridView1.CurrentRow.Cells[0].Value).Delete())
                {
                    MessageBox.Show("Application has been deleted successfully.", "Successful Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RestoreDefaultView();
                }

                else
                {
                    MessageBox.Show("Application has NOT been deleted.\nAnother data is linked to it (or another wrong may be happened while attempting to delete it).", "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frm = new frmManageTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, enmTestTypes.Vision);

            frm.ShowDialog();

            _RestoreDefaultView();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frm = new frmManageTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, enmTestTypes.Written);
            frm.ShowDialog();

            _RestoreDefaultView();
        }

        private void practicalStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frm = new frmManageTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, enmTestTypes.Street);

            frm.ShowDialog();

            _RestoreDefaultView();
        }

        private void issuelicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueNewDrivingLicenseFirstTime frm = new frmIssueNewDrivingLicenseFirstTime((int)dataGridView1.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RestoreDefaultView();
        }

        private void showDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(clsLocalLicense.GetLicenseIDWhichIssuedDueToApplicationID(clsNewLocalDrivingLicenseApplication.Find((int)dataGridView1.CurrentRow.Cells[0].Value).ApplicationID));

            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(clsNewLocalDrivingLicenseApplication.Find((int)dataGridView1.CurrentRow.Cells[0].Value).ApplicantPerson);

            frm.ShowDialog();

            _RestoreDefaultView();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowNewLocalDrivingLicenseApplicationDetails frm = new frmShowNewLocalDrivingLicenseApplicationDetails((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RestoreDefaultView();
        
        }
    }
}
