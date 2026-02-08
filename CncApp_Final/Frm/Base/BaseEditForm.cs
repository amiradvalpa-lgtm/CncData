using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using CncApp_Final.Services;

namespace CncApp_Final.Frm.Base
{
    /// <summary>
    /// نسخه حرفه‌ای BaseEditForm با Template Method
    /// تمام منطق 5 دکمه اصلی داخل بیس
    /// و فقط هوک‌های Before/After در فرم‌های مشتق‌شده
    /// </summary>
    public abstract class BaseEditFormV2<T> : RibbonForm where T : class, new()
    {
        protected T CurrentEntity { get; private set; }
        protected ICrudService<T> CrudService { get; }
        protected BindingSource EntityBindingSource { get; set; }

        protected bool IsReadOnly { get; }
        protected int RecordId { get; private set; }
        protected int NewCreatedRecordId { get; private set; } = 0;

        public event EventHandler ChangesSaved;


        protected BaseEditFormV2(int recordId, bool isReadOnly, ICrudService<T> crudService)
        {
            RecordId = recordId;
            IsReadOnly = isReadOnly;
            CrudService = crudService ?? throw new ArgumentNullException(nameof(crudService));
        }

        // ======================================================
        // Load
        // ======================================================

        protected virtual void BaseForm_Load(object sender, EventArgs e)
        {
            InitializeEntity();
            ApplyReadOnlyMode(IsReadOnly);
            OnAfterLoad();
        }

        protected virtual void InitializeEntity()
        {
            if (RecordId == 0)
            {
                CurrentEntity = new T();
                CrudService.Add(CurrentEntity);
                Text = GetNewTitle();

                GetDeleteButton()?.SetVisibility(BarItemVisibility.Never);
            }
            else
            {
                CurrentEntity = CrudService.GetById(RecordId);

                if (CurrentEntity == null)
                {
                    XtraMessageBox.Show("رکورد یافت نشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                Text = GetEditTitle();
            }

            EntityBindingSource.DataSource = CurrentEntity;
        }

        // ======================================================
        // Template Hooks (قابل override در فرم‌ها)
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

        protected abstract string GetNewTitle();
        protected abstract string GetEditTitle();

        protected abstract void SetControlsReadOnly(bool readOnly);

        // ======================================================
        // ReadOnly
        // ======================================================

        protected virtual void ApplyReadOnlyMode(bool readOnly)
        {
            Ribbon.Enabled = !readOnly;
            SetControlsReadOnly(readOnly);
        }

        // ======================================================
        // Buttons Logic (کاملاً مرکزی)
        // ======================================================

        protected virtual void SaveCore(bool closeAfterSave, bool newAfterSave)
        {
            if (!BeforeSave()) return;

            try
            {
                EntityBindingSource.EndEdit();
                bool isNew = RecordId == 0;

                CrudService.SaveChanges();

                if (isNew && CurrentEntity != null)
                {
                    var idProp = CurrentEntity.GetType().GetProperty("Id");
                    if (idProp != null)
                        NewCreatedRecordId = (int)(idProp.GetValue(CurrentEntity) ?? 0);
                }

                ChangesSaved?.Invoke(this, EventArgs.Empty);

                AfterSave();

                if (closeAfterSave)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                if (newAfterSave)
                {
                    RecordId = 0;
                    InitializeEntity();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطا در ذخیره: {ex.Message}", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void DeleteCore()
        {
            if (!BeforeDelete()) return;

            if (XtraMessageBox.Show("آیا مطمئن هستید؟", "حذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            CrudService.Delete(CurrentEntity);
            CrudService.SaveChanges();

            ChangesSaved?.Invoke(this, EventArgs.Empty);

            AfterDelete();

            DialogResult = DialogResult.Yes;
            Close();
        }

        protected virtual void ResetCore()
        {
            if (!BeforeReset()) return;

            CrudService.Reload(CurrentEntity);
            InitializeEntity();

            AfterReset();
        }

        protected virtual void CloseCore()
        {
            if (!BeforeClose()) return;

            DialogResult = DialogResult.Cancel;
            Close();
        }

        // ======================================================
        // Ribbon Event Handlers (فقط صدا زدن Core)
        // ======================================================

        protected void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
            => SaveCore(closeAfterSave: false, newAfterSave: false);

        protected void bbiSaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
            => SaveCore(closeAfterSave: true, newAfterSave: false);

        protected void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
            => SaveCore(closeAfterSave: false, newAfterSave: true);

        protected void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
            => DeleteCore();

        protected void bbiReset_ItemClick(object sender, ItemClickEventArgs e)
            => ResetCore();

        protected void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
            => CloseCore();

        // ======================================================
        // Button providers
        // ======================================================

        protected virtual BarButtonItem GetSaveButton() => null;
        protected virtual BarButtonItem GetSaveAndCloseButton() => null;
        protected virtual BarButtonItem GetSaveAndNewButton() => null;
        protected virtual BarButtonItem GetDeleteButton() => null;
    }

    internal static class BarItemExtensions
    {
        public static void SetVisibility(this BarButtonItem item, BarItemVisibility visibility)
        {
            if (item != null)
                item.Visibility = visibility;
        }
    }
}
