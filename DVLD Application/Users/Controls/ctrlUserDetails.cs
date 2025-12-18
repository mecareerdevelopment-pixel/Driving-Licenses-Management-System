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
    public partial class ctrlUserDetails : UserControl
    {
        public ctrlUserDetails()
        {
            InitializeComponent();
        }


        public void FillUserDetails(clsUser User)
        {
            ctrlPersonInformation1.FillWithPersonData(clsPerson.Find(User.UnderlyingPersonID));

            lblUserID.Text = User.ID.ToString();
            lblUsername.Text = User.Username;
            lblIsActive.Text = User.IsActive ? "Yes" : "No";

        }

        private void ctrlPersonInformation1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlUserDetails_Load(object sender, EventArgs e)
        {
        }
    }
}
