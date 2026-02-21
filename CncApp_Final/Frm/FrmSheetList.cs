using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Helper;
using CncApp_Final.Helpers;
using CncApp_Final.Services;
using DevExpress.Data;
using DevExpress.Data.Controls.ExpressionEditor;
using DevExpress.Data.Controls.ExpressionEditor.Native;
using DevExpress.Data.ExpressionEditor;
using DevExpress.DataAccess.ExpressionEditor.Localization;
using DevExpress.DataAccess.UI.ExpressionEditor;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Design;
using DevExpress.XtraEditors.ExpressionEditor;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Internal;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraVerticalGrid.Events;
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
using UnboundExpressionEditorEventArgs = DevExpress.XtraGrid.Views.Base.UnboundExpressionEditorEventArgs;

namespace CncApp_Final.Frm
{
    public partial class FrmSheetList : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private int focusedRowHandel;
        private int topRowIndex;

        public FrmSheetList()
        {
            InitializeComponent();
            
            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Sheets.Load();
            sheetsBindingSource.DataSource = dbContext.Sheets.Local.ToBindingList();
            bsiRecordsCount.Caption = "RECORDS : " + dbContext.Sheets.Local.Count;

            InitFormExtraConfig();
        }

        private void InitFormExtraConfig()
        {
            ControlExraInit.InitRibonControl(ribbonControl, "لیست ورق ها");
            ControlExraInit.InitGridView(gridView, "لیست ورق ها");
        }

        private void FrmSheetList_Load(object sender, EventArgs e)
        {
            //GridLayoutHelper.LoadLayout(
            //                            gridView,
            //                            1,
            //                            this.Name);
        }

        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************



        private void ReLoadList(int _NewRow_Id)
        {
            SavePosition();

            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Sheets.Load();
            sheetsBindingSource.DataSource = dbContext.Sheets.Local.ToBindingList();

            if (_NewRow_Id == 0)
                RestorePosition();
            else
                RestorePosition(_NewRow_Id);
        }

        public void SavePosition()
        {
            gridView = (GridView)this.gridControl.MainView;
            focusedRowHandel = gridView.FocusedRowHandle;
            topRowIndex = gridView.TopRowIndex;
        }

        public void RestorePosition()
        {
            gridView.FocusedRowHandle = focusedRowHandel;
            gridView.TopRowIndex = topRowIndex;
        }

        public void RestorePosition(int _NewRow_Id)
        {
            gridView.FocusedRowHandle = gridView.LocateByValue("Id", _NewRow_Id);
        }



        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************


        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FrmSheetEdit frmsheetEdit = new FrmSheetEdit(0, false,ReLoadList);
            //frmsheetEdit.ShowDialog();
            //if (frmsheetEdit.DialogResult == DialogResult.OK)
            //{
            //    ReLoadList(frmsheetEdit._NewCreatedRecordtId);
            //}


            var service = new EfCrudService<Sheet>(new AppDbContext());
            var frm = new Frms.EditForms.FrmSheetEdit(0, false, service);
            frm.ChangesSaved += (s, args) =>
            {
                ReLoadList(args.RecordId);
            };
            frm.ShowDialog();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ribbonControl.BeginInit();
            //int sheet_Id = (int)gridView.GetFocusedRowCellValue(colId);
            //FrmSheetEdit frmsheetEdit = new FrmSheetEdit(sheet_Id, false, ReLoadList);
            //frmsheetEdit.ShowDialog();
            //if (frmsheetEdit.DialogResult == DialogResult.OK)
            //{
            //    ReLoadList(0);
            //}
            //ribbonControl.EndInit();


