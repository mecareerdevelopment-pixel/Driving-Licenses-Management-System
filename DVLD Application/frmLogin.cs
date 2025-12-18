using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using static System.Windows.Forms.LinkLabel;

namespace DVLD_Application
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                errorProvider1.SetError(textBox1, textBox1.Text == "" ? "Please Enter Your Username." : "");
                errorProvider1.SetError(textBox2, textBox2.Text == "" ? "Please Enter Your Password." : "");
                MessageBox.Show("Both Username And Password Must Be Entered !", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (BusinessLogicTier.clsUser.AuthenticateUser(textBox1.Text, textBox2.Text))
            {
                case BusinessLogicTier.AuthenticationStatus.AuthenticatedActivated:
                    clsGlobalSettings.CurrentLoggedInUserID = BusinessLogicTier.clsUser.FindByUsernameAndPassword(textBox1.Text, textBox2.Text).ID;
               
                    if (checkBox1.Checked)
                    {

                        try
                        {
                            // Write the value to the Registry
                            Registry.SetValue(clsGlobalSettings.keyPath, "Username", textBox1.Text, RegistryValueKind.String);
                            Registry.SetValue(clsGlobalSettings.keyPath, "Password", textBox2.Text, RegistryValueKind.String);

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Can NOT Save the logged in user data\nit is a IT problem");
                        }
                    }

                    else
                    {
                        using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                        {
                            using (RegistryKey key = baseKey.OpenSubKey(@"Software\DVLD", true))
                            {
                                if (key != null)        // if path exists
                                {
                                    // Delete the specified value
                                    key.DeleteValue("Username", false);
                                    key.DeleteValue("Password", false);

                                }
                            }
                        }
                    }

                    this.Close();

                    break;

                case BusinessLogicTier.AuthenticationStatus.AuthenticatedDeactivated:
                    MessageBox.Show("This Account Is Deactivated. For More Info Contact You Admin.", "Deactivated Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case BusinessLogicTier.AuthenticationStatus.InvalidCredentials:
                    MessageBox.Show("Invalid Username / Password.", "Failed Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    MessageBox.Show("An unexpected error occurred. Please try again or contact management if the problem persists.", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 32;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Read the value from the Registry
            string Username = Registry.GetValue(clsGlobalSettings.keyPath, "Username", null) as string;
            string Password = Registry.GetValue(clsGlobalSettings.keyPath, "Password", null) as string;


            if (Username != null && Password != null)       // if entered here then he was clicked on remember me before
            {
                textBox1.Text = Username;
                textBox2.Text = Password;

                checkBox1.Checked = true;
            }
        }
    }
}
