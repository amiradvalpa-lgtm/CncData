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

namespace CncApp_Final.Frm
{
    public partial class FrmReceiptEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public int _Receipt_Id { get; private set; } = 0; // 0 for new receipt
        public int _NewCreatedReceiptId { get; private set; } = 0; // برای نگهداری شناسه جدید پس از ذخیره
        private readonly bool _IsReceiptReadonly = false;

        private AppDbContext _dbContext;
        private Receipt _currentReceipt;

        private readonly Action<int> _reloadCallback;


        public FrmReceiptEdit()
        {
            InitializeComponent();
            _dbContext = new AppDbContext();
            
        }

        public FrmReceiptEdit(int receiptId, bool isReceiptReadonly, Action<int> reloadCallback)
        {
            InitializeComponent();
            _Receipt_Id = receiptId;
            _IsReceiptReadonly = isReceiptReadonly;
            _dbContext = new AppDbContext();

            _reloadCallback = reloadCallback;
        }

        private void FrmReceiptEdit_Load(object sender, EventArgs e)
        {
            ControlExraInit.InitLookupEdit(lkpCustomer);
            ControlExraInit.InitLookupEdit(lkpBanks);

            DxValidationHelper.SetupValidation<Receipt>(this, dxValidationProvider1, receiptBindingSource);
            ControlExraInit.ApplyFocusColor(this);
            InitData();

        }


        // ----------------- متدهای داخلی اصلی -----------------

