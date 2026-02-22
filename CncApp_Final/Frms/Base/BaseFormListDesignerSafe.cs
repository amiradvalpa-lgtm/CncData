using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CncApp_Final.Frms.Base
{
    /// <summary>
    /// کلاس Designer Safe برای BaseFormList
    /// فرم‌های فرزند لیست در Designer از این کلاس ارث‌بری می‌کنند
    /// و در Runtime به صورت خودکار به BaseFormList سوئیچ می‌شوند
    /// </summary>
    public class BaseFormListDesignerSafe : RibbonForm
    {
        protected BindingSource EntityBindingSource { get; set; }

        // ======================================================
        // Constructors
        // ======================================================

        public BaseFormListDesignerSafe()
        {
            // فقط برای Designer
        }

        public BaseFormListDesignerSafe(object listService)
        {
            // فقط برای Designer
        }

        // ======================================================
        // Load
        // ======================================================

        protected virtual void BaseFormList_Load(object sender, EventArgs e) { }

        // ======================================================
        // Control Providers
        // ======================================================

        protected virtual RibbonControl GetRibbonControl() => null;
        protected virtual GridControl GetGridControl() => null;
        protected virtual GridView GetGridView() => null;
        protected virtual BarButtonItem GetNewButton() => null;
        protected virtual BarButtonItem GetEditButton() => null;
        protected virtual BarButtonItem GetDeleteButton() => null;
        protected virtual BarButtonItem GetRefreshButton() => null;
        protected virtual BarButtonItem GetPrintPreviewButton() => null;
        protected virtual BarStaticItem GetRecordsCountItem() => null;

        // ======================================================
        // Titles & Forms
        // ======================================================

        protected virtual string GetFormTitle() => string.Empty;
        protected virtual IEditForm CreateEditForm(int id, bool isReadOnly) => null;

        // ======================================================
        // Data
        // ======================================================

        protected virtual void LoadData() { }
        protected virtual void ReLoadList(int newRowId = 0) { }
        protected virtual int GetFocusedRowId() => 0;

        // ======================================================
        // Hooks
        // ======================================================

        protected virtual void BeforeDelete() { }
        protected virtual void AfterDelete() { }

        // ======================================================
        // Button Events
        // ======================================================

        protected virtual void bbiNew_ItemClick(object sender, ItemClickEventArgs e) { }
        protected virtual void bbiEdit_ItemClick(object sender, ItemClickEventArgs e) { }
        protected virtual void bbiDelete_ItemClick(object sender, ItemClickEventArgs e) { }
        protected virtual void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e) { }
        protected virtual void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e) { }
    }
}