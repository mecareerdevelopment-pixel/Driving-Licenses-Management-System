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
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void _BindDriversData()
        {
            dataGridView1.DataSource = clsDriver.GetAll().DefaultView;
            label4.Text = ((DataView)dataGridView1.DataSource).Count.ToString();

            dataGridView1.Columns["Full Name"].Width = 220;
            dataGridView1.Columns["Driver ID"].Width = dataGridView1.Columns["Person ID"].Width = 50;
            dataGridView1.Columns["Active Licenses"].Width = 75;
        }

        private void _SetDataGridViewToDefault()
        {
            comboBox1.Text = "None";
            _BindDriversData();
            txtFilteringCriteria.Focus();
        }

        private void txtFilteringCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((comboBox1.Text == "Person ID" || comboBox1.Text == "DriverID") && (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))) || (comboBox1.Text == "National No." && e.KeyChar == 32) || (comboBox1.Text == "Full Name" && e.KeyChar == 32 && txtFilteringCriteria.SelectionStart == 0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _BindDriversData();
            txtFilteringCriteria.Text = "";
            txtFilteringCriteria.Visible = (comboBox1.Text != "None");
            txtFilteringCriteria.Focus();
        }

        private void txtFilteringCriteria_TextChanged(object sender, EventArgs e)
        {
            if (txtFilteringCriteria.Text.Trim() == "")
            {
                _BindDriversData();
                return;
            }


            string FilteringField = comboBox1.Text;
            string FilteringCondition = "";

            switch (FilteringField)
            {
                case "Driver ID":
                    FilteringCondition = $" = {txtFilteringCriteria.Text}";

                    break;

                case "Person ID":
                    FilteringCondition = $" = {txtFilteringCriteria.Text}";

                    break;

                case "National No.":
                    FilteringCondition = $" LIKE '{txtFilteringCriteria.Text}%'";

                    break;

                case "Full Name":
                    FilteringCondition = $" LIKE '{txtFilteringCriteria.Text.Trim()}%'";

                    break;
            }


            ((DataView)dataGridView1.DataSource).RowFilter = $"[{FilteringField}] {FilteringCondition}";
            label4.Text = ((DataView)dataGridView1.DataSource).Count.ToString();

        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _SetDataGridViewToDefault();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

            _SetDataGridViewToDefault();
        }

        private void showLicenseHistorymenuitem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(clsPerson.Find((int)dataGridView1.CurrentRow.Cells[1].Value));
            frm.ShowDialog();

            _SetDataGridViewToDefault();
        }
    }
}
