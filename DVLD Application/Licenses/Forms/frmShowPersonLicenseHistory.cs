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
    public partial class frmShowPersonLicenseHistory : Form
    {
        private clsPerson _BackingPerson = null;

        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
        }

        public frmShowPersonLicenseHistory(clsPerson Person)
        {
            InitializeComponent();

            _BackingPerson = Person;
            
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_BackingPerson != null)     // entred in Per-chosen person mode
            {
                ctrlPersonInformationWithFindByFilter1.FillPersonDetailsControlAndFillFilter(_BackingPerson);
                ctrlDriverLicenses1.FillLicensesInfoForPerson(_BackingPerson.ID);
            }

        }

        private void ctrlPersonInformationWithFindByFilter1_OnPersonFound(clsPerson Person)
        {
            ctrlPersonInformationWithFindByFilter1.FillPersonDetailsControl(Person);
            ctrlDriverLicenses1.FillLicensesInfoForPerson(Person.ID);
        }

        private void ctrlPersonInformationWithFindByFilter1_OnPersonNotFound()
        {
            ctrlDriverLicenses1.FillLicensesInfoForPerson(-1);
        }

        private void frmShowPersonLicenseHistory_Activated(object sender, EventArgs e)
        {
            ctrlPersonInformationWithFindByFilter1.SetFocusToSearchBox();
        }
    }
}
