using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Helper;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CncApp_Final.Models;

namespace CncApp_Final.Frm
{
    public partial class FrmOrderDetails : DevExpress.XtraEditors.XtraForm
    {
        private OrderDetails _currentDetail;
        CncApp_Final.Data.AppDbContext _dbContext = new CncApp_Final.Data.AppDbContext();

        private OrderDetails _originalDetail;
        private OrderDetails _cloneDetail; // شیء Sandbox
        private Sheet _sheet; // شیء Sandbox

        public FrmOrderDetails()
        {
            InitializeComponent();
        }

        public FrmOrderDetails(OrderDetails detailToClone, AppDbContext dbContext)
        {
            InitializeComponent();

            ControlExraInit.InitLookupEdit(lkpMaterial);
            ControlExraInit.InitLookupEdit(lkpThickness);
            ControlExraInit.InitLookupEdit(lkpSheetId);
            FillMaterial();

            _originalDetail = detailToClone;
            _cloneDetail = (OrderDetails)_originalDetail.Clone(); // 🔑 انجام Clone در اینجا
                                                                  //_sheet = (Sheet)_originalDetail.Sheet.Clone();
            OrderDetailsCalcModel calcModel = new OrderDetailsCalcModel();
            calcModel.LoadFrom(detailToClone);
            //calcModel.ApplyTo(detailToClone);

            InitControls();





            orderDetailBindingSource.DataSource = _cloneDetail;

        }

        private Sheet GetSheetInfo(int sheetId)
        {
            _sheet = _dbContext.Sheets
                .FirstOrDefault(s => s.Id == sheetId);

            txbSheetBasePrice.EditValue = _sheet.SheetPrice;
            txbPiceBasePrice.EditValue = _sheet.PicesPrice;
            CalculateCncPrice();


            return _sheet;
        }
//
        private void CalculateCncPrice()
        {
            if (_sheet != null)
            {
                var z0 = double.TryParse(txbGrooveLength.EditValue?.ToString(), out double grooveLength) ? grooveLength : 0d;
                var z1 = double.TryParse(txbPiceArea.EditValue?.ToString(), out double area) ? area : 0d;
                var z2 = double.TryParse(spnSheetCount.EditValue?.ToString(), out double sheetCount) ? sheetCount : 0d;

                txbCncSuggestionPrice.EditValue = _sheet.CNCPriceByMeter * grooveLength;
                txbCncBasePrice.EditValue = _sheet.CNCPriceByMeter;

                double cncPriceByPiceTotal  = 0;
                if (area < 2)
                    cncPriceByPiceTotal = _sheet.CNCPriceByPice;
                else
                    cncPriceByPiceTotal = _sheet.CNCPriceBySheet;
                    txbCncCost.EditValue = cncPriceByPiceTotal + sheetCount * _sheet.CNCPriceBySheet;

            }
           
        }

        public OrderDetails GetClonedDetail() // 🔑 متد در فرم جزئیات است
        {
            return _cloneDetail;
        }

        private void InitControls()
        {
            rgpSuplier.Properties.Items.AddEnum(typeof(SupplierType));

            


            // باید sheetId بررسی شود و براساس اون materila , thivkness ست شوند

            if (_cloneDetail.Id == 0)
            {
                _cloneDetail.SheetCount = 1;
                rgpSheetType.SelectedIndex = 0;
                rgpSuplier.SelectedIndex = 0;

                int defoultSheetId = AppSettingsHelper.Get<int>(AppSettingKey.DefoultSheetId);
                _sheet = GetSheetInfo(defoultSheetId);
                lkpMaterial.EditValue = _sheet.Material;
                lkpThickness.EditValue = _sheet.Thickness;
                FillSizeByMaterialAndThickness();
                _cloneDetail.SheetId = defoultSheetId;
                //lkpSheetId.EditValue = defoultSheetId;
            }
            else
            {
                int orderDetailSheetId = _cloneDetail.SheetId;
                _sheet = GetSheetInfo(orderDetailSheetId);
                lkpMaterial.EditValue = _sheet.Material;
                lkpThickness.EditValue = _sheet.Thickness;
                lkpSheetId.EditValue = orderDetailSheetId;

                if (_cloneDetail.SheetCount > 0 && _cloneDetail.CutWidth > 0 && _cloneDetail.CutLength > 0)
                {
                    rgpSheetType.SelectedIndex = 2;
                }
                else if (_cloneDetail.SheetCount > 0 && _cloneDetail.CutWidth == 0 && _cloneDetail.CutLength == 0)
                {
                    rgpSheetType.SelectedIndex = 0;
                }
                else if (_cloneDetail.SheetCount == 0 && _cloneDetail.CutWidth > 0 && _cloneDetail.CutLength > 0)
                {
                    rgpSheetType.SelectedIndex = 1;
                }
            }
        }

