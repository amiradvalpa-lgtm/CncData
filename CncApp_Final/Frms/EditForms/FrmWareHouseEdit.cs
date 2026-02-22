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
    public partial class FrmWareHouseEdit :
#if DEBUG
                BaseFormEdit<Warehouse>
#else
                    BaseEditFormDesignerSafe
#endif
    {

        public FrmWareHouseEdit(int warehousedId, bool isReadOnly, ICrudService<Warehouse> service)
            : base(warehousedId, isReadOnly, service)
        {
            InitializeComponent();
            EntityBindingSource = warehousesBindingSource;
            this.Load += BaseForm_Load;
        }





#if DEBUG
        // ======================================================
        // متن های مخصوص فرم
        // ======================================================
        protected override string GetNewTitle() => "ورود به انبار جدید";
        protected override string GetEditTitle() => $"ویرایش ورود به انبار: {CurrentEntity.Id}";
        protected override string GetEntityDeleteMessge() => $"{CurrentEntity.Id}: {CurrentEntity.Id}";

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
            sheetSelector1.EditValueChanged += SheetSelector_EditValueChanged;
            base.BaseForm_Load(sender, e);
        }

        protected override void OnAfterLoad()
        {
            base.OnAfterLoad();   // ← خیلی مهم --> حذف نشود

            DxValidationHelper.SetupValidation<Receipt>(this, dxValidationProvider1, warehousesBindingSource);
            ControlExraInit.ApplyFocusColor(this);
            

            var db = CrudService.Context;   // ⭐ همان DbContext مشترک

            //db.Set<Customer>().Load();
            //customersBindingSource.DataSource =
            //    db.Set<Customer>().Local.ToBindingList();

            //db.Set<BankAccount>().Load();
            //banksBindingSource.DataSource =
            //    db.Set<BankAccount>().Local.ToBindingList();

            //txbPhone.ErrorImageOptions.Alignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight;

            ckbUpdateSheetPrice.Checked = false;

            NewSheetPriceTextEdit.DataBindings.Add(
                            new System.Windows.Forms.Binding(
                                "EditValue", warehousesBindingSource, "Sheet.SheetPrice", true)
                            );

            NewPicesPriceTextEdit.DataBindings.Add(
                            new System.Windows.Forms.Binding(
                                "EditValue", warehousesBindingSource, "Sheet.PicesPrice", true)
                            );

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
            var db = CrudService.Context;
            bool shouldUpdateSheet = ckbUpdateSheetPrice.CheckState == CheckState.Checked;
            bool pricesDiffer =
                NewSheetPriceTextEdit.Text != PreSheetPriceTextEdit.Text ||
                NewPicesPriceTextEdit.Text != PrePicesPriceTextEdit.Text;

            if (!shouldUpdateSheet && pricesDiffer)
            {
                var result = XtraMessageBox.Show(
                    "قیمت جدید (طبق فرمول) با قیمت قبلی متفاوت است.\n" +
                    "آیا مایل به ذخیره قیمت‌های جدید در ورق هستید؟",
                    "تفاوت قیمت ورق",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2
                );

                if (result == DialogResult.No)
                {
                    // فقط در این حالت تغییرات را دور می‌ریزیم
                    db.Entry(CurrentEntity).Reference(x => x.Sheet).Load();
                    db.Entry(CurrentEntity.Sheet).State = EntityState.Unchanged;
                }
                // اگر Yes زده → اجازه می‌دهیم تغییرات فعلی (قیمت جدید) بماند و ذخیره شود
                // هیچ Load ای انجام نمی‌دهیم
            }
            else if (!shouldUpdateSheet)
            {
                // قیمت‌ها تغییری نکرده‌اند → برای اطمینان تغییرات احتمالی قبلی را پاک می‌کنیم
                db.Entry(CurrentEntity.Sheet).State = EntityState.Unchanged;
            }

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
                XtraMessageBox.Show($"سند جدید انبار با مشخصات \" {GetEntityDeleteMessge()} \" ثبت شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        // ======================================================
        // قبل از حذف 
        // ======================================================
        protected override bool BeforeDelete()
        {
            DialogResult dialogResult = XtraMessageBox.Show(
                    $"آیا از حذف سند انبار '{GetEntityDeleteMessge()}' مطمئن هستید؟",
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
            DxValidationHelper.RemoveControlError<Warehouse>(this, dxValidationProvider1, warehousesBindingSource);
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

        private void btnCopyPrice_Click(object sender, EventArgs e)
        {
            NewSheetPriceTextEdit.EditValue = PreSheetPriceTextEdit.EditValue;
            NewPicesPriceTextEdit.EditValue = PrePicesPriceTextEdit.EditValue;
        }


        private void btnCalcPrices_Click(object sender, EventArgs e)
        {
            CalcPrices();
        }

        private void CalcPrices()
        {
            if (CurrentEntity.Sheet == null)
                return;
            Sheet _sheet = (Sheet)CurrentEntity.Sheet;

            _sheet.LastBuyPrice = CurrentEntity.SheetBasePrice;
            SheetCalculator.Calculate(_sheet);
            //NewSheetPriceTextEdit.EditValue = _sheet.SheetPrice;
            //NewPicesPriceTextEdit.EditValue = _sheet.PicesPrice;
            warehousesBindingSource.ResetBindings(false);
        }

        private void ckbUpdateSheetPrice_CheckedChanged(object sender, EventArgs e)
        {
            NewPicesPriceTextEdit.Enabled = ckbUpdateSheetPrice.Checked;
            NewSheetPriceTextEdit.Enabled = ckbUpdateSheetPrice.Checked;
            btnCalcPrices.Enabled = ckbUpdateSheetPrice.Checked;
            btnCopyPrice.Enabled = ckbUpdateSheetPrice.Checked;
        }


        private void SheetSelector_EditValueChanged(object sender, EventArgs e)
        {
            if (sheetSelector1.EditValue != null)
            {
                var db = CrudService.Context;
                CurrentEntity.SheetId = (int)sheetSelector1.EditValue;
                warehousesBindingSource.EndEdit();
                db.Entry(CurrentEntity).Reference(x => x.Sheet).Load();
                warehousesBindingSource.ResetBindings(false);

                PreSheetPriceTextEdit.Text = CurrentEntity.Sheet.SheetPrice.ToString();
                PrePicesPriceTextEdit.Text = CurrentEntity.Sheet.PicesPrice.ToString();
                CalcPrices();
            }
            else
            {
                PreSheetPriceTextEdit.ResetText();
                PrePicesPriceTextEdit.ResetText();

                NewSheetPriceTextEdit.ResetText();
                NewPicesPriceTextEdit.ResetText();

                //_currentWareHouse.SheetId = 0;
            }
        }

        private void SheetBuyPriceTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (SheetBuyPriceTextEdit.EditValue == null ||
            SheetBuyPriceTextEdit.EditValue == DBNull.Value )
            {
                return; // یا مقدار پیش‌فرض: SheetBuyPriceTextEdit.EditValue = 0m;
            }


            SheetBuyPriceTextEdit.EditValueChanged -= SheetBuyPriceTextEdit_EditValueChanged;

            try
            {
                warehousesBindingSource.EndEdit();
                CalcPrices();
            }
            finally
            {
                SheetBuyPriceTextEdit.EditValueChanged += SheetBuyPriceTextEdit_EditValueChanged;
            }
        }
    }
}