
using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Frm;
using CncApp_Final.Frms;
using CncApp_Final.Helper; // فرض می‌کنیم این فضای نام برای کلاس‌های کمکی است.
using CncApp_Final.Helpers;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;


namespace CncApp_Final.Frm
{
    public partial class FrmOrder : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public VGCore.Document SelectedDocument;

        // خصوصیات برای نگهداری شناسه و وضعیت سفارش
        public int _Order_Id { get; private set; } = 0; // 0 for new order
        private readonly bool _IsOrderReadonly = false;
        private bool _Save_SuccesFull = false;


        // کانکست پایگاه داده
        private AppDbContext _dbContext = new CncApp_Final.Data.AppDbContext();
        private Order _currentOrder;

        


        public FrmOrder()
        {
            InitializeComponent();
        }

        // سازنده برای ویرایش سفارش موجود (با پارامتر)
        public FrmOrder(int order_Id, bool isOrderReadonly)
        {
            InitializeComponent();


            ribbonControl1.ApplicationCaption = order_Id == 0 ? "سفارش جدید" : "ویرایش سفارش";
            _Order_Id = order_Id;
            _IsOrderReadonly = isOrderReadonly;
            _dbContext = new AppDbContext(); // ایجاد یک کانکست جدید


            _dbContext.Customers.Load();
            customersBindingSource.DataSource = _dbContext.Customers.Local.ToBindingList();




            //
            //*******************************************************************************************
            //

            Order order = _dbContext.Orders.Include(o => o.OrderDetails)
                                                     .FirstOrDefault(o => o.Id == _Order_Id);
            if (_Order_Id > 0)
            {
                // حالت ویرایش: بارگذاری یک رکورد مشخص
                order = _dbContext.Orders.Include(o => o.OrderDetails)
                                                     .FirstOrDefault(o => o.Id == _Order_Id);
                if (order != null)
                {

                }
                else
                {
                    // اگر رکورد پیدا نشد، فرم را به حالت جدید ببرید
                    order = new Order() { OrderDate = DateTime.Now, InvoiceNumber = GetNextInvoiceNumber() };
                }
            }
            else
            {
                // حالت جدید: ایجاد یک رکورد جدید
                order = new Order() { OrderDate = DateTime.Now ,InvoiceNumber= GetNextInvoiceNumber() };
            }
            orderBindingSource.DataSource = order;
            orderDetailsBindingSource.DataSource = order.OrderDetails;

            //
            //*******************************************************************************************
            //



            // 🆕 اعمال تنظیمات ReadOnly
            if (_IsOrderReadonly)
            {
                SetReadOnly(this._IsOrderReadonly);
            }
            SetDxDalidation();
        }

        private void SetDxDalidation()
        {
            // 🔑 فراخوانی برای تنظیم قوانین اعتبارسنجی Order Header
            DxValidationHelper.SetupValidation<Order>(this, dxValidationProvider1, orderBindingSource);
        }

        // FrmOrder.cs

        /// <summary>
        /// تنظیم حالت فقط خواندنی برای تمام کنترل‌ها و دکمه‌های ریبون
        /// </summary>
        private void SetReadOnly(bool readOnly)
        {
            // الف) کنترل‌های Header (LookUpEdit, TextEdit, MemoEdit)
            lueCustomer.Properties.ReadOnly = readOnly;
            txbFaOrderDate.InnerTextEdit.Properties.ReadOnly = readOnly;
            txbFaDeliveryDate.InnerTextEdit.Properties.ReadOnly = readOnly;
            txbTransportCost.Properties.ReadOnly = readOnly;
            txbMiscCost.Properties.ReadOnly = readOnly;
            txbDescription.Properties.ReadOnly = readOnly;

            // ب) کنترل‌های مرتبط با جزئیات (GridControl و دکمه‌های افزودن/حذف)
            btnNewCustomer.Enabled = !readOnly;
            btnNewDetail.Enabled = !readOnly;

            // ج) غیرفعال کردن امکان ویرایش سطرها در GridControl
            grdvOrderDetails.OptionsBehavior.Editable = !readOnly;
            grdvOrderDetails.OptionsBehavior.ReadOnly = readOnly;

            // د) دکمه‌های ریبون (ذخیره و حذف)
            bbiSave.Enabled = !readOnly;
            bbiSaveClose.Enabled = !readOnly;
            bbiDelete.Enabled = !readOnly;

            // فرض می‌کنیم bbiDeleteDetail برای حذف جزئیات در ریبون وجود دارد
            // bbiDeleteDetail.Enabled = !readOnly; 
        }

