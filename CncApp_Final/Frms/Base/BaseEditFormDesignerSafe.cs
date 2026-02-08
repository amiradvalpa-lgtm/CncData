using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace CncApp_Final.Frms.Base
{
    /// <summary>
    /// کلاس Designer Safe برای استفاده در Designer و Debug
    /// تمام متدهای Base را به صورت virtual یا abstract خالی پیاده سازی می‌کند
    /// </summary>
    public class BaseEditFormDesignerSafe : RibbonForm
    {
        // ======================================================
        // Properties مشابه Base
        // ======================================================
        protected object CurrentEntity { get; private set; }
        protected object CrudService { get; }
        protected BindingSource EntityBindingSource { get; set; }

        protected bool IsReadOnly { get; }
        protected int RecordId { get; private set; }
        protected int NewCreatedRecordId { get; private set; } = 0;

        //public event EventHandler<object> ChangesSaved;
        public event EventHandler<RecordSavedEventArgs> ChangesSaved;

        // ======================================================
        // Constructor
        // ======================================================


        public BaseEditFormDesignerSafe()
        {
            // فقط برای Designer، هیچ کاری انجام نمی‌دهد
        }

        public BaseEditFormDesignerSafe(object x, object y, object z)
        {
            // فقط برای Designer، هیچ کاری انجام نمی‌دهد
        }

        // ======================================================
        // Load
        // ======================================================
        protected virtual void BaseForm_Load(object sender, EventArgs e) { }
        protected virtual void InitializeEntity() { }

        // ======================================================
        // Template Hooks
        // ======================================================
        protected virtual void OnAfterLoad() { }

        protected virtual bool BeforeSave() => true;
        protected virtual void AfterSave() { }

        protected virtual bool BeforeDelete() => true;
        protected virtual void AfterDelete() { }

        protected virtual bool BeforeReset() => true;
        protected virtual void AfterReset() { }

        protected virtual bool BeforeClose() => true;

        // ======================================================
        // Titles
        // ======================================================
        protected virtual string GetNewTitle() => string.Empty;
        protected virtual string GetEditTitle() => string.Empty;
        protected virtual string GetEntityDeleteMessge() => string.Empty;

        protected virtual void SetControlsReadOnly(bool readOnly) { }

        // ======================================================
        // ReadOnly
        // ======================================================
        protected virtual void ApplyReadOnlyMode(bool readOnly) { }

        // ======================================================
        // Buttons Logic
        // ======================================================
        protected virtual bool SaveCore(bool closeAfterSave, bool newAfterSave) => true;
        protected virtual void DeleteCore() { }
        protected virtual void ResetCore() { }
        protected virtual bool CloseCore() => true;

        // ======================================================
        // Ribbon Event Handlers
        // ======================================================
        protected virtual void bbiSave_ItemClick(object sender, ItemClickEventArgs e) { }
        protected virtual void bbiSaveAndClose_ItemClick(object sender, ItemClickEventArgs e) { }
        protected virtual void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e) { }
        protected virtual void bbiDelete_ItemClick(object sender, ItemClickEventArgs e) { }
        protected virtual void bbiReset_ItemClick(object sender, ItemClickEventArgs e) { }
        protected virtual void bbiClose_ItemClick(object sender, ItemClickEventArgs e) { }

        // ======================================================
        // Button providers
        // ======================================================
        protected virtual BarButtonItem GetSaveButton() => null;
        protected virtual BarButtonItem GetSaveAndCloseButton() => null;
        protected virtual BarButtonItem GetSaveAndNewButton() => null;
        protected virtual BarButtonItem GetDeleteButton() => null;
        protected virtual BarButtonItem GetResetButton() => null;
        protected virtual BarButtonItem GetCloseButton() => null;
    }
}
