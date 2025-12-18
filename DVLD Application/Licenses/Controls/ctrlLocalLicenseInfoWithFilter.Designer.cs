namespace DVLD_Application.Licenses.Controls
{
    partial class ctrlLocalLicenseInfoWithFilter
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
            this.btnFindLicenseWithID = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ctrlDriverLicenseInfo1 = new DVLD_Application.ctrlLocalLicenseInfo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindLicenseWithID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter License ID";
            // 
            // btnFindLicenseWithID
            // 
            this.btnFindLicenseWithID.Image = global::DVLD_Application.Properties.Resources.License_View_32;
            this.btnFindLicenseWithID.Location = new System.Drawing.Point(707, 14);
            this.btnFindLicenseWithID.Name = "btnFindLicenseWithID";
            this.btnFindLicenseWithID.Size = new System.Drawing.Size(60, 55);
            this.btnFindLicenseWithID.TabIndex = 2;
            this.btnFindLicenseWithID.UseVisualStyleBackColor = true;
            this.btnFindLicenseWithID.Click += new System.EventHandler(this.btnFindLicenseWithID_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Local License ID : ";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(312, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(295, 35);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(3, 78);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(968, 263);
            this.ctrlDriverLicenseInfo1.TabIndex = 1;
            // 
            // ctrlLocalLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlLocalLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(969, 344);
            this.Load += new System.EventHandler(this.ctrlFindLicenseWithFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private ctrlLocalLicenseInfo ctrlDriverLicenseInfo1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFindLicenseWithID;
    }
}
