namespace ReportServerWinFormsClientDemo
{
    partial class MainForm
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
            this.printReportButton = new System.Windows.Forms.Button();
            this.export2PDFReportButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ReportServerWinFormsClientDemo.WaitForm1), true, true);
            this.SuspendLayout();
            // 
            // printReportButton
            // 
            this.printReportButton.Location = new System.Drawing.Point(170, 12);
            this.printReportButton.Name = "printReportButton";
            this.printReportButton.Size = new System.Drawing.Size(115, 23);
            this.printReportButton.TabIndex = 0;
            this.printReportButton.Text = "Print...";
            this.printReportButton.UseVisualStyleBackColor = true;
            this.printReportButton.Click += new System.EventHandler(this.printReportButton_Click);
            // 
            // export2PDFReportButton
            // 
            this.export2PDFReportButton.Location = new System.Drawing.Point(13, 12);
            this.export2PDFReportButton.Name = "export2PDFReportButton";
            this.export2PDFReportButton.Size = new System.Drawing.Size(115, 23);
            this.export2PDFReportButton.TabIndex = 3;
            this.export2PDFReportButton.Text = "Export to PDF";
            this.export2PDFReportButton.UseVisualStyleBackColor = true;
            this.export2PDFReportButton.Click += new System.EventHandler(this.export2PDFReportButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 46);
            this.Controls.Add(this.export2PDFReportButton);
            this.Controls.Add(this.printReportButton);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printReportButton;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Button export2PDFReportButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