        //************************************************************************************************************************************



        private void FrmFacture_Load(object sender, EventArgs e)
        {
            GridLayoutHelper.LoadLayout(
                                        grdvOrderDetails,
                                        1,
                                        this.Name);



            // حالا تنظیمات را مجدداً به اجبار (Force) اعمال کنید
            var view = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view != null)
            {
                view.OptionsView.RowAutoHeight = true;

                // ستون مورد نظر را پیدا کنید و دوباره تنظیم کنید
                var column = view.Columns["CutSheetDetails"];
                if (column != null)
                {
                    column.ColumnEdit = repositoryItemMemoEdit1; // حتماً دوباره انتساب دهید
                    column.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

                    // 2. حالا تنظیمات تراز عمودی را به اجبار اعمال کنید
                    // تنظیم برای تمام سطرها
                    grdvOrderDetails.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    grdvOrderDetails.Appearance.Row.Options.UseTextOptions = true;

                    // اگر می‌خواهید فقط ستون مشخصات وسط‌چین شود:
                    column.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    column.AppearanceCell.Options.UseTextOptions = true;

                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    column.AppearanceCell.Options.UseTextOptions = true;


                }
            }

            //dxValidationProvider1.SetValidationRule(txbFaDeliveryDate,
            //        new DevExpress.XtraEditors.DXErrorProvider.CustomValidationRule()
            //        {
            //            ErrorText = "",
            //            Validate = (ctrl, value) =>
            //            {
            //                DateTime dt;
            //                string err;

            //                bool ok = PersianDate.TryParse(Convert.ToString(value), out dt, out err);

            //                if (!ok)
            //                    ErrorText = err;

            //                return ok;
            //            }
            //        });

            //            dxValidationProvider1.SetValidationRule(
            //    txbFaDeliveryDate,
            //    new PersianDateValidationRule()
            //);


            //// Validation روی TextEdit
            //dxValidationProvider1.SetValidationRule(txbFaDeliveryDate,
            //    new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
            //    {
            //        ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator..Custom,
            //        ErrorText = "", // پیام را در PersianDateValidationRule می‌دهیم
            //        ValidationCallback = (ctrl, value) =>
            //        {
            //            DateTime dt;
            //            string err;
            //            bool ok = PersianDate.TryParse(Convert.ToString(value), out dt, out err);
            //            if (!ok)
            //            {
            //                dxValidationProvider1.SetError(ctrl, err, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            //            }
            //            return ok;
            //        }
            //    });




            //            // txbFaDeliveryDate اسم TextEdit
            //            dxValidationProvider1.SetValidationRule(
            //                txbFaDeliveryDate,
            //                new PersianDateValidationRule()
            //            );

            //            dxValidationProvider1.SetValidationRule(
            //    persianDateTextEdit1.InnerTextEdit,
            //    new PersianDateValidationRule()
            //);

            //            dxValidationProvider1.SetValidationRule(
            //    persianDateTextEdit2.InnerTextEdit,
            //    new PersianDateValidationRule()
            //);