        private void FrmOrderDetails_Load(object sender, EventArgs e)
        {
            
        }

        private void FrmOrderDetails_Shown(object sender, EventArgs e)
        {
            orderDetailBindingSource.SuspendBinding();
        }

        private void groupControl1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            orderDetailBindingSource.EndEdit();

            DialogResult = DialogResult.OK; // تأیید موفقیت ویرایش
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************


        public enum SheetPriceStrategy
        {
            MaxPrice, // بیشترین قیمت
            LastRecord // قیمت آخرین رکورد (بر اساس Id)
        }

        /// <summary>
        /// استخراج قیمت ورق بر اساس Material و Thickness و استراتژی جستجو
        /// </summary>
        /// <param name="material">جنس ورق</param>
        /// <param name="thickness">ضخامت ورق</param>
        /// <param name="strategy">استراتژی جستجو (بیشترین قیمت یا آخرین رکورد)</param>
        /// <returns>قیمت یافت شده. اگر موردی یافت نشود، 0 برمی‌گردد.</returns>
        private double GetSheetPrice(string material, double thickness, SheetPriceStrategy strategy)
        {
            if (string.IsNullOrWhiteSpace(material) || thickness <= 0)
            {
                return 0;
            }

            try
            {
                // مرحله اول: فیلتر کردن رکوردهای مطابق
                var filteredSheets = _dbContext.Sheets
                                              .Local
                                              .Where(s => s.Material == material && s.Thickness == thickness)
                                              .ToList();

                if (!filteredSheets.Any())
                {
                    return 0;
                }

                switch (strategy)
                {
                    case SheetPriceStrategy.MaxPrice:
                        // استراتژی ۱: بیشترین قیمت
                        return filteredSheets.Max(s => s.SheetPrice);

                    case SheetPriceStrategy.LastRecord:
                        // استراتژی ۲: قیمت آخرین رکورد
                        // فرض می‌کنیم بالاترین Id جدیدترین رکورد است.

                        // مرتب سازی نزولی بر اساس Id و گرفتن اولین مورد
                        var lastRecord = filteredSheets
                                            .OrderByDescending(s => s.Id)
                                            .FirstOrDefault();

                        return lastRecord?.SheetPrice ?? 0;

                    default:
                        return 0;
                }
            }
            catch (Exception ex)
            {
                // مدیریت خطا
                System.Diagnostics.Debug.WriteLine($"خطا در محاسبه قیمت: {ex.Message}");
                return 0;
            }
        }




        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************



        private void rgpSheetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //navigationFrame1.SelectedPageIndex = rgpSheetType.SelectedIndex;
            if (rgpSheetType.SelectedIndex == 0)
            {
                spnSheetCount.Value = 1;
                spnSheetCount.Properties.MinValue = 1;
                spnSheetCount.Properties.MaxLength = 100;
                spnSheetCount.ReadOnly = false;
                
                txbCutWidth.EditValue = 0;
                txbCutWidth.ReadOnly = true;
                txbCutLength.EditValue = 0;
                txbCutLength.ReadOnly = true;
            }
            else if(rgpSheetType.SelectedIndex == 1)
            {
                spnSheetCount.Value = 0;
                spnSheetCount.Properties.MinValue = 0;
                spnSheetCount.Properties.MaxLength = 0;
                spnSheetCount.ReadOnly = true;
                txbSheetCount.EditValue = 0;
                //var x =_cloneDetail.SheetCount;
                txbCutWidth.ReadOnly = false;
                txbCutLength.ReadOnly = false;
            }
            else if (rgpSheetType.SelectedIndex == 2)
            {
                spnSheetCount.Value = 1;
                spnSheetCount.Properties.MinValue = 1;
                spnSheetCount.Properties.MaxLength = 100;
                spnSheetCount.ReadOnly = false;
                
                txbCutWidth.ReadOnly = false;
                txbCutLength.ReadOnly = false;
            }

            ////var x = _cloneDetail.SheetCount;
            //////_cloneDetail.SheetCount = 22;
            orderDetailBindingSource.EndEdit();
        }

