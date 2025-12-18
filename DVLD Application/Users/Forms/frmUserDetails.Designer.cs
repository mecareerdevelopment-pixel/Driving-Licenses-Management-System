namespace DVLD_Application
{
    partial class frmUserDetails
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
            this.ctrlUserDetails1 = new DVLD_Application.ctrlUserDetails();
            this.SuspendLayout();
            // 
            // ctrlUserDetails1
            // 
            this.ctrlUserDetails1.Location = new System.Drawing.Point(12, 12);
            this.ctrlUserDetails1.Name = "ctrlUserDetails1";
            this.ctrlUserDetails1.Size = new System.Drawing.Size(1025, 457);
            this.ctrlUserDetails1.TabIndex = 0;
            this.ctrlUserDetails1.Load += new System.EventHandler(this.ctrlUserDetails1_Load);
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 467);
            this.Controls.Add(this.ctrlUserDetails1);
            this.Name = "frmUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlUserDetails ctrlUserDetails1;
    }
}