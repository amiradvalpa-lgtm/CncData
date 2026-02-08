using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Helper;
using DevExpress.XtraEditors;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncApp_Final.Frm
{
    public partial class FrmWareHouseEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public int _New_Row_Id;
        private bool _Save_SuccesFull = false;

        //**********************************************************************
        public int _WareHouse_Id { get; private set; } = 0; // 0 for new WareHouse
        public int _NewCreatedWareHousetId { get; private set; } = 0; // برای نگهداری شناسه جدید پس از ذخیره
        private readonly bool _IsWareHouseReadonly = false;

        private AppDbContext _dbContext;
        private Warehouse _currentWareHouse;
        private Sheet _currentSheet;

        private readonly Action<int> _reloadCallback;
        //**********************************************************************


        public FrmWareHouseEdit()
        {
            InitializeComponent();
        }


        public FrmWareHouseEdit(int warehouseId = 0, bool isReadOnly = false)
        {
            InitializeComponent();

            _WareHouse_Id = warehouseId;
            _IsWareHouseReadonly = isReadOnly;
            _dbContext = new AppDbContext();

            //_reloadCallback = reloadCallback;
        }


        private void FrmWareHouseEdit_Load(object sender, EventArgs e)
        {
            InitData();
            DxValidationHelper.SetupValidation<Warehouse>(this, dxValidationProvider1, warehousesBindingSource);
            ControlExraInit.ApplyFocusColor(this);
        }

        
        
       
        private void InitData()
        {
            sheetSelector1.EditValueChanged += SheetSelector_EditValueChanged;
            ckbUpdateSheetPrice.Checked = false;

            NewSheetPriceTextEdit.DataBindings.Add(
                            new System.Windows.Forms.Binding(
                                "EditValue", warehousesBindingSource, "Sheet.SheetPrice", true)
                            );

            NewPicesPriceTextEdit.DataBindings.Add(
                            new System.Windows.Forms.Binding(
                                "EditValue", warehousesBindingSource, "Sheet.PicesPrice", true)
                            );




            ControlExraInit.InitRibonControl(mainRibbonControl, _WareHouse_Id == 0 ? "ورود به انبار جدید" : "ویرایش ورودی انبار");
            
            //dbContext.Sheets.Load();
            //sheetsBindingSource.DataSource = dbContext.Sheets.Local.ToBindingList();

            if (_WareHouse_Id > 0)
            {

                // بارگذاری رسید موجود از دیتابیس
                _currentWareHouse = _dbContext.Warehouses.Include(w => w.Sheet)
                                            .FirstOrDefault(r => r.Id == _WareHouse_Id);

                if (_currentWareHouse == null)
                {
                    XtraMessageBox.Show("رسید مورد نظر یافت نشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                this.Text = $"ویرایش رسید: {_currentWareHouse.Id}";
            }
            else
            {
                // ایجاد یک نمونه جدید و اضافه کردن آن به DBContext برای ردیابی (Track)
                _currentWareHouse = _dbContext.Warehouses.Create();
                _dbContext.Warehouses.Add(_currentWareHouse);

                this.Text = "رسید جدید";
                bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; // حذف برای مورد جدید نمایش داده نشود

                _currentWareHouse.OrderDate = DateTime.Now;
                sheetSelector1.Focus();
            }
            warehousesBindingSource.DataSource = _currentWareHouse;

            // 🆕 اعمال تنظیمات ReadOnly
            SetReadOnly(_IsWareHouseReadonly);

            
        }



        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************


        private void SheetSelector_EditValueChanged(object sender, EventArgs e)
        {
            if (sheetSelector1.EditValue != null)
            {
                _currentWareHouse.SheetId = (int)sheetSelector1.EditValue;
                warehousesBindingSource.EndEdit();
                _dbContext.Entry(_currentWareHouse).Reference(x => x.Sheet).Load();
                warehousesBindingSource.ResetBindings(false);

                PreSheetPriceTextEdit.Text = _currentWareHouse.Sheet.SheetPrice.ToString();
                PrePicesPriceTextEdit.Text = _currentWareHouse.Sheet.PicesPrice.ToString();
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


        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************





        /// <summary>
        /// متد اعتبارسنجی ساده (همیشه True)
        /// </summary>
        private bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// ذخیره اطلاعات Warehouse و به‌روزرسانی Sheet
        /// </summary>
        private bool Save()
        {
            if (_IsWareHouseReadonly) // 🆕 جلوگیری از ذخیره در حالت ReadOnly
            {
                XtraMessageBox.Show("فرم در حالت فقط خواندنی است و امکان ذخیره وجود ندارد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (IsValid())
            {
                try
                {
                    dxValidationProvider1.Validate();
                    warehousesBindingSource.EndEdit();

                    Warehouse currentWarehouse = warehousesBindingSource.Current as Warehouse;
                    if (currentWarehouse == null) return false;

                    bool isNewRecord = currentWarehouse.Id == 0; //

                    Sheet sheetToUpdate = currentWarehouse.Sheet;
                    if (sheetToUpdate == null)
                    {
                        XtraMessageBox.Show($"sheetToUpdate is null", "sheetToUpdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (sheetToUpdate != null)
                    {
                        // اطمینان از پیوستگی شیء برای ویرایش
                        _dbContext.Entry(sheetToUpdate).State = EntityState.Modified;
                    }

                    if (currentWarehouse.Id == 0)
                    {
                        _dbContext.Warehouses.Add(currentWarehouse);
                    }

                    // 3. ذخیره تغییرات در Database
                    int affectedRows = _dbContext.SaveChanges();
                    if (affectedRows > 0)
                    {
                        _New_Row_Id = currentWarehouse.Id;
                    }
                    _Save_SuccesFull = true;
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
            if (_IsWareHouseReadonly)
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
                    _dbContext.Warehouses.Remove(currentWarehouse);
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

        
        private void FrmWareHouseEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Save_SuccesFull)
            {
                DialogResult = DialogResult.OK;
            }
        }


        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************




        private void btnCopyPrice_Click(object sender, EventArgs e)
        {
            NewSheetPriceTextEdit.EditValue = PreSheetPriceTextEdit.EditValue;
            NewPicesPriceTextEdit.EditValue = PrePicesPriceTextEdit.EditValue;
        }


        private void btnCalcPrices_Click(object sender, EventArgs e)
        {
            Sheet _sheet = (Sheet)_currentWareHouse.Sheet;
            _sheet.LastBuyPrice = _currentWareHouse.SheetBasePrice;
            SheetCalculator.Calculate(_sheet);
            warehousesBindingSource.ResetBindings(false);
        }

        private void ckbUpdateSheetPrice_CheckedChanged(object sender, EventArgs e)
        {
            NewPicesPriceTextEdit.Enabled = ckbUpdateSheetPrice.Checked;
            NewSheetPriceTextEdit.Enabled = ckbUpdateSheetPrice.Checked;
            btnCalcPrices.Enabled = ckbUpdateSheetPrice.Checked;
            btnCopyPrice.Enabled = ckbUpdateSheetPrice.Checked;
        }





        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************



        #region Temp



        private void bbiFormula_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //////FrmSheetFormulaEditor frmSheetFormulaEditor = new FrmSheetFormulaEditor();
            //////frmSheetFormulaEditor.ShowDialog();



            //// فراخوانی برای فرمول قیمت کامل
            //SheetExpressionHelper.ShowExpressionEditor(_sheet, SheetFormulaType.SheetPrice);

            //// بعد از بستن فرم، فرمول جدید در currentSheet.SheetPriceFormula ذخیره شده است
            ////txtFormulaDisplay.Text = _sheet.SheetPriceFormula;

            //SheetExpressionHelper.ShowExpressionEditor(_sheet, SheetFormulaType.SheetPrice);
            //SheetExpressionHelper.ShowExpressionEditor(_sheet, SheetFormulaType.PiecePrice);

            //// محاسبه قیمت کامل
            //var fullPrice = SheetExpressionHelper.Evaluate(_sheet, SheetFormulaType.SheetPrice);
            //if (fullPrice.HasValue)
            //    _sheet.SheetPrice = fullPrice.Value;

            //// محاسبه قیمت تکه
            //var piecePrice = SheetExpressionHelper.Evaluate(_sheet, SheetFormulaType.PiecePrice);
            //if (piecePrice.HasValue)
            //    _sheet.PicesPrice = piecePrice.Value;

        }

        

        #endregion


        ////**********************************************************************************************************************
        ////**********************************************************************************************************************

    }
}