            //            dxValidationProvider1.SetValidationRule(
            //    persianDateTextEdit3.InnerTextEdit,
            //    new PersianDateValidationRule()
            //);


        }






        //***********************************************************************************************************************************
        //************************************************************************************************************************************
        //************************************************************************************************************************************
        //************************************************************************************************************************************
        //************************************************************************************************************************************



        // ─── Event Handlers دکمه‌ها ────────────────────────────────────────────────────────

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                // ایجاد شیء جدید برای ذخیره بعدی
                orderBindingSource.DataSource = new Order() { OrderDate = DateTime.Now };
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_IsOrderReadonly)
            {
                XtraMessageBox.Show("فرم در حالت فقط خواندنی است و امکان حذف وجود ندارد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Order currentOrder = orderBindingSource.Current as Order;

            if (currentOrder != null && currentOrder.Id > 0)
            {
                if (XtraMessageBox.Show("آیا مطمئن هستید که می‌خواهید این مورد را حذف کنید؟", "تأیید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // از Local حذف نکنید، مستقیماً از DbContext حذف کنید
                    _dbContext.Orders.Remove(currentOrder);
                    _dbContext.SaveChanges();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        

        private void FrmOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Save_SuccesFull)
            {
                DialogResult = DialogResult.OK;
            }
        }


        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomerEdit newFrmCustomers = new FrmCustomerEdit(0, false, null);
            newFrmCustomers.ShowDialog();

            if (newFrmCustomers.DialogResult == DialogResult.OK)
            {
                // فرض می‌کنیم FrmCustomers لیست مشتریان را به‌روز کرده و باید دوباره لود شود
                _dbContext.Customers.Load();
                customersBindingSource.DataSource = _dbContext.Customers.Local.ToBindingList();
                lueCustomer.Refresh();
                lueCustomer.EditValue = newFrmCustomers._NewCreatedCustomertId;
                // اگر مشتری جدیدی ثبت شده باشد، می‌توانید EditValue را به آن مشتری جدید تنظیم کنید.
            }
        }



        //************************************************************************************************************************************
        //************************************************************************************************************************************
        //************************************************************************************************************************************
        //************************************************************************************************************************************
        //************************************************************************************************************************************


        #region Saving Logic

        // FrmOrder.cs

        private bool Save()
        {
            // 1. پایان ویرایش در BindingSource اصلی (Order Header)
            orderBindingSource.EndEdit();

            if(!dxValidationProvider1.Validate())
                return false;

            Order currentOrder = orderBindingSource.Current as Order;

            if (currentOrder == null)
            {
                XtraMessageBox.Show("سفارشی برای ذخیره وجود ندارد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //// 2. اعتبارسنجی اولیه Order Header
            //if (currentOrder.CustomerId <= 0 )
            //{
            //    XtraMessageBox.Show("انتخاب مشتری الزامی است.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            if (!currentOrder.OrderDetails.Any())
            {
                XtraMessageBox.Show("سفارش باید حداقل یک جزئیات داشته باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 3. افزودن به Context در صورت نیاز (حالت New)
            if (currentOrder.Id == 0)
            {
                // اگر سفارش جدید است، آن را به Context اضافه می‌کنیم. 
                // EF به طور خودکار OrderDetails مرتبط را نیز در حالت Added قرار می‌دهد.
                _dbContext.Orders.Add(currentOrder);
            }

            // 4. SaveChanges - تراکنش نهایی
            try
            {
                var changedSheets = _dbContext.ChangeTracker.Entries()
    .Where(e => e.State == EntityState.Added && e.Entity.GetType().Name.Contains("Sheet"))
    .ToList();

                var changedSheets1 = _dbContext.ChangeTracker.Entries();
                if (changedSheets.Any())
                {
                    foreach (var entry in changedSheets)
                    {
                        var props = entry.CurrentValues.PropertyNames
                            .Where(p => entry.Property(p).IsModified)
                            .ToList();

                        string msg = $"Sheet تغییر کرده در فیلدهای: {string.Join(", ", props)}";
                        MessageBox.Show(msg);
                        // اینجا لاگ کن یا MessageBox بزن
                    }
                }




                _dbContext.SaveChanges();

                _Save_SuccesFull = true;
                XtraMessageBox.Show("سفارش با موفقیت ذخیره شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. به‌روزرسانی Id سفارش (اگر جدید بود)
                if (_Order_Id == 0)
                {
                    _Order_Id = currentOrder.Id;
                    ribbonControl1.ApplicationCaption = "ویرایش سفارش";
                    // مطمئن شوید که txbVCF_Id (شماره فاکتور) هم به‌روز شده است
                }
                SetCorelFileFullPath();
                SaveDocumentToResources(SelectedDocument, currentOrder.FilePath);
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
                XtraMessageBox.Show($"خطا در ذخیره سازی: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion
        //************************************************************************************************************************************



        InputLanguage original;
        private void textEdit_Enter(object sender, EventArgs e)
        {
            original = InputLanguage.CurrentInputLanguage;
            var culture = System.Globalization.CultureInfo.GetCultureInfo("fa-IR");
            var language = InputLanguage.FromCulture(culture);
            if (InputLanguage.InstalledInputLanguages.IndexOf(language) >= 0)
                InputLanguage.CurrentInputLanguage = language;
            else
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        private void textEdit_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = original;
        }


        /// <summary>
                /// کرفتن متن ستون از گریدیو
                /// </summary>
                /// <param name="gw"></param>
                /// <param name="column"></param>
                /// <returns></returns>
        private static string GetTextColumnValue(GridView gw, string column)
        {
            if (gw.RowCount <= 0)
            {
                return " ";
            }
            try
            {
                int i = gw.FocusedRowHandle;
                return gw.IsGroupRow(i)
                ? gw.GetGroupRowValue(i, gw.Columns[column]).ToString()
                : gw.GetRowCellValue(i, column).ToString();
            }
            catch
            {
                MessageBox.Show($@"درخواستی در کنترل انتخابی موجود نمی باشد( {column} ) ستون");
                return " ";
            }
        }



        
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ReportHelper.PrintCurrent(_VCF_Id);
        }

        private void bbiPrintPhoto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ReportHelper.PrintCurrentPhoto(_VCF_Id);
        }

        private void bbiExportPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ReportHelper.ExportPDFCurrent(_VCF_Id);
        }

        
        private void bbiPhoto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //XfrmPhoto xfrmPhoto = new XfrmPhoto(_VCF_Id);
            //xfrmPhoto.ShowDialog();
        }



        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************


      

        private void OpenOrderDetailForEdit(OrderDetails originalDetail)
        {
            using (CncApp_Final.TempFrm.FrmOrderDetails frmOrderDetailEdit = new CncApp_Final.TempFrm.FrmOrderDetails(originalDetail, _dbContext))
            {
                DialogResult result = frmOrderDetailEdit.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _dbContext.Entry(originalDetail).Reference(x => x.Sheet).Load();

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

            if ((info.InRow || info.InRowCell) && view.IsDataRow(info.RowHandle))
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
            grdvOrderDetails.RefreshData();
            Order currentOrder = orderBindingSource.Current as Order;

            if (currentOrder == null)
            {
                XtraMessageBox.Show("ابتدا سفارش را ایجاد یا انتخاب کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OrderDetails newDetail = new OrderDetails();
            newDetail.OrderId = currentOrder.Id;

            using (CncApp_Final.TempFrm.FrmOrderDetails frmOrderDetailNew = new CncApp_Final.TempFrm.FrmOrderDetails(newDetail, _dbContext))
            {
                DialogResult result = frmOrderDetailNew.ShowDialog();

                if (result == DialogResult.OK)
                {
                    newDetail.Id = 0;
                    newDetail.OrderId = currentOrder.Id;

                    //_dbContext.Entry(newDetail).Reference(x => x.Sheet).Load();

                    currentOrder.OrderDetails.Add(newDetail);
                    orderDetailsBindingSource.ResetBindings(false);
                    orderBindingSource.ResetBindings(false);
                }
            }
        }


        private void FrmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridLayoutHelper.SaveLayout(
                                        grdvOrderDetails,
                                        1,
                                        this.Name);
        }

        public string GetNextInvoiceNumber()
        {
            var pc = new PersianCalendar();
            int year = pc.GetYear(DateTime.Now);
            int yy = year % 100; // دو رقم آخر سال

            string prefix = $"F{yy:D2}-";

            var lastInvoice = _dbContext.Orders
                .Where(o => o.InvoiceNumber.StartsWith(prefix))
                .Select(o => o.InvoiceNumber)
                .OrderByDescending(x => x)
                .FirstOrDefault();

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

        private void txbInvoiceNumber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void grdvOrderDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

        }

        private void btnImportFromCorel_Click(object sender, EventArgs e)
        {
            FrmCorelDataImporter frmCorelDataImporter = new FrmCorelDataImporter(_dbContext);
            frmCorelDataImporter.ShowDialog();

            Order currentOrder = orderBindingSource.Current as Order;
            foreach (var detail in frmCorelDataImporter._orderDetails)
            {
                // مهم: اگر OrderDetails جدید است، حتماً OrderId را ست کنید
                if (detail.OrderId == 0)   // یا هر شرطی که نشان‌دهنده جدید بودن است
                {
                    detail.OrderId = currentOrder.Id;
                }
                currentOrder.OrderDetails.Add(detail);
            }

            SelectedDocument = frmCorelDataImporter.SelectedDocument;
            currentOrder.FilePath = SelectedDocument.FileName;
            orderDetailsBindingSource.ResetBindings(false);
            orderBindingSource.ResetBindings(false);
        }

        private void btnOpenFile_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {
                e.DisplayText = string.Empty;
                return;
            }

            var value = e.Value.ToString();

            if (string.IsNullOrWhiteSpace(value))
            {
                e.DisplayText = string.Empty;
                return;
            }

            e.DisplayText = Path.GetFileName(value);
        }

        /// =================
        /// ذخیره سند کورل در پوشه Resources\CorelFiles با نام یکتا
        /// فایل با فرمت CDR ذخیره می‌شود
        /// =================
        /// <param name="selectedDocument">سند کورل برای ذخیره</param>
        /// <returns>مسیر کامل فایل ذخیره شده</returns>
        /// <exception cref="InvalidOperationException">اگر سند null باشد</exception>
        /// <exception cref="Exception">اگر ذخیره‌سازی با خطا مواجه شود</exception>
        public static string SaveDocumentToResources(VGCore.Document selectedDocument, string fullPath)
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
                return fullPath;
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ذخیره فایل کورل:\n" + ex.Message, ex);
            }


        }

        private void SetCorelFileFullPath()
        {
            Order currentOrder = orderBindingSource.Current as Order;

            // مسیر bin\Debug یا bin\Release
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // مسیر نهایی: Resources\CorelFiles
            string targetFolder = Path.Combine(basePath, "Resources", "CorelFiles", $"User{currentOrder.CustomerId}");

            // اگر فولدر وجود نداشت بساز
            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);

            string fullPath = Path.Combine(targetFolder, SelectedDocument.FileName);
            currentOrder.FilePath = fullPath;
            
        }

        private void btnOpenFile_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Order currentOrder = orderBindingSource.Current as Order;

            string fileName = btnOpenFile.EditValue.ToString();

            // مسیر bin\Debug یا bin\Release
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // مسیر نهایی: Resources\CorelFiles
            string targetFolder = Path.Combine(basePath, "Resources", "CorelFiles", $"User{currentOrder.CustomerId}");

            string filePath = Path.Combine(targetFolder, fileName);


            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is empty.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found.", filePath);

            Process.Start("explorer.exe", $"/select,\"{filePath}\"");
        }
    }
}
