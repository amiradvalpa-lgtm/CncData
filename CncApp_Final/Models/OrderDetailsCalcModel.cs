// OrderDetailsCalcModel.cs
// .NET Framework 4.7.2 | WinForms | EF6-safe
// محاسبات مرکزی + پشتیبانی از User Override


using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CncApp_Final.Entities;

namespace CncApp_Final.Models
{
    public enum SheetType
    {
        [Description("ورق کامل")]
        Full = 0,

        [Description("ورق تکه")]
        Piece = 1,

        [Description("هر دو")]
        Both = 2
    }
    
    

    public enum CncPricingMode
    {
        ByMeter = 0,
        BySheet = 1
    }

    public class OrderDetailsCalcModel : INotifyPropertyChanged
    {
        #region ===== Infrastructure =====
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void Set<T>(ref T field, T value, [CallerMemberName] string name = null)
        {
            if (!Equals(field, value))
            {
                field = value;
                OnPropertyChanged(name);
            }
        }
        #endregion

        #region ===== Flags =====
        public bool IsFinalSheetCostUserEdited { get; private set; }
        public bool IsCncCostUserEdited { get; private set; }
        #endregion

        #region ===== Inputs (Bindable) =====
        private SheetType _sheetType;
        public SheetType SheetType
        {
            get => _sheetType;
            set
            {
                Set(ref _sheetType, value);
                ApplySheetTypeRules();
                Recalculate();
            }
        }

        private int _sheetId;
        public int SheetId
        {
            get => _sheetId;
            set
            {
                Set(ref _sheetId, value);
                // LoadSheetInfo(sheetId) باید از بیرون صدا زده شود
                Recalculate();
            }
        }

        private double _sheetCount;
        public double SheetCount
        {
            get => _sheetCount;
            set
            {
                Set(ref _sheetCount, value);
                Recalculate();
            }
        }

        private double _cutLength;
        public double CutLength
        {
            get => _cutLength;
            set
            {
                Set(ref _cutLength, value);
                Recalculate();
            }
        }

        private double _cutWidth;
        public double CutWidth
        {
            get => _cutWidth;
            set
            {
                Set(ref _cutWidth, value);
                Recalculate();
            }
        }

        private double _grooveLength;
        public double GrooveLength
        {
            get => _grooveLength;
            set
            {
                Set(ref _grooveLength, value);
                Recalculate();
            }
        }

        private SupplierType _supplier;
        public SupplierType Supplier
        {
            get => _supplier;
            set
            {
                Set(ref _supplier, value);
                Recalculate();
            }
        }

        public string DetailName { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }

        public CncPricingMode CncPricingMode { get; set; }
        #endregion

        #region ===== Base Prices (from Sheet) =====
        public double CNCPriceByMeter { get; set; }
        public double CNCPriceBySheet { get; set; }
        public double CNCPriceByPice { get; set; }
        public double SheetBasePrice { get; set; }
        public double PiceBasePrice { get; set; }
        #endregion

        #region ===== Calculated (System) =====
        public double PiceArea { get; private set; }
        public double SheetTotalPrice { get; private set; }
        public double PiceTotalPrice { get; private set; }
        public double FinalSheetPrice { get; private set; }

        public double FinalCNCPriceByMeter { get; private set; }
        public double FinalCNCPriceBySheet { get; private set; }
        #endregion

        #region ===== User Editable Outputs =====
        private double _finalSheetCost;
        public double FinalSheetCost
        {
            get => _finalSheetCost;
            set
            {
                Set(ref _finalSheetCost, value);
                IsFinalSheetCostUserEdited = true;
            }
        }

        private double _cncCost;
        public double CncCost
        {
            get => _cncCost;
            set
            {
                Set(ref _cncCost, value);
                IsCncCostUserEdited = true;
            }
        }
        #endregion

        #region ===== Core Logic =====
        private void ApplySheetTypeRules()
        {
            switch (SheetType)
            {
                case SheetType.Full:
                    if (SheetCount < 1) SheetCount = 1;
                    CutLength = 0;
                    CutWidth = 0;
                    break;

                case SheetType.Piece:
                    SheetCount = 0;
                    break;

                case SheetType.Both:
                    if (SheetCount < 1) SheetCount = 1;
                    break;
            }
        }
        public void ForceRecalculate(bool resetUserOverrides = true)
        {
            if (resetUserOverrides)
            {
                IsFinalSheetCostUserEdited = false;
                IsCncCostUserEdited = false;
            }

            Recalculate();
        }


        public void Recalculate()
        {
            // ===== Validation-like guards =====
            if ((SheetType == SheetType.Piece || SheetType == SheetType.Both)
                && (CutLength <= 0 || CutWidth <= 0))
            {
                PiceArea = 0;
            }
            else
            {
                PiceArea = (CutLength * CutWidth) / 10000d;
            }

            SheetTotalPrice = SheetCount * SheetBasePrice;
            PiceTotalPrice = PiceArea * PiceBasePrice;
            FinalSheetPrice = SheetTotalPrice + PiceTotalPrice;

            FinalCNCPriceByMeter = CNCPriceByMeter * GrooveLength;

            FinalCNCPriceBySheet = (SheetCount * CNCPriceBySheet);
            if (PiceArea > 0)
            {
                FinalCNCPriceBySheet += (PiceArea < 2)
                    ? CNCPriceByPice
                    : CNCPriceBySheet;
            }

            // ===== Apply defaults (respect User Override) =====
            if (!IsFinalSheetCostUserEdited)
                FinalSheetCost = FinalSheetPrice;

            if (!IsCncCostUserEdited)
                CncCost = (CncPricingMode == CncPricingMode.ByMeter)
                    ? FinalCNCPriceByMeter
                    : FinalCNCPriceBySheet;

            // ===== Supplier Rule =====
            if (Supplier == SupplierType.Customer)
            {
                _finalSheetCost = 0;
                OnPropertyChanged(nameof(FinalSheetCost));
            }
        }
        #endregion

        #region ===== Mapping =====
        public void LoadFrom(OrderDetails source)
        {
            SheetId = source.SheetId;
            SheetCount = source.SheetCount;
            CutLength = source.CutLength;
            CutWidth = source.CutWidth;
            GrooveLength = source.GrooveLength;
            Supplier = source.Supplier;

            FinalSheetCost = source.FinalSheetCost;
            CncCost = source.CncCost;

            DetailName = source.DetailName;
            FilePath = source.FilePath;
            Description = source.Description;

            IsFinalSheetCostUserEdited = true;
            IsCncCostUserEdited = true;
        }

        public void ApplyTo(OrderDetails target)
        {
            target.SheetId = SheetId;
            target.SheetCount = SheetCount;
            target.CutLength = CutLength;
            target.CutWidth = CutWidth;
            target.GrooveLength = GrooveLength;
            target.Supplier = Supplier;

            target.FinalSheetCost = FinalSheetCost;
            target.CncCost = CncCost;

            target.DetailName = DetailName;
            target.FilePath = FilePath;
            target.Description = Description;
        }
        #endregion
    }


}
