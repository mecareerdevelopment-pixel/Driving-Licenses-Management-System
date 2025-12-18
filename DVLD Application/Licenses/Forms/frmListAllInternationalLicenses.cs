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
using DVLD_Application.Applications.Forms;

namespace DVLD_Application.Licenses.Forms
{
    public partial class frmListAllInternationalLicenses : Form
    {
        public frmListAllInternationalLicenses()
        {
            InitializeComponent();
        }

        private void _RetrieveAllInternationalLicensesDataToUI()
        {
            dataGridView1.DataSource = clsInternationalLicense.GetAll().DefaultView;
            label4.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.Columns["Application ID"].Width = 100;
            dataGridView1.Columns["Driver ID"].Width = 50;
        }

        private void frmListAllInternationalLicenses_Load(object sender, EventArgs e)
        {
            _RetrieveAllInternationalLicensesDataToUI();
            comboBox1.Text = "None";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((DataView)dataGridView1.DataSource).RowFilter = "";
            label4.Text = dataGridView1.Rows.Count.ToString();
            txtFilteringCriteria.Text = "";
            txtFilteringCriteria.Visible = !(comboBox1.Text == "None" || comboBox1.Text == "Is Active");

            if (comboBox1.Text == "Is Active")
            {
                comboBox2.Text = "All";
                comboBox2.Visible = true;
            }

            else
            {
                comboBox2.Visible = false;
            }
        }

        private void txtFilteringCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void txtFilteringCriteria_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "None" && comboBox1.Text != "Is Active")
            {
                ((DataView)dataGridView1.DataSource).RowFilter = (txtFilteringCriteria.Text == "" ? "" : $"[{comboBox1.Text}] = {txtFilteringCriteria.Text}");
                label4.Text = dataGridView1.Rows.Count.ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "All")
            {
                ((DataView)dataGridView1.DataSource).RowFilter = "";
            }

            else if (comboBox2.Text == "Yes")
            {
                ((DataView)dataGridView1.DataSource).RowFilter = "[Is Active] = true";
            }

            else
            {
                ((DataView)dataGridView1.DataSource).RowFilter = "[Is Active] = false";
            }

            label4.Text = dataGridView1.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(clsApplication.Find(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value)).ApplicantPersonID);
            frm.Show();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            frm.Show();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(clsPerson.Find(clsDriver.GetPersonID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value))));
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frm = new frmAddNewInternationalLicense();
            frm.Show();

            frmListAllInternationalLicenses_Load(null, null);       // to refresh the list of international driving licenses
        }
    }
}
