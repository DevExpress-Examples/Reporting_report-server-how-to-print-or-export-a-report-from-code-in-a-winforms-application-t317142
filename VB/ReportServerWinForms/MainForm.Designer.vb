Namespace ReportServerWinFormsClientDemo
    Partial Public Class MainForm
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.printReportButton = New System.Windows.Forms.Button()
            Me.export2PDFReportButton = New System.Windows.Forms.Button()
            Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
            Me.splashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.ReportServerWinFormsClientDemo.WaitForm1), True, True)
            Me.SuspendLayout()
            ' 
            ' printReportButton
            ' 
            Me.printReportButton.Location = New System.Drawing.Point(170, 12)
            Me.printReportButton.Name = "printReportButton"
            Me.printReportButton.Size = New System.Drawing.Size(115, 23)
            Me.printReportButton.TabIndex = 0
            Me.printReportButton.Text = "Print..."
            Me.printReportButton.UseVisualStyleBackColor = True
            ' 
            ' export2PDFReportButton
            ' 
            Me.export2PDFReportButton.Location = New System.Drawing.Point(13, 12)
            Me.export2PDFReportButton.Name = "export2PDFReportButton"
            Me.export2PDFReportButton.Size = New System.Drawing.Size(115, 23)
            Me.export2PDFReportButton.TabIndex = 3
            Me.export2PDFReportButton.Text = "Export to PDF"
            Me.export2PDFReportButton.UseVisualStyleBackColor = True
            ' 
            ' saveFileDialog1
            ' 
            Me.saveFileDialog1.DefaultExt = "pdf"
            Me.saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"
            ' 
            ' MainForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(298, 46)
            Me.Controls.Add(Me.export2PDFReportButton)
            Me.Controls.Add(Me.printReportButton)
            Me.Name = "MainForm"
            Me.Text = "Main Form"
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents printReportButton As System.Windows.Forms.Button
        Private splashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
        Private WithEvents export2PDFReportButton As System.Windows.Forms.Button
        Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    End Class
End Namespace

