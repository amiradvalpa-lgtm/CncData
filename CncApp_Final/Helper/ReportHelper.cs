using DevExpress.Charts.Native;
using DevExpress.DataAccess.Native.EntityFramework;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
//using Holoo1Space.DataSet.AlpaDataSetTableAdapters;
using CncApp_Final.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncApp_Final.Helper
{
    internal static class ReportHelper
    {
        ////internal static async void PrintVCFX_List(string VCF_Ids)
        ////{
        ////    ReportVCFXSummary report = new ReportVCFXSummary();

        ////    report.DataSource = await FillDatabaseVCFX(VCF_Ids);

        ////    #region   Temp Code


        ////    //reportX.DataSource = await FillDatabaseX(ids);


        ////    //SqlDataSource ds = (SqlDataSource)reportX.DataSource;
        ////    //int vcf_id = (int)gridView1.GetFocusedRowCellValue(colVCF_Id);
        ////    //ds.Queries[0].Parameters[0].Value = vcf_id;
        ////    //ds.Queries[1].Parameters[0].Value = vcf_id;
        ////    #endregion

        ////    report.RequestParameters = false;
        ////    ReportPrintTool printTool = new ReportPrintTool(report);
        ////    printTool.ShowRibbonPreview();
        ////}

        internal static async void PrintCurrent(int VCF_Id)
        {
            ReportVCFX_Id report = new ReportVCFX_Id();

            report.DataSource = await FillDatabase(VCF_Id);
            InitBands(report);


            ////if (true)
            ////{
            ////    ReportVCFX_Id_Photo_3x3 reportPhoto_3x3 = new ReportVCFX_Id_Photo_3x3();
            ////    reportPhoto_3x3.DataSource = await FillDatabasePhoto(VCF_Id);

            ////    if (reportPhoto_3x3.DataSource != null)
            ////    {
            ////        reportPhoto_3x3.CreateDocument();
            ////        report = (ReportVCFX_Id)MergePrint(report, reportPhoto_3x3);
            ////    }
            ////}

            #region   Temp Code


            //reportX.DataSource = await FillDatabaseX(ids);


            //SqlDataSource ds = (SqlDataSource)reportX.DataSource;
            //int vcf_id = (int)gridView1.GetFocusedRowCellValue(colVCF_Id);
            //ds.Queries[0].Parameters[0].Value = vcf_id;
            //ds.Queries[1].Parameters[0].Value = vcf_id;
            #endregion

            report.RequestParameters = false;
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowRibbonPreview();
        }

        ////internal static async void PrintCurrentPhoto(int VCF_Id)
        ////{
        ////    ReportVCFX_Id_Photo_3x3 report = new ReportVCFX_Id_Photo_3x3();

        ////    report.DataSource = await FillDatabasePhoto(VCF_Id);

        ////    report.RequestParameters = false;
        ////    ReportPrintTool printTool = new ReportPrintTool(report);
        ////    printTool.ShowRibbonPreview();
        ////}

        internal static async void ExportPDFCurrent(int VCF_Id)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save an PDF File";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ReportVCFX_Id report = new ReportVCFX_Id();

                report.DataSource = await FillDatabase(VCF_Id);
                InitBands(report);
                report.ExportToPdf(saveFileDialog1.FileName);




                switch (QAZ())
                {
                    case DialogResult.OK:
                        if (File.Exists(saveFileDialog1.FileName))
                        {
                            Process.Start("explorer.exe", saveFileDialog1.FileName);
                        }
                        break;

                    case DialogResult.Retry:
                        if (File.Exists(saveFileDialog1.FileName))
                        {
                            string argument = "/select, \"" + saveFileDialog1.FileName + "\"";
                            Process.Start("explorer.exe", argument);
                        }
                        break;

                    case DialogResult.Cancel:
                        break;

                }

            }
        }

        private static DialogResult QAZ()
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = "";
            args.Text = "مایل به انجام کدام کار هستید؟";
            args.Buttons = new System.Windows.Forms.DialogResult[] { System.Windows.Forms.DialogResult.OK, DialogResult.Retry, DialogResult.Cancel };
            args.Showing += args_Showing;

            return XtraMessageBox.Show(args);
        }
        private static void  args_Showing(object sender, XtraMessageShowingArgs e)
        {
            //e.Form.Appearance.Font = new System.Drawing.Font(e.Form.Appearance.Font, FontStyle.Bold);
            e.Form.Size = new Size(500, 300);
            MessageButtonCollection buttons = e.Buttons as MessageButtonCollection;


            SimpleButton btnOpenFile = buttons[System.Windows.Forms.DialogResult.OK] as SimpleButton;
            if (btnOpenFile != null)
            {
                btnOpenFile.Text = "باز کردن فایل PDF";
                btnOpenFile.Size = btnOpenFile.CalcBestSize() + new Size(15, 0);
            }

            SimpleButton btnOpenPath = buttons[System.Windows.Forms.DialogResult.Retry] as SimpleButton;
            if (btnOpenPath != null)
            {
                btnOpenPath.Text = "باز کردن مسیر فایل";
                btnOpenPath.Size = btnOpenPath.CalcBestSize() + new Size(15, 0);
            }

            SimpleButton btnCancel = buttons[System.Windows.Forms.DialogResult.Cancel] as SimpleButton;
            if (btnCancel != null)
            {
                btnCancel.Text = "لغو";
            }
        }

        ////internal static async void PrintAll(List<int> VCF_Ids_List)
        ////{
        ////    if (VCF_Ids_List.Count > 0)
        ////    {
        ////        int vcf_Idx = VCF_Ids_List[0];

        ////        // Create the 1st report and generate its document.
        ////        ReportVCFX_Id report1X = new ReportVCFX_Id();
        ////        report1X.DataSource = await FillDatabase(vcf_Idx);
        ////        InitBands(report1X);
        ////        report1X.CreateDocument();

        ////        if (true)
        ////        {
        ////            ReportVCFX_Id_Photo_3x3 reportPhoto_3x3 = new ReportVCFX_Id_Photo_3x3();
        ////            reportPhoto_3x3.DataSource = await FillDatabasePhoto(vcf_Idx);

        ////            if (reportPhoto_3x3.DataSource != null)
        ////            {
        ////                reportPhoto_3x3.CreateDocument();
        ////                report1X = (ReportVCFX_Id)MergePrintX(report1X, reportPhoto_3x3);
        ////            }
        ////        }

        ////        //for (int index = VCF_Ids_List.Count - 1; index > 0; index--)
        ////        for (int index =  1; index < VCF_Ids_List.Count; index++)
        ////        {
        ////            int vcf_Id = VCF_Ids_List[index];

                    

        ////            // Create the 2nd report and generate its document.
        ////            ReportVCFX_Id report2x = new ReportVCFX_Id();
        ////            report2x.DataSource = await FillDatabase(vcf_Id);
        ////            InitBands(report2x);
        ////            report2x.CreateDocument();

        ////            report1X = (ReportVCFX_Id)MergePrintX(report1X, report2x);

        ////            //// Merge pages of two reports, page-by-page.
        ////            //int minPageCount = Math.Min(report1X.Pages.Count, report2x.Pages.Count);
        ////            //for (int i = 0; i < minPageCount; i++)
        ////            //{
        ////            //    report1X.Pages.Insert(i * 2 + 1, report2x.Pages[i]);
        ////            //}
        ////            //if (report2x.Pages.Count != minPageCount)
        ////            //{
        ////            //    for (int i = minPageCount; i < report2x.Pages.Count; i++)
        ////            //    {
        ////            //        report1X.Pages.Add(report2x.Pages[i]);
        ////            //    }
        ////            //}


        ////            if (true)
        ////            {
        ////                ReportVCFX_Id_Photo_3x3 reportPhoto_3x3 = new ReportVCFX_Id_Photo_3x3();
        ////                reportPhoto_3x3.DataSource = await FillDatabasePhoto(vcf_Id);

        ////                if (reportPhoto_3x3.DataSource != null)
        ////                {
        ////                    reportPhoto_3x3.CreateDocument();
        ////                    report1X = (ReportVCFX_Id)MergePrintX(report1X, reportPhoto_3x3);
        ////                }
        ////            }

        ////        }

        ////        // Reset all page numbers in the resulting document.
        ////        //report3X.PrintingSystem.ContinuousPageNumbering = true;

        ////        // Show the Print Preview form.
        ////        report1X.ShowRibbonPreview();
        ////    }
        ////}

        internal static XtraReport MergePrint(XtraReport MainReport, XtraReport SecondReport)
        {
            //MainReport.CreateDocument();

            // Merge pages of two reports, page-by-page.
            int minPageCount = Math.Min(MainReport.Pages.Count, SecondReport.Pages.Count);
            for (int i = 0; i < minPageCount; i++)
            {
                MainReport.Pages.Insert(i * 2 + 1, SecondReport.Pages[i]);
            }
            if (SecondReport.Pages.Count != minPageCount)
            {
                for (int i = minPageCount; i < SecondReport.Pages.Count; i++)
                {
                    MainReport.Pages.Add(SecondReport.Pages[i]);
                }
            }
            return MainReport;
        }

        internal static XtraReport MergePrintX(XtraReport MainReport, XtraReport SecondReport)
        {
            for (int i = 0; i < SecondReport.Pages.Count; i++)
            {
                MainReport.Pages.Add(SecondReport.Pages[i]);
            }

            
            return MainReport;
        }


        internal static void PrintSummary(List<int> list)
        {

        }

        private static void InitBands(ReportVCFX_Id report)
        {
            ////System.Data.DataSet ds = report.DataSource as System.Data.DataSet;
            ////ds.Tables.IndexOf("VCF_Cost");
            ////if (ds.Tables[ds.Tables.IndexOf("VCF_Cost")].Rows.Count == 0)
            ////{
            ////    var bands = report.Bands;
            ////    foreach (var item in bands)
            ////    {
            ////        if (item.GetType() == typeof(DevExpress.XtraReports.UI.DetailReportBand))
            ////        {
            ////            DetailReportBand dd = (DetailReportBand)item;
            ////            if (dd.DataMember == "VCF_Cost")
            ////                ((DetailReportBand)item).Visible = false;

            ////        }
            ////    }
            ////}
        }

        private static async Task<System.Data.DataSet> FillDatabase(int vcf_ID)
        {
            System.Data.DataSet ds = new System.Data.DataSet("sqlDataSource1");
            ////DataTable VCF_Cost = new DataTable("VCF_Cost");
            ////DataTable VCF_Frame = new DataTable("VCF_Frame");
            ////DataTable VCFX = new DataTable("VCFX");

            ////VCF_CostTableAdapter costTableAdapter = new VCF_CostTableAdapter();
            ////VCF_Cost = costTableAdapter.GetDataBy(vcf_ID);
            ////VCF_Cost.TableName = "VCF_Cost";
            ////ds.Tables.Add(VCF_Cost);

            ////VCF_FrameTableAdapter vCF_FrameTableAdapter = new VCF_FrameTableAdapter();
            ////VCF_Frame = vCF_FrameTableAdapter.GetDataBy(vcf_ID);
            ////VCF_Frame.TableName = "VCF_Frame";
            ////ds.Tables.Add(VCF_Frame);

            ////PrintFaktorTableAdapter printFaktorTableAdapter = new PrintFaktorTableAdapter();
            ////VCFX = printFaktorTableAdapter.GetDataBy(vcf_ID);
            ////VCFX.TableName = "VCFX";
            ////ds.Tables.Add(VCFX);

            return ds;
        }

        ////private static async Task<System.Data.DataSet> FillDatabaseVCFX(string vcf_IDs)
        ////{
        ////    System.Data.DataSet ds = new System.Data.DataSet("sqlDataSource1");
        ////    DataTable VCFX_Summary = new DataTable("VCFX_Summary");

        ////    VCFX_SummaryTableAdapter vCFX_SummaryTableAdapter = new VCFX_SummaryTableAdapter();
        ////    VCFX_Summary = vCFX_SummaryTableAdapter.GetData().Select($"VCF_Id In ({vcf_IDs})").CopyToDataTable();
        ////    VCFX_Summary.TableName = "View_VCFX_Summary";
        ////    ds.Tables.Add(VCFX_Summary);

        ////    return ds;
        ////}

        ////private static async Task<System.Data.DataSet> FillDatabasePhoto(int vcf_ID)
        ////{
        ////    var xx = await FillDatabase(vcf_ID);
        ////    DataTable dtframe = xx.Tables["VCF_Frame"];

        ////    System.Data.DataSet ds = new System.Data.DataSet("sqlDataSource1");
        ////    DataTable View_VCFX_Image = new DataTable("View_VCFX_Image");

        ////    VCF_ImageTableAdapter vCF_ImageTableAdapter = new VCF_ImageTableAdapter();
        ////    View_VCFX_Image = vCF_ImageTableAdapter.GetDataByVCF_Id(vcf_ID);
        ////    View_VCFX_Image.TableName = "View_VCFX_Image";

        ////    int radif = 1;
        ////    foreach (DataRow row in dtframe.Rows)
        ////    {
        ////        int count = 1;
        ////        foreach (DataRow rowX in View_VCFX_Image.Rows)
        ////        {
        ////            if ((int)row["id"] == (int)rowX["VCF_Details_Id"])
        ////            {
        ////                rowX["Radif"] = $"ردیف{radif} - تصویر{count}";
        ////                count++;
        ////            }
        ////        }
        ////        radif++;
        ////    }


        ////    ds.Tables.Add(View_VCFX_Image);


        ////    if (View_VCFX_Image.Rows.Count > 0)
        ////        return ds;
        ////    else
        ////        return null;
        ////}


    }
}
