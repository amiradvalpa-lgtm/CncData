using CncApp_Final.Entities;
using CncApp_Final.Helper;
using CncApp_Final.Helpers;
using DevExpress.DataAccess.ExpressionEditor.Localization;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace CncApp_Final.Frm
{
    public partial class FrmSheetList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmSheetList()
        {
            InitializeComponent();
            
            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Sheets.Load();
            sheetsBindingSource.DataSource = dbContext.Sheets.Local.ToBindingList();
            bsiRecordsCount.Caption = "RECORDS : " + dbContext.Sheets.Local.Count;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void FrmSheetList_Load(object sender, EventArgs e)
        {
            //GridLayoutHelper.LoadLayout(
            //                            gridView,
            //                            1,
            //                            this.Name);

            ControlExraInit.InitRibonControl(ribbonControl, "ورود به انبار جدید");

        }

        private void bbiSheetPriceFilter_ItemClick(object sender, ItemClickEventArgs e)
        {
            // گرفتن ردیف فعلی (فوکوس‌شده)
            int rowHandle = gridView.FocusedRowHandle;
            if (rowHandle < 0) return; // هیچ ردیفی انتخاب نشده

            Color backColor = gridView.Appearance.FocusedRow.BackColor;
            gridView.Appearance.FocusedRow.BackColor = Color.LightGreen;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceHideSelection = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;


            //gridView.RefreshRow(rowHandle);
            //gridView.GridControl.Update();



            Sheet currentSheet = gridView.GetRow(rowHandle) as Sheet;
            if (currentSheet == null) return;

            // پیدا کردن ستون unbound مخفی
            GridColumn colExpression = colTempExpression;
            if (colExpression == null) return;

            // قرار دادن فرمول فعلی ردیف در UnboundExpression ستون
            colExpression.UnboundExpression = currentSheet.SheetPriceFormula ?? "";

            // فراخوانی Expression Editor داخلی گرید برای این ستون
            gridView.ShowUnboundExpressionEditor(colExpression);

            // بعد از بستن editor (OK یا Cancel)، چک کن آیا OK زده شده
            // DevExpress خودش ذخیره می‌کنه، پس مستقیم بگیری
            string newFormula = colExpression.UnboundExpression ?? "";

            // ذخیره فرمول جدید در ردیف
            currentSheet.SheetPriceFormula = newFormula;

            // محاسبه مجدد قیمت برای این ردیف
            SheetCalculator.Calculate(currentSheet);

            // به‌روزرسانی سلول‌ها در گرید
            gridView.RefreshRow(rowHandle);



            gridView.Appearance.FocusedRow.BackColor = backColor;
            gridView.Appearance.FocusedRow.Options.UseBackColor = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
        }

        private void gridView_UnboundExpressionEditorCreated(object sender, DevExpress.XtraGrid.Views.Base.UnboundExpressionEditorEventArgs e)
        {
            //e.ExpressionEditorView.

           
        }
    }



    

}