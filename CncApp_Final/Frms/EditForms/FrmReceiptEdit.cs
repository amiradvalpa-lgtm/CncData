using CncApp_Final.Entities;
using CncApp_Final.Frms.Base;
using CncApp_Final.Helper;
using CncApp_Final.Services;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CncApp_Final.Frms.EditForms
{
    public partial class FrmReceiptEdit :
#if DEBUG
                BaseEditForm<Receipt>
#else
                    BaseEditFormDesignerSafe
#endif
    {

        public FrmReceiptEdit(int customerId, bool isReadOnly, ICrudService<Receipt> service)
            : base(customerId, isReadOnly, service)
        {
            InitializeComponent();
            EntityBindingSource = receiptBindingSource;
            this.Load += BaseForm_Load;
        }





#if DEBUG
        // ======================================================
        // متن های مخصوص فرم
        // ======================================================
        protected override string GetNewTitle() => "رسید جدید";
        protected override string GetEditTitle() => $"ویرایش رسید: {CurrentEntity.CustomerName}";
        protected override string GetEntityDeleteMessge() => $"{CurrentEntity.CustomerName}: {CurrentEntity.Id}";

#else
        // ======================================================
        // متن های مخصوص DesignerSafe
        // ======================================================
        protected override string GetNewTitle() => "رسید جدید";
        protected override string GetEditTitle() => $"ویرایش رسید";
        protected override string GetEntityDeleteMessge() => string.Empty;

#endif




        // ======================================================
        //  کنترل ها
        // ======================================================

        protected override void SetControlsReadOnly(bool readOnly)
        {
            foreach (Control control in groupControl1.Controls)
            {
                if (control is TextEdit textEdit)
                {
                    textEdit.Properties.ReadOnly = readOnly;
                }
                else if (control is ImageComboBoxEdit comboBoxEdit)
                {
                    comboBoxEdit.Properties.ReadOnly = readOnly;
                }
            }
        }


        // ======================================================
        // بارگذاری فرم
        // ======================================================

        protected override void OnAfterLoad()
        {
            base.OnAfterLoad();   // ← خیلی مهم --> حذف نشود

            DxValidationHelper.SetupValidation<Receipt>(this, dxValidationProvider1, receiptBindingSource);
            ControlExraInit.ApplyFocusColor(this);
            ControlExraInit.InitLookupEdit(lkpCustomer);
            ControlExraInit.InitLookupEdit(lkpBanks);


            var db = CrudService.Context;   // ⭐ همان DbContext مشترک

            db.Set<Customer>().Load();
            customersBindingSource.DataSource =
                db.Set<Customer>().Local.ToBindingList();

            db.Set<BankAccount>().Load();
            banksBindingSource.DataSource =
                db.Set<BankAccount>().Local.ToBindingList();

            //txbPhone.ErrorImageOptions.Alignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight;


        }



        // ======================================================
        // قبل از ذخیره
        // ======================================================
        protected override bool BeforeSave()
        {

            // اعتبارسنجی DevExpress
            return dxValidationProvider1.Validate();
        }


        // ======================================================
        // بعد از ذخیره 
        // ======================================================
        protected override void AfterSave()
        {
            if (RecordId == 0) // اگر جدید بود
            {
                //XtraMessageBox.Show($"مشتری جدید با کد {NewCreatedRecordId} ثبت شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XtraMessageBox.Show($"مشتری جدید با مشخصات \" {GetEntityDeleteMessge()} \" ثبت شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        // ======================================================
        // قبل از حذف 
        // ======================================================
        protected override bool BeforeDelete()
        {
            DialogResult dialogResult = XtraMessageBox.Show(
                    $"آیا از حذف رسید '{GetEntityDeleteMessge()}' مطمئن هستید؟",
                    "تأیید حذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (dialogResult == DialogResult.Yes)
                return base.BeforeDelete();
            return false;
        }


        //*****************************************************************************************************************************************
        //*****************************************************************************************************************************************
        //*****************************************************************************************************************************************


        private void txb_must_Trim_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit textEdit = (sender as TextEdit);
            if (textEdit.EditValue != null)
            {
                textEdit.EditValue = textEdit.Text.Trim();
            }
        }



        //*****************************************************************************************************************************************
        //*****************************************************************************************************************************************

        #region قسمت مربوط به دکمه های فرم  --  در تمام فرمها  ثابت  است و تغییر نکند

        // ======================================================
        //  دکمه‌های اصلی BaseEditForm
        // ======================================================
        protected override BarButtonItem GetSaveButton() => bbiSave;
        protected override BarButtonItem GetSaveAndCloseButton() => bbiSaveAndClose;
        protected override BarButtonItem GetSaveAndNewButton() => bbiSaveAndNew;
        protected override BarButtonItem GetDeleteButton() => bbiDelete;
        protected override BarButtonItem GetResetButton() => bbiReset;
        protected override BarButtonItem GetCloseButton() => bbiClose;

        #endregion

        //*****************************************************************************************************************************************
        //*****************************************************************************************************************************************

        protected override void AfterReset()
        {
            base.AfterReset();
            DxValidationHelper.RemoveControlError<Receipt>(this, dxValidationProvider1, receiptBindingSource);
            //ClearValidation();
        }

        private void ClearValidation()
        {
            foreach (var ctrl in this.groupControl1.Controls.OfType<BaseEdit>())
            {
                dxValidationProvider1.RemoveControlError(ctrl);
            }

        }
    }
}