        private void rgpSuplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isWareHouse = rgpSuplier.SelectedIndex == 0;
            txbFinalSheetCost.Properties.ReadOnly = !isWareHouse;
            txbFinalSheetCost.TabStop = isWareHouse;
        }



        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************


        private void txbGrooveLength_EditValueChanged(object sender, EventArgs e)
        {
            CalculateCncPrice();

            //int sheetId = (int)lkpSheetId.EditValue;
            //Sheet sheet = _dbContext.Sheets.FirstOrDefault(o => o.Id == sheetId);

            //txbCncSuggestionPrice.EditValue = (double)txbGrooveLength.EditValue * sheet.CNCPrice;
            //txbCncCost.EditValue = sheet.CNCPrice;
        }


        private void lkpMaterial_EditValueChanged(object sender, EventArgs e)
        {
            FillThicknessByMaterial();
        }

        private void lkpThickness_EditValueChanged(object sender, EventArgs e)
        {
            FillSizeByMaterialAndThickness();
            
        }


        private void lkpSheetId_EditValueChanged(object sender, EventArgs e)
        {

            int sheetId = (int)lkpSheetId.EditValue;
            GetSheetInfo(sheetId);

            //txbBasePrice.EditValue = sheet.PicesPrice;

            //CalCulateArea();
        }


        //**********************************************************************************************************************
        //**********************************************************************************************************************
        
        
        #region FillLookUp

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
                lkpThickness.EditValue = thicknesses.First();
        }






        private void FillSizeByMaterialAndThickness()
        {
            if (lkpMaterial.EditValue == null || lkpThickness.EditValue == null)
                return;

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
                lkpSheetId.EditValue = sheets.First().Id;
                //////orderDetailBindingSource.EndEdit();



                ////// 2. قطع اتصال LookUpEdit به BindingSource
                ////// این کار از فراخوانی مجدد EditValueChanged در حین ResetBindings جلوگیری می‌کند
                ////Binding lookUpBinding = lkpSheetId.DataBindings["EditValue"];
                ////lkpSheetId.DataBindings.Clear();

                ////try
                ////{
                ////    //// 3. انتساب شیء Sheet جدید و به‌روزرسانی SheetId در مدل
                ////    //currentWarehouse.Sheet = newSheet;
                ////    //// اگرچه LookUpEdit قطع شده، این خط مقدار نهایی را در مدل ذخیره می‌کند
                ////    //currentWarehouse.SheetId = newSheetId;

                ////    //// 4. رفرش BindingSource برای به‌روزرسانی فیلدهای محاسبه‌ای (PreSheetPrice, NewSheetPrice)
                ////    //warehousesBindingSource.ResetBindings(false);
                ////}
                ////catch (Exception ex)
                ////{
                ////    // در صورت بروز خطا، آن را مدیریت کنید
                ////    XtraMessageBox.Show($"خطا در به‌روزرسانی قیمت‌های ورق: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ////}
                ////finally
                ////{
                ////    // 5. اتصال مجدد LookUpEdit
                ////    if (lookUpBinding != null)
                ////    {
                ////        lkpSheetId.DataBindings.Add(lookUpBinding);
                ////    }
                ////}
            }
        }


        #endregion


        //**********************************************************************************************************************
        //**********************************************************************************************************************

        private void spnSheetCount_EditValueChanged(object sender, EventArgs e)
        {

            CalCulateArea();
        }

        private void txbCutLength_EditValueChanged(object sender, EventArgs e)
        {
            txbPiceArea.EditValue =
                                    (double.TryParse(txbCutLength.EditValue?.ToString(), out double length) ? length : 0d) *
                                    (double.TryParse(txbCutWidth.EditValue?.ToString(), out double width) ? width : 0d)
                                    / 10000d;

            //orderDetailBindingSource.EndEdit();
            CalCulateArea();

            //Binding txbBinding = txbCutLength.DataBindings["EditValue"];
            //txbCutLength.DataBindings.Clear();

            //try
            //{
            //    var x = txbCutLength.EditValue;
            //    _cloneDetail.CutLength = (double)x;
            //    CalCulateArea();
            //}
            //catch (Exception ex)
            //{
            //    // در صورت بروز خطا، آن را مدیریت کنید
            //    XtraMessageBox.Show($"خطا در به‌روزرسانی قیمت‌های ورق: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    // 5. اتصال مجدد LookUpEdit
            //    if (txbBinding != null)
            //    {
            //        txbCutLength.DataBindings.Add(txbBinding);
            //    }
            //}
        }

        private void txbCutWidt_EditValueChanged(object sender, EventArgs e)
        {
            txbPiceArea.EditValue =
                                    (double.TryParse(txbCutLength.EditValue?.ToString(), out double length) ? length : 0d) *
                                    (double.TryParse(txbCutWidth.EditValue?.ToString(), out double width) ? width : 0d)
                                    / 10000d;
            CalCulateArea();
            //        BindingHelper.UpdateTextEditSafely(
            //txbCutLength,
            //orderDetailBindingSource,
            //() =>
            //{
            //    _cloneDetail.CutLength = 120;
            //});
            ////orderDetailBindingSource.ResetBindings(false);
        }

        private void CalCulateArea()
        {

            ////orderDetailBindingSource.EndEdit();
            ////int  sheetId = (int)lkpSheetId.EditValue;
            ////Sheet sheet = _dbContext.Sheets.FirstOrDefault(o => o.Id == sheetId);


            ////if (sheet == null)
            ////{
            ////    txbFinalSheetCost.EditValue = 0d;
            ////    return;
            ////}

            ////double sheetCount = Convert.ToDouble(spnSheetCount.EditValue);
            ////double cutLength = Convert.ToDouble(txbCutLength.EditValue);
            ////double cutWidth = Convert.ToDouble(txbCutWidth.EditValue);
            ////double sheetPrice = sheetCount * sheet.SheetPrice;

            ////double sheetArea = sheet.Width * sheet.Length;
            ////double cutArea = cutLength * cutWidth;
            ////double picePrice = cutArea/10000d * sheet.PicesPrice;

            ////double finalArea = (sheetCount * sheetArea + cutArea) / 10000d;

            ////txbSheetArea.EditValue = finalArea;


            ////if (_cloneDetail != null)
            ////{
            ////    //_cloneDetail.FinalSheetCost = finalArea * (double)txbBasePrice.EditValue;
            ////    txbFinalSheetCost.EditValue = sheetPrice + picePrice;
            ////    //orderDetailBindingSource.EndEdit();
            ////}
        }

        private void CalculateSheetPrice(object sender, EventArgs e)
        {
            txbSheetTotalPrice.EditValue = (double.TryParse(txbSheetCount.EditValue?.ToString(), out double length) ? length : 0d) *
                                    (double.TryParse(txbSheetBasePrice.EditValue?.ToString(), out double width) ? width : 0d);
        }
        
        private void CalculatePicePrice(object sender, EventArgs e)
        {
            txbPiceTotalPrice.EditValue = (double.TryParse(txbPiceArea.EditValue?.ToString(), out double length) ? length : 0d) *
                                    (double.TryParse(txbPiceBasePrice.EditValue?.ToString(), out double width) ? width : 0d);
        }

        private void txbSheetTotalPrice_EditValueChanged(object sender, EventArgs e)
        {
            orderDetailBindingSource.EndEdit();
            if(_cloneDetail != null)
            _cloneDetail.FinalSheetCost = (double.TryParse(txbSheetTotalPrice.EditValue?.ToString(), out double length) ? length : 0d) +
                                   (double.TryParse(txbPiceTotalPrice.EditValue?.ToString(), out double width) ? width : 0d);

            
            
            
            
            //txbFinalSheetCost.EditValue = (double.TryParse(txbSheetTotalPrice.EditValue?.ToString(), out double length) ? length : 0d) +
            //                        (double.TryParse(txbPiceTotalPrice.EditValue?.ToString(), out double width) ? width : 0d);
            //orderDetailBindingSource.EndEdit();
        }

        private void orderDetailBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {

        }
    }


    //**********************************************************************************************************************
    //**********************************************************************************************************************

    #region Temp


    //public static class BindingHelper
    //{
    //    public static void UpdateTextEditSafely(
    //        DevExpress.XtraEditors.TextEdit textEdit,
    //        BindingSource bindingSource,
    //        Action updateAction)
    //    {
    //        if (textEdit == null || bindingSource == null || updateAction == null)
    //            return;

    //        Binding savedBinding = textEdit.DataBindings["EditValue"];

    //        // قطع موقت Binding
    //        if (savedBinding != null)
    //            textEdit.DataBindings.Remove(savedBinding);

    //        try
    //        {
    //            // تغییر مدل (نه کنترل)
    //            updateAction.Invoke();

    //            // رفرش برای پراپرتی‌های محاسباتی
    //            bindingSource.ResetBindings(false);
    //        }
    //        finally
    //        {
    //            // اتصال مجدد Binding
    //            if (savedBinding != null)
    //                textEdit.DataBindings.Add(savedBinding);
    //        }
    //    }
    //}



    #endregion

    //**********************************************************************************************************************
    //**********************************************************************************************************************


}