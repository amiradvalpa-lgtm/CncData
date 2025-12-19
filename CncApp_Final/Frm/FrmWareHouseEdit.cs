using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CncApp_Final.Helper;
using CncApp_Final.Entities;
using System.Data.Entity;

namespace CncApp_Final.Frm
{
    public partial class FrmWareHouseEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
        private bool isReadOnly;
        public int _New_Row_Id;
        private bool _Save_SuccesFull = false;

        public FrmWareHouseEdit()
        {
            InitializeComponent();

            ControlExraInit.InitRibonControl(mainRibbonControl, "ورود به انبار جدید");
            ControlExraInit.InitLookupEdit(SheetIdLookUpEdit);

            
            dbContext.Warehouses.Load();
            warehousesBindingSource.DataSource = dbContext.Warehouses.Local.ToBindingList();
            
            dbContext.Sheets.Load();
            sheetsBindingSource.DataSource = dbContext.Sheets.Local.ToBindingList();
        }


        public FrmWareHouseEdit(int warehouseId = 0, bool isReadOnly = false)
        {
            InitializeComponent();

            this.isReadOnly = isReadOnly; // 🆕 ذخیره وضعیت

            ControlExraInit.InitRibonControl(mainRibbonControl, warehouseId == 0 ? "ورود به انبار جدید" : "ویرایش ورودی انبار");
            ControlExraInit.InitLookupEdit(SheetIdLookUpEdit);

            dbContext.Sheets.Load();
            sheetsBindingSource.DataSource = dbContext.Sheets.Local.ToBindingList();

            if (warehouseId > 0)
            {
                // حالت ویرایش: بارگذاری یک رکورد مشخص
                Warehouse warehouse = dbContext.Warehouses.Include(w => w.Sheet)
                                                     .FirstOrDefault(w => w.Id == warehouseId);

                if (warehouse != null)
                {
                    warehousesBindingSource.DataSource = warehouse;
                }
                else
                {
                    // اگر رکورد پیدا نشد، فرم را به حالت جدید ببرید
                    warehousesBindingSource.DataSource = new Warehouse() { OrderDate = DateTime.Now };
                }
            }
            else
            {
                // حالت جدید: ایجاد یک رکورد جدید
                warehousesBindingSource.DataSource = new Warehouse() { OrderDate = DateTime.Now };
            }

            // 🆕 اعمال تنظیمات ReadOnly
            SetReadOnly(this.isReadOnly);

            SheetIdLookUpEdit.EditValueChanged += SheetIdLookUpEdit_EditValueChanged;
        }


        private void FrmWareHouseEdit_Load(object sender, EventArgs e)
        {
            // بارگذاری در سازنده انجام شد، نیازی به AddNew یا چک کردن Current نیست.
        }



        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************





        /// <summary>
        /// 🆕 راه‌حل نهایی: به‌روزرسانی شیء Sheet و رفرش Binding با قطع و وصل موقت اتصال LookUpEdit
        /// </summary>
        private void SheetIdLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (SheetIdLookUpEdit.EditValue == null || SheetIdLookUpEdit.EditValue == DBNull.Value) return;

            if (warehousesBindingSource.Current is Warehouse currentWarehouse)
            {
                int newSheetId = (int)SheetIdLookUpEdit.EditValue;

                // اگر SheetId واقعاً تغییر نکرده و شیء Sheet وجود دارد، کاری نکنیم
                if (currentWarehouse.SheetId == newSheetId && currentWarehouse.Sheet != null)
                {
                    return;
                }

                // 1. جستجوی شیء Sheet جدید
                Sheet newSheet = dbContext.Sheets.Local.FirstOrDefault(s => s.Id == newSheetId);

                if (newSheet != null)
                {
                    // 2. قطع اتصال LookUpEdit به BindingSource
                    // این کار از فراخوانی مجدد EditValueChanged در حین ResetBindings جلوگیری می‌کند
                    Binding lookUpBinding = SheetIdLookUpEdit.DataBindings["EditValue"];
                    SheetIdLookUpEdit.DataBindings.Clear();

                    try
                    {
                        // 3. انتساب شیء Sheet جدید و به‌روزرسانی SheetId در مدل
                        currentWarehouse.Sheet = newSheet;
                        // اگرچه LookUpEdit قطع شده، این خط مقدار نهایی را در مدل ذخیره می‌کند
                        currentWarehouse.SheetId = newSheetId;

                        // 4. رفرش BindingSource برای به‌روزرسانی فیلدهای محاسبه‌ای (PreSheetPrice, NewSheetPrice)
                        warehousesBindingSource.ResetBindings(false);
                    }
                    catch (Exception ex)
                    {
                        // در صورت بروز خطا، آن را مدیریت کنید
                        XtraMessageBox.Show($"خطا در به‌روزرسانی قیمت‌های ورق: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // 5. اتصال مجدد LookUpEdit
                        if (lookUpBinding != null)
                        {
                            SheetIdLookUpEdit.DataBindings.Add(lookUpBinding);
                        }
                    }
                }
            }
        }
        





        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************





