using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD.Applications.ApplicationTypes;
using System.Windows.Forms;
using DVLD_Application.Applications.Forms;
using DVLD_Application.Licenses.Forms;
using DVLD_Application.Licenses.Forms.Detained_Licenses;

namespace DVLD_Application
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmManagePeople frm = new frmManagePeople();

            frm.MdiParent = this;

            frm.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.CurrentLoggedInUserID = -1;
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmManageUsers frm = new frmManageUsers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmUserDetails frm = new frmUserDetails(BusinessLogicTier.clsUser.FindByUserID(clsGlobalSettings.CurrentLoggedInUserID));

            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.MdiParent = this;
            frm.Show();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Changes done in this fucnton are reflected to the global current loggedin user

            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmChangePassword frm = new frmChangePassword(clsGlobalSettings.CurrentLoggedInUserID);

            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.Show();

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmManageApplicationTypes frm = new frmManageApplicationTypes();

            frm.MdiParent = this;

            frm.Show();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmManageTestTypes frm = new frmManageTestTypes();

            frm.MdiParent = this;

            frm.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)        // add new
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();


            frmAddUpdateNewLocalDrivingLicenseApplication frm = new frmAddUpdateNewLocalDrivingLicenseApplication();

            frm.MdiParent = this;

            frm.Show();
        }


        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();


            frmManageNewLocalDrivingLicenseApplications frm = new frmManageNewLocalDrivingLicenseApplications();

            frm.MdiParent = this;

            frm.Show();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmManageDrivers frm = new frmManageDrivers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmManageNewLocalDrivingLicenseApplications frm = new frmManageNewLocalDrivingLicenseApplications();
            frm.MdiParent = this;
            frm.Show();

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory();
            frm.MdiParent = this;
            frm.Show();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmAddNewInternationalLicense frm = new frmAddNewInternationalLicense();
            frm.MdiParent = this;
            frm.Show();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmListAllInternationalLicenses frm = new frmListAllInternationalLicenses();
            frm.MdiParent = this;
            frm.Show();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmRenewLocalDrivingLicense frm = new frmRenewLocalDrivingLicense();
            frm.MdiParent = this;
            frm.Show();
        }

        private void replacementForLostDamagedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmReplacementForLostOrDamagedLicense frm = new frmReplacementForLostOrDamagedLicense();
            frm.MdiParent = this;
            frm.Show();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmDetainLicense frm = new frmDetainLicense();
            frm.MdiParent = this;
            frm.Show();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.MdiParent = this;
            frm.Show();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.MdiChildren.Length))
                this.MdiChildren[0].Close();

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
