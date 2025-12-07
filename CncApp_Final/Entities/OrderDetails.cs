using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CncApp_Final.Entities
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("شناسه سفارش")]
        public int OrderId { get; set; }

        [DisplayName("سفارش")]
        public virtual Order Order { get; set; }

        [DisplayName("نام سفارش")]
        [Description("نام سفارش")]
        public string DetailName { get; set; }

        [DisplayName("مسیر فایل")]
        [Description("مسیر فایل مربوط به این جزئیات سفارش")]
        public string FilePath { get; set; }

        [DisplayName("شناسه ورق")]
        [Description("ورق انتخاب شده برای این جزئیات")]
        public int SheetId { get; set; }

        [DisplayName("ورق")]
        [Description("ورق مربوط به این جزئیات سفارش")]
        public virtual Sheet Sheet { get; set; }

        [DisplayName("تامین‌کننده")]
        [Description("نوع تامین‌کننده این جزئیات سفارش")]
        public SupplierType Supplier { get; set; }

        [DisplayName("طول برش")]
        [Description("طول برش ورق بر حسب میلی‌متر")]
        public double CutLength { get; set; }

        [DisplayName("عرض برش")]
        [Description("عرض برش ورق بر حسب میلی‌متر")]
        public double CutWidth { get; set; }

        [DisplayName("هزینه نهایی ورق")]
        [Description("هزینه نهایی ورق بعد از برش")]
        public double FinalSheetCost { get; set; }

        [DisplayName("طول شیار")]
        [Description("مجموع طول شیارهای ایجاد شده بر روی ورق")]
        public double GrooveLength { get; set; }

        [DisplayName("هزینه CNC")]
        [Description("هزینه ماشینکاری CNC این جزئیات")]
        public double CncCost { get; set; }

        [DisplayName("توضیحات جزئیات")]
        [Description("توضیحات اضافی برای این جزئیات سفارش")]
        public string Description { get; set; }

        // ─── فیلدهای محاسباتی (NotMapped) ─────────────────────────────────────

        [NotMapped]
        [DisplayName("مشخصات ورق")]
        public string SheetDetails => Sheet != null
            ? $"{Sheet.Material} {Sheet.Thickness}mm {Sheet.Width}*{Sheet.Length}"
            : "ورق انتخاب نشده";

        [NotMapped]
        [DisplayName("مشخصات ورق برشی")]
        public string CutSheetDetails => Sheet != null
            ? $"{Sheet.Material} {Sheet.Thickness}mm {CutWidth}*{CutLength}"
            : "ورق انتخاب نشده";

        [NotMapped]
        [DisplayName("قیمت ورق")]
        public double? SheetPrice => Sheet?.SheetPrice;

        [NotMapped]
        [DisplayName("قیمت تکه")]
        public double? PicesPrice => Sheet?.PicesPrice;

        [NotMapped]
        [DisplayName("قیمت ورق")]
        public string FinalSheetCostDisplay => Supplier == SupplierType.Warehouse
            ? $"{FinalSheetCost:N0} تومان"
            : "ورق مشتری";

        [NotMapped]
        [DisplayName("تامین‌کننده")]
        public string SupplierTypeDescription => GetEnumDescription(Supplier);

        private static string GetEnumDescription(SupplierType value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;
            return attribute?.Description ?? value.ToString();
        }
    }
}