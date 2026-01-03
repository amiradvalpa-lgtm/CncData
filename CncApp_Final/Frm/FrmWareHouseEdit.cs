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
using CncApp_Final.Data;
using CncApp_Final.Helper;
using CncApp_Final.Entities;
using System.Data.Entity;

namespace CncApp_Final.Frm
{
    public partial class FrmWareHouseEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
        public int _New_Row_Id;
        private bool _Save_SuccesFull = false;

        //**********************************************************************
        public int _WareHouse_Id { get; private set; } = 0; // 0 for new WareHouse
        public int _NewCreatedWareHousetId { get; private set; } = 0; // برای نگهداری شناسه جدید پس از ذخیره
        private readonly bool _IsWareHouseReadonly = false;

        private AppDbContext _dbContext;
        private Warehouse _currentWareHouse;

        private readonly Action<int> _reloadCallback;
        //**********************************************************************


        public FrmWareHouseEdit()
        {
            InitializeComponent();

            ControlExraInit.InitRibonControl(mainRibbonControl, "ورود به انبار جدید");
            ControlExraInit.InitLookupEdit(lkpSheetId);

            
            dbContext.Warehouses.Load();
            warehousesBindingSource.DataSource = dbContext.Warehouses.Local.ToBindingList();
            
            dbContext.Sheets.Load();
            sheetsBindingSource.DataSource = dbContext.Sheets.Local.ToBindingList();
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
            InitFillMaterial();
            DxValidationHelper.SetupValidation<Warehouse>(this, dxValidationProvider1, warehousesBindingSource);
            ControlExraInit.ApplyFocusColor(this);

            
        }

        private void InitFillMaterial()
        {
            this.lkpMaterial.EditValueChanged += new System.EventHandler(this.lkpMaterial_EditValueChanged);
            this.lkpThickness.EditValueChanged += new System.EventHandler(this.lkpThickness_EditValueChanged);
            this.lkpSheetId.EditValueChanged += new System.EventHandler(this.lkpSheetId_EditValueChanged);

            FillMaterial();

            if (_currentWareHouse.SheetId == 0)
            {
                int defoultSheetId = AppSettingsHelper.Get<int>(AppSettingKey.DefoultSheetId);
                _sheet = GetSheetInfo(defoultSheetId);
                lkpMaterial.EditValue = _sheet.Material;
                lkpThickness.EditValue = _sheet.Thickness;
                lkpSheetId.EditValue = defoultSheetId;
            }
            else
            {
                int currentWareHouse = _currentWareHouse.SheetId;
                _sheet = GetSheetInfo(currentWareHouse);
                lkpMaterial.EditValue = _sheet.Material;
                lkpThickness.EditValue = _sheet.Thickness;
                lkpSheetId.EditValue = currentWareHouse;

            }
        }
        private Sheet _sheet;
        private Sheet GetSheetInfo(int sheetId)
        {
            _sheet = _dbContext.Sheets
                .FirstOrDefault(s => s.Id == sheetId);
            return _sheet;
        }
        private void InitData()
        {
            ControlExraInit.InitRibonControl(mainRibbonControl, _WareHouse_Id == 0 ? "ورود به انبار جدید" : "ویرایش ورودی انبار");
            ControlExraInit.InitLookupEdit(lkpMaterial);
            ControlExraInit.InitLookupEdit(lkpThickness);
            ControlExraInit.InitLookupEdit(lkpSheetId);

            dbContext.Sheets.Load();
            sheetsBindingSource.DataSource = dbContext.Sheets.Local.ToBindingList();

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
                lkpMaterial.Focus();
            }
            warehousesBindingSource.DataSource = _currentWareHouse;

            // 🆕 اعمال تنظیمات ReadOnly
            SetReadOnly(_IsWareHouseReadonly);

            lkpSheetId.EditValueChanged += SheetIdLookUpEdit_EditValueChanged;
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
            if (lkpSheetId.EditValue != null)
            {
                _currentWareHouse.SheetId = (int)lkpSheetId.EditValue;
                warehousesBindingSource.EndEdit();
                _dbContext.Entry(_currentWareHouse).Reference(x => x.Sheet).Load();
                warehousesBindingSource.ResetBindings(false);
            }

