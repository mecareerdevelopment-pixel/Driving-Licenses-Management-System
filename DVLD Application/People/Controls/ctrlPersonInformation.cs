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
    public partial class ctrlPersonInformation : UserControl
    {
        public void FillDefault()
        {
            lblPersonID.Text = lblAddress.Text = lblCountry.Text = lblDateOfBirth.Text = lblEmail.Text = lblG.Text = lblName.Text = lblNNo.Text = lblPhone.Text = "...";

            pictureBox1.ImageLocation = null;
        }


        public ctrlPersonInformation()
        {
            InitializeComponent();
        }

        public void FillWithPersonData(clsPerson P)
        {

            lblPersonID.Text = P.ID.ToString();
            lblCountry.Text = P.ContactInfo.CountryName;
            lblPhone.Text = P.ContactInfo.Phone;
            lblEmail.Text = P.ContactInfo.Email;
            lblAddress.Text = P.ContactInfo.Address;
            lblDateOfBirth.Text = P.DateOfBirth.ToString("MM/dd/yyyy");
            lblG.Text = P.Gender ? "Female" : "Male";
            lblName.Text = P.FirstName + " " + P.SecondName + " " + P.ThirdName + " " + P.LastName;
            lblNNo.Text = P.NationalNumber;

            if (P.ImagePath != "")
            {
                pictureBox1.ImageLocation = P.ImagePath;
            }

            else
            {
                pictureBox1.Image = P.Gender ? Properties.Resources.Female_512 : Properties.Resources.Male_512;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmAddUpdatePerson form = new frmAddUpdatePerson(Convert.ToInt32(this.lblPersonID.Text));
                form.ShowDialog();

                this.FillWithPersonData(clsPerson.Find(Convert.ToInt32(this.lblPersonID.Text)));
            }

            catch
            {
                MessageBox.Show("Must load person here to edit it");
            }
            
        }

   
    }
}
