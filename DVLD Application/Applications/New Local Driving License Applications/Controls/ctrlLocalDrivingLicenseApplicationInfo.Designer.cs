namespace DVLD_Application
{
    partial class ctrlLocalDrivingLicenseApplicationInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPassed = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ctrlApplicationBasicInfo1 = new DVLD_Application.ctrlApplicationBasicInfo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.lblPassed);
            this.groupBox1.Controls.Add(this.lblClass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 122);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local Driving License Application Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblPassed
            // 
            this.lblPassed.AutoSize = true;
            this.lblPassed.Location = new System.Drawing.Point(463, 92);
            this.lblPassed.Name = "lblPassed";
            this.lblPassed.Size = new System.Drawing.Size(52, 18);
            this.lblPassed.TabIndex = 7;
            this.lblPassed.Text = "label2";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(463, 65);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(52, 18);
            this.lblClass.TabIndex = 6;
            this.lblClass.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(304, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Passed Tests : ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(178, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Applied For License Class :  ";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(463, 38);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(52, 18);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Local Driving License Application ID : ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.linkLabel1.Location = new System.Drawing.Point(607, 92);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(144, 18);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Show License Info";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ctrlApplicationBasicInfo1
            // 
            this.ctrlApplicationBasicInfo1.Location = new System.Drawing.Point(3, 126);
            this.ctrlApplicationBasicInfo1.Name = "ctrlApplicationBasicInfo1";
            this.ctrlApplicationBasicInfo1.Size = new System.Drawing.Size(787, 151);
            this.ctrlApplicationBasicInfo1.TabIndex = 0;
            // 
            // ctrlLocalDrivingLicenseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlApplicationBasicInfo1);
            this.Name = "ctrlLocalDrivingLicenseApplicationInfo";
            this.Size = new System.Drawing.Size(793, 280);
            this.Load += new System.EventHandler(this.ctrlLocalDrivingLicenseApplication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlApplicationBasicInfo ctrlApplicationBasicInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPassed;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
