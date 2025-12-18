using System;
using System.Windows.Forms;
using BusinessLogicTier;

namespace DVLD_Application
{
    public partial class frmPersonDetails : Form
    {

        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();

            ctrlPersonInformation1.FillWithPersonData(clsPerson.Find(PersonID));
        }

        public frmPersonDetails(string NationalNumber)
        {
            InitializeComponent();

            ctrlPersonInformation1.FillWithPersonData(clsPerson.Find(NationalNumber));
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
