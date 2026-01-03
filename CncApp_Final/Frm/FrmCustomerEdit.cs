using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Helper;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CncApp_Final.Helper;

namespace CncApp_Final.Frm
{
    public partial class FrmCustomerEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        // ------------------------------------------------------------------
        // تغییر 1: اضافه کردن فیلد برای نگهداری شناسه جدید (برای بازگشت به لیست)
        // و تغییر نوع فیلد _Customer_Id به public برای دسترسی از فرم پدر (FrmCustomers.cs)
        // ------------------------------------------------------------------
        public int _Customer_Id { get; private set; } = 0; // 0 for new order
        public int _NewCreatedCustomertId { get; private set; } = 0; // برای نگهداری شناسه جدید پس از ذخیره
        private readonly bool _IsCustomerReadonly = false;

        private AppDbContext _dbContext;
        private Customer _currenCustomer;

        private readonly Action<int> _reloadCallback;
        

        public FrmCustomerEdit()
        {
            InitializeComponent();
            _dbContext = new AppDbContext();
        }



        public FrmCustomerEdit(int CustomerId, bool IsCustomerReadonly, Action<int> reloadCallback)
        {
            InitializeComponent();
            _Customer_Id = CustomerId;
            _IsCustomerReadonly = IsCustomerReadonly;
            _dbContext = new AppDbContext();
            _reloadCallback = reloadCallback;
        }


        // ------------------------------------------------------------------
        // تغییر 4: بازنویسی FrmCustomerEdit_Load برای فراخوانی InitData()
        // ------------------------------------------------------------------
        private void FrmCustomerEdit_Load(object sender, EventArgs e)
        {
            InitData();
            DxValidationHelper.SetupValidation<Customer>(this, dxValidationProvider1, customerBindingSource);
            ControlExraInit.ApplyFocusColor(this);

            txbPhone.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
            ClearValidation();
        }

        private void ClearValidation()
        {
            foreach (var ctrl in this.groupControl1.Controls.OfType<BaseEdit>())
            {
                dxValidationProvider1.RemoveControlError(ctrl);
            }

        }


