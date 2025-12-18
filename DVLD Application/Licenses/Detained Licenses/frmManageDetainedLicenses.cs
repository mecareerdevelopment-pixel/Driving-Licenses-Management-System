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

namespace DVLD_Application.Licenses.Forms.Detained_Licenses
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _RetrieveAllInternationalLicensesDataToDataGridView()
        {
            dataGridView1.DataSource = clsLicenseDetention.GetAllDetainedLicenses().DefaultView;
            label4.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.Columns["D. ID"].Width = dataGridView1.Columns["L. ID"].Width = 40;
            dataGridView1.Columns["Is Released"].Width = dataGridView1.Columns["National No."].Width = dataGridView1.Columns["Applied Fine"].Width = 60;
            dataGridView1.Columns["R. App. ID"].Width = 65;
            dataGridView1.Columns["Release Date"].Width = dataGridView1.Columns["D. Date"].Width = 80;
            dataGridView1.Columns["Full Name"].Width = 210;
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RetrieveAllInternationalLicensesDataToDataGridView();
            comboBox1.Text = "None";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((DataView)dataGridView1.DataSource).RowFilter = "";
            label4.Text = dataGridView1.Rows.Count.ToString();

            txtFilteringCriteria.Text = "";
            txtFilteringCriteria.Visible = !(comboBox1.Text == "None" || comboBox1.Text == "Is Released");

            if (comboBox1.Text == "Is Released")
            {
                comboBox2.Text = "All";
                comboBox2.Visible = true;
            }

            else
            {
                comboBox2.Visible = false;
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
                ((DataView)dataGridView1.DataSource).RowFilter = "[Is Released] = true";
            }

            else
            {
                ((DataView)dataGridView1.DataSource).RowFilter = "[Is Released] = false";
            }

            label4.Text = dataGridView1.Rows.Count.ToString();
        }

        private void txtFilteringCriteria_TextChanged(object sender, EventArgs e)
        {
            if (txtFilteringCriteria.Text == "")        // mainly to handle the empty case while the text box appears (when the user delete all the characters in the text box while same combo box item is selected)
            {
                ((DataView)dataGridView1.DataSource).RowFilter = "";
                label4.Text = dataGridView1.Rows.Count.ToString();

                return;
            }

            string FilterColumn;

            switch (comboBox1.Text)
            {
                case "Detain ID":
                    FilterColumn = "D. ID";
                    break;

                case "Release Application ID":
                    FilterColumn = "R. App. ID";
                    break;

                case "License ID":
                    FilterColumn = "L. ID";
                    break;

                default:
                    FilterColumn = comboBox1.Text;
                    break;
            }

            if (FilterColumn == "D. ID" || FilterColumn == "R. App. ID" || FilterColumn == "L. ID")
                ((DataView)dataGridView1.DataSource).RowFilter = $"[{FilterColumn}] = {txtFilteringCriteria.Text}";

            else
                ((DataView)dataGridView1.DataSource).RowFilter = $"[{FilterColumn}] LIKE '{txtFilteringCriteria.Text.Trim()}%'";

            label4.Text = dataGridView1.Rows.Count.ToString();
        }

        private void txtFilteringCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) && (comboBox1.Text == "Release Application ID" || comboBox1.Text == "Detain ID" || comboBox1.Text == "License ID"));
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            frm.ShowDialog();

            frmManageDetainedLicenses_Load(null, null);

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(clsPerson.Find(dataGridView1.CurrentRow.Cells[6].Value.ToString()));
            frm.ShowDialog();

            frmManageDetainedLicenses_Load(null, null);

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            releaseToolStripMenuItem.Enabled = !Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense((int)dataGridView1.CurrentRow.Cells[1].Value);

            frm.ShowDialog();
            frmManageDetainedLicenses_Load(null, null);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();

            frm.ShowDialog();

            comboBox1.Text = "None";
            _RetrieveAllInternationalLicensesDataToDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)      // detain license
        {
            frmDetainLicense frm = new frmDetainLicense();

            frm.ShowDialog();

            frmManageDetainedLicenses_Load(null, null);
        }
    }
}
