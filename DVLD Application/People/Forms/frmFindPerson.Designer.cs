namespace DVLD_Application
{
    partial class frmFindPerson
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
            this.ctrlPersonInformationWithFindByFilter1 = new DVLD_Application.ctrlPersonInformationWithFindByFilter();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlPersonInformationWithFindByFilter1
            // 
            this.ctrlPersonInformationWithFindByFilter1.Location = new System.Drawing.Point(25, 94);
            this.ctrlPersonInformationWithFindByFilter1.Name = "ctrlPersonInformationWithFindByFilter1";
            this.ctrlPersonInformationWithFindByFilter1.Size = new System.Drawing.Size(1116, 449);
            this.ctrlPersonInformationWithFindByFilter1.TabIndex = 0;
            this.ctrlPersonInformationWithFindByFilter1.OnPersonFound += new System.Action<BusinessLogicTier.clsPerson>(this.ctrlPersonInformationWithFindByFilter1_OnPersonFound);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HP Simplified", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(507, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find Person";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("HP Simplified", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Application.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(982, 525);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 41);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 602);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPersonInformationWithFindByFilter1);
            this.Name = "frmFindPerson";
            this.Text = "Find Person";
            this.Load += new System.EventHandler(this.frmFindPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonInformationWithFindByFilter ctrlPersonInformationWithFindByFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}