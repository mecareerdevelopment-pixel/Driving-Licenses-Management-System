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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _LoadDataToGrid()
        {
            dataGridView1.DataSource = clsTestType.GetAll().DefaultView;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Description";
            dataGridView1.Columns[2].Width = 400;
            dataGridView1.Columns[3].HeaderText = "Fees";

            dataGridView1.Sort(dataGridView1.Columns["TestTypeTitle"], ListSortDirection.Ascending);

            lblRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadDataToGrid();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadDataToGrid();
        }
    }
}