        /// <summary>
        /// متد اعتبارسنجی ساده (همیشه True)
        /// </summary>
        private bool IsValid()
        {
            // طبق درخواست شما، اعتبارسنجی انجام نمی‌شود
            return true;
        }

        /// <summary>
        /// ذخیره اطلاعات Warehouse و به‌روزرسانی Sheet
        /// </summary>
        private bool Save()
        {
            if (isReadOnly) // 🆕 جلوگیری از ذخیره در حالت ReadOnly
            {
                XtraMessageBox.Show("فرم در حالت فقط خواندنی است و امکان ذخیره وجود ندارد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (IsValid())
            {
                try
                {
                    this.dataLayoutControl1.Validate();
                    warehousesBindingSource.EndEdit();

                    Warehouse currentWarehouse = warehousesBindingSource.Current as Warehouse;
                    if (currentWarehouse == null) return false;

                    bool isNewRecord = currentWarehouse.Id == 0; //

                    // 1. به‌روزرسانی قیمت‌های NewSheetPrice و NewPicesPrice در جدول Sheet
                    // اگر شیء Sheet قبلاً از طریق Include بارگذاری شده باشد، این خط کار می‌کند:
                    Sheet sheetToUpdate = currentWarehouse.Sheet;

                    // اگر نه، باید دوباره آن را از دیتابیس بگیریم (در سازنده با include بارگذاری شده است)
                    if (sheetToUpdate == null)
                    {
                        sheetToUpdate = dbContext.Sheets.Find(currentWarehouse.SheetId);
                    }

                    if (sheetToUpdate != null)
                    {
                        sheetToUpdate.SheetPrice = currentWarehouse.NewSheetPrice;
                        sheetToUpdate.PicesPrice = currentWarehouse.NewPicesPrice;

                        // اطمینان از پیوستگی شیء برای ویرایش
                        dbContext.Entry(sheetToUpdate).State = EntityState.Modified;
                    }

                    // 2. اگر رکورد جدید است، آن را به DbSet اضافه کنید
                    if (currentWarehouse.Id == 0)
                    {
                        dbContext.Warehouses.Add(currentWarehouse);
                    }

                    // 3. ذخیره تغییرات در Database
                    int affectedRows = dbContext.SaveChanges();
                    if (affectedRows > 0)
                    {
                        _New_Row_Id = currentWarehouse.Id;
                    }
                    _Save_SuccesFull = true;
                    return true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطا در ذخیره‌سازی داده‌ها: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 🆕 تنظیم حالت فقط خواندنی برای تمام کنترل‌ها و دکمه‌های ریبون
        /// </summary>
        private void SetReadOnly(bool readOnly)
        {
            //dataLayoutControl1.OptionsView.IsReadOnly = readOnly;

            // غیرفعال کردن دکمه‌های عملیاتی در ریبون
            bbiSave.Enabled = !readOnly;
            bbiSaveAndClose.Enabled = !readOnly;
            bbiSaveAndNew.Enabled = !readOnly;
            bbiDelete.Enabled = !readOnly;

            // مخفی کردن دکمه‌های مربوط به ذخیره و حذف
            bbiSave.Visibility = readOnly ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            bbiSaveAndClose.Visibility = readOnly ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            bbiSaveAndNew.Visibility = readOnly ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            bbiDelete.Visibility = readOnly ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;

            // ⚠️ نکته: اگرچه ستون‌های NewSheetPrice و NewPicesPrice در Warehouse.cs به صورت NotMapped هستند، 
            // اما چون در حالت فقط خواندنی (ReadOnly) نباید قابلیت ویرایش داشته باشند، بهتر است ReadOnly بودن را به صورت
            // کلی روی dataLayoutControl1 اعمال کنیم که شامل آن‌ها نیز می‌شود.
        }

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
                warehousesBindingSource.DataSource = new Warehouse() { OrderDate = DateTime.Now };
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isReadOnly)
            {
                XtraMessageBox.Show("فرم در حالت فقط خواندنی است و امکان حذف وجود ندارد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Warehouse currentWarehouse = warehousesBindingSource.Current as Warehouse;

            if (currentWarehouse != null && currentWarehouse.Id > 0)
            {
                if (XtraMessageBox.Show("آیا مطمئن هستید که می‌خواهید این مورد را حذف کنید؟", "تأیید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // از Local حذف نکنید، مستقیماً از DbContext حذف کنید
                    dbContext.Warehouses.Remove(currentWarehouse);
                    dbContext.SaveChanges();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnCopyPrice_Click(object sender, EventArgs e)
        {
            NewSheetPriceTextEdit.EditValue = PreSheetPriceTextEdit.EditValue;
            NewPicesPriceTextEdit.EditValue = PrePicesPriceTextEdit.EditValue;
        }

        private void FrmWareHouseEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Save_SuccesFull )
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
