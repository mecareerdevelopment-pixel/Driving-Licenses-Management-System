namespace DVLD_Application
{
    partial class frmSetTestResult
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
            this.ctrlSetTestResult1 = new DVLD_Application.ctrlSetTestResult();
            this.SuspendLayout();
            // 
            // ctrlSetTestResult1
            // 
            this.ctrlSetTestResult1.Location = new System.Drawing.Point(1, -2);
            this.ctrlSetTestResult1.Name = "ctrlSetTestResult1";
            this.ctrlSetTestResult1.Size = new System.Drawing.Size(722, 666);
            this.ctrlSetTestResult1.TabIndex = 0;
            this.ctrlSetTestResult1.SavingTrialFinished += new System.Action(this.ctrlSetTestResult1_SavingTrialFinished);
            this.ctrlSetTestResult1.OnSavingSuccessfully += new System.Action<int>(this.ctrlSetTestResult1_OnSavingSuccessfully);
            // 
            // frmSetTestResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 676);
            this.Controls.Add(this.ctrlSetTestResult1);
            this.Name = "frmSetTestResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSetTestResult";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlSetTestResult ctrlSetTestResult1;
    }
}