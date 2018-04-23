Imports System
Imports DevExpress.XtraWaitForm

Namespace ReportServerWinFormsClientDemo
    Partial Public Class WaitForm1
        Inherits WaitForm

        Public Sub New()
            InitializeComponent()
            Me.progressPanel1.AutoHeight = True
        End Sub

        #Region "Overrides"

        Public Overrides Sub SetCaption(ByVal caption As String)
            MyBase.SetCaption(caption)
            Me.progressPanel1.Caption = caption
        End Sub
        Public Overrides Sub SetDescription(ByVal description As String)
            MyBase.SetDescription(description)
            Me.progressPanel1.Description = description
        End Sub
        Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
            MyBase.ProcessCommand(cmd, arg)
        End Sub

        #End Region
    End Class
End Namespace
