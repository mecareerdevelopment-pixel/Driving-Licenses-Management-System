namespace DVLD_Application.Applications.Forms
{
    partial class frmRenewLocalDrivingLicense
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
            this.lblLdlId = new System.Windows.Forms.Label();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblIssue = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRLID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAppID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblLicenseClassFees = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.btnRenew = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ctrlLocalLicenseInfoWithFilter1 = new DVLD_Application.Licenses.Controls.ctrlLocalLicenseInfoWithFilter();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLdlId
            // 
            this.lblLdlId.AutoSize = true;
            this.lblLdlId.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLdlId.Location = new System.Drawing.Point(780, 49);
            this.lblLdlId.Name = "lblLdlId";
            this.lblLdlId.Size = new System.Drawing.Size(64, 22);
            this.lblLdlId.TabIndex = 15;
            this.lblLdlId.Text = "[????]";
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblExpDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblExpDate.Location = new System.Drawing.Point(780, 77);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(63, 22);
            this.lblExpDate.TabIndex = 14;
            this.lblExpDate.Text = "label2";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUser.Location = new System.Drawing.Point(781, 105);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(63, 22);
            this.lblUser.TabIndex = 13;
            this.lblUser.Text = "label2";
            // 
            // lblIssue
            // 
            this.lblIssue.AutoSize = true;
            this.lblIssue.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblIssue.ForeColor = System.Drawing.Color.Green;
            this.lblIssue.Location = new System.Drawing.Point(276, 77);
            this.lblIssue.Name = "lblIssue";
            this.lblIssue.Size = new System.Drawing.Size(63, 22);
            this.lblIssue.TabIndex = 12;
            this.lblIssue.Text = "label2";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAppFees.Location = new System.Drawing.Point(276, 105);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(63, 22);
            this.lblAppFees.TabIndex = 11;
            this.lblAppFees.Text = "label2";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAppDate.Location = new System.Drawing.Point(276, 49);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(63, 22);
            this.lblAppDate.TabIndex = 10;
            this.lblAppDate.Text = "label2";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(883, 584);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 37);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Enabled = false;
            this.linkLabel2.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(403, 594);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(133, 19);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Show New License";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(77, 594);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(217, 19);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Show Driver\'s Licenses History";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(560, 105);
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
            this.label8.Location = new System.Drawing.Point(574, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 22);
            this.label8.TabIndex = 8;
            this.label8.Text = "Expiration Date : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(47, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Application Fees :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(109, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "Issue Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(574, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Old License ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(48, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Application Date :";
            // 
            // lblRLID
            // 
            this.lblRLID.AutoSize = true;
            this.lblRLID.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRLID.Location = new System.Drawing.Point(780, 21);
            this.lblRLID.Name = "lblRLID";
            this.lblRLID.Size = new System.Drawing.Size(64, 22);
            this.lblRLID.TabIndex = 3;
            this.lblRLID.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(509, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Renewed License ID :";
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAppID.Location = new System.Drawing.Point(276, 21);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(64, 22);
            this.lblAppID.TabIndex = 1;
            this.lblAppID.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(74, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application ID :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalFees);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblLicenseClassFees);
            this.groupBox1.Controls.Add(this.lblLicenseFees);
            this.groupBox1.Controls.Add(this.lblLdlId);
            this.groupBox1.Controls.Add(this.lblExpDate);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.lblIssue);
            this.groupBox1.Controls.Add(this.lblAppFees);
            this.groupBox1.Controls.Add(this.lblAppDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblRLID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblAppID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 163);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Renew License Application Info";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotalFees.Location = new System.Drawing.Point(781, 133);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(64, 22);
            this.lblTotalFees.TabIndex = 19;
            this.lblTotalFees.Text = "[????]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(622, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 22);
            this.label11.TabIndex = 18;
            this.label11.Text = "Total Fees : ";
            // 
            // lblLicenseClassFees
            // 
            this.lblLicenseClassFees.AutoSize = true;
            this.lblLicenseClassFees.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLicenseClassFees.Location = new System.Drawing.Point(276, 133);
            this.lblLicenseClassFees.Name = "lblLicenseClassFees";
            this.lblLicenseClassFees.Size = new System.Drawing.Size(64, 22);
            this.lblLicenseClassFees.TabIndex = 17;
            this.lblLicenseClassFees.Text = "[????]";
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLicenseFees.Location = new System.Drawing.Point(82, 133);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(157, 22);
            this.lblLicenseFees.TabIndex = 16;
            this.lblLicenseFees.Text = "License Fees :";
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.Color.White;
            this.btnRenew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRenew.Enabled = false;
            this.btnRenew.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnRenew.Location = new System.Drawing.Point(685, 568);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(162, 70);
            this.btnRenew.TabIndex = 8;
            this.btnRenew.Text = "Renew";
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(358, 510);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(563, 42);
            this.txtNotes.TabIndex = 26;
            this.txtNotes.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(9, 523);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(285, 18);
            this.label10.TabIndex = 25;
            this.label10.Text = "Notes In The Renewed License : ";
            this.label10.Visible = false;
            // 
            // ctrlLocalLicenseInfoWithFilter1
            // 
            this.ctrlLocalLicenseInfoWithFilter1.Location = new System.Drawing.Point(3, 2);
            this.ctrlLocalLicenseInfoWithFilter1.Name = "ctrlLocalLicenseInfoWithFilter1";
            this.ctrlLocalLicenseInfoWithFilter1.Size = new System.Drawing.Size(969, 338);
            this.ctrlLocalLicenseInfoWithFilter1.TabIndex = 7;
            this.ctrlLocalLicenseInfoWithFilter1.OnLicenseExists += new System.Action<int>(this.ctrlLocalLicenseInfoWithFilter1_OnLicenseExists);
            this.ctrlLocalLicenseInfoWithFilter1.OnLicenseDoesNotExist += new System.Action(this.ctrlLocalLicenseInfoWithFilter1_OnLicenseDoesNotExist);
            // 
            // frmRenewLocalDrivingLicense
            // 
            this.AcceptButton = this.btnRenew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(975, 661);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlLocalLicenseInfoWithFilter1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRenew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRenewLocalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Local Driving License";
            this.Load += new System.EventHandler(this.frmRenewLocalDrivingLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.Controls.ctrlLocalLicenseInfoWithFilter ctrlLocalLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lblLdlId;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblIssue;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRLID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Label lblLicenseClassFees;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label10;
    }
}