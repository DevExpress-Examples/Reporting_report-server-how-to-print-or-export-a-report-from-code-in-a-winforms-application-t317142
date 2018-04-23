Imports System
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.DocumentServices.ServiceModel
Imports DevExpress.DocumentServices.ServiceModel.DataContracts
Imports DevExpress.ReportServer.ServiceModel.Client
Imports DevExpress.ReportServer.ServiceModel.ConnectionProviders
Imports DevExpress.ReportServer.ServiceModel.DataContracts
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI

Namespace ReportServerWinFormsClientDemo
    Partial Public Class MainForm
        Inherits Form

        Private Const ServerAddress As String = "https://reportserver.devexpress.com"
        Private ReadOnly serverConnection As ConnectionProvider = New GuestConnectionProvider(ServerAddress)

        Private ReadOnly ReportId As Integer = 1113 'Customer Order History report
        Private ReadOnly reportParameters() As ReportParameter = { _
            New ReportParameter With {.Path = "Northwind.CustOrderHist.@CustomerID", .Value = "BERGS", .MultiValue = False} _
        }

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub export2PDFReportButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles export2PDFReportButton.Click
            If saveFileDialog1.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
                Return
            End If
            ExportTo(serverConnection, ReportId, New PdfExportOptions(), reportParameters, Sub(x) File.WriteAllBytes(saveFileDialog1.FileName, x))
        End Sub

        Private Sub printReportButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles printReportButton.Click
            ExportTo(serverConnection, ReportId, New NativeFormatOptions(), reportParameters, Sub(x) PrintReportFromPrnx(x))
        End Sub

        Private Sub PrintReportFromPrnx(ByVal prnx() As Byte)
            Using report As New XtraReport()
                Using stream As New MemoryStream(prnx)
                    report.PrintingSystem.LoadDocument(stream)
                End Using
                report.Print("Microsoft XPS Document Writer") 'specify a printer name here
            End Using
        End Sub

        Private Sub ExportTo(ByVal serverConnection As ConnectionProvider, ByVal reportId As Integer, ByVal exportOptions As ExportOptionsBase, ByVal parameters() As ReportParameter, ByVal action As Action(Of Byte()))
            printReportButton.Enabled = False
            export2PDFReportButton.Enabled = False
            splashScreenManager1.ShowWaitForm()
            serverConnection.ConnectAsync().ContinueWith(Function(t)
                Dim client As IReportServerClient = t.Result
                Return Task.Factory.ExportReportAsync(client, New ReportIdentity(reportId), exportOptions, parameters, Nothing)
            End Function).Unwrap().ContinueWith(Sub(t)
                splashScreenManager1.CloseWaitForm()
                printReportButton.Enabled = True
                export2PDFReportButton.Enabled = True
                Try
                    If t.IsFaulted Then
                        Throw New Exception(t.Exception.Flatten().InnerException.Message)
                    End If
                    action(t.Result)
                Catch e As Exception
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
End Sub, TaskScheduler.FromCurrentSynchronizationContext())
        End Sub
    End Class
End Namespace
