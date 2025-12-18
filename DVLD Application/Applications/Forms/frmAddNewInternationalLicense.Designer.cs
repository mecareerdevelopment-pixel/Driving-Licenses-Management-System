namespace DVLD_Application.Applications.Forms
{
    partial class frmAddNewInternationalLicense
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
            this.btnIssue = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLdlId = new System.Windows.Forms.Label();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblIssue = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIlID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIlAppID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlLocalLicenseInfoWithFilter1 = new DVLD_Application.Licenses.Controls.ctrlLocalLicenseInfoWithFilter();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.White;
            this.btnIssue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIssue.Enabled = false;
            this.btnIssue.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnIssue.Location = new System.Drawing.Point(610, 593);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(153, 66);
            this.btnIssue.TabIndex = 1;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(191, 602);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(217, 19);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Show Driver\'s Licenses History";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Enabled = false;
            this.linkLabel2.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(191, 640);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(239, 19);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Show Issued International License";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(806, 602);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 38);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLdlId);
            this.groupBox2.Controls.Add(this.lblExpDate);
            this.groupBox2.Controls.Add(this.lblUser);
            this.groupBox2.Controls.Add(this.lblIssue);
            this.groupBox2.Controls.Add(this.lblFees);
            this.groupBox2.Controls.Add(this.lblAppDate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblIlID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblIlAppID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(2, 417);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(959, 151);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New International License Info";
            // 
            // lblLdlId
            // 
            this.lblLdlId.AutoSize = true;
            this.lblLdlId.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLdlId.Location = new System.Drawing.Point(778, 51);
            this.lblLdlId.Name = "lblLdlId";
            this.lblLdlId.Size = new System.Drawing.Size(64, 22);
            this.lblLdlId.TabIndex = 15;
            this.lblLdlId.Text = "[????]";
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblExpDate.Location = new System.Drawing.Point(779, 81);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(63, 22);
            this.lblExpDate.TabIndex = 14;
            this.lblExpDate.Text = "label2";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUser.Location = new System.Drawing.Point(780, 111);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(63, 22);
            this.lblUser.TabIndex = 13;
            this.lblUser.Text = "label2";
            // 
            // lblIssue
            // 
            this.lblIssue.AutoSize = true;
            this.lblIssue.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblIssue.Location = new System.Drawing.Point(276, 81);
            this.lblIssue.Name = "lblIssue";
            this.lblIssue.Size = new System.Drawing.Size(63, 22);
            this.lblIssue.TabIndex = 12;
            this.lblIssue.Text = "label2";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFees.Location = new System.Drawing.Point(276, 111);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(63, 22);
            this.lblFees.TabIndex = 11;
            this.lblFees.Text = "label2";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAppDate.Location = new System.Drawing.Point(277, 51);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(63, 22);
            this.lblAppDate.TabIndex = 10;
            this.lblAppDate.Text = "label2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(560, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 22);
            this.label9.TabIndex = 9;
            this.label9.Text = "Created By User : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.Color.Crimson;
            this.label8.Location = new System.Drawing.Point(574, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 22);
            this.label8.TabIndex = 8;
            this.label8.Text = "Expiration Date : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(189, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Fees :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(109, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "Issue Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(630, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "L.D.L. ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(48, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Application Date :";
            // 
            // lblIlID
            // 
            this.lblIlID.AutoSize = true;
            this.lblIlID.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblIlID.Location = new System.Drawing.Point(778, 21);
            this.lblIlID.Name = "lblIlID";
            this.lblIlID.Size = new System.Drawing.Size(64, 22);
            this.lblIlID.TabIndex = 3;
            this.lblIlID.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(574, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "I.D License ID :";
            // 
            // lblIlAppID
            // 
            this.lblIlAppID.AutoSize = true;
            this.lblIlAppID.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblIlAppID.Location = new System.Drawing.Point(276, 21);
            this.lblIlAppID.Name = "lblIlAppID";
            this.lblIlAppID.Size = new System.Drawing.Size(64, 22);
            this.lblIlAppID.TabIndex = 1;
            this.lblIlAppID.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "I.D.L. Application ID :";
            // 
            // ctrlLocalLicenseInfoWithFilter1
            // 
            this.ctrlLocalLicenseInfoWithFilter1.Location = new System.Drawing.Point(2, 73);
            this.ctrlLocalLicenseInfoWithFilter1.Name = "ctrlLocalLicenseInfoWithFilter1";
            this.ctrlLocalLicenseInfoWithFilter1.Size = new System.Drawing.Size(969, 338);
            this.ctrlLocalLicenseInfoWithFilter1.TabIndex = 0;
            this.ctrlLocalLicenseInfoWithFilter1.OnLicenseExists += new System.Action<int>(this.ctrlLocalLicenseInfoWithFilter1_OnLicenseExists);
            this.ctrlLocalLicenseInfoWithFilter1.OnLicenseDoesNotExist += new System.Action(this.ctrlLocalLicenseInfoWithFilter1_OnLicenseDoesNotExist);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Noto Sans JP Medium", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SpringGreen;
            this.label3.Location = new System.Drawing.Point(203, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(596, 61);
            this.label3.TabIndex = 20;
            this.label3.Text = "Issue International License";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddNewInternationalLicense
            // 
            this.AcceptButton = this.btnIssue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(974, 685);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.ctrlLocalLicenseInfoWithFilter1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNewInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue New International License";
            this.Load += new System.EventHandler(this.frmAddNewInternationalLicense_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLdlId;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblIssue;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIlID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIlAppID;
        private System.Windows.Forms.Label label1;
        private Licenses.Controls.ctrlLocalLicenseInfoWithFilter ctrlLocalLicenseInfoWithFilter1;
        private System.Windows.Forms.Label label3;
    }
}