        // ------------------------------------------------------------------
        // تغییر 2: پیاده‌سازی InitData()
        // ------------------------------------------------------------------
        private void InitData()
        {
            

            if (_Customer_Id == 0) // حالت جدید (New Customer)
            {
                // ایجاد یک نمونه جدید و اضافه کردن آن به DBContext برای ردیابی (Track)
                _currenCustomer = _dbContext.Customers.Create();
                _dbContext.Customers.Add(_currenCustomer);
                this.Text = "مشتری جدید";
                bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; // حذف برای مورد جدید نمایش داده نشود
            }
            else // حالت ویرایش یا فقط خواندنی (Edit or ReadOnly)
            {
                // بارگذاری مشتری موجود از دیتابیس
                _currenCustomer = _dbContext.Customers
                                            .FirstOrDefault(c => c.Id == _Customer_Id);

                if (_currenCustomer == null)
                {
                    XtraMessageBox.Show("مشتری مورد نظر یافت نشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                this.Text = $"ویرایش مشتری: {_currenCustomer.CustomerName}";
            }
            // اتصال نمونه Customer به BindingSource
            customerBindingSource.DataSource = _currenCustomer;

            // اعمال حالت فقط خواندنی (ReadOnly)
            if (_IsCustomerReadonly)
            {
                SetReadOnlyMode(true);
            }

            if ((double)txbBeginning_Balance.EditValue == 0)
                cmbBanalceMode.SelectedIndex = 0;
            else if ((double)txbBeginning_Balance.EditValue < 0)
                cmbBanalceMode.SelectedIndex = 1;
            else if ((double)txbBeginning_Balance.EditValue > 0)
                cmbBanalceMode.SelectedIndex = 2;

            var x = cmbBanalceMode.EditValue;

            txbBeginning_Balance.EditValue = Math.Abs((double)txbBeginning_Balance.EditValue);
        }

        // ------------------------------------------------------------------
        // تغییر 3: پیاده‌سازی متد کمکی برای حالت ReadOnly
        // ------------------------------------------------------------------
        private void SetReadOnlyMode(bool isReadOnly)
        {
            // بستن تمام امکانات ویرایش در نوار ریبون
            mainRibbonPageGroup.Enabled = !isReadOnly;

            // اگر حالت فقط خواندنی است، امکان بستن را هم فراهم کن
            bbiClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            // بستن امکان ویرایش برای تمام کنترل‌های ورودی (مانند TextEdit ها)
            foreach (Control control in groupControl1.Controls)
            {
                if (control is TextEdit textEdit)
                {
                    textEdit.Properties.ReadOnly = isReadOnly;
                }
                else if (control is ImageComboBoxEdit comboBoxEdit)
                {
                    comboBoxEdit.Properties.ReadOnly = isReadOnly;
                }
                // اگر کنترل‌های دیگری مانند CheckEdit یا DateEdit دارید، باید اینجا اضافه شوند.
            }
        }

        

        // ------------------------------------------------------------------
        // تغییر 5: پیاده‌سازی متد اصلی ذخیره
        // ------------------------------------------------------------------
        private bool SaveData()
        {

            // اعتبارسنجی ساده
            if ((double)txbBeginning_Balance.EditValue != 0 && (double)cmbBanalceMode.EditValue == 0)
            {
                XtraMessageBox.Show("با توجه مقدار اول دوره نوع ماهیت را انتخاب کنید.", "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBanalceMode.Focus();
                return false;
            }
            else
            {
                txbBeginning_Balance.EditValue = Math.Abs((double)txbBeginning_Balance.EditValue) * (double)cmbBanalceMode.EditValue;
            }

            if (!dxValidationProvider1.Validate())
                return false;

            customerBindingSource.EndEdit();
            
            try
            {
                // اگر مشتری جدید است، تغییرات توسط _dbContext.Customers.Add() در InitData ردیابی شده است.
                // اگر مشتری موجود است، تغییرات به طور خودکار توسط BindingSource و EF ردیابی می‌شوند.

                bool isNew = (_Customer_Id == 0);   // 👈 تشخیص جدید/ویرایش
                _dbContext.SaveChanges();
                _NewCreatedCustomertId = isNew ? _currenCustomer.Id : 0;   // 👈 همین خط مشکل را حل می‌کند


                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                // مدیریت خطاهای اعتبارسنجی Entity Framework
                var errorMessages = dbEx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => $"{x.PropertyName}: {x.ErrorMessage}");

                var fullErrorMessage = string.Join(Environment.NewLine, errorMessages);
                XtraMessageBox.Show($"خطای اعتبارسنجی در هنگام ذخیره:{Environment.NewLine}{fullErrorMessage}", "خطای ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطا در هنگام ذخیره سازی: {ex.Message}", "خطای ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }










        // ------------------------------------------------------------------
        // تغییر 6: پیاده‌سازی رویدادهای Ribbon Bar
        // ------------------------------------------------------------------

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveData())
            {
                _reloadCallback?.Invoke(_NewCreatedCustomertId);
                txbBeginning_Balance.EditValue = Math.Abs((double)txbBeginning_Balance.EditValue);

                XtraMessageBox.Show("ذخیره سازی با موفقیت انجام شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveData())
            {
                this.DialogResult = DialogResult.OK; // OK برای Refresh در فرم پدر
                this.Close();
            }
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveData())
            {
                _reloadCallback?.Invoke(_NewCreatedCustomertId);

                XtraMessageBox.Show("ذخیره سازی با موفقیت انجام شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // فرم را برای ورود مشتری جدید آماده می‌کند.
                _Customer_Id = 0; // تنظیم مجدد شناسه به حالت جدید
                InitData();      // بارگذاری داده‌های جدید (فرم را پاک می‌کند)
            }
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // لغو تمام تغییرات ردیابی شده توسط DbContext
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
            //بارگذاری مجدد فرم
            InitData();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // این دکمه فقط در حالت ویرایش نمایش داده می‌شود.
            if (_Customer_Id > 0)
            {
                DialogResult dialogResult = XtraMessageBox.Show(
                    $"آیا از حذف مشتری '{_currenCustomer.CustomerName}' مطمئن هستید؟",
                    "تأیید حذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        _dbContext.Customers.Remove(_currenCustomer);
                        _dbContext.SaveChanges();
                        this.DialogResult = DialogResult.Yes; // Yes برای Refresh در فرم پدر و اعلام حذف
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطا در حذف مشتری: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // اگر تغییراتی وجود دارد، از کاربر سوال شود
            if (_dbContext.ChangeTracker.HasChanges())
            {
                DialogResult dialogResult = XtraMessageBox.Show(
                    "تغییراتی اعمال شده است. آیا مایل به ذخیره هستید؟",
                    "ذخیره تغییرات",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.Yes)
                {
                    if (SaveData())
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    // اگر ذخیره موفقیت آمیز نبود، فرم بسته نمی‌شود (Cancel ضمنی)
                }
                else if (dialogResult == DialogResult.No)
                {
                    // رها کردن تغییرات و بستن
                    this.DialogResult = DialogResult.Cancel; // Cancel برای عدم Refresh در فرم پدر
                    this.Close();
                }
                // اگر Cancel شد، هیچ عملی انجام نمی‌شود.
            }
            else
            {
                // اگر تغییری نیست، فرم را ببند
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }





        //*****************************************************************************************************************************************
        //*****************************************************************************************************************************************
        //*****************************************************************************************************************************************




        private void txbCustomerName_Leave(object sender, EventArgs e)
        {
            //var x = txbCustomerName.EditValue;
            ////var z = string.IsNullOrWhiteSpace(x);
            //var s = x.GetType();

            
            
            
        }

        

        private void dxValidationProvider1_ValidationFailed(object sender, ValidationFailedEventArgs e)
        {
            
        }

        private void txbCustomerName_Validating(object sender, CancelEventArgs e)
        { 
            ////e.Cancel = true;
            //txbCustomerName.EditValue = txbCustomerName.Text.Trim();
            //var x = txbCustomerName.EditValue.GetType();
            //if (string.IsNullOrEmpty(txbCustomerName.Text))
            //{
            //    txbCustomerName.EditValue = null;
            //    dxValidationProvider1.Validate();
            //}
        }

        private void txbCustomerName_Validated(object sender, EventArgs e)
        {
            
        }



        private void txbCustomerName_EditValueChanged(object sender, EventArgs e)
        {
            if (txbCustomerName.EditValue != null)
            {
                txbCustomerName.EditValue = txbCustomerName.Text.Trim();
            }
        }

        private void txbAddress_EditValueChanged(object sender, EventArgs e)
        {
            if (txbAddress.EditValue != null)
            {
                txbAddress.EditValue = txbAddress.Text.Trim();
            }
        }

        

    }
}