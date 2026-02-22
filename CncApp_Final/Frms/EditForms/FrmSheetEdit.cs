using CncApp_Final.Entities;
using CncApp_Final.Frm;
using CncApp_Final.Frms.Base;
using CncApp_Final.Helper;
using CncApp_Final.Services;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CncApp_Final.Frms.EditForms
{
    public partial class FrmSheetEdit :
#if DEBUG
                BaseFormEdit<Sheet>
#else
                    BaseEditFormDesignerSafe
#endif
    {

        public FrmSheetEdit(int sheetId, bool isReadOnly, ICrudService<Sheet> service)
            : base(sheetId, isReadOnly, service)
        {
            InitializeComponent();
            EntityBindingSource = sheetsBindingSource;
            this.Load += BaseForm_Load;
        }





#if DEBUG
        // ======================================================
        // متن های مخصوص فرم
        // ======================================================
        protected override string GetNewTitle() => "ورق جدید";
        protected override string GetEditTitle() => $"ویرایش ورق: {CurrentEntity.SheetName}";
        protected override string GetEntityDeleteMessge() => $"{CurrentEntity.SheetName}";

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
            bbiSave.Enabled = !readOnly;
            bbiSaveAndClose.Enabled = !readOnly;
            bbiSaveAndNew.Enabled = !readOnly;
            bbiDelete.Enabled = !readOnly;
        }


        // ======================================================
        // بارگذاری فرم
        // ======================================================
        protected override void BaseForm_Load(object sender, EventArgs e)
        {
            sheetDetails.LoadDataBaseSheet();
            base.BaseForm_Load(sender, e);
        }

        protected override void OnAfterLoad()
        {
            base.OnAfterLoad();   // ← خیلی مهم --> حذف نشود

            DxValidationHelper.SetupValidation<Sheet>(this, dxValidationProvider1, EntityBindingSource);
            ControlExraInit.ApplyFocusColor(this);

            this.mainRibbonControl.RibbonCaptionAlignment = DevExpress.XtraBars.Ribbon.RibbonCaptionAlignment.Right;
            this.mainRibbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ShowToolbarCustomizeItem = false;
            this.mainRibbonControl.Toolbar.ShowCustomizeItem = false;
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
                XtraMessageBox.Show($"ورق جدید با مشخصات \" {GetEntityDeleteMessge()} \" ثبت شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        // ======================================================
        // قبل از حذف 
        // ======================================================
        protected override bool BeforeDelete()
        {
            DialogResult dialogResult = XtraMessageBox.Show(
                    $"آیا از حذف ورق ' {GetEntityDeleteMessge()} ' مطمئن هستید؟",
                    "تأیید حذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (dialogResult == DialogResult.Yes)
                return base.BeforeDelete();
            return false;
        }



        // ======================================================
        // بعد از Reset 
        // ======================================================
        protected override void AfterReset()
        {
            base.AfterReset();
            DxValidationHelper.RemoveControlError<Sheet>(this, dxValidationProvider1, EntityBindingSource);
            //ClearValidation();
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


        private void btneSheetPriceFormula_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit btne = sender as ButtonEdit;
            string expression = btne.EditValue.ToString();
            string expressionName = GetDisplayName(btne);
            //expression = "[طول ورق]";

            FrmSheetFormulaEditor frmSheetFormulaEditor = new FrmSheetFormulaEditor(expression, expressionName);
            frmSheetFormulaEditor.ShowDialog(this);
            btne.EditValue = frmSheetFormulaEditor.ExpressionText;
        }

        private void btnePicesPriceFormula_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit btne = sender as ButtonEdit;
            string expression = btne.EditValue.ToString();
            string expressionName = GetDisplayName(btne);
            //expression = "[طول ورق]";

            FrmSheetFormulaEditor frmSheetFormulaEditor = new FrmSheetFormulaEditor(expression, expressionName);
            frmSheetFormulaEditor.ShowDialog(this);
            btne.EditValue = frmSheetFormulaEditor.ExpressionText;
        }

        private string GetDisplayName(ButtonEdit be)
        {
            // گرفتن اولین بایند (مثلاً EditValue)
            var binding = be.DataBindings["EditValue"];
            if (binding == null)
                return null;

            var bs = binding.DataSource as BindingSource;
            if (bs == null) return null;

            // نام پراپرتی بایند شده
            var propertyName = binding.BindingMemberInfo.BindingField;
            var prop = TypeDescriptor.GetProperties(bs.Current)[propertyName];
            var displayName = prop?.DisplayName;


            // اگر DisplayNameAttribute داشت
            return prop.DisplayName;
        }










    }
}