            //if (lkpSheetId.EditValue == null || lkpSheetId.EditValue == DBNull.Value) return;

            //if (warehousesBindingSource.Current is Warehouse currentWarehouse)
            //{
            //    int newSheetId = (int)lkpSheetId.EditValue;

            //    // اگر SheetId واقعاً تغییر نکرده و شیء Sheet وجود دارد، کاری نکنیم
            //    if (currentWarehouse.SheetId == newSheetId && currentWarehouse.Sheet != null)
            //    {
            //        return;
            //    }

            //    Sheet newSheet = dbContext.Sheets.Local.FirstOrDefault(s => s.Id == newSheetId);

            //    if (newSheet != null)
            //    {
            //        // 2. قطع اتصال LookUpEdit به BindingSource
            //        // این کار از فراخوانی مجدد EditValueChanged در حین ResetBindings جلوگیری می‌کند
            //        Binding lookUpBinding = lkpSheetId.DataBindings["EditValue"];
            //        lkpSheetId.DataBindings.Clear();

            //        try
            //        {
            //            // 3. انتساب شیء Sheet جدید و به‌روزرسانی SheetId در مدل
            //            currentWarehouse.Sheet = newSheet;
            //            // اگرچه LookUpEdit قطع شده، این خط مقدار نهایی را در مدل ذخیره می‌کند
            //            currentWarehouse.SheetId = newSheetId;

            //            warehousesBindingSource.ResetBindings(false);
            //        }
            //        catch (Exception ex)
            //        {
            //            XtraMessageBox.Show($"خطا در به‌روزرسانی قیمت‌های ورق: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        finally
            //        {
            //            // 5. اتصال مجدد LookUpEdit
            //            if (lookUpBinding != null)
            //            {
            //                lkpSheetId.DataBindings.Add(lookUpBinding);
            //            }
            //        }
            //    }
            //}
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

                    // 1. به‌روزرسانی قیمت‌های NewSheetPrice و NewPicesPrice در جدول Sheet
                    // اگر شیء Sheet قبلاً از طریق Include بارگذاری شده باشد، این خط کار می‌کند:
                    Sheet sheetToUpdate = currentWarehouse.Sheet;

                    // اگر نه، باید دوباره آن را از دیتابیس بگیریم (در سازنده با include بارگذاری شده است)
                    if (sheetToUpdate == null)
                    {
                        sheetToUpdate = _dbContext.Sheets.Find(currentWarehouse.SheetId);
                    }

                    if (sheetToUpdate != null)
                    {
                        sheetToUpdate.SheetPrice = currentWarehouse.NewSheetPrice;
                        sheetToUpdate.PicesPrice = currentWarehouse.NewPicesPrice;

                        // اطمینان از پیوستگی شیء برای ویرایش
                        _dbContext.Entry(sheetToUpdate).State = EntityState.Modified;
                    }

                    // 2. اگر رکورد جدید است، آن را به DbSet اضافه کنید
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





        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************



        #region FillLookUp

        private void lkpMaterial_EditValueChanged(object sender, EventArgs e)
        {
            FillThicknessByMaterial();
            FillSizeByMaterialAndThickness();
        }

        private void lkpThickness_EditValueChanged(object sender, EventArgs e)
        {
            FillSizeByMaterialAndThickness();

        }

        private void lkpSheetId_EditValueChanged(object sender, EventArgs e)
        {
            //if (_isLoading) return;
            if (lkpSheetId.EditValue == null) return;

            int sheetId = Convert.ToInt32(lkpSheetId.EditValue);
            LoadSheetInfo(sheetId);

        }
        private void LoadSheetInfo(int sheetId)
        {
            var sheet = _dbContext.Sheets.FirstOrDefault(s => s.Id == sheetId);
            if (sheet == null) return;

            //_calcModel.SheetId = sheetId;
            //_calcModel.CNCPriceByMeter = sheet.CNCPriceByMeter;
            //_calcModel.CNCPriceBySheet = sheet.CNCPriceBySheet;
            //_calcModel.CNCPriceByPice = sheet.CNCPriceByPice;
            //_calcModel.SheetBasePrice = sheet.SheetPrice;
            //_calcModel.PiceBasePrice = sheet.PicesPrice;

            //// بعد از تزریق قیمت‌ها، محاسبه انجام می‌شود
            //_calcModel.Recalculate();
        }