        // 1. InitData: آماده‌سازی فرم و بارگذاری داده‌ها
        private void InitData()
        {
            // 1. بارگذاری داده‌های مرجع برای LookUpEdit ها
            // این بخش برای پر کردن لیست مشتریان و حساب‌های بانکی ضروری است و حفظ می‌شود.
            _dbContext.Customers.Load();
            customersBindingSource.DataSource = _dbContext.Customers.Local.ToBindingList();

            _dbContext.BankAccounts.Load();
            banksBindingSource.DataSource = _dbContext.BankAccounts.Local.ToBindingList();

            // 2. تعیین حالت فرم (جدید/ویرایش)
            if (_Receipt_Id == 0) // حالت جدید (New Receipt)
            {
                // ایجاد یک نمونه جدید و اضافه کردن آن به DBContext برای ردیابی (Track)
                _currentReceipt = _dbContext.Receipts.Create();
                _dbContext.Receipts.Add(_currentReceipt);

                this.Text = "رسید جدید";
                bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; // حذف برای مورد جدید نمایش داده نشود

                // مقداردهی اولیه فیلدهای جدید (همانند اصول قبلی برای جلوگیری از Null)
                _currentReceipt.Date = DateTime.Now;
                _currentReceipt.Amount = 0;
                lkpCustomer.Focus();
            }
            else // حالت ویرایش یا فقط خواندنی (Edit or ReadOnly)
            {
                // بارگذاری رسید موجود از دیتابیس
                _currentReceipt = _dbContext.Receipts
                                            .FirstOrDefault(r => r.Id == _Receipt_Id);

                if (_currentReceipt == null)
                {
                    XtraMessageBox.Show("رسید مورد نظر یافت نشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                this.Text = $"ویرایش رسید: {_currentReceipt.Id}";

            }

            // 3. اتصال نمونه Receipt به BindingSource (الگوی مستقیم فرم پایه)
            // توجه: در این الگو، موجودیت مستقیماً به DataSource وصل می‌شود.
            receiptBindingSource.DataSource = _currentReceipt;

            // 4. اعمال حالت فقط خواندنی (ReadOnly)
            if (_IsReceiptReadonly)
            {
                SetReadOnlyMode(true);
            }

            ClearValidation();
        }

        private void ClearValidation()
        {
            foreach (var ctrl in this.groupControl1.Controls.OfType<BaseEdit>())
            {
                dxValidationProvider1.RemoveControlError(ctrl);
            }
            
        }


        // 2. SetReadOnlyMode: اعمال حالت فقط خواندنی
        private void SetReadOnlyMode(bool isReadOnly)
        {
            mainRibbonPageGroup.Enabled = !isReadOnly;
            bbiClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            foreach (Control control in groupControl1.Controls)
            {
                BaseEdit baseEdit = control as BaseEdit;
                if (baseEdit != null)
                {
                    baseEdit.Properties.ReadOnly = isReadOnly;
                }
            }
        }


        private bool SaveData()
        {
            receiptBindingSource.EndEdit();

            if (!dxValidationProvider1.Validate())
            {
                XtraMessageBox.Show("لطفاً اطلاعات ورودی را به درستی تکمیل کنید.", "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
                        
            try
            {
                bool isNew = (_Receipt_Id == 0);   // 👈 تشخیص جدید/ویرایش
                _dbContext.SaveChanges();
                _NewCreatedReceiptId = isNew ? _currentReceipt.Id : 0;   // 👈 همین خط مشکل را حل می‌کند

                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
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



        // ----------------- رویدادهای Ribbon Bar -----------------

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveData())
            {
                _reloadCallback?.Invoke(_NewCreatedReceiptId);

                XtraMessageBox.Show("ذخیره سازی با موفقیت انجام شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveData())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveData())
            {
                _reloadCallback?.Invoke(_NewCreatedReceiptId);

                XtraMessageBox.Show("ذخیره سازی با موفقیت انجام شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // آماده سازی برای رسید جدید
                // 1. Detach کردن نمونه قدیمی
                if (_currentReceipt != null)
                {
                    _dbContext.Entry(_currentReceipt).State = EntityState.Detached;
                    _currentReceipt = null;
                }

                _Receipt_Id = 0; // تنظیم مجدد شناسه به حالت جدید
                InitData();      // بارگذاری داده‌های جدید
            }
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 1. Detach کردن نمونه فعلی از ردیابی
            if (_currentReceipt != null)
            {
                _dbContext.Entry(_currentReceipt).State = EntityState.Detached;
                _currentReceipt = null;
            }

            // 2. بارگذاری مجدد فرم
            InitData();
            XtraMessageBox.Show("تغییرات لغو و مقادیر اصلی بازیابی شدند.", "بازنشانی", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_Receipt_Id > 0)
            {
                DialogResult dialogResult = XtraMessageBox.Show(
                    $"آیا از حذف رسید به مبلغ '{_currentReceipt.Amount:N0}' مطمئن هستید؟",
                    "تأیید حذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        _dbContext.Receipts.Remove(_currentReceipt);
                        _dbContext.SaveChanges();
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطا در حذف رسید: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void bbiReset_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_Receipt_Id == 0)
            {
                // اگر در حالت ثبت رسید جدید هستیم
                DialogResult dr = XtraMessageBox.Show(
                    "اطلاعات وارد شده پاک شود و فرم به حالت جدید برگردد؟",
                    "بازنشانی",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    // Detach موجودیت فعلی
                    if (_currentReceipt != null)
                    {
                        _dbContext.Entry(_currentReceipt).State = EntityState.Detached;
                        _currentReceipt = null;
                    }

                    InitData();   // فرم را دوباره در حالت New آماده می‌کند
                }

                return;
            }

            // ---- حالت ویرایش (Edit) ----
            DialogResult result = XtraMessageBox.Show(
                "تغییرات انجام شده حذف و اطلاعات اصلی دوباره بارگذاری شود؟",
                "بازنشانی تغییرات",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // موجودیت فعلی را از ردیابی خارج کن
                if (_currentReceipt != null)
                {
                    _dbContext.Entry(_currentReceipt).State = EntityState.Detached;
                    _currentReceipt = null;
                }

                // دوباره لود کن
                _currentReceipt = _dbContext.Receipts
                                            .FirstOrDefault(r => r.Id == _Receipt_Id);

                if (_currentReceipt == null)
                {
                    XtraMessageBox.Show("رسید در دیتابیس یافت نشد.",
                        "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                receiptBindingSource.DataSource = _currentReceipt;

                XtraMessageBox.Show("تغییرات لغو و اطلاعات اصلی بازیابی شد.",
                    "بازنشانی",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطا در بازنشانی: {ex.Message}",
                    "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}
