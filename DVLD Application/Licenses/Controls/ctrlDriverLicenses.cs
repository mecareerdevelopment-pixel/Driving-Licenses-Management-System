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
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _BackingPersonID;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void _FillLocalLicensesInfo()
        {
            dataGridView1.DataSource = clsLocalLicense.GetAllLicensesForPerson(_BackingPersonID);
            dataGridView1.Columns["Lic. id"].Width = dataGridView1.Columns["app. id"].Width = 40;
            dataGridView1.Columns["is active"].Width = 50;
            dataGridView1.Columns["issue date"].Width = dataGridView1.Columns["expiration date"].Width = 90;
            dataGridView1.Columns["class name"].Width = 220;

            label2.Text = ((DataTable)dataGridView1.DataSource).Rows.Count.ToString();
        }

        private void _FillInternationalLicensesInfo()
        {
            dataGridView2.DataSource = clsInternationalLicense.GetAllLicensesForPerson(_BackingPersonID);
            dataGridView2.Columns["app. id"].Width = dataGridView2.Columns["lic. id"].Width = 40;
            dataGridView2.Columns["is active"].Width = 50;
            dataGridView2.Columns["local lic. id"].Width = 60;
            dataGridView2.Columns["issue date"].Width = dataGridView2.Columns["expiration date"].Width = 90;

            label3.Text = ((DataTable)dataGridView2.DataSource).Rows.Count.ToString();
        }

        public void FillLicensesInfoForPerson(int PersonID)
        {
            _BackingPersonID = PersonID;

            _FillLocalLicensesInfo();
            _FillInternationalLicensesInfo();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }
    }
}
