using System;
using BusinessLogicTier;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Application
{
    public partial class frmAddUpdateUser : Form
    {
        
        private clsUser _BackingUser = new clsUser();

        private enmMode _FormMode = enmMode.AddNew;

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();

            _BackingUser.ID = UserID;
            _BackingUser.UnderlyingPersonID = -1;

            if (UserID != -1)
            {
                _FormMode = enmMode.Update;

                _BackingUser = clsUser.FindByUserID(_BackingUser.ID);

                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_BackingUser.UnderlyingPersonID == -1)
            {
                MessageBox.Show("The New user Must have a valid existing non-user person to be assigned to it. \nAdd one if there is not.", "No Person Assigned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedIndex = 1;
        }

        private void ctrlPersonInformationWithFindByFilter1_OnPersonFound(BusinessLogicTier.clsPerson obj)
        {
            ctrlPersonInformationWithFindByFilter1.FillPersonDetailsControl(obj);


            if (clsUser.DoesPersonIDExistForAUser(obj.ID))
            {
                MessageBox.Show("Selected Person already have a user. Choose Another person.", "Selected Person Is a User.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                ctrlPersonInformationWithFindByFilter1.SetFocusToSearchBox();
                return;

            }

            _BackingUser.UnderlyingPersonID = obj.ID;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (_BackingUser.UnderlyingPersonID == -1)
                {
                    tabControl1.SelectedIndex = 0;
                    MessageBox.Show("The New user Must have a valid existing non-user person to be assigned to it. \nAdd one if there is not.", "No Person Assigned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            btnSave.Enabled = (tabControl1.SelectedIndex == 1);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                errorProvider1.SetError((Control)sender, "Username is Required");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError((Control)sender, "");

                if (clsUser.DoesUsernameExist(textBox1.Text) && _BackingUser.Username != textBox1.Text)
                {
                    errorProvider1.SetError((Control)sender, "Username already taken by another User.");
                    e.Cancel = true;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == 32);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError((Control)sender, textBox3.Text == "" ? "Password is Required" : "");

            if (((TextBox)sender).Text == "" && _FormMode == enmMode.AddNew)
                e.Cancel = true;

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError((Control)sender, textBox2.Text != textBox3.Text ? "Confirm Password Field Must Be identical to Password Field" : "");

            if (textBox2.Text != textBox3.Text)
                e.Cancel = true;
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if (_FormMode == enmMode.Update)
            {
                label1.Text = "Update User";
                ctrlPersonInformationWithFindByFilter1.FillPersonDetailsControlAndFillFilter(clsPerson.Find(_BackingUser.UnderlyingPersonID));
                label3.Text = _BackingUser.ID.ToString();
                textBox1.Text = _BackingUser.Username;
                checkBox1.Checked = _BackingUser.IsActive;
                textBox2.Visible = textBox3.Visible = label9.Visible = label7.Visible = false;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            _BackingUser.IsActive = checkBox1.Checked;
            _BackingUser.Username = textBox1.Text;

            if (_FormMode == enmMode.AddNew)
            {
                _BackingUser.Password = textBox2.Text;
            }

            if (_BackingUser.Save())
            {
                if (_FormMode == enmMode.AddNew)
                {
                    ctrlPersonInformationWithFindByFilter1.DisableFilter();
                    label1.Text = "Update User";
                    _FormMode = enmMode.Update;
                    label3.Text = _BackingUser.ID.ToString();
                    textBox2.Visible = textBox3.Visible = label9.Visible = label7.Visible = false;

                }

                MessageBox.Show("data is saved successfully !");

            }

            else
            {
                MessageBox.Show("Error While trying to save the user data!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

        }

        private void ctrlPersonInformationWithFindByFilter1_Validating(object sender, CancelEventArgs e)
        {
        }

        private void ctrlPersonInformationWithFindByFilter1_OnPersonNotFound()
        {
            _BackingUser.UnderlyingPersonID = -1;
        }

        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonInformationWithFindByFilter1.SetFocusToSearchBox();
        }
    }
}
