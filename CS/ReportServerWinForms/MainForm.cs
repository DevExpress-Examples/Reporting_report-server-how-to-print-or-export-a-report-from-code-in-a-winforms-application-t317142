using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DocumentServices.ServiceModel;
using DevExpress.DocumentServices.ServiceModel.DataContracts;
using DevExpress.ReportServer.ServiceModel.Client;
using DevExpress.ReportServer.ServiceModel.ConnectionProviders;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace ReportServerWinFormsClientDemo {
    public partial class MainForm : Form {
        const string ServerAddress = "https://reportserver.devexpress.com";
        readonly ConnectionProvider serverConnection = new GuestConnectionProvider(ServerAddress);

        readonly int ReportId = 1113; //Customer Order History report
        readonly ReportParameter[] reportParameters = new ReportParameter[] {
            new ReportParameter {
                Path = "@CustomerID", 
                Value = "BERGS",
                MultiValue = false
            }};

        public MainForm() {
            InitializeComponent();
        }

        private void export2PDFReportButton_Click(object sender, EventArgs e) {
            if(saveFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }
            ExportTo(serverConnection, ReportId, new PdfExportOptions(), reportParameters, x => File.WriteAllBytes(saveFileDialog1.FileName, x));
        }

        private void printReportButton_Click(object sender, EventArgs e) {
            ExportTo(serverConnection, ReportId, new NativeFormatOptions(), reportParameters, x => PrintReportFromPrnx(x));
        }

        void PrintReportFromPrnx(byte[] prnx) {
            using(XtraReport report = new XtraReport()) {
                using(MemoryStream stream = new MemoryStream(prnx)) {
                    report.PrintingSystem.LoadDocument(stream);
                }
                report.Print("Microsoft XPS Document Writer"); //specify a printer name here
            }
        }

        void ExportTo(ConnectionProvider serverConnection, int reportId, ExportOptionsBase exportOptions, ReportParameter[] parameters, Action<byte[]> action) {
            printReportButton.Enabled = false;
            export2PDFReportButton.Enabled = false;
            splashScreenManager1.ShowWaitForm();
            serverConnection
                .ConnectAsync()
                .ContinueWith(t => {
                    IReportServerClient client = t.Result;
                    return Task.Factory.ExportReportAsync(client, new ReportIdentity(reportId), exportOptions, parameters, null);
                }).Unwrap()
                .ContinueWith(t => {
                    splashScreenManager1.CloseWaitForm();
                    printReportButton.Enabled = true;
                    export2PDFReportButton.Enabled = true;
                    try {
                        if(t.IsFaulted) {
                            throw new Exception(t.Exception.Flatten().InnerException.Message);
                        }
                        action(t.Result);
                    } catch(Exception e) {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
