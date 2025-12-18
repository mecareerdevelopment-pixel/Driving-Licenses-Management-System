namespace DVLD_Application.Applications.Forms
{
    partial class frmReleaseDetainedLicense
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
            this.btnRelease = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblUserR = new System.Windows.Forms.Label();
            this.lblRUser = new System.Windows.Forms.Label();
            this.lblFine = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDLID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAppID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblUserD = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblDDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlLocalLicenseInfoWithFilter1 = new DVLD_Application.Licenses.Controls.ctrlLocalLicenseInfoWithFilter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRelease
            // 
            this.btnRelease.BackColor = System.Drawing.Color.White;
            this.btnRelease.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRelease.Enabled = false;
            this.btnRelease.Font = new System.Drawing.Font("Noto Serif JP", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnRelease.Location = new System.Drawing.Point(594, 617);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(191, 70);
            this.btnRelease.TabIndex = 23;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = false;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(180, 643);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(217, 19);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Show Driver\'s Licenses History";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(859, 634);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 37);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans JP", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(301, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(467, 52);
            this.label3.TabIndex = 27;
            this.label3.Text = "Release Detained License";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblUserR);
            this.groupBox1.Controls.Add(this.lblRUser);
            this.groupBox1.Controls.Add(this.lblFine);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblDLID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblAppID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblTotalFees);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblUserD);
            this.groupBox1.Controls.Add(this.lblAppFees);
            this.groupBox1.Controls.Add(this.lblDDate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblDID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(0, 425);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 177);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detain and Release Application Info";
            // 
            // lblRDate
            // 
            this.lblRDate.AutoSize = true;
            this.lblRDate.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRDate.ForeColor = System.Drawing.Color.Green;
            this.lblRDate.Location = new System.Drawing.Point(765, 49);
            this.lblRDate.Name = "lblRDate";
            this.lblRDate.Size = new System.Drawing.Size(64, 22);
            this.lblRDate.TabIndex = 31;
            this.lblRDate.Text = "[????]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(573, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 22);
            this.label9.TabIndex = 30;
            this.label9.Text = "Release Date :";
            // 
            // lblUserR
            // 
            this.lblUserR.AutoSize = true;
            this.lblUserR.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUserR.ForeColor = System.Drawing.Color.Green;
            this.lblUserR.Location = new System.Drawing.Point(765, 133);
            this.lblUserR.Name = "lblUserR";
            this.lblUserR.Size = new System.Drawing.Size(64, 22);
            this.lblUserR.TabIndex = 29;
            this.lblUserR.Text = "[????]";
            // 
            // lblRUser
            // 
            this.lblRUser.AutoSize = true;
            this.lblRUser.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRUser.ForeColor = System.Drawing.Color.Green;
            this.lblRUser.Location = new System.Drawing.Point(519, 133);
            this.lblRUser.Name = "lblRUser";
            this.lblRUser.Size = new System.Drawing.Size(211, 22);
            this.lblRUser.TabIndex = 28;
            this.lblRUser.Text = "Released By User : ";
            // 
            // lblFine
            // 
            this.lblFine.AutoSize = true;
            this.lblFine.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFine.ForeColor = System.Drawing.Color.Maroon;
            this.lblFine.Location = new System.Drawing.Point(276, 77);
            this.lblFine.Name = "lblFine";
            this.lblFine.Size = new System.Drawing.Size(64, 22);
            this.lblFine.TabIndex = 27;
            this.lblFine.Text = "[????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(91, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 22);
            this.label5.TabIndex = 26;
            this.label5.Text = "Fine Amount :";
            // 
            // lblDLID
            // 
            this.lblDLID.AutoSize = true;
            this.lblDLID.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDLID.ForeColor = System.Drawing.Color.Maroon;
            this.lblDLID.Location = new System.Drawing.Point(276, 105);
            this.lblDLID.Name = "lblDLID";
            this.lblDLID.Size = new System.Drawing.Size(64, 22);
            this.lblDLID.TabIndex = 23;
            this.lblDLID.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 22);
            this.label4.TabIndex = 22;
            this.label4.Text = "Detained License ID : ";
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAppID.ForeColor = System.Drawing.Color.Green;
            this.lblAppID.Location = new System.Drawing.Point(764, 21);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(64, 22);
            this.lblAppID.TabIndex = 21;
            this.lblAppID.Text = "[????]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(551, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 22);
            this.label8.TabIndex = 20;
            this.label8.Text = "Application ID :";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotalFees.ForeColor = System.Drawing.Color.Green;
            this.lblTotalFees.Location = new System.Drawing.Point(764, 105);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(64, 22);
            this.lblTotalFees.TabIndex = 19;
            this.lblTotalFees.Text = "[????]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(605, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 22);
            this.label11.TabIndex = 18;
            this.label11.Text = "Total Fees : ";
            // 
            // lblUserD
            // 
            this.lblUserD.AutoSize = true;
            this.lblUserD.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUserD.ForeColor = System.Drawing.Color.Maroon;
            this.lblUserD.Location = new System.Drawing.Point(278, 136);
            this.lblUserD.Name = "lblUserD";
            this.lblUserD.Size = new System.Drawing.Size(64, 22);
            this.lblUserD.TabIndex = 13;
            this.lblUserD.Text = "[????]";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAppFees.ForeColor = System.Drawing.Color.Green;
            this.lblAppFees.Location = new System.Drawing.Point(767, 77);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(63, 22);
            this.lblAppFees.TabIndex = 11;
            this.lblAppFees.Text = "label2";
            // 
            // lblDDate
            // 
            this.lblDDate.AutoSize = true;
            this.lblDDate.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDDate.ForeColor = System.Drawing.Color.Maroon;
            this.lblDDate.Location = new System.Drawing.Point(276, 49);
            this.lblDDate.Name = "lblDDate";
            this.lblDDate.Size = new System.Drawing.Size(64, 22);
            this.lblDDate.TabIndex = 10;
            this.lblDDate.Text = "[????]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(38, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(209, 22);
            this.label10.TabIndex = 9;
            this.label10.Text = "Detained By User : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(538, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Application Fees :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(91, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Detain Date :";
            // 
            // lblDID
            // 
            this.lblDID.AutoSize = true;
            this.lblDID.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDID.ForeColor = System.Drawing.Color.Maroon;
            this.lblDID.Location = new System.Drawing.Point(275, 21);
            this.lblDID.Name = "lblDID";
            this.lblDID.Size = new System.Drawing.Size(64, 22);
            this.lblDID.TabIndex = 1;
            this.lblDID.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(117, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detain ID : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Application.Properties.Resources.Release_Detained_License_64;
            this.pictureBox1.Location = new System.Drawing.Point(212, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlLocalLicenseInfoWithFilter1
            // 
            this.ctrlLocalLicenseInfoWithFilter1.Location = new System.Drawing.Point(0, 83);
            this.ctrlLocalLicenseInfoWithFilter1.Name = "ctrlLocalLicenseInfoWithFilter1";
            this.ctrlLocalLicenseInfoWithFilter1.Size = new System.Drawing.Size(973, 336);
            this.ctrlLocalLicenseInfoWithFilter1.TabIndex = 20;
            this.ctrlLocalLicenseInfoWithFilter1.OnLicenseExists += new System.Action<int>(this.ctrlLocalLicenseInfoWithFilter1_OnLicenseExists);
            this.ctrlLocalLicenseInfoWithFilter1.OnLicenseDoesNotExist += new System.Action(this.ctrlLocalLicenseInfoWithFilter1_OnLicenseDoesNotExist);
            // 
            // frmReleaseDetainedLicense
            // 
            this.AcceptButton = this.btnRelease;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(972, 699);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.ctrlLocalLicenseInfoWithFilter1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReleaseDetainedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReleaseDetainedLicense";
            this.Load += new System.EventHandler(this.frmReleaseDetainedLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRelease;
        private Licenses.Controls.ctrlLocalLicenseInfoWithFilter ctrlLocalLicenseInfoWithFilter1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUserD;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblDDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDLID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUserR;
        private System.Windows.Forms.Label lblRUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRDate;
        private System.Windows.Forms.Label label9;
    }
}