        //**********************************************************************************************************************
        //**********************************************************************************************************************



        private void FillMaterial()
        {
            var materials = _dbContext.Sheets
                .Where(s => !string.IsNullOrEmpty(s.Material))
                .Select(s => s.Material)
                .Distinct()
                .OrderBy(s => s)
                .ToList();

            lkpMaterial.Properties.DataSource = materials;
            lkpMaterial.Properties.DisplayMember = "";
            lkpMaterial.Properties.ValueMember = "";

            if (materials.Any())
                lkpMaterial.EditValue = materials.First();
        }





        private void FillThicknessByMaterial()
        {
            if (lkpMaterial.EditValue == null)
                return;

            string material = lkpMaterial.EditValue.ToString();

            var thicknesses = _dbContext.Sheets
                .Where(s => s.Material == material)
                .Select(s => s.Thickness)
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            lkpThickness.Properties.DataSource = thicknesses;
            lkpThickness.Properties.DisplayMember = "";
            lkpThickness.Properties.ValueMember = "";

            if (thicknesses.Any())
            {
                //////lkpThickness.EditValue = thicknesses.First();
                lkpThickness.EditValue = null;
            }
        }






        private void FillSizeByMaterialAndThickness()
        {
            if (lkpMaterial.EditValue == null || lkpThickness.EditValue == null)
            {
                lkpSheetId.EditValue = null;
                return;
            }

            string material = lkpMaterial.EditValue.ToString();
            int thickness = Convert.ToInt32(lkpThickness.EditValue);

            var sheets = _dbContext.Sheets
                                            .Where(s => s.Material == material && s.Thickness == thickness)
                                            .Select(s => new
                                            {
                                                s.Id,
                                                s.Width,
                                                s.Length
                                            })
                                            .AsEnumerable()   // ⬅️ از اینجا به بعد LINQ معمولی
                                            .Select(s => new
                                            {
                                                s.Id,
                                                DisplayText = $"{s.Width} × {s.Length}"
                                            })
                                            .ToList();

            lkpSheetId.Properties.DataSource = sheets;
            lkpSheetId.Properties.DisplayMember = "DisplayText";
            lkpSheetId.Properties.ValueMember = "Id";

            if (sheets.Any())
            {
                lkpSheetId.EditValue = null;
                //////lkpSheetId.EditValue = sheets.First().Id;
            }
        }

        private void bbiFormula_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSheetFormulaEditor frmSheetFormulaEditor = new FrmSheetFormulaEditor();
            frmSheetFormulaEditor.ShowDialog();



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

        private void btnEditSheetPrice_Click(object sender, EventArgs e)
        {
            //// باز کردن Expression Editor
            //SheetExpressionHelper.ShowExpressionEditor(_sheet, SheetFormulaType.SheetPrice);

            //// محاسبه جدید بعد از تغییر فرمول
            //var price = SheetExpressionHelper.Evaluate(_sheet, SheetFormulaType.SheetPrice);
            //if (price.HasValue)
            //    _sheet.SheetPrice = price.Value;

            //// نمایش به Label یا Grid
            ////////lblSheetPrice.Text = price?.ToString("N2") ?? "فرمول خالی است";
        }

        private void btnEditPiecePrice_Click(object sender, EventArgs e)
        {
            //SheetExpressionHelper.ShowExpressionEditor(_sheet, SheetFormulaType.PicesPrice);
            //var piece = SheetExpressionHelper.Evaluate(_sheet, SheetFormulaType.PicesPrice);
            //if (piece.HasValue)
            //    _sheet.PicesPrice = piece.Value;
            //////lblPiecePrice.Text = piece?.ToString("N2") ?? "فرمول خالی است";
            ///


            SheetCalculator.Calculate(_sheet);

        }




        #endregion


        //**********************************************************************************************************************
        //**********************************************************************************************************************

    }
}
