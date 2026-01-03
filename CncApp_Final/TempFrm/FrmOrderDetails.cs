using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Helper;
using CncApp_Final.Models;
using DevExpress.DataAccess.Native.Json;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CncApp_Final.TempFrm
{
    public partial class FrmOrderDetails : DevExpress.XtraEditors.XtraForm
    {
        private OrderDetails _currentDetail;
        CncApp_Final.Data.AppDbContext _dbContext = new CncApp_Final.Data.AppDbContext();
        private bool _isLoading;

        private OrderDetails _originalDetail;
        private OrderDetails _cloneDetail; // شیء Sandbox
        private Sheet _sheet;


        private OrderDetailsCalcModel _calcModel;


        private string _lastDirectory;



        public FrmOrderDetails()
        {
            InitializeComponent();
        }

        public FrmOrderDetails(OrderDetails orderDetail, AppDbContext dbContext)
        {
            InitializeComponent();
            
            ControlExraInit.InitLookupEdit(lkpMaterial);
            ControlExraInit.InitLookupEdit(lkpThickness);
            ControlExraInit.InitLookupEdit(lkpSheetId);



            //InitControls();

            _dbContext = dbContext;
            _originalDetail = orderDetail;
            
            _calcModel = new OrderDetailsCalcModel();
            orderDetailBindingSource.DataSource = _calcModel;

            BindControls();

            FillMaterial();

        }

        private Sheet GetSheetInfo(int sheetId)
        {
            _sheet = _dbContext.Sheets
                .FirstOrDefault(s => s.Id == sheetId);
            return _sheet;
        }


        public OrderDetails GetClonedDetail() // 🔑 متد در فرم جزئیات است
        {
            return _cloneDetail;
        }

        private void InitControls()
        {
            rgpSuplier.Properties.Items.AddEnum(typeof(SupplierType));
            rgpSheetType.Properties.Items.AddEnum(typeof(SheetType));


            if (_originalDetail.SheetId == 0)
            {
                this.Text = "جدید";

                rgpSheetType.SelectedIndex = 0;
                rgpSuplier.SelectedIndex = 0;

                int defoultSheetId = AppSettingsHelper.Get<int>(AppSettingKey.DefoultSheetId);
                _sheet = GetSheetInfo(defoultSheetId);
                lkpMaterial.EditValue = _sheet.Material;
                lkpThickness.EditValue = _sheet.Thickness;
                //FillSizeByMaterialAndThickness();
                //_calcModel.SheetId = defoultSheetId;
                lkpSheetId.EditValue = defoultSheetId;
            }
            else
            {
                this.Text = "ویرایش";

                int orderDetailSheetId = _originalDetail.SheetId;
                _sheet = GetSheetInfo(orderDetailSheetId);
                lkpMaterial.EditValue = _sheet.Material;
                lkpThickness.EditValue = _sheet.Thickness;
                lkpSheetId.EditValue = orderDetailSheetId;
                //lkpSheetId.EditValue = orderDetailSheetId;

            }


            //////// باید sheetId بررسی شود و براساس اون materila , thivkness ست شوند

            //////if (_cloneDetail.Id == 0)
            //////{
            //////    _cloneDetail.SheetCount = 1;
            //////    rgpSheetType.SelectedIndex = 0;
            //////    rgpSuplier.SelectedIndex = 0;

            //////    int defoultSheetId = AppSettingsHelper.Get<int>(AppSettingKey.DefoultSheetId);
            //////    _sheet = GetSheetInfo(defoultSheetId);
            //////    lkpMaterial.EditValue = _sheet.Material;
            //////    lkpThickness.EditValue = _sheet.Thickness;
            //////    FillSizeByMaterialAndThickness();
            //////    _cloneDetail.SheetId = defoultSheetId;
            //////    lkpSheetId.EditValue = defoultSheetId;
            //////}
            //////else
            //////{
            //////    int orderDetailSheetId = _cloneDetail.SheetId;
            //////    //_sheet = GetSheetInfo(orderDetailSheetId);
            //////    lkpMaterial.EditValue = _sheet.Material;
            //////    lkpThickness.EditValue = _sheet.Thickness;
            //////    lkpSheetId.EditValue = orderDetailSheetId;

            //////    if (_cloneDetail.SheetCount > 0 && _cloneDetail.CutWidth > 0 && _cloneDetail.CutLength > 0)
            //////    {
            //////        rgpSheetType.SelectedIndex = 2;
            //////    }
            //////    else if (_cloneDetail.SheetCount > 0 && _cloneDetail.CutWidth == 0 && _cloneDetail.CutLength == 0)
            //////    {
            //////        rgpSheetType.SelectedIndex = 0;
            //////    }
            //////    else if (_cloneDetail.SheetCount == 0 && _cloneDetail.CutWidth > 0 && _cloneDetail.CutLength > 0)
            //////    {
            //////        rgpSheetType.SelectedIndex = 1;
            //////    }
            //////}
        }

        private void FrmOrderDetails_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            _calcModel.LoadFrom(_originalDetail);
            InitControls();
            LoadSheetInfo(_calcModel.SheetId);


            orderDetailBindingSource.ResetBindings(false);
            var x = lkpSheetId.EditValue;

            _isLoading = false;
        }

        public static void ApplyFocusColor(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if(control.Name == "spnSheetCount")
                {
                    
                }
                if (control is DevExpress.XtraEditors.BaseEdit editor)
                {
                    // اگر کنترل DevExpress و TabStop فعال بود
                    if (editor.TabStop)
                    {
                        editor.Properties.AppearanceFocused.BackColor =
                            Color.FromArgb(255, 255, 192);

                        editor.Properties.AppearanceFocused.Options.UseBackColor = true;
                    }
                }
                if (control.HasChildren)
                {
                    ApplyFocusColor(control);
                }

                //// اگر کنترل DevExpress و TabStop فعال بود
                //if (control.TabStop && control is BaseEdit editor)
                //{
                //    //if(control is DevExpress.XtraEditors.ButtonEdit buttontEdit)
                //    //{
                //    //    buttontEdit.Properties.TextEditStyle
                //    //}
                //    editor.Properties.AppearanceFocused.BackColor =
                //        Color.FromArgb(255, 255, 192);

                //    editor.Properties.AppearanceFocused.Options.UseBackColor = true;
                //}

                // اگر این کنترل خودش بچه دارد (Group, Panel, Layout, ...)
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ApplyValidationRules(_calcModel);

            if (!dxValidationProvider1.Validate())
                return;

            _originalDetail.Sheet = GetSheetInfo(_originalDetail.SheetId);
            orderDetailBindingSource.EndEdit();
            _calcModel.ApplyTo(_originalDetail);
            DialogResult = DialogResult.OK;
        }

        private void ApplyValidationRules(OrderDetailsCalcModel m)
        {
            // اول همه Validationها پاک شود
            ClearValidation(txbDetailName);
            ClearValidation(lkpSheetId);
            ClearValidation(spnSheetCount);
            ClearValidation(txbCutLength);
            ClearValidation(txbCutWidth);
            ClearValidation(txbGrooveLength);
            ClearValidation(txbFinalSheetCost);
            ClearValidation(txbCncCost);

            // 🔹 همیشه لازم
            Required(txbDetailName, "نام سفارش الزامی است");
            Required(lkpSheetId, "ورق باید انتخاب شود");
            GreaterThanZero(txbGrooveLength, "طول شیار باید بزرگتر از صفر باشد");

            // 🔹 SheetType logic
            switch (m.SheetType)
            {
                case SheetType.Full:
                    GreaterThanZero(spnSheetCount, "تعداد ورق باید بزرگتر از صفر باشد");
                    break;

                case SheetType.Piece:
                    GreaterThanZero(txbCutLength, "طول برش الزامی است");
                    GreaterThanZero(txbCutWidth, "عرض برش الزامی است");
                    break;

                case SheetType.Both:
                    GreaterThanZero(spnSheetCount, "تعداد ورق باید بزرگتر از صفر باشد");
                    GreaterThanZero(txbCutLength, "طول برش الزامی است");
                    GreaterThanZero(txbCutWidth, "عرض برش الزامی است");
                    break;
            }

            // 🔹 Supplier logic
            if (m.Supplier == SupplierType.Warehouse)
            {
                GreaterThanZero(txbFinalSheetCost, "هزینه نهایی ورق باید مشخص شود");
            }
            // اگر Customer است → Validation ندارد (صفر می‌شود)
        }

        private void ClearValidation(BaseEdit ctrl)
        {
            dxValidationProvider1.RemoveControlError(ctrl);
            dxValidationProvider1.SetValidationRule(ctrl, null);
        }

        private void Required(BaseEdit ctrl, string message)
        {
            var rule = new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.IsNotBlank,
                ErrorText = message,
                ErrorType = ErrorType.Critical
            };
            dxValidationProvider1.SetValidationRule(ctrl, rule);
        }

        private void GreaterThanZero(BaseEdit ctrl, string message)
        {
            var rule = new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.Greater,
                Value1 = 0,
                ErrorText = message,
                ErrorType = ErrorType.Critical
            };
            dxValidationProvider1.SetValidationRule(ctrl, rule);
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }




        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************


        //////public enum SheetPriceStrategy
        //////{
        //////    MaxPrice, // بیشترین قیمت
        //////    LastRecord // قیمت آخرین رکورد (بر اساس Id)
        //////}

        ///////// <summary>
        ///////// استخراج قیمت ورق بر اساس Material و Thickness و استراتژی جستجو
        ///////// </summary>
        ///////// <param name="material">جنس ورق</param>
        ///////// <param name="thickness">ضخامت ورق</param>
        ///////// <param name="strategy">استراتژی جستجو (بیشترین قیمت یا آخرین رکورد)</param>
        ///////// <returns>قیمت یافت شده. اگر موردی یافت نشود، 0 برمی‌گردد.</returns>
        //////private double GetSheetPrice(string material, double thickness, SheetPriceStrategy strategy)
        //////{
        //////    if (string.IsNullOrWhiteSpace(material) || thickness <= 0)
        //////    {
        //////        return 0;
        //////    }

        //////    try
        //////    {
        //////        // مرحله اول: فیلتر کردن رکوردهای مطابق
        //////        var filteredSheets = _dbContext.Sheets
        //////                                      .Local
        //////                                      .Where(s => s.Material == material && s.Thickness == thickness)
        //////                                      .ToList();

        //////        if (!filteredSheets.Any())
        //////        {
        //////            return 0;
        //////        }

        //////        switch (strategy)
        //////        {
        //////            case SheetPriceStrategy.MaxPrice:
        //////                // استراتژی ۱: بیشترین قیمت
        //////                return filteredSheets.Max(s => s.SheetPrice);

        //////            case SheetPriceStrategy.LastRecord:
        //////                // استراتژی ۲: قیمت آخرین رکورد
        //////                // فرض می‌کنیم بالاترین Id جدیدترین رکورد است.

        //////                // مرتب سازی نزولی بر اساس Id و گرفتن اولین مورد
        //////                var lastRecord = filteredSheets
        //////                                    .OrderByDescending(s => s.Id)
        //////                                    .FirstOrDefault();

        //////                return lastRecord?.SheetPrice ?? 0;

        //////            default:
        //////                return 0;
        //////        }
        //////    }
        //////    catch (Exception ex)
        //////    {
        //////        // مدیریت خطا
        //////        System.Diagnostics.Debug.WriteLine($"خطا در محاسبه قیمت: {ex.Message}");
        //////        return 0;
        //////    }
        //////}




        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************



        private void rgpSheetType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rgpSheetType.SelectedIndex == 0)
            {
                //spnSheetCount.Value = 1;
                spnSheetCount.Properties.MinValue = 1;
                spnSheetCount.Properties.MaxLength = 100;
                spnSheetCount.ReadOnly = false;

                //txbCutWidth.EditValue = 0;
                txbCutWidth.ReadOnly = true;
                //txbCutLength.EditValue = 0;
                txbCutLength.ReadOnly = true;
            }
            else if (rgpSheetType.SelectedIndex == 1)
            {
                //spnSheetCount.Value = 0;
                spnSheetCount.Properties.MinValue = 0;
                spnSheetCount.Properties.MaxLength = 0;
                spnSheetCount.ReadOnly = true;
                //txbSheetCount.EditValue = 0;
                ////var x =_cloneDetail.SheetCount;
                txbCutWidth.ReadOnly = false;
                txbCutLength.ReadOnly = false;
            }
            else if (rgpSheetType.SelectedIndex == 2)
            {
                //spnSheetCount.Value = 1;
                spnSheetCount.Properties.MinValue = 1;
                spnSheetCount.Properties.MaxLength = 100;
                spnSheetCount.ReadOnly = false;

                txbCutWidth.ReadOnly = false;
                txbCutLength.ReadOnly = false;
            }
            ApplyTabStopRules(_calcModel);
            ApplyValidationRules(_calcModel);
            ApplyFocusColor(this);
        }

        private void rgpSuplier_SelectedIndexChanged(object sender, EventArgs e)
        {

            //////bool isWareHouse = rgpSuplier.SelectedIndex == 0;
            //////txbFinalSheetCost.Properties.ReadOnly = !isWareHouse;
            //////txbFinalSheetCost.TabStop = isWareHouse;
        }



        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************




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
            if (_isLoading) return;
            if (lkpSheetId.EditValue == null) return;

            int sheetId = Convert.ToInt32(lkpSheetId.EditValue);
            LoadSheetInfo(sheetId);



            //if (_calcModel == null) return;

            //int sheetId = Convert.ToInt32(lkpSheetId.EditValue);
            //_calcModel.SheetId = sheetId;

            //LoadSheetInfo(sheetId);

            ////////int sheetId = (int)lkpSheetId.EditValue;
            ////////GetSheetInfo(sheetId);

            //////////txbBasePrice.EditValue = sheet.PicesPrice;

            //////////CalCulateArea();
        }
        private void LoadSheetInfo(int sheetId)
        {
            var sheet = _dbContext.Sheets.FirstOrDefault(s => s.Id == sheetId);
            if (sheet == null) return;

            _calcModel.SheetId = sheetId;
            _calcModel.CNCPriceByMeter = sheet.CNCPriceByMeter;
            _calcModel.CNCPriceBySheet = sheet.CNCPriceBySheet;
            _calcModel.CNCPriceByPice = sheet.CNCPriceByPice;
            _calcModel.SheetBasePrice = sheet.SheetPrice;
            _calcModel.PiceBasePrice = sheet.PicesPrice;

            // بعد از تزریق قیمت‌ها، محاسبه انجام می‌شود
            _calcModel.Recalculate();
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


        #endregion


        //**********************************************************************************************************************
        //**********************************************************************************************************************



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


        private void BindControls()
        {
            // ===== SheetType =====
            rgpSheetType.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.SheetType),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            // ===== SheetId =====
            lkpSheetId.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.SheetId),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            // ===== SheetCount (editable) =====
            spnSheetCount.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.SheetCount),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            // ===== CutLength =====
            txbCutLength.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.CutLength),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            // ===== CutWidth =====
            txbCutWidth.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.CutWidth),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            // ===== Supplier =====
            rgpSuplier.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.Supplier),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            // ===== GrooveLength =====
            txbGrooveLength.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.GrooveLength),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            // ===== User Editable Costs =====
            txbCncCost.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.CncCost),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            txbFinalSheetCost.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.FinalSheetCost),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            // ===== Text Fields =====
            txbDetailName.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.DetailName),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );


            txbDescription.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                nameof(OrderDetailsCalcModel.Description),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            // ===== READ ONLY FIELDS =====
            BindReadOnly(txbSheetTotalPrice, nameof(OrderDetailsCalcModel.SheetTotalPrice));
            BindReadOnly(txbSheetBasePrice, nameof(OrderDetailsCalcModel.SheetBasePrice));
            BindReadOnly(txbPiceArea, nameof(OrderDetailsCalcModel.PiceArea));
            BindReadOnly(txbPiceBasePrice, nameof(OrderDetailsCalcModel.PiceBasePrice));
            BindReadOnly(txbPiceTotalPrice, nameof(OrderDetailsCalcModel.PiceTotalPrice));
            BindReadOnly(txbCncBasePrice, nameof(OrderDetailsCalcModel.CNCPriceByMeter));
            BindReadOnly(txbFinalCNCPriceByMeter, nameof(OrderDetailsCalcModel.FinalCNCPriceByMeter));
            BindReadOnly(txbFinalCNCPriceBySheet, nameof(OrderDetailsCalcModel.FinalCNCPriceBySheet));
            BindReadOnly(txbCNCPriceByPice, nameof(OrderDetailsCalcModel.CNCPriceByPice));
            BindReadOnly(txbCNCPriceBySheet, nameof(OrderDetailsCalcModel.CNCPriceBySheet));
        }

        private void BindReadOnly(Control control, string propertyName)
        {
            control.DataBindings.Add(
                "EditValue",
                orderDetailBindingSource,
                propertyName,
                true,
                DataSourceUpdateMode.Never
            );

            if (control is DevExpress.XtraEditors.BaseEdit be)
                be.Properties.ReadOnly = true;
        }

        private void btnRecalculate_Click(object sender, EventArgs e)
        {
            if (_isLoading) return;

            var result = XtraMessageBox.Show(
                "محاسبات مجدداً انجام شود و مقادیر دستی حذف شوند؟",
                "محاسبه مجدد",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            _calcModel.ForceRecalculate(true);
            orderDetailBindingSource.ResetBindings(false);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string filePath = OpenDesignFile();
            if (!string.IsNullOrEmpty(filePath))
            {
                _calcModel.FilePath = filePath;
                orderDetailBindingSource.ResetBindings(false);
                var x = btnOpenFile.EditValue;
            }
            this.SelectNextControl(
                                    this.ActiveControl,   // کنترل فعلی
                                    true,                 // forward
                                    true,                 // tabStopOnly
                                    true,                 // nested
                                    true                  // wrap
                                );

        }

        private string OpenDesignFile()
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.RestoreDirectory = true;
                dlg.Title = "انتخاب فایل";
                dlg.Filter =
                    "CorelDraw (*.cdr)|*.cdr|" +
                    "AutoCAD DXF (*.dxf)|*.dxf|" +
                    "همه فایل‌ها (*.*)|*.*";

                dlg.FilterIndex = 1; // پیش‌فرض CDR
                dlg.Multiselect = false;

                if (!string.IsNullOrEmpty(_lastDirectory))
                    dlg.InitialDirectory = _lastDirectory;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _lastDirectory = Path.GetDirectoryName(dlg.FileName);
                    return dlg.FileName; // مسیر کامل + نام فایل
                }
            }

            return null;
        }


        

        private void SetTab(DevExpress.XtraEditors.BaseEdit ctrl, bool enable)
        {
            ctrl.TabStop = enable;
            ctrl.Properties.AllowFocused = enable;
        }

        private void ApplyTabStopRules(OrderDetailsCalcModel m)
        {
            // ورودی‌های همیشه فعال
            SetTab(rgpSheetType, true);
            SetTab(lkpSheetId, true);
            SetTab(rgpSuplier, true);
            SetTab(txbGrooveLength, true);
            SetTab(txbDetailName, true);
            SetTab(txbDescription, true);

            // SheetType logic
            SetTab(spnSheetCount, m.SheetType != SheetType.Piece);
            SetTab(txbCutLength, m.SheetType != SheetType.Full);
            SetTab(txbCutWidth, m.SheetType != SheetType.Full);

            // Supplier logic
            SetTab(txbFinalSheetCost, m.Supplier == SupplierType.Warehouse);

            // خروجی‌های محاسباتی
            SetTab(txbSheetBasePrice, false);
            SetTab(txbSheetTotalPrice, false);
            SetTab(txbPiceArea, false);
            SetTab(txbPiceBasePrice, false);
            SetTab(txbPiceTotalPrice, false);
            SetTab(txbCncBasePrice, false);
            //SetTab(FinalCNCPriceByMeter, false);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ApplyTabStopRules(_calcModel);
            ApplyValidationRules(_calcModel);
            ApplyFocusColor(this);

        }

        private void orderDetailBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {

        }

        private void btnOpenFile_EditValueChanged(object sender, EventArgs e)
        {
            txbDetailName.EditValue = Path.GetFileNameWithoutExtension(btnOpenFile.Text);
        }

        private void btnOpenFile_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
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
    }

}