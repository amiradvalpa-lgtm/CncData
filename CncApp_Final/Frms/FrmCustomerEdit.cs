using CncApp_Final.Entities;
using CncApp_Final.Frms.Base;
using CncApp_Final.Helper;
using CncApp_Final.Services;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace CncApp_Final.Frms
{
    //public partial class FrmCustomerEdit : BaseEditForm<Customer>
    //{
        public partial class FrmCustomerEdit :
            #if DEBUG
                    BaseEditFormDesignerSafe
            #else
                BaseEditForm<Customer>
            #endif
        {

        //public FrmCustomerEdit()
        //    #if !DEBUG
        //                    : base(0, false, null)
        //    #endif
        //{
        //    InitializeComponent();

        //    if (!DesignMode)
        //        EntityBindingSource = customerBindingSource;

        //    this.Load += BaseForm_Load;
        //}
               



        public FrmCustomerEdit(int customerId, bool isReadOnly, ICrudService<Customer> service)
            : base(customerId, isReadOnly, service)
        {
            InitializeComponent();
            EntityBindingSource = customerBindingSource;
            this.Load += BaseForm_Load;
        }

        // =================== عنوان فرم ===================
        protected override string GetNewTitle() => "مشتری جدید";
        //////protected override string GetEditTitle() => $"ویرایش مشتری: {CurrentEntity.CustomerName}";
        protected override string GetEditTitle() => $"ویرایش مشتری";


        // =================== نام مشتری ===================
        ////protected override string GetEntityDeleteMessge() => $"{CurrentEntity.CustomerName}";
        protected override string GetEntityDeleteMessge() => $"";


        // =================== کنترل ها ===================
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

        // =================== بارگذاری فرم ===================
        protected override void OnAfterLoad()
        {
            base.OnAfterLoad();   // ← خیلی مهم

            DxValidationHelper.SetupValidation<Customer>(this, dxValidationProvider1, customerBindingSource);
            ControlExraInit.ApplyFocusColor(this);

            txbPhone.ErrorImageOptions.Alignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight;

            // تنظیم Balance Mode بر اساس Beginning_Balance
            if ((double)txbBeginning_Balance.EditValue == 0)
                cmbBanalceMode.SelectedIndex = 0;
            else if ((double)txbBeginning_Balance.EditValue < 0)
                cmbBanalceMode.SelectedIndex = 1;
            else
                cmbBanalceMode.SelectedIndex = 2;

            txbBeginning_Balance.EditValue = Math.Abs((double)txbBeginning_Balance.EditValue);
        }

        // =================== قبل از ذخیره ===================
        protected override bool BeforeSave()
        {
            // اعتبارسنجی Balance
            if ((double)txbBeginning_Balance.EditValue != 0 && (double)cmbBanalceMode.EditValue == 0)
            {
                XtraMessageBox.Show("با توجه مقدار اول دوره نوع ماهیت را انتخاب کنید.", "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBanalceMode.Focus();
                return false;
            }

            // اصلاح مقدار Balance بر اساس Combo
            txbBeginning_Balance.EditValue = Math.Abs((double)txbBeginning_Balance.EditValue) * (double)cmbBanalceMode.EditValue;

            // اعتبارسنجی DevExpress
            return dxValidationProvider1.Validate();
        }

        // =================== بعد از ذخیره ===================
        protected override void AfterSave()
        {
            // پیام مشابه فرم اصلی
            if (RecordId == 0) // اگر جدید بود
            {
                //XtraMessageBox.Show($"مشتری جدید با کد {NewCreatedRecordId} ثبت شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XtraMessageBox.Show($"مشتری جدید با مشخصات \" { GetEntityDeleteMessge()} \" ثبت شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        protected override bool BeforeDelete()
        {
            DialogResult dialogResult = XtraMessageBox.Show(
                    $"آیا از حذف مشتری '{GetEntityDeleteMessge()}' مطمئن هستید؟",
                    "تأیید حذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (dialogResult == DialogResult.Yes)
                return base.BeforeDelete();
            return false;
        }

        // =================== دکمه‌ها ===================
        protected override BarButtonItem GetSaveButton() => bbiSave;
        protected override BarButtonItem GetSaveAndCloseButton() => bbiSaveAndClose;
        protected override BarButtonItem GetSaveAndNewButton() => bbiSaveAndNew;
        protected override BarButtonItem GetDeleteButton() => bbiDelete;
        protected override BarButtonItem GetResetButton() => bbiReset;
        protected override BarButtonItem GetCloseButton() => bbiClose;



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
    }
}