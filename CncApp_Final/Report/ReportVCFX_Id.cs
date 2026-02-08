using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace CncApp_Final.Report
{
    public partial class ReportVCFX_Id : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportVCFX_Id()
        {
            InitializeComponent();
        }

        private void DetailReport_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            DetailReportBand xx = sender as DetailReportBand;
            xx.Visible = false;
        }

        private void DetailReport1_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            DetailReportBand xx = sender as DetailReportBand;
            xx.Visible = false;
        }
    }
}
