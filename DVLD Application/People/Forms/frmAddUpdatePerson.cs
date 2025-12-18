using System;
using BusinessLogicTier;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
namespace DVLD_Application
{
    internal enum enmFormMode
    {
        AddNewPerson,
        UpdateExistingPerson
    }

    public partial class frmAddUpdatePerson : Form
    {


        public delegate void delDataBack(int PersonID);
        public delDataBack DataBack;


        private enmFormMode _FormMode = enmFormMode.AddNewPerson;

        private  clsPerson _BackingPerson = new clsPerson();

        public frmAddUpdatePerson(int BackingPersonID)
        {
            InitializeComponent();

            btnClose.CausesValidation = false;

            comboBox1.DataSource = clsBusinessLogicTier.GetCountriesList().DefaultView;
            comboBox1.DisplayMember = "countryname";
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);

            _BackingPerson.ID = BackingPersonID;

            if (BackingPersonID != -1)
            {
                _FormMode = enmFormMode.UpdateExistingPerson;
                lblTitle.Text = "Update Person";
                _BackingPerson = clsPerson.Find(_BackingPerson.ID);
                return;
            }

            comboBox1.Text = "egypt";
        }

        private void FillTheFormWithBackingPersonData()
        {
            label2.Text = _BackingPerson.ID.ToString();
            txtFirst.Text = _BackingPerson.FirstName;
            txtSecond.Text = _BackingPerson.SecondName;
            txtThird.Text = _BackingPerson.ThirdName;
            txtLast.Text = _BackingPerson.LastName;
            txtNationalNumber.Text = _BackingPerson.NationalNumber;
            dateTimePicker1.Value = _BackingPerson.DateOfBirth;
            txtPhone.Text = _BackingPerson.ContactInfo.Phone;
            txtEmail.Text = _BackingPerson.ContactInfo.Email;
            txtAddress.Text = _BackingPerson.ContactInfo.Address;
            comboBox1.Text = _BackingPerson.ContactInfo.CountryName;
            rbFemale.Checked = _BackingPerson.Gender;

            if (_BackingPerson.ImagePath != "")
            {
                pictureBox1.ImageLocation = _BackingPerson.ImagePath;

                linkLabel2.Visible = true;
            }
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            if (_FormMode ==  enmFormMode.UpdateExistingPerson)
                this.FillTheFormWithBackingPersonData();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = (pictureBox1.ImageLocation == null ? (rbFemale.Checked ? Properties.Resources.Female_512 : Properties.Resources.Male_512) : pictureBox1.Image);
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, null);
                return;
            }

            if (txtEmail.Text.Trim() != _BackingPerson.ContactInfo.Email && !clsUtility.ValidateEmailAddress(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email");
            }

            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtNationalNumber_Validating(object sender, CancelEventArgs e)     // no one else have the same national no.
        {
            if (String.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                e.Cancel = true;        // cancel , and do not lose the focus
                errorProvider1.SetError((TextBox)sender, "This Field Can not Be Empty.");
            }

            else if (_BackingPerson.NationalNumber != txtNationalNumber.Text.Trim() && clsBusinessLogicTier.DoesNationalNumberExist(txtNationalNumber.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNumber, "National No. Already Exists In The System.");
            }

            else
            {
                errorProvider1.SetError(txtNationalNumber, "");
            }
        }

        private void ControlsValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "This Field Can not Be Empty.");
            }

            else
            {
                errorProvider1.SetError((TextBox)sender, "");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Title = "Choose Image For Person";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                linkLabel2.Visible = true;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel2.Visible = false;
            pictureBox1.Image = (rbFemale.Checked ? Properties.Resources.Female_512 : Properties.Resources.Male_512);
            pictureBox1.ImageLocation = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Make sure that all controls have valid data.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _BackingPerson.FirstName = txtFirst.Text.Trim();
            _BackingPerson.SecondName = txtSecond.Text.Trim();
            _BackingPerson.ThirdName = txtThird.Text.Trim();
            _BackingPerson.LastName = txtLast.Text.Trim();
            _BackingPerson.NationalNumber = txtNationalNumber.Text.Trim();
            _BackingPerson.DateOfBirth = dateTimePicker1.Value;
            _BackingPerson.ContactInfo.Phone = txtPhone.Text.Trim();
            _BackingPerson.ContactInfo.Email = txtEmail.Text.Trim();
            _BackingPerson.ContactInfo.Address = txtAddress.Text.Trim();
            _BackingPerson.ContactInfo.CountryID = comboBox1.FindStringExact(comboBox1.Text) + 1;
            _BackingPerson.Gender = rbFemale.Checked;


            if (_BackingPerson.ImagePath != pictureBox1.ImageLocation)      // the saved backing person before 
            {
                if (_BackingPerson.ImagePath != "")
                {
                    File.Delete(_BackingPerson.ImagePath);
                    _BackingPerson.ImagePath = "";
                }

                if (pictureBox1.ImageLocation != null)
                {
                    if (!Directory.Exists(@"C:\DVLD_People_Images\"))
                        Directory.CreateDirectory(@"C:\DVLD_People_Images\");


                    _BackingPerson.ImagePath = @"C:\DVLD_People_Images\" + Guid.NewGuid().ToString() + Path.GetExtension(pictureBox1.ImageLocation);
                    File.Copy(pictureBox1.ImageLocation, _BackingPerson.ImagePath);
                    pictureBox1.ImageLocation = _BackingPerson.ImagePath;
                }
            }

            

            if (_BackingPerson.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Person Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_FormMode == enmFormMode.AddNewPerson)
                {
                    label2.Text = _BackingPerson.ID.ToString();         // to make the new id visible
                    _FormMode = enmFormMode.UpdateExistingPerson;
                    lblTitle.Text = "Update Person";
                }
            }

            else
            {
                MessageBox.Show("Error Occurred While Saving !", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddUpdatePerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBack?.Invoke(_BackingPerson.ID);
        }

        private void txtNationalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
                e.Handled = true;
        }
    }
}
