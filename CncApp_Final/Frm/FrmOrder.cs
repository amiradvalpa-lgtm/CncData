
using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Frm;
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
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace CncApp_Final.Frm
{
    public partial class FrmOrder : DevExpress.XtraBars.Ribbon.RibbonForm
    {

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


            ribbonControl1.ApplicationCaption = order_Id == 0 ? "ورود به انبار جدید" : "ویرایش ورودی انبار";
            _Order_Id = order_Id;
            _IsOrderReadonly = isOrderReadonly;
            _dbContext = new AppDbContext(); // ایجاد یک کانکست جدید


            _dbContext.Customers.Load();
            customersBindingSource.DataSource = _dbContext.Customers.Local.ToBindingList();


            if (_Order_Id > 0)
            {
                // حالت ویرایش: بارگذاری یک رکورد مشخص
                Order order = _dbContext.Orders.Include(o => o.OrderDetails)
                                                     .FirstOrDefault(o => o.Id == _Order_Id);

                if (order != null)
                {
                    orderBindingSource.DataSource = order;
                    orderDetailsBindingSource.DataSource = order.OrderDetails;
                }
                else
                {
                    // اگر رکورد پیدا نشد، فرم را به حالت جدید ببرید
                    orderBindingSource.DataSource = new Order() { OrderDate = DateTime.Now };
                }
            }
            else
            {
                // حالت جدید: ایجاد یک رکورد جدید
                orderBindingSource.DataSource = new Order() { OrderDate = DateTime.Now };
            }

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
            txbFaOrderDate.Properties.ReadOnly = readOnly;
            txbFaDeliveryDate.Properties.ReadOnly = readOnly;
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
                                        _dbContext,
                                        grdvOrderDetails,
                                        1,
                                        this.Name);
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
            FrmCustomerEdit newFrmCustomers = new FrmCustomerEdit(0, false);
            newFrmCustomers.ShowDialog();

            if (newFrmCustomers.DialogResult == DialogResult.OK)
            {
                // فرض می‌کنیم FrmCustomers لیست مشتریان را به‌روز کرده و باید دوباره لود شود
                _dbContext.Customers.Load();
                customersBindingSource.DataSource = _dbContext.Customers.Local.ToBindingList();
                lueCustomer.Refresh();
                lueCustomer.EditValue = newFrmCustomers._New_Customer_Id;
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

            Order currentOrder = orderBindingSource.Current as Order;

            if (currentOrder == null)
            {
                XtraMessageBox.Show("سفارشی برای ذخیره وجود ندارد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 2. اعتبارسنجی اولیه Order Header
            if (currentOrder.CustomerId <= 0 || currentOrder.Customer == null)
            {
                XtraMessageBox.Show("انتخاب مشتری الزامی است.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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
                _dbContext.SaveChanges();

                _Save_SuccesFull = true;
                XtraMessageBox.Show("سفارش با موفقیت ذخیره شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. به‌روزرسانی Id سفارش (اگر جدید بود)
                if (_Order_Id == 0)
                {
                    _Order_Id = currentOrder.Id;
                    ribbonControl1.ApplicationCaption = "ویرایش ورودی انبار";
                    // مطمئن شوید که txbVCF_Id (شماره فاکتور) هم به‌روز شده است
                }
                return true;
            }
            // مدیریت خطاهای اعتبارسنجی
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                // ... (منطق نمایش خطای DbEntityValidationException)
                XtraMessageBox.Show("خطای اعتبارسنجی در Entity Framework. جزئیات را چک کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        // FrmOrder.cs

        private void OpenOrderDetailForEdit(OrderDetails originalDetail)
        {
            using (CncApp_Final.TempFrm.FrmOrderDetails frmOrderDetailEdit = new CncApp_Final.TempFrm.FrmOrderDetails(originalDetail, _dbContext))
            {
                DialogResult result = frmOrderDetailEdit.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // 3. رفرش DataGrid و فیلدهای محاسباتی Order
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
                // دریافت شیء کامل OrderDetails از سطر فوکوس شده
                OrderDetails detailToEdit = view.GetRow(info.RowHandle) as OrderDetails;

                if (detailToEdit != null)
                {
                    // EndEdit برای اطمینان از اعمال هرگونه تغییرات ناتمام در سطر
                    view.CloseEditor();
                    view.UpdateCurrentRow();

                    OpenOrderDetailForEdit(detailToEdit);
                }
            }
        }

        private void btnNewDetail_Click(object sender, EventArgs e)
        {
            Order currentOrder = orderBindingSource.Current as Order;

            if (currentOrder == null)
            {
                XtraMessageBox.Show("ابتدا سفارش را ایجاد یا انتخاب کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. ایجاد یک شیء جدید OrderDetails
            OrderDetails newDetail = new OrderDetails();

            // اگر از قبل OrderId وجود داشت، آن را به Detail پاس می‌دهیم (اختیاری، اما مفید برای Navigation Property)
            newDetail.OrderId = currentOrder.Id;

            // 2. باز کردن فرم مودال برای افزودن جدید
            using (CncApp_Final.TempFrm.FrmOrderDetails frmOrderDetailNew = new CncApp_Final.TempFrm.FrmOrderDetails(newDetail, _dbContext))
            {
                DialogResult result = frmOrderDetailNew.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // 🔑 اعمال منطق افزودن جدید: تنظیم Id = 0 و افزودن به Collection اصلی
                    // این اطمینان می‌دهد که EF آن را به عنوان یک ردیف جدید در دیتابیس درج کند.
                    newDetail.Id = 0;

                    // اگر OrderId از ابتدا ست نشده بود، اینجا ست شود:
                    newDetail.OrderId = currentOrder.Id;

                    // افزودن به Collection ناوبری Order اصلی
                    currentOrder.OrderDetails.Add(newDetail);

                    // برای اینکه DataGrid و فیلدهای محاسباتی Order به‌روز شوند:
                    orderDetailsBindingSource.ResetBindings(false);
                    orderBindingSource.ResetBindings(false);
                }
            }
        }

        private void groupControl4_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void FrmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridLayoutHelper.SaveLayout(
                                        _dbContext,
                                        grdvOrderDetails,
                                        1,
                                        this.Name);
        }
    }
}
