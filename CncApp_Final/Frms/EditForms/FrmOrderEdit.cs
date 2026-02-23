
using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Frms.Base;
using CncApp_Final.Helper;
using CncApp_Final.Services;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncApp_Final.Frms.EditForms
{
    public partial class FrmOrderEdit :
        #if DEBUG
                    BaseFormEdit<Order>
            #else
                    BaseEditFormDesignerSafe
            #endif
    {

        public VGCore.Document SelectedDocument;


        public FrmOrderEdit(int orderId, bool isReadOnly, ICrudService<Order> service)
            : base(orderId, isReadOnly, service)
        {
            InitializeComponent();
            EntityBindingSource = orderBindingSource;
            this.Load += BaseForm_Load;
        }


#if !DEBUG
        // ======================================================
        // متن های مخصوص فرم
        // ======================================================
        protected override string GetNewTitle() => "مشتری جدید";
        protected override string GetEditTitle() => $"ویرایش مشتری: {CurrentEntity.CustomerName}";
        protected override string GetEntityDeleteMessge() => $"{CurrentEntity.CustomerName}";

#else
        // ======================================================
        // متن های مخصوص DesignerSafe
        // ======================================================
        protected override string GetNewTitle() => "سفارش جدید";
        protected override string GetEditTitle() => $"ویرایش سفارش";
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
            base.OnAfterLoad();   // ← خیلی مهم

            DxValidationHelper.SetupValidation<Order>(this, dxValidationProvider1, orderBindingSource);
            ControlExraInit.ApplyFocusColor(this);

            var db = CrudService.Context;   // ⭐ همان DbContext مشترک
            db.Set<Customer>().Load();
            customersBindingSource.DataSource =
                db.Set<Customer>().Local.ToBindingList();
            orderDetailsBindingSource.DataSource = CurrentEntity.OrderDetails;


            if (RecordId  == 0)
            {
                CurrentEntity.InvoiceNumber = GetNextInvoiceNumber();
                CurrentEntity.OrderDate = DateTime.Now;
                EntityBindingSource.ResetBindings(false);
                lueCustomer.Focus();
            }

            btnOpenFile.Properties.Buttons[0].Enabled = false;
            btnOpenFile.EditValue = Path.GetFileName(CurrentEntity.FilePath);

            btnNewCustomer.Click += btnNewCustomer_Click;
            btnOpenFile.Properties.ButtonClick += btnOpenFile_Properties_ButtonClick;
            btnImportFromCorel.Click += btnImportFromCorel_Click;
            gridControl.DoubleClick += gridControl_DoubleClick;
            btnNewDetail.Click += btnNewDetail_Click;
        }



        // ======================================================
        // قبل از ذخیره
        // ======================================================
        protected override bool BeforeSave()
        {

            SetCorelFileFullPath();
            if (!SaveDocumentToResources(SelectedDocument, CurrentEntity.FilePath))
            {
                return false;
            }

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
                XtraMessageBox.Show($"سفارش جدید با مشخصات \" {GetEntityDeleteMessge()} \" ثبت شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        // ======================================================
        // قبل از حذف 
        // ======================================================
        protected override bool BeforeDelete()
        {
            DialogResult dialogResult = XtraMessageBox.Show(
                    $"آیا از حذف سفارش '{GetEntityDeleteMessge()}' مطمئن هستید؟",
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



        public string GetNextInvoiceNumber()
        {
            var pc = new PersianCalendar();
            int year = pc.GetYear(DateTime.Now);
            int yy = year % 100; // دو رقم آخر سال

            string prefix = $"F{yy:D2}-";
            string lastInvoice = null;
            try
            {
                var db = CrudService.Context;   // ⭐ همان DbContext مشترک
                db.Set<Order>().Load();
                lastInvoice = db.Set<Order>().Local
                    .Where(o => o.InvoiceNumber != null && o.InvoiceNumber.StartsWith(prefix))
                    .Select(o => o.InvoiceNumber)
                    .OrderByDescending(x => x)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {

            }

            int nextNumber;

            if (string.IsNullOrEmpty(lastInvoice))
            {
                nextNumber = 101;   // مقدار اولیه طبق حرفت
            }
            else
            {
                var numberPart = lastInvoice.Substring(prefix.Length);
                nextNumber = int.Parse(numberPart) + 1;
            }

            return $"{prefix}{nextNumber:0000}";
        }


        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            var service = new EfCrudService<Customer>(new AppDbContext());
            var frm = new FrmCustomerEdit(0, false, service);

            frm.ChangesSaved += (s, args) =>
            {
                // رفرش lookupEdit با همان DbContext مشترک
                var db = CrudService.Context;
                db.Set<Customer>().Load();
                customersBindingSource.DataSource = db.Set<Customer>().Local.ToBindingList();

                // انتخاب مشتری جدید در lookup
                lueCustomer.EditValue = args.RecordId;
            };

            frm.ShowDialog();
        }

        private void OpenOrderDetailForEdit(OrderDetails originalDetail)
        {
            var db = CrudService.Context;
            using (CncApp_Final.TempFrm.FrmOrderDetails frmOrderDetailEdit = new CncApp_Final.TempFrm.FrmOrderDetails(originalDetail, (AppDbContext)db))
            {
                DialogResult result = frmOrderDetailEdit.ShowDialog();

                if (result == DialogResult.OK)
                {
                    db.Entry(originalDetail).Reference(x => x.Sheet).Load();

                    orderDetailsBindingSource.ResetBindings(false);
                    orderBindingSource.ResetBindings(false); // برای به‌روزرسانی TotalAmount در فرم مادر
                }
            }
        }

        // رویداد DoubleClick در گرید OrderDetails (اصلاح شده)
        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            GridView view = gridControl.MainView as GridView;
            GridHitInfo info = view.CalcHitInfo((e as DXMouseEventArgs).Location);

            if ((info.InRow || info.InRowCell) && view.IsDataRow(info.RowHandle) && info.Column != colDeleteSelectedDetail)
            {
                OrderDetails detailToEdit = view.GetRow(info.RowHandle) as OrderDetails;

                if (detailToEdit != null)
                {
                    view.CloseEditor();
                    view.UpdateCurrentRow();

                    OpenOrderDetailForEdit(detailToEdit);
                }
            }
        }

        private void btnNewDetail_Click(object sender, EventArgs e)
        {
            //grdvOrderDetails.RefreshData();
            //Order currentOrder = orderBindingSource.Current as Order;

            //if (currentOrder == null)
            //{
            //    XtraMessageBox.Show("ابتدا سفارش را ایجاد یا انتخاب کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //OrderDetails newDetail = new OrderDetails();
            //newDetail.OrderId = currentOrder.Id;

            //using (CncApp_Final.TempFrm.FrmOrderDetails frmOrderDetailNew = new CncApp_Final.TempFrm.FrmOrderDetails(newDetail, _dbContext))
            //{
            //    DialogResult result = frmOrderDetailNew.ShowDialog();

            //    if (result == DialogResult.OK)
            //    {
            //        newDetail.Id = 0;
            //        newDetail.OrderId = currentOrder.Id;

            //        //_dbContext.Entry(newDetail).Reference(x => x.Sheet).Load();

            //        currentOrder.OrderDetails.Add(newDetail);
            //        orderDetailsBindingSource.ResetBindings(false);
            //        orderBindingSource.ResetBindings(false);
            //    }
            //}
        }


        private void btnImportFromCorel_Click(object sender, EventArgs e)
        {
            var db = CrudService.Context;
            FrmCorelDataImporter frmCorelDataImporter = new FrmCorelDataImporter((AppDbContext)db);
            frmCorelDataImporter.ShowDialog();

            //Order currentOrder = orderBindingSource.Current as Order;
            foreach (var detail in frmCorelDataImporter._orderDetails)
            {
                // مهم: اگر OrderDetails جدید است، حتماً OrderId را ست کنید
                if (detail.OrderId == 0)   // یا هر شرطی که نشان‌دهنده جدید بودن است
                {
                    detail.OrderId = CurrentEntity.Id;
                }
                CurrentEntity.OrderDetails.Add(detail);
            }

            SelectedDocument = frmCorelDataImporter.SelectedDocument;
            CurrentEntity.FilePath = SelectedDocument.FileName;
            btnOpenFile.EditValue = CurrentEntity.FilePath;
            orderDetailsBindingSource.ResetBindings(false);
            orderBindingSource.ResetBindings(false);
        }






        /// =================
        /// ذخیره سند کورل در پوشه Resources\CorelFiles با نام یکتا
        /// فایل با فرمت CDR ذخیره می‌شود
        /// =================
        /// <param name="selectedDocument">سند کورل برای ذخیره</param>
        /// <returns>مسیر کامل فایل ذخیره شده</returns>
        /// <exception cref="InvalidOperationException">اگر سند null باشد</exception>
        /// <exception cref="Exception">اگر ذخیره‌سازی با خطا مواجه شود</exception>
        public static bool SaveDocumentToResources(VGCore.Document selectedDocument, string fullPath)
        {
            if (selectedDocument == null)
                throw new InvalidOperationException("سند کورل معتبر نیست.");

            try
            {
                // ساخت تنظیمات ذخیره‌سازی
                var opt = new VGCore.StructSaveAsOptions();
                opt.Version = VGCore.cdrFileVersion.cdrVersion17;     // ورژن 17 = CorelDRAW X7
                opt.Overwrite = true;   // بازنویسی فایل در صورت وجود
                opt.EmbedICCProfile = false; // بدون پروفایل رنگی
                opt.EmbedVBAProject = false; // بدون پروژه VBA
                opt.IncludeCMXData = false; // بدون داده CMX
                opt.Range = VGCore.cdrExportRange.cdrAllPages;

                selectedDocument.SaveAs(fullPath, opt);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ذخیره فایل کورل:\n" + ex.Message, ex);
            }
        }





        private void SetCorelFileFullPath()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string targetFolder = Path.Combine(basePath, "Resources", "CorelFiles", $"User{CurrentEntity.CustomerId}");

            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);

            string fullPath = Path.Combine(targetFolder, SelectedDocument.FileName);
            CurrentEntity.FilePath = fullPath;

        }





        private void btnOpenFile_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string fileName = btnOpenFile.EditValue.ToString();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string targetFolder = Path.Combine(basePath, "Resources", "CorelFiles", $"User{CurrentEntity.CustomerId}");
            string filePath = Path.Combine(targetFolder, fileName);

            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is empty.");

            if (!File.Exists(filePath))
            {
                DialogResult dialogResult = XtraMessageBox.Show(
                    $"مایل به باز کردن پوشه مورد نظر هستید",
                    "File not found.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", filePath);
                    return;
                }
            }

            Process.Start("explorer.exe", $"/select,\"{filePath}\"");
        }

        private void rpsBtnDeleteCurrentDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            DialogResult dialogResult = XtraMessageBox.Show(
                    $"آیا از حذف ردیف انتخاب شده '{GetEntityDeleteMessge()}' مطمئن هستید؟",
                    "تأیید حذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (dialogResult == DialogResult.Yes)
            {
                OrderDetails selectedOrderDetail = (OrderDetails)grdvOrderDetails.GetFocusedRow();
                CurrentEntity.OrderDetails.Remove(selectedOrderDetail);
                grdvOrderDetails.RefreshData();
            }
        }

        private void btnOpenFile_EditValueChanged(object sender, EventArgs e)
        {
            var filename = btnOpenFile.EditValue;
            if (filename != null && !string.IsNullOrEmpty(filename.ToString()))
                btnOpenFile.Properties.Buttons[0].Enabled = true;
            else
                btnOpenFile.Properties.Buttons[0].Enabled = false;
        }
    }
}