            int sheet_Id = (int)gridView.GetFocusedRowCellValue(colId);
            var service = new EfCrudService<Sheet>(new AppDbContext());
            var frm = new Frms.EditForms.FrmSheetEdit(sheet_Id, false, service);
            frm.ChangesSaved += (s, args) =>
            {
                ReLoadList(sheet_Id);
            };
            frm.ShowDialog();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReLoadList(0);
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }



        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************



        //******************************************************************************************************************************
        //******************************************************************************************************************************
        //******************************************************************************************************************************


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

            ShowUnboundExpressionEditor(colExpression);
        }

        private void gridView_UnboundExpressionEditorCreated(object sender, DevExpress.XtraGrid.Views.Base.UnboundExpressionEditorEventArgs e)
        {
            ((ExpressionEditorView)e.ExpressionEditorView).Text = "سلام";

           
        }



        //******************************************************************************************************************************
        //******************************************************************************************************************************
        //******************************************************************************************************************************


        //
        // Summary:
        //     Invokes an Expression Editor that enables editing an expression for the specified
        //     unbound column.
        //
        // Parameters:
        //   column:
        //     A DevExpress.XtraGrid.Columns.GridColumn that represents an unbound column whose
        //     expression will be edited in the Expression Editor.

        private ColumnViewOptionsBehavior optionsBehavior;
        public void ShowUnboundExpressionEditor(GridColumn column)
        {
            IDataColumnInfo context = new GridColumnIDataColumnInfoWrapper(column, GridColumnIDataColumnInfoWrapperEnum.ExpressionEditor);
            if (true /*WindowsFormsSettings.GetExpressionEditorMode(OptionsBehavior.UnboundColumnExpressionEditorMode) == ExpressionEditorMode.AutoComplete && ExpressionEditorHelper.IsAutoCompleteExpressionEditorExisted*/)
            {
                IExpressionEditorView expressionEditorView = ExpressionEditorHelper.GetExpressionEditorView(gridControl.LookAndFeel, gridControl.MenuManager, gridView.GridControl);
                ((ExpressionEditorView)expressionEditorView).Text = "Hi";
                ((ExpressionEditorView)expressionEditorView).Size = new Size (((ExpressionEditorView)expressionEditorView).Size.Width , ((ExpressionEditorView)expressionEditorView).MinimumSize.Height);
                //((ExpressionEditorView)expressionEditorView).Size = ((ExpressionEditorView)expressionEditorView).MinimumSize;
                try
                {
                    ExpressionEditorContext expressionEditorContext = ExpressionEditorHelper.GetExpressionEditorContext(base.LookAndFeel, context);
                    List<IBoundProperty> expressionEditorUnboundProperties = EnsureExpressionEditorContextColumns(column, expressionEditorContext);
                    UnboundExpressionEditorEventArgs unboundExpressionEditorEventArgs = new UnboundExpressionEditorEventArgs(column, column.UnboundExpression, expressionEditorView, expressionEditorContext, context);
                    //OnUnboundExpressionEditorCreated(unboundExpressionEditorEventArgs);
                    if (!unboundExpressionEditorEventArgs.ShowExpressionEditor)
                    {
                        return;
                    }

                    string expressionString = (unboundExpressionEditorEventArgs.ConvertExpressionStringToCaption ? UnboundExpressionConvertHelper.ConvertToCaption(context, unboundExpressionEditorEventArgs.ExpressionString, expressionEditorUnboundProperties) : unboundExpressionEditorEventArgs.ExpressionString);
                    if (ExpressionEditorUIHelper.RunExpressionEditor(ref expressionString, unboundExpressionEditorEventArgs.ExpressionEditorView, unboundExpressionEditorEventArgs.ExpressionEditorContext, delegate (string e)
                    {
                        string expression = UnboundExpressionConvertHelper.ConvertToFields(context, e, expressionEditorUnboundProperties);
                        try
                        {
                            UnboundExpressionConvertHelper.ValidateExpressionFields(context, expression, expressionEditorUnboundProperties);
                            return (string)null;
                        }
                        catch
                        {
                            return Localizer.Active.GetLocalizedString(StringId.FilterCriteriaInvalidExpressionEx);
                        }
                    }))
                    {
                        if (unboundExpressionEditorEventArgs.ConvertExpressionStringToCaption)
                        {
                            column.UnboundExpression = UnboundExpressionConvertHelper.ConvertToFields(context, expressionString, expressionEditorUnboundProperties);
                        }
                        else
                        {
                            column.UnboundExpression = expressionString;
                        }
                    }

                    return;
                }
                finally
                {
                    if (expressionEditorView is IDisposable)
                    {
                        ((IDisposable)expressionEditorView).Dispose();
                    }
                }
            }

            //ShowSimpleUnboundExpressionEditor(column, context);
        }

        //private void ShowSimpleUnboundExpressionEditor(GridColumn column, IDataColumnInfo context)
        //{
        //    ExpressionEditorForm expressionEditorForm = new UnboundColumnExpressionEditorForm(context, null);
        //    if (gridView.GridControl != null)
        //    {
        //        expressionEditorForm.SetMenuManager(gridView.GridControl.MenuManager);
        //    }

        //    expressionEditorForm.StartPosition = FormStartPosition.CenterParent;
        //    //InitDialogFormProperties(expressionEditorForm);
        //    //UnboundExpressionEditorEventArgs unboundExpressionEditorEventArgs = new UnboundExpressionEditorEventArgs(expressionEditorForm, column);
        //    //OnUnboundExpressionEditorCreated(unboundExpressionEditorEventArgs);
        //    //if (unboundExpressionEditorEventArgs.ShowExpressionEditor && GetFormResult(expressionEditorForm) == DialogResult.OK)
        //    //{
        //    //    column.UnboundExpression = expressionEditorForm.Expression;
        //    //}

        //    if (GetFormResult(expressionEditorForm) == DialogResult.OK)
        //    {
        //        column.UnboundExpression = expressionEditorForm.Expression;
        //    }
        //}

        //private DialogResult GetFormResult(Form frm)
        //{
        //    if (gridView.GridControl != null && gridView.GridControl.FindForm() != null)
        //    {
        //        return frm.ShowDialog(gridView.GridControl.FindForm());
        //    }

        //    return frm.ShowDialog();
        //}


        private List<IBoundProperty> EnsureExpressionEditorContextColumns(GridColumn column, ExpressionEditorContext expressionEditorContext)
        {
            if (column.View == null)
            {
                return null;
            }

            return EnsureExpressionEditorContextColumns(column.View.Columns, expressionEditorContext);
        }

        private List<IBoundProperty> EnsureExpressionEditorContextColumns(GridColumnCollection viewColumns, ExpressionEditorContext expressionEditorContext)
        {
            List<IBoundProperty> list = null;
            List<ColumnInfo> list2 = expressionEditorContext.Columns;
            for (int num = list2.Count - 1; num > 0; num--)
            {
                GridColumn gridColumn = viewColumns[list2[num].Name];
                if (gridColumn == null && list2[num] is IBoundProperty boundProperty)
                {
                    gridColumn = viewColumns[BoundPropertyWrapper.Unwrap(boundProperty).Name];
                    if (gridColumn == null && boundProperty != null)
                    {
                        list = list ?? new List<IBoundProperty>();
                        list.Add(boundProperty);
                    }
                }

                if (gridColumn != null && !gridColumn.OptionsColumn.ShowInExpressionEditor)
                {
                    list2.RemoveAt(num);
                }
            }

            return list;
        }



        //******************************************************************************************************************************
        //******************************************************************************************************************************
        //******************************************************************************************************************************
    
    }
}