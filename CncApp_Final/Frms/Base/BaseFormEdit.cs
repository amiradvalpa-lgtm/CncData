using CncApp_Final.Services;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CncApp_Final.Frms.Base
{
    /// <summary>
    /// نسخه حرفه‌ای BaseEditForm با Template Method
    /// تمام منطق 5 دکمه اصلی داخل بیس
    /// و فقط هوک‌های Before/After در فرم‌های مشتق‌شده
    /// </summary>
    public abstract class BaseFormEdit<T> : RibbonForm, IEditForm where T : class, new()
    {
        protected T CurrentEntity { get; private set; }
        protected ICrudService<T> CrudService { get; }
        protected BindingSource EntityBindingSource { get; set; }

        protected bool IsReadOnly { get; }
        protected int RecordId { get; private set; }
        protected int NewCreatedRecordId { get; private set; } = 0;

        public event EventHandler<RecordSavedEventArgs> ChangesSaved;


        protected BaseFormEdit()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
        }

        protected BaseFormEdit(int recordId, bool isReadOnly, ICrudService<T> crudService)
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
            EntityBindingSource.ResetBindings(false);

            EntityBindingSource.CurrentItemChanged += (_, __) => UpdateResetButtonState();
            EntityBindingSource.ListChanged += (_, __) => UpdateResetButtonState();
        }

        // ======================================================
        // Template Hooks (قابل override در فرم‌ها)
        // ======================================================

        protected virtual void OnAfterLoad()
        {
            var btnSave = GetSaveButton();
            if (btnSave != null)
                btnSave.ItemClick += bbiSave_ItemClick;

            var btnSaveClose = GetSaveAndCloseButton();
            if (btnSaveClose != null)
                btnSaveClose.ItemClick += bbiSaveAndClose_ItemClick;

            var btnSaveNew = GetSaveAndNewButton();
            if (btnSaveNew != null)
                btnSaveNew.ItemClick += bbiSaveAndNew_ItemClick;

            var btnDelete = GetDeleteButton();
            if (btnDelete != null)
                btnDelete.ItemClick += bbiDelete_ItemClick;
            
            var btnReset = GetResetButton();
            if (btnReset != null)
                btnReset.ItemClick += bbiReset_ItemClick;
            
            var btnClose = GetCloseButton();
            if (btnClose != null)
                btnClose.ItemClick += bbiClose_ItemClick;
        }

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
        protected abstract string GetEntityDeleteMessge();

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

        protected virtual bool SaveCore(bool closeAfterSave, bool newAfterSave)
        {
            if (!BeforeSave()) return false;

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

                var recordSavedEventArgs = new RecordSavedEventArgs(NewCreatedRecordId);
                ChangesSaved?.Invoke(this, recordSavedEventArgs);

                AfterSave();

                if (closeAfterSave)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    BarItemExtensions.SetEnablility(GetResetButton(), false);
                    return true;
                }

                if (newAfterSave)
                {
                    RecordId = 0;
                    InitializeEntity();
                }
                BarItemExtensions.SetEnablility(GetResetButton(), false);
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var sb = new StringBuilder("خطاهای اعتبارسنجی:\n\n");

                foreach (var eve in dbEx.EntityValidationErrors)
                {
                    string entityName = eve.Entry.Entity.GetType().Name;
                    sb.AppendLine($"→ موجودیت: {entityName} (وضعیت: {eve.Entry.State})");

                    foreach (var ve in eve.ValidationErrors)
                    {
                        sb.AppendLine($"   • {ve.PropertyName,-20} : {ve.ErrorMessage}");
                    }
                    sb.AppendLine();
                }

                XtraMessageBox.Show(sb.ToString(), "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطا در هنگام ذخیره سازی: {ex.Message}", "خطای ذخیره",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected virtual void DeleteCore()
        {
            if (!BeforeDelete()) return;

            //if (XtraMessageBox.Show("آیا مطمئن هستید؟", "حذف",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            //    return;

            CrudService.Delete(CurrentEntity);
            CrudService.SaveChanges();

            var recordSavedEventArgs = new RecordSavedEventArgs(-1);
            ChangesSaved?.Invoke(this, recordSavedEventArgs);

            AfterDelete();

            DialogResult = DialogResult.Yes;
            Close();
        }

        protected virtual void ResetCore()
        {
            DialogResult dr;
            if (RecordId == 0)
            {
                dr = XtraMessageBox.Show(
                    "اطلاعات وارد شده پاک شود و فرم به حالت جدید برگردد؟",
                    "بازنشانی",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            }
            else
            {
                dr = XtraMessageBox.Show(
                "تغییرات انجام شده حذف و اطلاعات اصلی دوباره بارگذاری شود؟",
                "بازنشانی تغییرات",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            }
            if (dr != DialogResult.Yes)
                return;


            if (!BeforeReset()) return;

            CrudService.Reload(CurrentEntity);
            InitializeEntity();

            AfterReset();
        }

        //protected virtual void CloseCore()
        //{
        //    if (!BeforeClose()) return;


        //    // اگر تغییراتی وجود دارد، از کاربر سوال شود
        //    EntityBindingSource.EndEdit();
        //    if (CrudService.HasChanges())
        //    {
        //        DialogResult dialogResult = XtraMessageBox.Show(
        //            "تغییراتی اعمال شده است. آیا مایل به ذخیره هستید؟",
        //            "ذخیره تغییرات",
        //            MessageBoxButtons.YesNoCancel,
        //            MessageBoxIcon.Warning
        //        );

        //        if (dialogResult == DialogResult.Yes)
        //        {
        //            SaveCore(closeAfterSave: true, newAfterSave: false);
        //        }
        //        else if (dialogResult == DialogResult.No)
        //        {
        //            DialogResult = DialogResult.Cancel; // Cancel برای عدم Refresh در فرم پدر
        //            Close();
        //        }
        //    }
        //    else
        //    {
        //        DialogResult = DialogResult.Cancel;
        //        Close();
        //    }
        //}

        protected void UpdateResetButtonState()
        {
            var btn = GetResetButton();
            if (btn != null)
                btn.Enabled = CrudService.HasChanges();
        }

        protected virtual bool CloseCore()
        {
            if (!BeforeClose())
                return false;

            EntityBindingSource?.EndEdit();

            if (CrudService.HasChanges())
            {
                var dialogResult = XtraMessageBox.Show(
                    "تغییراتی اعمال شده است. آیا مایل به ذخیره هستید؟",
                    "ذخیره تغییرات",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.Yes)
                {
                    // اگر ذخیره ناموفق باشد → بستن لغو شود
                    if (!SaveCore(closeAfterSave: false, newAfterSave: false))
                        return false;

                    DialogResult = DialogResult.OK;
                }
                else if (dialogResult == DialogResult.No)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    return false; // Cancel → بستن متوقف شود
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }

            return true; // اجازه بستن فرم
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


        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    base.OnFormClosing(e);

        //    if (e.CloseReason == CloseReason.UserClosing)
        //    {
        //        if (!CloseCore())
        //        {
        //            e.Cancel = true; // جلوگیری از بسته شدن
        //        }
        //    }
        //}

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!CloseCore())
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnFormClosing(e);
        }

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


    public class RecordSavedEventArgs : EventArgs
    {
        public int RecordId { get; }

        public RecordSavedEventArgs(int recordId)
        {
            RecordId = recordId;
        }
    }

    internal static class BarItemExtensions
    {
        public static void SetVisibility(this BarButtonItem item, BarItemVisibility visibility)
        {
            if (item != null)
                item.Visibility = visibility;
        }

        public static void SetEnablility(this BarButtonItem item, bool Enabled)
        {
            if (item != null)
                item.Enabled = Enabled;
        }
    }
}

