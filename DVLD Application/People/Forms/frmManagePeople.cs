using System;
using System.IO;
using System.Data;
using BusinessLogicTier;
using System.Windows.Forms;

namespace DVLD_Application
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson(-1);     // always must be -1 as new person
           
            form.ShowDialog();

            UpdatePeopleList();
        }

        private void UpdatePeopleList()     // get the up-to-date version of table of people from database
        {
            // secondly, fill the data grid view with data
            dataGridView1.DataSource = clsBusinessLogicTier.GetAllPeople().DefaultView;
            label4.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.DataSource == null)
                MessageBox.Show("Error While Retrieving Person Details !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            UpdatePeopleList();

            comboBox1.Text = "None";
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson(GetSelectedPersonIDInDGV());

            form.ShowDialog();

            UpdatePeopleList();
        }
        
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seding Email Logic Will Be Here ........", "JUST A STUB FOR DEMO");
        }

        private void makeAPhoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Making Phone Call Logic Will Be Here ........", "JUST A STUB FOR DEMO");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure that you want to delete the selected person ?\n[ID : {GetSelectedPersonIDInDGV()}] ", "Confirm Person Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string ImagePath = clsPerson.Find(GetSelectedPersonIDInDGV()).ImagePath;

                if (clsPerson.DeletePersonWithID(GetSelectedPersonIDInDGV()))
                {
                    MessageBox.Show("Person has been deleted successfully.", "Successful Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdatePeopleList();

                    if (ImagePath != "")
                        File.Delete(ImagePath);
                }

                else
                {
                    MessageBox.Show("Person has NOT been deleted.\nAnother data is linked to it (or another wrong may be happened while attempting to delete the person).", "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails form = new frmPersonDetails(GetSelectedPersonIDInDGV());

            form.ShowDialog();

            UpdatePeopleList();
        }

        private int GetSelectedPersonIDInDGV()
        {
            if (!Convert.ToBoolean(dataGridView1.SelectedRows.Count))
                dataGridView1.Rows[0].Selected = true;

            return (int)dataGridView1.SelectedRows[0].Cells["personid"].Value;
        }

        private void txtFilteringCriteria_TextChanged(object sender, EventArgs e)
        {
            if (txtFilteringCriteria.Text.Trim() == "")
            {
                ((DataView)dataGridView1.DataSource).RowFilter = "";
                label4.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            switch (comboBox1.Text)
            {
                case "Person ID":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"PersonID = {txtFilteringCriteria.Text}";
                    
                    break;

                case "National No.":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"[National No.] liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "First Name":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"[First Name] liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "Second Name":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"[Second Name] liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "Third Name":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"[Third Name] liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "Last Name":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"[Last Name] liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "Nationality":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"[nationality] liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "Gender":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"[gender] liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "Phone":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"[phone] liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                case "Email":
                    ((DataView)dataGridView1.DataSource).RowFilter = $"[email] liKE '{txtFilteringCriteria.Text.Trim()}%'";
                    break;

                default:
                    break;
            }

            label4.Text = dataGridView1.Rows.Count.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilteringCriteria.Text = "";
            txtFilteringCriteria.Visible = !(comboBox1.Text == "None");
            txtFilteringCriteria.Focus();
        }

        private void txtFilteringCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "Person ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
