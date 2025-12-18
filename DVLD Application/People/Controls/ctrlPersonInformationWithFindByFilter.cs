using System;
using BusinessLogicTier;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Application
{
    public partial class ctrlPersonInformationWithFindByFilter : UserControl
    {
        public int _BackingPersonID;

        public event Action<clsPerson> OnPersonFound;
        public event Action OnPersonNotFound;

        public ctrlPersonInformationWithFindByFilter()
        {
            InitializeComponent();

            textBox1.Focus();
        }

        public void SetFocusToSearchBox()
        {
            this.textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "Person ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }

            if (e.KeyChar == (char)13)      // enter key
            {
                btnFind.PerformClick();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Enter a value to search for it !");
                return;
            }

            if (comboBox1.Text == "National Number" && clsPerson.CheckExistance(textBox1.Text))
            {
                OnPersonFound?.Invoke(clsPerson.Find(textBox1.Text));
            }

            else if (comboBox1.Text == "Person ID" && clsPerson.CheckExistance(Convert.ToInt32(textBox1.Text)))
            {
                OnPersonFound?.Invoke(clsPerson.Find(Convert.ToInt32(textBox1.Text)));
            }

            else
            {
                OnPersonNotFound?.Invoke();
                ctrlPersonInformation1.FillDefault();
                MessageBox.Show("No Person was found with the given filter.", "Can not Find Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);

            frm.DataBack += FillControlWithRetrievedData;

            frm.ShowDialog();
        }

        private void FillControlWithRetrievedData(int PersonID)
        {

            if (PersonID == -1)
            {
                MessageBox.Show("No Person was added !");
                return;
            }

            textBox1.Text = PersonID.ToString();
            comboBox1.Text = "Person ID";

            btnFind.PerformClick();
        }

        public void FillPersonDetailsControl(clsPerson P)
        {
            ctrlPersonInformation1.FillWithPersonData(P);
        }

        public void FillPersonDetailsControlAndFillFilter(clsPerson P)
        {
            ctrlPersonInformation1.FillWithPersonData(P);
            comboBox1.Text = "Person ID";
            textBox1.Text = P.ID.ToString();
            DisableFilter();
        }

        private void ctrlPersonInformationWithFindByFilter_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "National Number";
        }

        public void DisableFilter()
        {
            groupBox1.Enabled = false;
        }

        private void ctrlPersonInformation1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
