using System;
using System.Data;
using System.Windows.Forms;
using BusinessLogicTier;

namespace DVLD_Application
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void _BindUsersDataToUI() 
        {
            dataGridView1.DataSource = clsUser.GetAllUsers().DefaultView;
            label4.Text = dataGridView1.Rows.Count.ToString();
            dataGridView1.Columns["Full Name"].Width = 500;
            dataGridView1.Columns["Username"].Width = 200;

            if (dataGridView1.DataSource == null)
                MessageBox.Show("Error While Retrieving Users Form Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _BindUsersDataToUI();
            comboBox1.Text = "None";
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(-1);
            frm.ShowDialog();
            _BindUsersDataToUI();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails(clsUser.FindByUserID(GetSelectedUserIDInDGV()));

            frm.ShowDialog();

            _BindUsersDataToUI();
        }
        
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }
        
        private int GetSelectedUserIDInDGV()
        {
            if (!Convert.ToBoolean(dataGridView1.SelectedRows.Count))
                dataGridView1.Rows[0].Selected = true;

            return (int)dataGridView1.SelectedRows[0].Cells["User ID"].Value;
        }
        
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser form = new frmAddUpdateUser(GetSelectedUserIDInDGV());

            form.ShowDialog();

            _BindUsersDataToUI();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((DataView)dataGridView1.DataSource).RowFilter = "";
            label4.Text = dataGridView1.Rows.Count.ToString();
            txtFilteringCriteria.Text = "";
            txtFilteringCriteria.Visible = !(comboBox1.Text == "None" || comboBox1.Text == "Is Active");

            if (comboBox1.Text == "Is Active")
            {
                comboBox2.Text = "All";
                comboBox2.Visible = true;
            }

            else
            {
                comboBox2.Visible = false;
            }
        }

        private void txtFilteringCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "Person ID" || comboBox1.Text == "User ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void txtFilteringCriteria_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "User ID":
                    ((DataView)dataGridView1.DataSource).RowFilter = (txtFilteringCriteria.Text == "" ? "" : $"[User ID] = {txtFilteringCriteria.Text}");
                    break;

                case "Person ID":
                    ((DataView)dataGridView1.DataSource).RowFilter = (txtFilteringCriteria.Text == "" ? "" : $"[Person ID] = {txtFilteringCriteria.Text}");
                    break;

                case "Full Name":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"[Full Name] liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "UserName":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"USERName liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;
            }

            label4.Text = dataGridView1.Rows.Count.ToString();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobalSettings.CurrentLoggedInUserID == GetSelectedUserIDInDGV())
            {
                MessageBox.Show($"That is You ({dataGridView1.SelectedRows[0].Cells["Full Name"].Value}).\nYou Can not delete yourself as a User.", "Self Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are you sure that you want to delete the selected User ?\n[ID : {GetSelectedUserIDInDGV()}] ", "Confirm User Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUser.DeleteUserWithID(GetSelectedUserIDInDGV()))
                {
                    MessageBox.Show("User has been deleted successfully.", "Successful Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _BindUsersDataToUI();
                }

                else
                {
                    MessageBox.Show("User has NOT been deleted.\nAnother data is linked to it (or another wrong may be happened while attempting to delete the User).", "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "All")
            {
                ((DataView)dataGridView1.DataSource).RowFilter = "";
            }

            else if (comboBox2.Text == "Yes")
            {
                ((DataView)dataGridView1.DataSource).RowFilter = "[Is Active] = true";
            }

            else
            {
                ((DataView)dataGridView1.DataSource).RowFilter = "[Is Active] = false";
            }

            label4.Text = dataGridView1.Rows.Count.ToString();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(GetSelectedUserIDInDGV());

            frm.ShowDialog();
        }

    }
}
