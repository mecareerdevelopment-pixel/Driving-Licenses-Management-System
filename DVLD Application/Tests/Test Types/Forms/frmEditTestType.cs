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
    public partial class frmEditTestType : Form
    {
        private clsTestType _BackingTestType;

        public frmEditTestType(int TTID)
        {
            InitializeComponent();


            _BackingTestType = clsTestType.Find(TTID);
        }

        private void _LoadBackingTestType()
        {
            lblID.Text = _BackingTestType.ID.ToString();
            textBox1.Text = _BackingTestType.Title;
            textBox2.Text = _BackingTestType.Description;
            textBox3.Text = _BackingTestType.Fees.ToString();
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _LoadBackingTestType();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Check the Fields, entered values are not allowed.", "editing refused", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _BackingTestType.Title = textBox1.Text;
            _BackingTestType.Description = textBox2.Text;
            _BackingTestType.Fees = Convert.ToDouble(textBox3.Text);

            MessageBox.Show(_BackingTestType.Save() ? "Data saved successfully" : "Error in saving data, test type was not beed edited");
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.' || e.KeyChar == '.' && textBox3.Text.Contains(".")));
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                errorProvider1.SetError((Control)sender, "This Field Can NOT be empty");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError((Control)sender, null);

            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError((Control)sender, "This Field Can NOT be empty");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError((Control)sender, null);

            }
        }
    }
}
