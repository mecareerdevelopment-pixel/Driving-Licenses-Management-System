namespace DVLD_Application
{
    partial class frmShowPersonLicenseHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlDriverLicenses1 = new DVLD_Application.ctrlDriverLicenses();
            this.ctrlPersonInformationWithFindByFilter1 = new DVLD_Application.ctrlPersonInformationWithFindByFilter();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(2, 311);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(990, 362);
            this.ctrlDriverLicenses1.TabIndex = 2;
            // 
            // ctrlPersonInformationWithFindByFilter1
            // 
            this.ctrlPersonInformationWithFindByFilter1.Location = new System.Drawing.Point(2, 1);
            this.ctrlPersonInformationWithFindByFilter1.Name = "ctrlPersonInformationWithFindByFilter1";
            this.ctrlPersonInformationWithFindByFilter1.Size = new System.Drawing.Size(1022, 434);
            this.ctrlPersonInformationWithFindByFilter1.TabIndex = 1;
            this.ctrlPersonInformationWithFindByFilter1.OnPersonFound += new System.Action<BusinessLogicTier.clsPerson>(this.ctrlPersonInformationWithFindByFilter1_OnPersonFound);
            this.ctrlPersonInformationWithFindByFilter1.OnPersonNotFound += new System.Action(this.ctrlPersonInformationWithFindByFilter1_OnPersonNotFound);
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(612, 567);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.Controls.Add(this.ctrlPersonInformationWithFindByFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowPersonLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Person License History";
            this.Activated += new System.EventHandler(this.frmShowPersonLicenseHistory_Activated);
            this.Load += new System.EventHandler(this.frmShowPersonLicenseHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ctrlPersonInformationWithFindByFilter ctrlPersonInformationWithFindByFilter1;
        private ctrlDriverLicenses ctrlDriverLicenses1;
    }
}