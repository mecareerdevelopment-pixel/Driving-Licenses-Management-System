using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessLogicTier;
using System.Windows.Forms;
using System.Runtime.Hosting;

namespace DVLD_Application
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int ApplicantPersonID;
        private int _ApplicationID;

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();


        }

        public void FillApplicationBasicInfo(int ApplicationID)
        {
            clsApplication Application = clsApplication.Find(ApplicationID);

            ApplicantPersonID = Application.ApplicantPersonID;
            _ApplicationID = Application.ApplicationID;

            lblApplicant.Text = Application.ApplicantPerson.FullName;
            lblType.Text = clsApplicationType.Find((int)Application.ApplicationType).Title;
            lblDate.Text = Application.ApplicationDate.ToString("MM/dd/yyyy");
            lblFees.Text = Application.PaidFees.ToString();
            lblID.Text = Application.ApplicationID.ToString();
            lblStatus.Text = Application.Status.ToString();
            lblStatusDate.Text = Application.LastStatusDate.ToString("MM/dd/yyyy");
            lblUser.Text = Application.CreatedByUser.Username;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(ApplicantPersonID);

            frm.ShowDialog();

            FillApplicationBasicInfo(_ApplicationID);   // to update if the person data is changed
        }

        private void ctrlApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
