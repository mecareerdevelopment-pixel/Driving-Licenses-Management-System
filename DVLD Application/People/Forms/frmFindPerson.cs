using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Application
{
    public partial class frmFindPerson : Form
    {
        public delegate void delDataBack(int PersonID);

        public delDataBack DataBack;

        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void ctrlPersonInformationWithFindByFilter1_OnPersonFound(BusinessLogicTier.clsPerson obj)
        {
            MessageBox.Show("Person Is Found Successfully");
            ctrlPersonInformationWithFindByFilter1.FillPersonDetailsControl(obj);

            DataBack?.Invoke(obj.ID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFindPerson_Load(object sender, EventArgs e)
        {
            ctrlPersonInformationWithFindByFilter1.Focus();
        }
    }
}
