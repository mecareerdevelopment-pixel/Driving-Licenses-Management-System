using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BusinessLogicTier;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Application
{
    public partial class frmChangePassword : Form
    {
        private clsUser _BackingUser;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _BackingUser = clsUser.FindByUserID(UserID);
            ctrlUserDetails1.FillUserDetails(_BackingUser);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (clsUtility.GetHashValue(textBox1.Text) != _BackingUser.PasswordHashedValue)
            {
                errorProvider1.SetError(textBox1, "Wrong Password For User.");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(textBox1, "");
            }

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Enter The new password !");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text != textBox2.Text)
            {
                errorProvider1.SetError(textBox3, "Confirm is not idetical to your new password !");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(textBox3, "");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error In Password ...... Hover Red Circles To Know More", "Changing Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            if (_BackingUser.ChangePassword(textBox2.Text))
            {
                MessageBox.Show("Password Have Been Changed Successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }

            else
            {
                MessageBox.Show("System Error While Changing Password");
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
