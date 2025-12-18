using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private BusinessLogicTier.clsApplicationType _BackingApplicationType;

        public frmEditApplicationType(int ATID)
        {
            InitializeComponent();

            _BackingApplicationType = BusinessLogicTier.clsApplicationType.Find(ATID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadBackingApplicationType()
        {
            lblID.Text = _BackingApplicationType.ID.ToString();
            textBox1.Text = _BackingApplicationType.Title;
            textBox3.Text = _BackingApplicationType.Fees.ToString();
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _LoadBackingApplicationType();
        }

        private void button1_Click(object sender, EventArgs e)  //save
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Check the Fields, entered values are not allowed.", "editing refused", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _BackingApplicationType.Title = textBox1.Text;
            _BackingApplicationType.Fees = Convert.ToDouble(textBox3.Text);

            MessageBox.Show(_BackingApplicationType.Save() ? "Data saved successfully" : "Error in saving data, application type was not beed edited");
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
    }
}
