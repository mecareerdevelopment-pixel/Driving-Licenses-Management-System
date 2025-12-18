using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.ApplicationTypes
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _LoadDataToGrid()
        {
            dataGridView1.DataSource = BusinessLogicTier.clsApplicationType.GetAll().DefaultView;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].HeaderText = "Fees";

            dataGridView1.Sort(dataGridView1.Columns["applicationtypetitle"], ListSortDirection.Ascending);

            lblRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadDataToGrid();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _LoadDataToGrid();
        }
    }
}
